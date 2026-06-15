
const { DataTypes } = require('sequelize');
const { sequelize } = require('../connection');


const User = sequelize.define('User', {
  userId: { 
    type: DataTypes.INTEGER,    
    primaryKey: true, 
    autoIncrement: true,        
    field: 'UserID' 
  },
  FullName: {
    type: DataTypes.STRING(50),
    field: 'FullName',
    allowNull: false
  },
  email: {
    type: DataTypes.STRING(100),
    field: 'Email',
    allowNull: false,
    unique: true
  },
  passwordHash: {
    type: DataTypes.STRING(255),
    field: 'PasswordHash',
    allowNull: false
  },
  isActive: {
    type: DataTypes.BOOLEAN,
    field: 'IsActive',
    defaultValue: true
  }
}, { tableName: 'Users', schema: 'dbo', timestamps: true, createdAt: 'CreatedAt', updatedAt: 'UpdatedAt' });

module.exports = User;