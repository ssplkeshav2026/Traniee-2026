const { Role, User } = require("../models");

const getEmployees =
    async () => {

        return await User.findAll({

            include: [

                {
                    model: Role,
                    where: {
                        id: 3
                    }
                }

            ]

        });

    };

module.exports = {
    getEmployees
};

const getAllUsers =
    async () => {

        return await User.findAll({

            include: [
                {
                    model: Role
                }
            ]

        });

    };

const getUserById =
    async (id) => {

        return await User.findByPk(id, {

            include: [
                {
                    model: Role
                }
            ]

        });

    };

const updateUser =
    async (id, data) => {

        const user =
            await User.findByPk(id);

        if (!user) {

            throw new Error(
                "User not found"
            );

        }

        await user.update(data);

        return user;

    };

const deleteUser =
    async (id) => {

        const user =
            await User.findByPk(id);

        if (!user) {

            throw new Error(
                "User not found"
            );

        }

        await user.destroy();

        return true;

    };

module.exports = {
    getEmployees,
    getAllUsers,
    getUserById,
    updateUser,
    deleteUser
}