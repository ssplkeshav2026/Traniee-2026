let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

  function saveTasks() {
    localStorage.setItem("tasks", JSON.stringify(tasks));
  }

  function renderTasks() {
    $("#taskList").empty();

    $.each(tasks, function(index, task) {
      let li = $("<li></li>");

      let left = $("<div class='task-left'></div>");

 let checkbox = $("<input type='checkbox'>");
      checkbox.prop("checked", task.completed);

      checkbox.change(function() {
        toggleComplete(index);
      });

      let label = $("<span></span>").text(task.text);
      if (task.completed) label.addClass("completed");

      left.append(checkbox);
      left.append(label);

      let actions = $("<div class='actions'></div>");

      let del = $("<button>Delete</button>");
      del.click(function() {
        deleteTask(index);
      });

      actions.append(del);

      li.append(left);
      li.append(actions);

      $("#taskList").append(li);
    });
  }

  function addTask() {
    let text = $("#taskInput").val().trim();
    if (text === "") return;

    tasks.push({ text: text, completed: false });
    $("#taskInput").val("");

    saveTasks();
    renderTasks();
  }

  function deleteTask(index) {
    tasks.splice(index, 1);
    saveTasks();
    renderTasks();
  }

  function toggleComplete(index) {
    tasks[index].completed = !tasks[index].completed;
    saveTasks();
    renderTasks();
  }

  $(document).ready(function() {
    $("#addBtn").click(addTask);
    renderTasks();
  });