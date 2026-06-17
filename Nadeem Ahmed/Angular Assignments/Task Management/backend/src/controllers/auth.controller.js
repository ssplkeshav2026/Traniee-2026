const authService = require("../services/auth.service");

const register = async (req, res) => {

    try {

        const user =
            await authService.register(
                req.body
            );

        return res.status(201).json({
            success: true,
            message:
                "User registered successfully",
            data: user
        });

    } catch (error) {

        return res.status(500).json({
            success: false,
            message: error.message
        });

    }
};

const login = async (req, res) => {

    try {

        const {
            email,
            password
        } = req.body;

        const result =
            await authService.login(
                email,
                password
            );

        res.cookie(
            "refreshToken",
            result.refreshToken,
            {
                httpOnly: true,
                secure:
                    process.env.NODE_ENV ===
                    "production",
                sameSite: "strict",
                maxAge:
                    7 * 24 * 60 * 60 * 1000
            }
        );

        return res.status(200).json({
            success: true,
            message: "Login successful",
            accessToken:
                result.accessToken,
            user: result.user
        });

    } catch (error) {

        return res.status(401).json({
            success: false,
            message: error.message
        });

    }
};

const refreshToken = async (
    req,
    res
) => {

    try {

        const refreshToken =
            req.cookies.refreshToken;

        const accessToken =
            await authService
                .refreshAccessToken(
                    refreshToken
                );

        return res.status(200).json({
            success: true,
            accessToken
        });

    } catch (error) {

        return res.status(401).json({
            success: false,
            message: error.message
        });

    }
};

const logout = async (req, res) => {

    try {

        const { userId } = req.body;

        await authService.logout(
            userId
        );

        res.clearCookie(
            "refreshToken"
        );

        return res.status(200).json({
            success: true,
            message:
                "Logout successful"
        });

    } catch (error) {

        return res.status(500).json({
            success: false,
            message: error.message
        });

    }
};

module.exports = {
    register,
    login,
    refreshToken,
    logout
};