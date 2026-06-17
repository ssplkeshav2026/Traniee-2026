let present = 0;
let steps = document.querySelectorAll(".block");
let circles = document.querySelectorAll(".nav");

function showStep(index) {
    steps.forEach(step => step.style.display = "none");
    steps[index].style.display = "block";

    circles.forEach(c => c.classList.remove("active"));
    for (let i = 0; i <= index; i++) {
        circles[i].classList.add("active");
    }
}

showStep(present);

document.querySelectorAll(".next").forEach(btn => {
    btn.addEventListener("click", () => {
        if (present < steps.length - 1) {
            present++;
            showStep(present);
        }
    });
});

document.querySelectorAll(".prev").forEach(btn => {
    btn.addEventListener("click", () => {
        if (present > 0) {
            present--;
            showStep(present);
        }
    });
});

document.getElementById("form").addEventListener("submit", function(e){
    e.preventDefault();

    let formData = {};
    document.querySelectorAll("input, select").forEach(el => {
        if (el.id) formData[el.id] = el.value;
    });

    let allData = JSON.parse(localStorage.getItem("formData")) || [];
    allData.push(formData);

    localStorage.setItem("formData", JSON.stringify(allData));

    document.getElementById("submit").style.display = "block";

    console.log(allData);
});