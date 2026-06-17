const {
    User,
    Role,
    RefreshToken
} = require("../models");

const findUserByEmail = async (email) => {
    return await User.findOne({
        where: { email }
    });
};

const createUser = async (userData) => {
    return await User.create(userData);
};

const findUserWithRoleByEmail = async (email) => {
    return await User.findOne({
        where: { email },
        include: [
            {
                model: Role
            }
        ]
    });
};

const findUserById = async (userId) => {
    return await User.findByPk(userId);
};

const findUserByIdWithRole = async (userId) => {
    return await User.findByPk(userId, {
        include: [
            {
                model: Role
            }
        ]
    });
};

const createRefreshToken = async (
    token,
    userId,
    expiresAt
) => {
    return await RefreshToken.create({
        token,
        userId,
        expiresAt
    });
};

const findRefreshToken = async (token) => {
    return await RefreshToken.findOne({
        where: {
            token
        }
    });
};

const deleteRefreshTokensByUserId = async (
    userId
) => {
    return await RefreshToken.destroy({
        where: {
            userId
        }
    });
};

module.exports = {
    findUserByEmail,
    createUser,
    findUserWithRoleByEmail,
    findUserById,
    findUserByIdWithRole,
    createRefreshToken,
    findRefreshToken,
    deleteRefreshTokensByUserId
};