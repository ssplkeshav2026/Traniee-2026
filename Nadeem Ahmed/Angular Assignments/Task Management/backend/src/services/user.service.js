const userRepository = require("../repositories/user.repository")

const getEmployees =
    async () => {

        return await userRepository
            .getEmployees();

    };
const getAllUsers =
    async () => {

        return await userRepository
            .getAllUsers();

    };

const getUserById =
    async (id) => {

        return await userRepository
            .getUserById(id);

    };

const updateUser =
    async (id, data) => {

        return await userRepository
            .updateUser(id, data);

    };

const deleteUser =
    async (id) => {

        return await userRepository
            .deleteUser(id);

    };

module.exports = {
    getEmployees,
    getAllUsers,
    getUserById,
    updateUser,
    deleteUser
};