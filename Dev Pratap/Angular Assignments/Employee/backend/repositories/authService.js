const bcrypt = require('bcrypt');
const { sequelize } = require('../connection'); 
const { User, Role, UserRole,RefreshToken } = require('../module/index');
const { generateAccessToken, generateRefreshToken } = require('../utils/token');

async function login(email, password) {
  const user = await User.findOne({ where: { email } })
  return user
}


const registerUser = async (userData) => {
  const { fullname, email, password, roleName = 'Employee' } = userData;

  return await sequelize.transaction(async (t) => {

    const role = await Role.findOne({ where: { roleName }, transaction: t });
    if (!role) {
      const error = new Error(`Role '${roleName}' does not exist in the system.`);
      error.statusCode = 400;
      throw error;
    }

    const saltRounds = 10;
    const passwordHash = await bcrypt.hash(password, saltRounds);

    const newUser = await User.create({
      userId: 1000,
      FullName: fullname,
      email,
      passwordHash
    }, { transaction: t });

    console.log(newUser.dataValues)

    await UserRole.create({
      userId: newUser.userId,
      roleId: role.roleId
    }, { transaction: t });

    return {
      userId: newUser.userId,
      firstName: newUser.firstName,
      lastName: newUser.lastName,
      email: newUser.email,
      role: roleName
    };
  });
};

const loginUser = async (email, password) => {
  const user = await User.findOne({
    where: { email },
    include: [
      {
        model: Role,
        attributes: ['roleName'],
        through: { attributes: [] } 
      }
    ]
  });

  if (!user || !user.isActive) {
    const error = new Error('AUTHENTICATION_FAILED');
    error.statusCode = 401;
    throw error;
  }


  const isPasswordValid = await bcrypt.compare(password, user.passwordHash);
  if (!isPasswordValid) {
    const error = new Error('AUTHENTICATION_FAILED');
    error.statusCode = 401;
    throw error;
  }

  const roleName = user.Roles && user.Roles.length > 0 ? user.Roles[0].roleName : 'Employee';


  const accessToken = await generateAccessToken({ userId: user.userId, role: roleName, fullName: user.FullName })

  const refreshTokenString = await generateRefreshToken({ userId: user.userId })


  const expiresAtDate = new Date();
  expiresAtDate.setDate(expiresAtDate.getDate() + 7);

  await RefreshToken.create({
    token: refreshTokenString,
    userId: user.userId, 
    expiresAt: expiresAtDate
  });

  return {
    accessToken,
    refreshToken: refreshTokenString
  };
};

const rotateTokens = async (incomingRefreshToken) => {
  return await sequelize.transaction(async (t) => {

    let decoded;
    try {
      decoded = jwt.verify(incomingRefreshToken, process.env.REFRESH_TOKEN_SECRET);
    } catch (err) {
      const error = new Error('INVALID_TOKEN');
      error.statusCode = 401;
      throw error;
    }

    const storedToken = await RefreshToken.findOne({
      where: { token: incomingRefreshToken, userId: decoded.userId },
      transaction: t
    });

    if (!storedToken) {
      const error = new Error('TOKEN_NOT_FOUND');
      error.statusCode = 401;
      throw error;
    }

    if (new Date() > new Date(storedToken.expiresAt)) {
      await storedToken.destroy({ transaction: t });
      const error = new Error('TOKEN_EXPIRED');
      error.statusCode = 401;
      throw error;
    }

    await storedToken.destroy({ transaction: t });

    const user = await User.findOne({
      where: { userId: decoded.userId, isActive: true },
      include: [{ model: Role, attributes: ['roleName'], through: { attributes: [] } }],
      transaction: t
    });

    if (!user) {
      const error = new Error('USER_NOT_FOUND');
      error.statusCode = 401;
      throw error;
    }

    const roleName = user.Roles && user.Roles.length > 0 ? user.Roles[0].roleName : 'Employee';

    const newAccessToken = jwt.sign(
      { userId: user.userId, role: roleName },
      process.env.ACCESS_TOKEN_SECRET,
      { expiresIn: '15m' }
    );

    const newRefreshTokenString = jwt.sign(
      { userId: user.userId },
      process.env.REFRESH_TOKEN_SECRET,
      { expiresIn: '7d' }
    );

    const expiresAtDate = new Date();
    expiresAtDate.setDate(expiresAtDate.getDate() + 7);

    await RefreshToken.create({
      token: newRefreshTokenString,
      userId: user.userId,
      expiresAt: expiresAtDate
    }, { transaction: t });

    return {
      accessToken: newAccessToken,
      refreshToken: newRefreshTokenString
    };
  });
};

const deleleRefreshToken = async (tokenString) => {
  const tokenRecord = await RefreshToken.findOne({
    where: { token: tokenString }
  });


  if (!tokenRecord) {
    const error = new Error('TOKEN_NOT_FOUND');
    error.statusCode = 404;
    throw error;
  }

  await tokenRecord.destroy();

  return true;
};



module.exports = {
  loginUser,
  registerUser,
  rotateTokens,
  deleleRefreshToken
}

