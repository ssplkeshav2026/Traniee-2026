let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

  function saveTasks() {
    localStorage.setItem("tasks", JSON.stringify(tasks));
  }

  function renderTasks() {
    let list = document.getElementById("taskList");
    list.innerHTML = "";

    tasks.forEach((task, index) => {
      let li = document.createElement("li");

      let text = document.createElement("span");
      text.innerText = task.text;
      if (task.completed) text.classList.add("completed");

      let actions = document.createElement("div");
      actions.classList.add("actions");

      let completeBtn = document.createElement("span");
      completeBtn.innerHTML = "✔";
      completeBtn.classList.add("complete");
      completeBtn.onclick = () => toggleTask(index);

      let deleteBtn = document.createElement("span");
      deleteBtn.innerHTML = "🗑";
      deleteBtn.classList.add("delete");
      deleteBtn.onclick = () => deleteTask(index);

      actions.appendChild(completeBtn);
      actions.appendChild(deleteBtn);

      li.appendChild(text);
      li.appendChild(actions);

      list.appendChild(li);
    });
  }

  function addTask() {
    let input = document.getElementById("taskInput");
    let value = input.value.trim();

    if (value === "") return;

    tasks.push({ text: value, completed: false });
    input.value = "";

    saveTasks();
    renderTasks();
  }

  function deleteTask(index) {
    tasks.splice(index, 1);
    saveTasks();
    renderTasks();
  }

  function toggleTask(index) {
    tasks[index].completed = !tasks[index].completed;
    saveTasks();
    renderTasks();
  }

  renderTasks();