const express = require("express");
const cookieParser = require("cookie-parser");
const cors = require("cors")

const authRoutes = require("./routes/auth.route")
const taskRoutes = require("./routes/task.route")
const userRoutes = require("./routes/user.route")

const app = express();

app.use(express.json());
app.use(cookieParser());

app.use(
  cors({
    origin: 'http://localhost:4200',
    credentials: true
  })
);

app.use("/api/v1/auth", authRoutes);
app.use("/api/v1/tasks", taskRoutes);
app.use("/api/v1/users", userRoutes)

module.exports=app;