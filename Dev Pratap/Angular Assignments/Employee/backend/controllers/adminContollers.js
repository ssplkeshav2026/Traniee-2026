const { testConnection } = require("../connection")
const User = require("../module/userModel")
const { getAllUsersWithRoles, getAllMan, getAllEmp,updateUserFields, hardDeleteEmployee } = require("../repositories/adminServices")

async function getAllEmpCont(req,res) {
    const Employees = await getAllUsersWithRoles()
    return res.status(200).json(Employees)
}

const updateUserHandler = async (req, res) => {
  const userId = parseInt(req.params.id, 10);

  const { fullName, email, Roles } = req.body;

  if (isNaN(userId)) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: The user ID parameter must be a valid number.'
    });
  }

 
  if (Roles !== undefined && !Array.isArray(Roles)) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: Roles property must be a structural array format.'
    });
  }

  try {
    const updatedUser = await updateUserFields(userId, { 
      fullName, 
      email, 
      rolesArray: Roles 
    });

    return res.status(200).json({
      success: true,
      message: `Success: Profile for User #${userId} has been updated.`,
      data: updatedUser
    });

  } catch (error) {
    
    if (error.message === 'USER_NOT_FOUND') {
      return res.status(404).json({
        success: false,
        message: `Not Found: Cannot update. No user profile matches ID: ${userId}`
      });
    }

    if (error.message.startsWith('ROLE_NOT_FOUND:')) {
      const missedRole = error.message.split(':')[1];
      return res.status(400).json({
        success: false,
        message: `Bad Request: The system role specification '${missedRole}' does not exist in master tables.`
      });
    }

    if (error.name === 'SequelizeUniqueConstraintError') {
      return res.status(409).json({
        success: false,
        message: 'Conflict error: The requested email address is already in use by another account.'
      });
    }

    console.error('User Update Exception:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected internal error occurred while modifying the user profile records.'
    });
  }
};

async function getAllEmpContlow(req,res) {
    const Employees = await getAllEmp()
    res.status(200).json(Employees)
}

async function getAllMngCont(req,res) {
    const Employees = await getAllMan()
    res.status(200).json(Employees)
}

const deleteEmployeeHandler = async (req, res) => {
  const userId = parseInt(req.params.id, 10);

  if (isNaN(userId)) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: The user ID parameter must be a valid number.'
    });
  }

  try {

    const result = await hardDeleteEmployee(userId); 

    return res.status(200).json({
      success: true,
      message: `Success: Employee profile #${userId} ("${result.fullName}") has been successfully deactivated.`,
      data: result
    });

  } catch (error) {
  if (error.message === 'USER_NOT_FOUND') {
    return res.status(404).json({ success: false, message: 'User profile not found.' });
  }

  if (error.message === 'ADMIN_DELETION_FORBIDDEN') {
    return res.status(403).json({ 
      success: false, 
      message: 'Security Violation: System Administrator profiles cannot be deleted from the database matrix.' 
    });
  }

  console.error('Delete Exception:', error);
  return res.status(500).json({ success: false, message: 'Internal server error.' });
}
};

module.exports = {
    updateUserHandler,
    getAllEmpCont,
    getAllEmpContlow,
    getAllMngCont,
    deleteEmployeeHandler
}