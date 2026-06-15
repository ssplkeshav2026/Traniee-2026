const express = require("express");
const authenticate = require("../middlewares/auth.middleware");
const authorize = require("../middlewares/role.middleware");
const { createTask, getMyTasks, updateTask, updateTaskStatus, deleteTask, getAllTasks, getTaskById } = require("../controllers/task.controller");
const router = express.Router();



router.post("/",
    authenticate,
    authorize("Admin", "Manager"),
    createTask
)

router.get("/",
    authenticate,
    authorize("Employee"),
    getMyTasks
)

router.get("/all",
    authenticate,
    authorize("Admin", "Manager"),
    getAllTasks
)

router.get("/:id",
    authenticate,
    getTaskById
)

router.put("/:id",
    authenticate,
    authorize("Admin", "Manager"),
    updateTask
)

router.patch("/:id",
    authenticate,
    authorize("Employee"),
    updateTaskStatus
)

router.delete("/:id",
    authenticate,
    authorize("Admin"),
    deleteTask
)  

module.exports = router;