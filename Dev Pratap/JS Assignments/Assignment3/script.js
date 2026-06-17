
$(document).ready(function () {
    // getting all the input felds
    let fname = $("#fname").val()
    let lname = $("#lname").val()
    let email = $("#gmail").val()
    let phone = $("#phone").val()
    let dob = $("#date").val()
    let gender = $("#gender").val()
    let username = $("#username").val()
    let password = $("#password").val()
    let users = JSON.parse(localStorage.getItem("users")) || []
    let user = {}

    // next button  handling
    $("#btn1-next").click(function () {
        fname = $("#fname").val()
        lname = $("#lname").val()
        if (!fname && !lname) alert("Input not found")
        else {
            $("#form-1").addClass("hidden-form")
            $("#form-2").removeClass("hidden-form")
            $(".level1").addClass("pink")
            user.fname = fname
            user.lname = lname
            console.log(user)
        }
    })

    $("#btn2-next").click(function () {
        Email = $("#gmail").val()
        phone = $("#phone").val()
        if (!Email && !phone) alert("Input not found")
        else {
            $("#form-2").addClass("hidden-form")
            $("#form-3").removeClass("hidden-form")
            $(".level2").addClass("pink")
            user.Email = Email
            user.phone = phone
            // console.log(user)
        }
    })

    $("#btn3-next").click(function () {
        dob = $("#date").val()
        gender = $("#gender").val()
        if (!dob && !gender) alert("Input not found")
        else {
            $("#form-3").addClass("hidden-form")
            $("#form-4").removeClass("hidden-form")
            $(".level3").addClass("pink")
            user.dob = dob
            user.gender = gender
            // console.log(user)
        }
    })

    $("#btn4-next").click(function () {
        username = $("#username").val()
        password = $("#password").val()
        if (!username && !password) alert("Input not found")
        else {
            $("#form-4").addClass("hidden-form")
            $(".level4").addClass("pink")

            user.username = username
            user.password = password
            // console.log(user)
            users.push(user)
            localStorage.setItem("users", JSON.stringify(users))
            $("#final-page").removeClass("hidden-form")
        }
    })


    // optimizing the code next-btn
    // $(".btn-next").click(function () {
    //     first = $(this).parent().prev("input")
    //     second = $(this).parent().prev().prev("input")
    //     if (!first.val() && !second.val()) alert("Input not found")
    //     else {
    //         $(this).parent().parent().addClass("hidden-form")
    //         $(this).parent().parent().next().removeClass("hidden-form")

    //         let id = $(this).parent().parent().attr("id")
    //         let idx = parseInt(id.slice(5,7))
    //         console.log(idx)
    //         $(`.level${idx}`).addClass("pink")

    //         user[`${first.attr("id")}`] = first.val()
    //         user[`${second.attr("id")}`] = second.val()
    //         console.log(user)
    //         if (idx === 4) {
    //             users.push(user)
    //             localStorage.setItem("users", JSON.stringify(users))
    //             $("#final-page").removeClass("hidden-form")
    //         }
    //     }
    // })



    $(".btn-pre").click(function () {

        console.log("btn clied only")
        $(this).parent().parent().toggleClass("hidden-form")
        $(this).parent().parent().prev().toggleClass("hidden-form")

    })





})