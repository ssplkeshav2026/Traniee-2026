const userService = require("../services/user.service")

const getEmployees =
    async (req, res) => {

        try {

            const employees =
                await userService
                    .getEmployees();

            return res.status(200)
                .json({

                    success: true,

                    data: employees

                });

        } catch (error) {

            return res.status(500)
                .json({

                    success: false,

                    message:
                        error.message

                });

        }

    };

const getAllUsers =
    async (req, res) => {

        try {

            const users =
                await userService
                    .getAllUsers();

            return res.json({

                success: true,

                data: users

            });

        } catch (error) {

            return res.status(500)
                .json({

                    success: false,

                    message:
                        error.message

                });

        }

    };

const getUserById =
    async (req, res) => {

        try {

            const user =
                await userService
                    .getUserById(
                        req.params.id
                    );

            return res.json({

                success: true,

                data: user

            });

        } catch (error) {

            return res.status(500)
                .json({

                    success: false,

                    message:
                        error.message

                });

        }

    };
const updateUser =
    async (req, res) => {

        try {

            const user =
                await userService
                    .updateUser(

                        req.params.id,

                        req.body

                    );

            return res.json({

                success: true,

                data: user

            });

        } catch (error) {

            return res.status(500)
                .json({

                    success: false,

                    message:
                        error.message

                });

        }

    };

const deleteUser =
    async (req, res) => {

        try {

            await userService
                .deleteUser(
                    req.params.id
                );

            return res.json({

                success: true,

                message:
                    "User deleted"

            });

        } catch (error) {

            return res.status(500)
                .json({

                    success: false,

                    message:
                        error.message

                });

        }

    };

module.exports = {
    getEmployees,
    getAllUsers,
    getUserById,
    updateUser,
    deleteUser
}