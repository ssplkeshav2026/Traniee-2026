const { Task } = require("../models");


const createTask = async (taskData) => {

    const task = await Task.create(taskData);
    return task;
};

const getAllTasks = async () => {
    return await Task.findAll();
}

const getTaskById = async(taskId) => {
    return await Task.findByPk(taskId);
}

const getTaskByUser = async(userId) => {
    return await Task.findAll({
        where:{
            assignedToUserId: userId
        }
    });
}

const updateTask = async (
    taskId,
    updateData
) => {
    const task = await Task.findByPk(taskId);

    if (!task) {
        return null;
    }

     await task.update(updateData)
     return task;
}

const updateTaskStatus = async (taskId, status) => {
    const task = await Task.findByPk(taskId);

    if (!task) {
        return null;
    }

    task.status = status;

    return await task.save();
};

const deleteTask = async (taskId) => {
    const task = await Task.findByPk(taskId);

    if (!task) {
        return null;
    }

    await task.destroy();

    return true;
};

module.exports={
    createTask,
    getAllTasks,
    getTaskById,
    getTaskByUser,
    updateTask,
    updateTaskStatus,
    deleteTask
}
