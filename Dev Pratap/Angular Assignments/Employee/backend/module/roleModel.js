const { DataTypes } = require('sequelize');
const { sequelize } = require('../connection');

const Role = sequelize.define('Role', {
  roleId: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true, field: 'RoleID' },
  roleName: { type: DataTypes.STRING(50), field: 'RoleName', allowNull: false, unique: true }
}, { tableName: 'Roles', schema: 'dbo', timestamps: false });

module.exports = Role;