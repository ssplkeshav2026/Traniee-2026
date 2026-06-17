// $(document).ready(function () {

//     $("#createTaskForm").submit(function (e) {

//         e.preventDefault();

//         $.ajax({

//             url: '/MvcTasks/Create',

//             type: 'POST',

//             data: $(this).serialize(),

//             success: function () {
//                 console.log("success");
//                 window.location.href = '/MvcTasks/Index'
//                 },
              
//             error: function () {

//                 alert("Something went wrong");
//             }
//         });

//     });

// });