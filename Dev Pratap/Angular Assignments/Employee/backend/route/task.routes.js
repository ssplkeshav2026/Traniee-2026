const express = require('express');
const router = express.Router();
const { getTasksController, createTaskController, deleteTaskController, updateTaskController, getUserTasksHandler, getTaskByIdHandler } = require('../controllers/taskController');
const authorize = require('../middleware/role.middleware');

// Secure these endpoints with authentication middleware in production
router.post('/',
    authorize("Admin", "Manager"),
    createTaskController);

router.get('/',
    authorize("Admin", "Manager"),
    getTasksController);
router.delete('/:id',
    authorize("Admin"),
    deleteTaskController);
router.patch('/:id', 
    updateTaskController);
router.get('/user/:userId', 
    getUserTasksHandler);
router.get('/:id', getTaskByIdHandler);

module.exports = router;