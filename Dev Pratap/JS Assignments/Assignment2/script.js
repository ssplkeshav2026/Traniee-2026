let crateBtn = document.getElementById('createbtn')
let textInput = document.getElementById('text-input')
let todoContainer = document.getElementsByClassName("todo-container")[0]
let deleteBtn = document.getElementsByClassName("delete-btn")
let checkboxes = document.getElementsByClassName("isDone")



// adding Elements 
crateBtn.addEventListener("click", function () {
    const todos = JSON.parse(localStorage.getItem("todos")) || [];

    const newTodo = {
        id: todos.length + 1,
        title: textInput.value,
        isDone: false
    };

    if (textInput.value === "") alert("non input")
    else todos.push(newTodo);

    localStorage.setItem("todos", JSON.stringify(todos));
})

function getTodos() {
    return JSON.parse(localStorage.getItem("todos")) || [];
}

let todos = getTodos()

// for display the list of todo
function renderTodos() {
    for (let i = 0; i <= todos.length - 1; i++) {
        const div = document.createElement('div')
        div.classList.add("todo-list")
        div.innerHTML = `
                        <input type="checkbox" class="isDone" ${todos[i].isDone ? "checked" : ""}>
                        <p class="todo-text ${todos[i].isDone ? "text-cencle" : ""}">${todos[i].title}</p>
                        <button id=${todos[i].id} class="delete-btn" type="buttton">
                            <i class="fa-solid fa-xmark"></i>
                        </button>
    `

        todoContainer.appendChild(div)

        // console.log(key, value)
    }

}

renderTodos()

for (let i = 0; i <= deleteBtn.length - 1; i++) {
    deleteBtn[i].addEventListener("click", function () {
        todos.splice(parseInt(todos[i].id) - 1, 1)
        localStorage.setItem("todos", JSON.stringify(todos));
        location.reload()
    })
}



for (let i = 0; i <= checkboxes.length - 1; i++) {
    checkboxes[i].addEventListener("click", function () {
        if (todos[i].isDone === true) todos[i].isDone = false
        else todos[i].isDone = true

        localStorage.setItem("todos", JSON.stringify(todos));
        location.reload()
    })
}

