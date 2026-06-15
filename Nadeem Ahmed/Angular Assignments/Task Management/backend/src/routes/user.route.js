const express = require("express");

const authenticate = require("../middlewares/auth.middleware")

const { getEmployees, updateUser, getUserById, getAllUsers, deleteUser } = require("../controllers/user.controller");

const authorize = require("../middlewares/role.middleware");

const router =
    express.Router();

router.get(
    "/employees",

    authenticate,

    authorize(
        "Admin",
        "Manager"
    ),

    getEmployees
);

router.get(
    "/",
    authenticate,
    authorize("Admin"),
    getAllUsers
);

router.get(
    "/:id",
    authenticate,
    authorize("Admin"),
    getUserById
);

router.put(
    "/:id",
    authenticate,
    authorize("Admin"),
    updateUser
);

router.delete(
    "/:id",
    authenticate,
    authorize("Admin"),
    deleteUser
);

module.exports = router;