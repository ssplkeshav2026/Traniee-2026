const { Task, User } = require('../module/index');
const { Op } = require('sequelize');


const getTasksByUserId = async (userId, filterType = 'assignedTo') => {
  const user = await User.findByPk(userId);
  if (!user) {
    const error = new Error('USER_NOT_FOUND');
    error.statusCode = 404;
    throw error;
  }

  const whereCondition = {};
  if (filterType === 'createdBy') {
    whereCondition.assignedByUserId = userId;
  } else {
    whereCondition.assignedToUserId = userId;
  }

  const tasks = await Task.findAll({
    where: whereCondition,
    include: [
      {
        model: User,
        as: 'Assignee',
        attributes: ['userId', 'FullName', 'email']
      },
      {
        model: User,
        as: 'Creator',
        attributes: ['userId', 'FullName', 'email']
      }
    ],
    order: [['createdDate', 'DESC']]
  });

  return tasks;
};


const createTask = async (taskData) => {
  const { title, description, assignedToUserId, assignedByUserId, dueDate,status } = taskData;


  const [assignee, creator] = await Promise.all([
    User.findByPk(assignedToUserId),
    User.findByPk(assignedByUserId)
  ]);

  if (!assignee) throw new Error('ASSIGNEE_NOT_FOUND');
  if (!creator) throw new Error('CREATOR_NOT_FOUND');


  const task = await Task.create({
    title,
    description,
    assignedToUserId,
    assignedByUserId,
    status,
    dueDate: dueDate ? new Date(dueDate) : null
  });

  return task;
};


const getAllTasksWithDetails = async () => {
  return await Task.findAll({
    include: [
      {
        model: User,
        as: 'Assignee',
        attributes: ['userId', 'FullName', 'email']
      },
      {
        model: User,
        as: 'Creator',
        attributes: ['userId', 'FullName', 'email']
      }
    ],
    order: [['createdDate', 'DESC']] 
  });
};

const deleteTask = async (taskId) => {
  const task = await Task.findByPk(taskId);
  
  if (!task) {
    const error = new Error('TASK_NOT_FOUND');
    error.statusCode = 404;
    throw error;
  }

  await task.destroy();

  return {
    taskId: task.taskId,
    title: task.title
  };
};

const updateTask = async (taskId, updateData) => {
  const task = await Task.findByPk(taskId);
  if (!task) {
    const error = new Error('TASK_NOT_FOUND');
    error.statusCode = 404;
    throw error;
  }

  if (updateData.assignedToUserId) {
    const assigneeExists = await User.findByPk(updateData.assignedToUserId);
    if (!assigneeExists) {
      const error = new Error('ASSIGNEE_NOT_FOUND');
      error.statusCode = 400;
      throw error;
    }
  }

  await task.update(updateData);

  return task;
};

const getTaskDetailsById = async (taskId) => {
  const task = await Task.findByPk(taskId, {
    include: [
      {
        model: User,
        as: 'Assignee',
        attributes: ['userId', 'FullName', 'email']
      },
      {
        model: User,
        as: 'Creator',
        attributes: ['userId', 'FullName', 'email']
      }
    ]
  });

  if (!task) {
    const error = new Error('TASK_NOT_FOUND');
    error.statusCode = 404;
    throw error;
  }

  return task;
};



module.exports = {
  createTask,
  getAllTasksWithDetails,
  deleteTask,
  updateTask,
  getTasksByUserId,
  getTaskDetailsById
};