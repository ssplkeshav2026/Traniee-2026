const express = require("express")
const app = express()
const authRoute = require("./route/auth.route")
const adminRoute = require("./route/admin.route")
const cors = require("cors")
const authorize  = require("./middleware/role.middleware")
const taskRouter = require("./route/task.routes")
const authenticate  = require("./middleware/auth.middleware")
require('dotenv').config()

app.use(express.json())
app.use(express.urlencoded({extended:true}))


app.use(
  cors({
    origin: "http://localhost:4200",
    methods: ["GET", "PATCH","POST", "PUT", "DELETE"],
    credentials: true,
  })
);

app.use("/auth",authRoute)

app.use("/task",authenticate,taskRouter)

app.use("/admin/api",
  authenticate,
  authorize("Admin","Manager"),
  adminRoute)

    

app.listen("8000")