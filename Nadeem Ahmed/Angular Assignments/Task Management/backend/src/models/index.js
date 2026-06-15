const RefreshToken = require("./refreshToken.model");
const Role = require("./role.model");
const Task = require("./task.model");
const User = require("./user.model");
const UserRole = require("./userRole.model");


Role.hasMany(User, {
    foreignKey: "roleId"
});

User.belongsTo(Role, {
    foreignKey: "roleId"
});

User.hasMany(Task, {
    foreignKey: "assignedToUserId",
    as: "AssignedTasks"
});

Task.belongsTo(User, {
    foreignKey: "assignedToUserId",
    as: "AssignedTo"
});


User.hasMany(Task, {
    foreignKey: "assignedByUserId",
    as: "CreatedTasks"
});

Task.belongsTo(User, {
    foreignKey: "assignedByUserId",
    as: "AssignedBy"
});

User.hasMany(RefreshToken, {
    foreignKey: "userId"
});

RefreshToken.belongsTo(User, {
    foreignKey: "userId"
});

User.belongsToMany(Role, {
    through: UserRole,
    foreignKey: "userId"
});

Role.belongsToMany(User, {
    through: UserRole,
    foreignKey: "roleId"
});

module.exports = {
    User,
    Role,
    Task,
    RefreshToken,
    UserRole
};