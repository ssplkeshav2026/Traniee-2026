const express = require("express")
const { getAllEmpCont, getAllEmpContlow, getAllMngCont, updateUserHandler, deleteEmployeeHandler } = require("../controllers/adminContollers")
const route = express.Router()

route.get("/",getAllEmpCont)
route.get("/Employee",getAllEmpContlow)
route.patch('/:id', updateUserHandler);
route.delete('/:id', deleteEmployeeHandler);



module.exports = route