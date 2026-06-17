const { DataTypes } = require("sequelize");
const { sequelize } = require("../config/db");


const Role = sequelize.define(
    "Role",
    {
        id: {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },

        name: {
            type: DataTypes.STRING(30),
            allowNull: false,
            unique: true
        }
    },
    {
        tableName: "Roles",
        timestamps: false
    }
);

module.exports = Role;