const express = require("express")
const {registerUser,loginUser,refreshTokenHandler, logoutUserHandler} = require("../controllers/authControllers")
const validateRegistrationPayload = require("../middleware/validationRegistration")
const route = express.Router()

route.post('/login',validateRegistrationPayload, loginUser);
route.post('/register',validateRegistrationPayload,registerUser);
route.post('/refresh' ,refreshTokenHandler);
route.post('/logout', logoutUserHandler);

module.exports = route