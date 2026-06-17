const { DataTypes } = require("sequelize");
const { sequelize } = require("../config/db");

const RefreshToken = sequelize.define(
    "RefreshToken",
    {
        id: {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },

        token: {
            type: DataTypes.TEXT,
            allowNull: false
        },

        expiresAt: {
            type: DataTypes.DATE,
            allowNull: false
        },

        userId: {
            type: DataTypes.INTEGER,
            allowNull: false
        }
    },
    {
        tableName: "RefreshTokens",
        timestamps: true
    }
);

module.exports = RefreshToken;