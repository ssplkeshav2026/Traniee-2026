$(document).ready(function () {
    $("#my-btn").click(function () {
        let value = $("#taskInput").val();

        if (value === "") return;

        let task = {
            id: Date.now(),
            title: value,
            checkbox: false,
        };

        let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

        tasks.push(task);

        localStorage.setItem("tasks", JSON.stringify(tasks));

        $("#taskInput").val("");

        loadData();
    });

    function loadData() {
        let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

        $(".showData").html("");

        tasks.forEach(function (task) {
            $(".showData").append(
                `<li class="task-item">
      
                <input type="checkbox" class="check-btn" data-id="${task.id}" ${task.checkbox ? "checked" : ""}>
      <span class="task-title ${task.checkbox ? 'completed' : ''}">
          ${task.title}
      </span>

      

      <button class="delete-btn" data-id="${task.id}">Delete</button>

  </li>`
            );
        });
    }

    $(document).on("click", ".delete-btn", function () {
        let id = $(this).data("id");

        let tasks = JSON.parse(localStorage.getItem("tasks")) || [];

        let updatedTasks = tasks.filter(function (task) {
            return task.id !== id;
        });

        localStorage.setItem("tasks", JSON.stringify(updatedTasks));

        loadData();
    });

    loadData();
});
