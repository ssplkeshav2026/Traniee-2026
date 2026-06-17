const input = document.getElementById("create");
const tasks = document.getElementById("task-container");

let ls = JSON.parse(localStorage.getItem("tasks")) || [];

function addData() {
    const task = input.value;

    if (!task) {
        alert("Please add your task");
            return;
        }

    const isTaskExist = tasks.querySelectorAll("span");
    for (let i = 0; i < isTaskExist.length; i++) {
        if (isTaskExist[i].textContent.trim().toLowerCase() === task.trim().toLowerCase()) {
         alert("This task is already present");
            return;
             }
    }

         const obj = {
            id: ls.length + 1,
        name: task,
        isCompleted: false
    
    };

    showTask(obj);

        ls.push(obj);

    localStorage.setItem("tasks", JSON.stringify(ls));

    input.value = "";
}

function showTask(obj){
    const addTasks = document.createElement("li");

    addTasks.innerHTML = `<label>
        <input type="checkbox" class="checkbox">
        <span>
            ${obj.name}
        </span>
        <button class="delete">Delete</button>
    </label>`;

    tasks.appendChild(addTasks);

    const check = addTasks.querySelector(".checkbox");
    const line = addTasks.querySelector("span");
    const dlt = addTasks.querySelector(".delete");

    check.addEventListener("change", function () {
            if (this.checked) {
            line.style.textDecoration = "line-through";
            obj.isCompleted = true;
        } else {
        line.style.textDecoration = "none";
            obj.isCompleted = false;
        
        }

        localStorage.setItem("tasks", JSON.stringify(ls));
    });

    dlt.addEventListener("click",function(){
        addTasks.remove();
        const index = ls.findIndex(data => data.id === obj.id);

    if (index !== -1) {
        ls.splice(index, 1);
    }
        localStorage.setItem("tasks", JSON.stringify(ls));
    }

);
}


for (let i = 0; i < ls.length; i++) {
            showTask(ls[i]);
        }

function DeleteAllData() {
    // const task = input.value;
    if (tasks.innerHTML === '') {
          alert("You don't have anything to delete");
            return;
    }

         tasks.innerHTML = "";
                 localStorage.removeItem("tasks");
    ls = [];
}




function getTaskById(id){
    return ls.find(data => data.id === id);
}

function checkIdExist(){
const taskId = prompt("Enter any task id:")
if (!taskId) {
        console.log("No ID entered");
        return;
    }
const res = getTaskById(Number(taskId));
if(res){
    console.log(res);
}else{
    console.log("task not found");
}
}