let currentStep = 0;
let steps = document.querySelectorAll(".step");

function ShowStep(index) {
    steps.forEach(step => step.classList.remove("active"));
    steps[index].classList.add("active");
}

function nextStep() {
    if (currentStep < steps.length - 1) {
        currentStep++;
        ShowStep(currentStep);
    }
}

function prevStep() {
    if (currentStep > 0) {
        currentStep--;
        ShowStep(currentStep);
    }
}

function submitForm() {
    let fname = document.getElementById("fname").value;
    let lname = document.getElementById("lname").value;
    let email = document.getElementById("email").value;
    let number = document.getElementById("number").value;
    let dob = document.getElementById("date").value;
    let gender = document.getElementById("gender").value;
    let username = document.getElementById("username").value;
    let password = document.getElementById("password").value;

    let userData = {
        fname,
        lname,
        email,
        number,
        dob,
        gender,
        username,
        password
    };

    
    let users = JSON.parse(localStorage.getItem("users")) || [];

    
    users.push(userData);

   
    localStorage.setItem("users", JSON.stringify(users));

    console.log("Saved:", users);

   
    currentStep++;
    ShowStep(currentStep);
}
+
ShowStep(currentStep);