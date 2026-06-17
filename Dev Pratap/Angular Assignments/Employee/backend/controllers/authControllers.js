const { Time } = require("mssql")
const User = require("../module/userModel")
const UserRoles = require("../module/userRoles")
const Roles = require("../module/roleModel")
const { login } = require("../repositories/authService")
const { saveRefreshToken } = require("../repositories/refreshToken")
const { generateAccessToken, generateRefreshToken } = require("../utils/token")
const bcrypt = require("bcrypt")
const { sequelize } = require('../connection');

const authService = require('../repositories/authService');
const { RefreshToken } = require("../module")

const registerUser = async (req, res) => {
  const { fullName, email, password, roleName = 'Employee' } = req.body;

  if (!fullName || !email || !password) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: fullName, email, and password fields are strictly required.'
    });
  }
  console.log(fullName,email,password,roleName)

  try {
    const result = await sequelize.transaction(async (t) => {
      
      const role = await Roles.findOne({ where: { roleName }, transaction: t });
      if (!role) {
        throw new Error(`ROLE_NOT_FOUND:${roleName}`);
      }

      const saltRounds = 10;
      const passwordHash = await bcrypt.hash(password, saltRounds);

      const newUser = await User.create({
        FullName: fullName,
        email,
        passwordHash
      }, { transaction: t });

      console.log(newUser.dataValues)

      await UserRoles.create({
        userId: newUser.userId,
        roleId: role.roleId
      }, { transaction: t });

      return {
        userId: newUser.userId,
        fullName: newUser.FullName,
        email: newUser.email,
        role: roleName
      };
    });

    return res.status(201).json({
      success: true,
      message: 'User registered successfully.',
      data: result
    });

  } catch (error) {

    if (error.name === 'SequelizeUniqueConstraintError') {
      return res.status(409).json({
        success: false,
        message: 'Conflict: An account with this email address already exists.',
        errors: error.errors.map(err => ({ field: err.path, detail: err.message }))
      });
    }

    if (error.name === 'SequelizeValidationError') {
      return res.status(400).json({
        success: false,
        message: 'Provided payload violates data structure criteria.',
        errors: error.errors.map(err => ({ field: err.path, detail: err.message }))
      });
    }

    if (error.message.startsWith('ROLE_NOT_FOUND:')) {
      const missedRole = error.message.split(':')[1];
      return res.status(400).json({
        success: false,
        message: `System configuration failure: The specified assignment role '${missedRole}' does not exist.`
      });
    }

    console.error('Unhandled Registration Exception:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected internal processing exception occurred while creating the user profile.'
    });
  }
};

const loginUser = async (req, res) => {
  const { email, password } = req.body;

  if (!email || !password) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: Both email and password fields are strictly required.'
    });
  }

  try {
    const result = await authService.loginUser(email, password);

   

    return res.status(200).json({
      success: true,
      message: 'Authentication validated successfully.',
      accessToken: result.accessToken,
      refreshToken:result.refreshToken,
      user: result.user
    });

  } catch (error) {

    if (error.message === 'AUTHENTICATION_FAILED') {
      return res.status(401).json({
        success: false,
        message: 'Authentication failed: Invalid email or password credentials.'
      });
    }

    console.error('Unhandled Login Exception Context:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected internal exception occurred while parsing authorization sessions.'
    });
  }
};

const refreshTokenHandler = async (req, res) => {
  const { refreshToken } = req.body;

  if (!refreshToken) {
    return res.status(400).json({ success: false, message: 'Refresh token is required.' });
  }

  try {
    const tokens = await authService.rotateTokens(refreshToken);

    return res.status(200).json({
      success: true,
      message: 'Tokens rotated successfully.',
      ...tokens 
    });
  } catch (error) {
    if (['INVALID_TOKEN', 'TOKEN_NOT_FOUND', 'USER_NOT_FOUND', 'TOKEN_EXPIRED'].includes(error.message)) {
      return res.status(401).json({ success: false, message: 'Session expired or invalid. Please log in again.' });
    }
    console.error('Rotation Error:', error);
    return res.status(500).json({ success: false, message: 'Internal server error during token rotation.' });
  }
};

const logoutUserHandler = async (req, res) => {
  const { refreshToken } = req.body;

  if (!refreshToken) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: The refreshToken parameter is required in the body payload.'
    });
  }

  try {
    await authService.deleleRefreshToken(refreshToken);

    return res.status(200).json({
      success: true,
      message: 'Success: Active session revoked and logged out successfully.'
    });

  } catch (error) {
    if (error.message === 'TOKEN_NOT_FOUND') {
      return res.status(200).json({
        success: true,
        message: 'Session was already inactive or previously revoked.'
      });
    }

    console.error('Session Revocation Exception:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected database error occurred while destroying the session token.'
    });
  }
};


module.exports = {
    registerUser,
    loginUser,
    refreshTokenHandler,
    logoutUserHandler
}