

const taskInput = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

window.onload = loadTasks;
addBtn.onclick = addTask;


function generateId() {
    return Date.now(); 
}

function addTask() {
    let text = taskInput.value.trim();

    if (text === "") {
        alert("Please enter a task");
        return;
    }

    let id = generateId();

    createTask(id, text, false);
    saveTask(id, text, false);

    taskInput.value = "";
}

function createTask(id, text, completed) {

    let taskDiv = document.createElement("div");
    taskDiv.className = "task";
    taskDiv.setAttribute("data-id", id); 

    taskDiv.innerHTML = `
        <input type="checkbox" ${completed ? "checked" : ""}>
        <span>${text}</span>
        <button class="delete">Delete</button>
    `;

    if (completed) {
        taskDiv.style.textDecoration = "line-through";
    }


    let checkbox = taskDiv.querySelector("input");
    checkbox.onchange = function () {
        updateTask(id, checkbox.checked);

        taskDiv.style.textDecoration = checkbox.checked? "line-through": "none";
    };

    let deleteBtn = taskDiv.querySelector(".delete");
    deleteBtn.onclick = function () {
        deleteTask(id);
        taskDiv.remove();
    };

    taskList.appendChild(taskDiv);
}

function saveTask(id, text, completed) {
    let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

    tasks.push({ id, text, completed });

    localStorage.setItem("tasks", JSON.stringify(tasks));
}


function loadTasks() {
    let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

    tasks.forEach(task => {
        createTask(task.id, task.text, task.completed);
    });
}

function updateTask(id, completed) {
    let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

    tasks = tasks.map(task =>
        task.id === id ? { ...task, completed } : task
    );

    localStorage.setItem("tasks", JSON.stringify(tasks));
}


function deleteTask(id) {
    let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

    tasks = tasks.filter(task => task.id !== id);

    localStorage.setItem("tasks", JSON.stringify(tasks));
}