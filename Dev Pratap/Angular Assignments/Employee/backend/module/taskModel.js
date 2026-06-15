const { DataTypes } = require('sequelize');
const { sequelize } = require('../connection');
const User = require('./userModel');

const Task = sequelize.define('Task', {
  taskId: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true, field: 'TaskID' },
  title: { type: DataTypes.STRING(255), allowNull: false, field: 'Title' },
  description: { type: DataTypes.TEXT, allowNull: true, field: 'Description' },
  assignedToUserId: { type: DataTypes.INTEGER, field: 'AssignedToUserId', allowNull: false },
assignedByUserId: { type: DataTypes.INTEGER, field: 'AssignedByUserId', allowNull: false },
  status: { type: DataTypes.STRING(20), defaultValue: 'Pending', field: 'Status' },
  dueDate: { type: DataTypes.DATE, allowNull: true, field: 'DueDate' },
  createdDate: { type: DataTypes.DATE, field: 'CreatedDate' },
  updatedDate: { type: DataTypes.DATE, field: 'UpdatedDate' }
}, {
  tableName: 'Tasks',
  schema: 'dbo',
  timestamps: true,
  createdAt: 'createdDate',
  updatedAt: 'updatedDate'
});

// Setup Associations

module.exports = Task;