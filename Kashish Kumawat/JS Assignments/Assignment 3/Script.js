document.addEventListener("DOMContentLoaded", function () {

    let current = 0;
    let steps = document.querySelectorAll(".form-step");
    let progress = document.querySelectorAll(".step");
    
    steps.forEach(step => step.style.left = "100%");
    steps[0].style.left = "0";
    steps[0].style.display = "block";
    function updateProgress(index) {
        progress.forEach((step, i) => {
            step.classList.remove("active", "completed");

            if (i < index) {
                step.classList.add("completed");
                step.textContent = "";
            } else {
                step.textContent = i + 1;
            }
        });
    progress[index].classList.add("active");

        let percent = (index) / (progress.length - 1) * 100;
        document.querySelector(".progress-fill").style.width = percent + "%";
    }

       function showStep(newIndex, dir) {
        let currentStep = steps[current];
        let nextStep = steps[newIndex];

        nextStep.style.left = (dir === "next") ? "100%" : "-100%";
        nextStep.style.display = "block";

        currentStep.style.transition = "0.3s";
        nextStep.style.transition = "0.3s";

        currentStep.style.left = (dir === "next") ? "-100%" : "100%";
        nextStep.style.left = "0%";

        current = newIndex;
        updateProgress(current);
    }

    document.querySelectorAll(".next").forEach(btn => {
        btn.addEventListener("click", () => {
            if (current < 3) showStep(current + 1, "next");
        });
    });
 
    document.querySelectorAll(".prev").forEach(btn => {
        btn.addEventListener("click", () => {
            if (current > 0) showStep(current - 1, "prev");
        });
    });

    
    document.getElementById("form").addEventListener("submit", function (e) {
        e.preventDefault();

        let data = {
            fname: document.getElementById("fname").value,
            lname: document.getElementById("lname").value,
            email: document.getElementById("email").value,
            phone: document.getElementById("phone").value,
            dob: document.getElementById("dob").value,
            gender: document.getElementById("gender").value,
            username: document.getElementById("username").value,
            password: document.getElementById("password").value
        };

        localStorage.setItem("userData", JSON.stringify(data));
        document.getElementById("form").style.display = "none";
        document.querySelector(".progress-container").style.display = "none";
        document.getElementById("successBox").classList.remove("hidden");
    });  

});