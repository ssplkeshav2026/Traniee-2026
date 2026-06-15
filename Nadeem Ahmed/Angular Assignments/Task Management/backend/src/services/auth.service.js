const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");

const authRepository =
require("../repositories/auth.repository");

const register = async (userData) => {

    const {
        username,
        email,
        password
    } = userData;

    const existingUser =
        await authRepository.findUserByEmail(
            email
        );

    if (existingUser) {
        throw new Error(
            "User already exists!"
        );
    }

    const hashedPassword =
        await bcrypt.hash(
            password,
            10
        );

    const user =
        await authRepository.createUser({
            username,
            email,
            password: hashedPassword,
            roleId: 3
        });

    return user;
};

const login = async (
    email,
    password
) => {

    const user =
        await authRepository
            .findUserWithRoleByEmail(
                email
            );

    if (!user) {
        throw new Error(
            "Invalid Email or Password"
        );
    }

    const isMatched =
        await bcrypt.compare(
            password,
            user.password
        );

    if (!isMatched) {
        throw new Error(
            "Invalid credentials"
        );
    }

    const accessToken =
        jwt.sign(
            {
                id: user.id,
                email: user.email,
                role: user.Role.name
            },
            process.env.ACCESS_TOKEN_SECRET,
            {
                expiresIn: "30m"
            }
        );

    const refreshToken =
        jwt.sign(
            {
                id: user.id
            },
            process.env.REFRESH_TOKEN_SECRET,
            {
                expiresIn: "7d"
            }
        );

    await authRepository
        .createRefreshToken(
            refreshToken,
            user.id,
            new Date(
                Date.now() +
                7 * 24 * 60 * 60 * 1000
            )
        );

    return {
        accessToken,
        refreshToken,
        user
    };
};

const refreshAccessToken =
async (refreshToken) => {

    if (!refreshToken) {
        throw new Error(
            "Refresh token required"
        );
    }

    const decoded =
        jwt.verify(
            refreshToken,
            process.env
                .REFRESH_TOKEN_SECRET
        );

    const user =
        await authRepository
            .findUserByIdWithRole(
                decoded.id
            );

    if (!user) {
        throw new Error(
            "User not found"
        );
    }

    const tokenRecord =
        await authRepository
            .findRefreshToken(
                refreshToken
            );

    if (!tokenRecord) {
        throw new Error(
            "Invalid refresh token"
        );
    }

    const accessToken =
        jwt.sign(
            {
                id: user.id,
                email: user.email,
                role: user.Role.name
            },
            process.env.ACCESS_TOKEN_SECRET,
            {
                expiresIn: "30m"
            }
        );

    return accessToken;
};

const logout = async (userId) => {

    const user =
        await authRepository.findUserById(
            userId
        );

    if (!user) {
        throw new Error(
            "User not found"
        );
    }

    await authRepository
        .deleteRefreshTokensByUserId(
            userId
        );

    return true;
};

module.exports = {
    register,
    login,
    refreshAccessToken,
    logout
};