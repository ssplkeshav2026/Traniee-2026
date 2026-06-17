const { DataTypes } = require("sequelize");
const { sequelize } = require("../config/db");

const Task = sequelize.define(
    "Task",
    {
        id: {
            type: DataTypes.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },

        title: {
            type: DataTypes.STRING(200),
            allowNull: false
        },

        description: {
            type: DataTypes.TEXT,
            allowNull: false
        },

        status: {
            type: DataTypes.ENUM(
                "Pending",
                "In Progress",
                "Completed"
            ),
            defaultValue: "Pending"
        },

        dueDate: {
            type: DataTypes.DATE,
            allowNull: false
        },

        assignedToUserId: {
            type: DataTypes.INTEGER,
            allowNull: false
        },

        assignedByUserId: {
            type: DataTypes.INTEGER,
            allowNull: false
        }
    },
    {
        tableName:"tasks",
        timestamps:true
    }
);

module.exports = Task;