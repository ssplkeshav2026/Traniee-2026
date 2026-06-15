const taskRepository = require("../repositories/task.repository")

const createTask = async (taskData) => {

    return await taskRepository.createTask(taskData)
};

const getAllTasks = async () => {
    return await taskRepository.getAllTasks();
}

const getTaskById = async (taskId) => {
    const task = await taskRepository.getTaskById(taskId);

    if (!task) {
        throw new Error("Task not found")
    }

    return task;
}

const getTaskByUser = async (userId) => {
    return await taskRepository.getTaskByUser(userId)
}


const updateTask = async (
    taskId,
    updateData
) => {
    const task = await taskRepository.updateTask(taskId, updateData);

    if (!task) {
        throw new Error("Task not found!")
    }
    return task;

}

const updateTaskStatus = async (
    taskId,
    status
) => {

    const task = await taskRepository.updateTaskStatus(taskId, status);

    if (!task) {
        throw new Error("Task not found");
    }

    return task;
};

const deleteTask = async (taskId) => {

    const deleted = await taskRepository.deleteTask(taskId);

    if (!deleted) {
        throw new Error("Task not found");
    }
    return true;
};

module.exports = {
    createTask,
    getAllTasks,
    getTaskById,
    getTaskByUser,
    updateTask,
    updateTaskStatus,
    deleteTask
}