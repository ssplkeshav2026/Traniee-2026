const {createTask,
  getAllTasksWithDetails,
  deleteTask,
  updateTask,
  getTasksByUserId,
  getTaskDetailsById} =require("../repositories/taskService")

const getUserTasksHandler = async (req, res) => {
  const userId = parseInt(req.params.userId, 10);
  const { type } = req.query; 

  if (isNaN(userId)) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: The userId route parameter must be a valid number.'
    });
  }


  const filterType = type === 'createdBy' ? 'createdBy' : 'assignedTo';

  try {
    const tasks = await getTasksByUserId(userId, filterType);

    return res.status(200).json({
      success: true,
      filterUsed: filterType,
      count: tasks.length,
      data: tasks
    });

  } catch (error) {

    if (error.message === 'USER_NOT_FOUND') {
      return res.status(404).json({
        success: false,
        message: `Not Found: No user profile matches the ID: ${userId}`
      });
    }

    console.error('Fetch User Tasks Exception:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected database error occurred while fetching tasks for this user parameter.'
    });
  }
};

const createTaskController = async (req, res) => {
  const { title, description, assignedToUserId, dueDate,status } = req.body;
  

  const assignedByUserId = req.user?.userId || req.body.assignedByUserId; 

  if (!title || !assignedToUserId || !assignedByUserId) {
    return res.status(400).json({
      success: false,
      message: 'Validation error: title, assignedToUserId, and assignedByUserId are mandatory.'
    });
  }

  try {
    const task = await createTask({
      title,
      description,
      assignedToUserId,
      assignedByUserId,
      dueDate,
      status
    });

    return res.status(201).json({
      success: true,
      message: 'Task successfully provisioned and assigned.',
      data: task
    });

  } catch (error) {
    if (error.message === 'ASSIGNEE_NOT_FOUND') {
      return res.status(404).json({ success: false, message: 'Assignee user profile not found.' });
    }
    if (error.message === 'CREATOR_NOT_FOUND') {
      return res.status(404).json({ success: false, message: 'Creator user profile not found.' });
    }

    console.error('Task Creation Error:', error);
    return res.status(500).json({ success: false, message: 'Internal processing failure creating task record.' });
  }
};

const getTasksController = async (req, res) => {
  try {
    const tasks = await getAllTasksWithDetails();
    return res.status(200).json({
      success: true,
      count: tasks.length,
      data: tasks
    });
  } catch (error) {
    console.error('Task Retrieval Error:', error);
    return res.status(500).json({ success: false, message: 'Failed to retrieve task records matrix.' });
  }
};

const deleteTaskController = async (req, res) => {
  const taskId = parseInt(req.params.id, 10);

  if (isNaN(taskId)) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: The task ID parameter must be a valid number.'
    });
  }

  try {
    const deletedTaskInfo = await deleteTask(taskId);

    return res.status(200).json({
      success: true,
      message: `Success: Task #${deletedTaskInfo.taskId} ("${deletedTaskInfo.title}") has been permanently deleted.`
    });

  } catch (error) {
    if (error.message === 'TASK_NOT_FOUND') {
      return res.status(404).json({
        success: false,
        message: `Not Found: Abandoning operation. No task matches ID: ${taskId}`
      });
    }

    console.error('Task Deletion Exception:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected database error occurred while trying to drop the task record.'
    });
  }
};

const updateTaskController = async (req, res) => {
  const taskId = parseInt(req.params.id, 10);
  const { title, description, assignedToUserId, status, dueDate } = req.body;

  if (isNaN(taskId)) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: The task ID parameter must be a valid number.'
    });
  }

  const validStatuses = ['Pending', 'In Progress', 'Completed'];
  if (status && !validStatuses.includes(status)) {
    return res.status(400).json({
      success: false,
      message: `Validation failed: Status must be one of the following: ${validStatuses.join(', ')}`
    });
  }

  try {
    const fieldsToUpdate = {};
    if (title !== undefined) fieldsToUpdate.title = title;
    if (description !== undefined) fieldsToUpdate.description = description;
    if (assignedToUserId !== undefined) fieldsToUpdate.assignedToUserId = assignedToUserId;
    if (status !== undefined) fieldsToUpdate.status = status;
    if (dueDate !== undefined) fieldsToUpdate.dueDate = dueDate ? new Date(dueDate) : null;

    const updatedTask = await updateTask(taskId, fieldsToUpdate);

    return res.status(200).json({
      success: true,
      message: `Success: Task #${taskId} has been updated successfully.`,
      data: updatedTask
    });

  } catch (error) {
    if (error.message === 'TASK_NOT_FOUND') {
      return res.status(404).json({
        success: false,
        message: `Not Found: Cannot update. No task matches ID: ${taskId}`
      });
    }

    if (error.message === 'ASSIGNEE_NOT_FOUND') {
      return res.status(400).json({
        success: false,
        message: `Bad Request: The requested assignee user ID (${assignedToUserId}) does not exist.`
      });
    }

    console.error('Task Update Exception:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected internal error occurred while modifying the database task row.'
    });
  }
};

const getTaskByIdHandler = async (req, res) => {
  const taskId = parseInt(req.params.id, 10);

  if (isNaN(taskId)) {
    return res.status(400).json({
      success: false,
      message: 'Validation failed: The task ID route parameter must be a valid number.'
    });
  }

  try {
    const task = await getTaskDetailsById(taskId);

    return res.status(200).json({
      success: true,
      data: task
    });

  } catch (error) {
    if (error.message === 'TASK_NOT_FOUND') {
      return res.status(404).json({
        success: false,
        message: `Not Found: No task record matches the provided ID: ${taskId}`
      });
    }

    console.error('Fetch Task Details Exception:', error);
    return res.status(500).json({
      success: false,
      message: 'An unexpected database error occurred while fetching the task details.'
    });
  }
};

module.exports = {
    getTasksController,createTaskController,deleteTaskController,updateTaskController,getUserTasksHandler,getTaskByIdHandler
}