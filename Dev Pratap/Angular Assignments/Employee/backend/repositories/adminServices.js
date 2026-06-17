const { sequelize } = require('../connection.js');
const { User, Role, UserRole,RefreshToken ,Task} = require('../module/index'); // Import from your central index

const getAllUsersWithRoles = async () => {
  try {
    const users = await User.findAll({
      limit: 1000, 
      include: [
        {
          model: Role,
          attributes: ['roleName'],   
          through: { attributes: [] } 
        }
      ],
      order: [['userId', 'ASC']] 
    });

    return users;
  } catch (error) {
    console.error('Failed to retrieve users:', error);
    throw error;
  }
};

async function getAllEmp() {
  try {
    const employees = await User.findAll({
      attributes: ['userId', 'FullName', 'email', 'isActive'],
      

      include: [
        {
          model: Role,
          where: { roleName: 'Employee' }, 
          attributes: [], 
          through: { attributes: [] } 
        }
      ]
    });

    return employees;
  } catch (error) {
    console.error('Failed to fetch employees:', error);
    throw error;
  }
}

const updateUserFields = async (userId, updateData) => {
  const { fullName, email, rolesArray } = updateData;

  return await sequelize.transaction(async (t) => {
    
    const user = await User.findByPk(userId, { transaction: t });
    if (!user) {
      const error = new Error('USER_NOT_FOUND');
      error.statusCode = 404;
      throw error;
    }

    
    const profileFields = {};
    if (fullName !== undefined) profileFields.FullName = fullName;
    if (email !== undefined) profileFields.email = email;

    if (Object.keys(profileFields).length > 0) {
      await user.update(profileFields, { transaction: t });
    }

   
    let appliedRolesOutput = [];
    
    if (rolesArray) {
      const targetRoleNames = rolesArray.map(item => {
        if (typeof item === 'string') return item;
        return item.roleName || item.RoleName; 
      }).filter(Boolean); 

      if (targetRoleNames.length > 0) {
        const masterRolesFound = await Role.findAll({
          where: { roleName: targetRoleNames },
          transaction: t
        });

        if (masterRolesFound.length !== targetRoleNames.length) {
          const foundNames = masterRolesFound.map(r => r.roleName);
          const missing = targetRoleNames.find(name => !foundNames.includes(name));
          const error = new Error(`ROLE_NOT_FOUND:${missing}`);
          error.statusCode = 400;
          throw error;
        }

        await UserRole.destroy({ where: { userId: user.userId }, transaction: t });

        const associationRows = masterRolesFound.map(role => ({
          userId: user.userId,
          roleId: role.roleId
        }));

        await UserRole.bulkCreate(associationRows, { transaction: t });
        
        appliedRolesOutput = masterRolesFound.map(r => r.roleName);
      }
    }

    return {
      userId: user.userId,
      fullName: user.FullName,
      email: user.email,
      Roles: appliedRolesOutput.length > 0 ? appliedRolesOutput : undefined
    };
  });
};



const hardDeleteEmployee = async (userId) => {
  return await sequelize.transaction(async (t) => {
    
    const user = await User.findByPk(userId, { 
      include: [{
        model: Role,
        attributes: ['roleName'],
        through: { attributes: [] }
      }],
      transaction: t 
    });

    if (!user) {
      const error = new Error('USER_NOT_FOUND');
      error.statusCode = 404;
      throw error;
    }

    const isSystemAdmin = user.Roles?.some(role => role.roleName === 'Admin');
    if (isSystemAdmin) {
      const error = new Error('ADMIN_DELETION_FORBIDDEN');
      error.statusCode = 403; 
      throw error;
    }

    await RefreshToken.destroy({ where: { userId: user.userId }, transaction: t });
    await UserRole.destroy({ where: { userId: user.userId }, transaction: t });
    await Task.destroy({ where: { assignedToUserId: user.userId }, transaction: t });

    await user.destroy({ transaction: t });

    return {
      userId: userId,
      fullName: user.FullName
    };
  });
};




async function getAllMan() {
    const users = await User.findAll({where:{Role:"Manager"}})
    return users
}







module.exports = {
  updateUserFields,
  
  hardDeleteEmployee,

  getAllUsersWithRoles,
  getAllEmp,
  getAllMan,

};