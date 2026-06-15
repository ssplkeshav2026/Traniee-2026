
const { DataTypes } = require('sequelize');
const { sequelize } = require('../connection');


const RefreshToken = sequelize.define('RefreshToken', {
  tokenId: { type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true, field: 'TokenID' },
  token: { type: DataTypes.TEXT, field: 'Token', allowNull: false },
  userId: { type: DataTypes.INTEGER, field: 'UserId', allowNull: false },
  expiresAt: { type: DataTypes.DATE, field: 'ExpiresAt', allowNull: false }
}, { tableName: 'RefreshTokens', schema: 'dbo', timestamps: true, createdAt: 'CreatedAt', updatedAt: false });

module.exports = RefreshToken;