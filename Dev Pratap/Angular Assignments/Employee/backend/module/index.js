const User = require('./userModel');
const Role = require('./roleModel');
const UserRole = require('./userRoles');
const Task = require('./taskModel');
const RefreshToken = require('./RefreshTokenModel');

User.belongsToMany(Role, { through: UserRole, foreignKey: 'userId', otherKey: 'roleId' });
Role.belongsToMany(User, { through: UserRole, foreignKey: 'roleId', otherKey: 'userId' });


Task.belongsTo(User, { as: 'Assignee', foreignKey: 'assignedToUserId' });
Task.belongsTo(User, { as: 'Creator', foreignKey: 'assignedByUserId' });

RefreshToken.belongsTo(User, { foreignKey: 'userId', onDelete: 'CASCADE' });

module.exports = { User, Role, UserRole, Task, RefreshToken };