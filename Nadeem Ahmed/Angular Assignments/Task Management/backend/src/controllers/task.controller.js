const taskService = require("../services/task.service");

const createTask = async (req, res) => {
    try {

        const task =
            await taskService.createTask({
                ...req.body,
                assignedByUserId: req.user.id
    });

        return res.status(201).json({
            success: true,
            data: task
        });

    } catch (error) {

        return res.status(500).json({
            success: false,
            message: error.message
        });

    }
};

const getAllTasks = async (req, res) => {
    try {

        const tasks =
            await taskService.getAllTasks();

        return res.status(200).json({
            success: true,
            data: tasks
        });

    } catch (error) {

        return res.status(500).json({
            success: false,
            message: error.message
        });

    }
};

const getTaskById = async (req, res) => {
    try {

        const task =
            await taskService.getTaskById(
                req.params.id
            );

        return res.status(200).json({
            success: true,
            data: task
        });

    } catch (error) {

        return res.status(404).json({
            success: false,
            message: error.message
        });

    }
};

const getMyTasks = async (req, res) => {
    try {

        console.log("REQ USER:")
        console.log(req.user)
        const tasks =
            await taskService.getTaskByUser(
                req.user.id
            );
        
            console.log("TASKS FOUND:");
            console.log(tasks)
        return res.status(200).json({
            success: true,
            data: tasks
        });

    } catch (error) {

        return res.status(500).json({
            success: false,
            message: error.message
        });

    }
};

const updateTask = async (req, res) => {
    try {

        const task =
            await taskService.updateTask(
                req.params.id,
                req.body
            );

        return res.status(200).json({
            success: true,
            data: task
        });

    } catch (error) {

        return res.status(404).json({
            success: false,
            message: error.message
        });

    }
};

const updateTaskStatus = async (req, res) => {
    try {

        const task =
            await taskService.updateTaskStatus(
                req.params.id,
                req.body.status
            );

        return res.status(200).json({
            success: true,
            data: task
        });

    } catch (error) {

        return res.status(404).json({
            success: false,
            message: error.message
        });

    }
};

const deleteTask = async (req, res) => {
    try {

        await taskService.deleteTask(
            req.params.id
        );

        return res.status(200).json({
            success: true,
            message: "Task deleted successfully"
        });

    } catch (error) {

        return res.status(404).json({
            success: false,
            message: error.message
        });

    }
};

module.exports = {
    createTask,
    getAllTasks,
    getTaskById,
    getMyTasks,
    updateTask,
    updateTaskStatus,
    deleteTask
};