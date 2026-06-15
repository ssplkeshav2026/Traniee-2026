const { DataTypes } = require('sequelize');
const { sequelize } = require('../connection');

const UserRole = sequelize.define('UserRole', {
  userRoleId: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true, field: 'UserRoleID' },
  userId: { type: DataTypes.INTEGER, field: 'UserId', allowNull: false },
  roleId: { type: DataTypes.INTEGER, field: 'RoleId', allowNull: false }
}, { tableName: 'UserRoles', schema: 'dbo', timestamps: true, createdAt: 'AssignedAt', updatedAt: false });

module.exports = UserRole;