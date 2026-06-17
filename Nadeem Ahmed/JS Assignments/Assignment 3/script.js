let currStep = 0;

const steps = $('.form-class');
const switchTabs = $('.step');

function updateUI() {
    steps.removeClass('active');
    steps.eq(currStep).addClass('active');

    switchTabs.removeClass('active');
    switchTabs.eq(currStep).addClass('active');
}

function nextStep() {

    let isValid = true;

    steps.eq(currStep).find("input, select").each(function () {
        if ($(this).val().trim() === "") {
            isValid = false;
        }
    });

    if (!isValid) {
        alert("Please fill all fields first!");
        return;
    }

    switchTabs.eq(currStep).addClass('completed')

    if (currStep < steps.length - 1) {
        currStep++;
        updateUI();
    }
}

function prevStep() {
    if (currStep > 0) {
        currStep--;
        updateUI();
    }
}

const form = document.querySelector('form');

form.addEventListener('submit', function (e) {
    e.preventDefault();

    const inputs = form.querySelectorAll("input, select");

    let formData = {};

    inputs.forEach((input) => {
        if (input.name) {
            formData[input.name] = input.value.trim();
        }
    });

    console.log("Current Form Data:", formData);

    
    let existingData = localStorage.getItem("FormData");


    existingData = existingData ? JSON.parse(existingData) : [];


    if (!Array.isArray(existingData)) {
        existingData = [];
    }

    existingData.push(formData);

  
    localStorage.setItem("FormData", JSON.stringify(existingData));

    console.log("All Stored Data: ", existingData);


    alert("Data saved Successfully!");

    form.reset();
    currStep = 0;
    switchTabs.removeClass('completed');
    updateUI();
});