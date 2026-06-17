$(document).ready(function () {

    const taskInput = $('#title');
    const taskList = $('#taskList');
    const button = $('#my-btn');


    const tasks = JSON.parse(localStorage.getItem('myTasks')) || [];
    tasks.forEach(task => addTaskElement(task));


    button.click(function () {
        const taskTitle = taskInput.val().trim();

        if (taskTitle === '') {
            alert("Please Enter title:");
            return;
        }

        let tasks = JSON.parse(localStorage.getItem('myTasks')) || [];

        const newTask = {
            id: tasks.length + 1,
            text: taskTitle,
            checkbox: false
        };

        tasks.push(newTask);
        localStorage.setItem('myTasks', JSON.stringify(tasks));

        addTaskElement(newTask);
        taskInput.val('');
    });



    function addTaskElement(task) {
        const li = $(`
            <li data-id="${task.id}">
                <input type="checkbox" class="check" ${task.checkbox ? 'checked' : ''}>
                <span>${task.text}</span>
                <button class="delete">Delete</button>
            </li>
        `);

        function updateCheckbox(id, isChecked) {
            let tasks = JSON.parse(localStorage.getItem('myTasks')) || [];

            tasks = tasks.map(task => {
                if (task.id === id) {
                    task.checkbox = isChecked;
                }
                return task;
            })
            localStorage.setItem('myTasks', JSON.stringify(tasks))
        }
        console.log("my: ", tasks)

        li.find('.check').change(function () {
            const isChecked = $(this).is(':checked')
            updateCheckbox(task.id, isChecked)
        })

        li.find('.delete').click(function () {
            deleteTask(task.id);
        });

        taskList.append(li);
    }


    function deleteTask(id) {
        let tasks = JSON.parse(localStorage.getItem('myTasks')) || [];
        console.log("TASKS:", tasks);
        tasks = tasks.filter(task => task.id !== id);
        console.log("TASKS:", tasks);
        localStorage.setItem('myTasks', JSON.stringify(tasks));

        $(`[data-id="${id}"]`).remove();
    }

});


