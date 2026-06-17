
$(document).on("focus", ".editable", function () {

   
    if ($(this).closest(".preview-mode").length) return;

    $(".icon-style").hide();

    let toolbar = $(this).closest(".form-title").find(".icon-style").first();

    $(this).after(toolbar);
    toolbar.show();
});





let currentEditable = null;

$(document).on("focus", ".editable", function () {

    
    if ($(this).closest(".preview-mode").length) return;

    currentEditable = $(this);

    $(".icon-style").hide();

    let toolbar = $(this).closest(".form-title").find(".icon-style").first();

    $(this).after(toolbar);
    toolbar.show();
});



// apply formatting 
$(document).on("click", ".icon-style span", function () {

    if (!currentEditable) return;

    let index = $(this).index();

    switch (index) {

        case 0:
            currentEditable.toggleClass("bold-text");
            break;

        case 1:
            currentEditable.toggleClass("italic-text");
            break;

        case 2:
            currentEditable.toggleClass("underline-text");
            break;

        case 3: 
        currentEditable.toggleClass("line-through");
            break;

        case 4: 
            currentEditable.removeClass("bold-text italic-text underline-text");
            currentEditable.css("text-decoration", "none");
            break;
    }
});


// for copy
$(document).on("click", ".copy", function () {
    let current = $(this).closest(".form-title");
    let clone = current.clone(true);
    current.after(clone);
});


// for delete

$(document).on("click", ".delete", function () {
    $(this).closest(".form-title").remove();
});


// for question type
$(document).on("change", ".question-type", function () {

    let type = $(this).val();
    let area = $(this).closest(".form-title").find(".question-area");

    if (type === "multiple") {

        let groupName = "q_" + $(this).closest(".form-title").index();

        area.html(`
            <div class="option-item">
                <label>
                    <input type="radio" name="${groupName}">
                    <span class="option-text">Option 1</span>
                </label>
            </div>

            <div class="option-item add-option">
                <label>
                    <input type="radio" disabled>
                    <span>Add option</span>
                </label>
            </div>
        `);
    }

    else if (type === "checkbox") {
        area.html(`
            <div class="option-item">
                <label>
                    <input type="checkbox">
                    <span class="option-text">Option 1</span>
                </label>
            </div>

            <div class="option-item add-option">
                <label>
                    <input type="checkbox" disabled>
                    <span>Add option</span>
                </label>
            </div>
        `);
    }

    else if (type === "dropdown") {

        area.html(`
            <div class="dropdown-builder">

                <div class="option-item">
                    <input type="text" class="dropdown-input" value="Option 1">
                </div>

                <div class="option-item add-option">
                    <span>Add option</span>
                </div>

                <select class="dropdown-preview"></select>

            </div>
        `);

        updateDropdownNew(area.find(".dropdown-builder"));
    }

    else if (type === "short Answer") {
        area.html(`<input type="text">`);
    }

    else if (type === "date") {
        area.html(`<input type="date">`);
    }

    else if (type === "paragraph") {
        area.html(`<textarea rows="4"></textarea>`);
    }
});

//  DEFAULT LOAD 
$(document).ready(function () {
    $(".question-type").trigger("change");
});


//  for adding question
$(document).on("click", ".fa-plus", function () {

    let newQuestion = `
        <div class="que">
            <div class="form-title">
                <div class="drag-handle">
                    <span class="grip"><i class="fa-solid fa-grip"></i></span>
                </div>

                <div class="title-input editable" contenteditable="true">Untitled Question</div>

                <span class="image"><i class="fa-regular fa-image"></i></span>
                <input type="file" class="image-input" style="display:none;">

                <select class="question-type">
                    <option value="multiple">Multiple choice</option>
                    <option value="checkbox">Checkboxes</option>
                    <option value="dropdown">Drop-down</option>
                    <option value="date">Date</option>
                    <option value="paragraph">paragraph</option>
                    <option value="short Answer">short Answer</option>
                                                            

                </select>

                <div class="icon-style">
                   <span class="bold"><i class="fa-solid fa-bold"></i></span>
                        <span class="italic"><i class="fa-solid fa-italic"></i></span>
                        <span class="underline"><i class="fa-solid fa-underline"></i></span>
                         <span class="Strikethrough"><i class="fa-solid fa-strikethrough"></i></span>
                         <span class="remove-format"><i class="fas fa-remove-format"></i></i></span>
                </div>

                <div class="desc question-area"></div>

                <div class="icon-delete-copy-required">
                    <span class="copy"><i class="fa-regular fa-copy"></i></span>
                    <span class="delete"><i class="fa-solid fa-delete-left"></i></span>
                </div>
            </div>
        </div>
    `;

    $(".que-main").append(newQuestion);
    $(".que-main .form-title:last .question-type").trigger("change");
});


// for adding title
$(document).on("click", ".fa-t", function () {

    let newTitle = `
        <div class="form-title">
            <div class="color"></div>

            <div class="title-input editable" contenteditable="true">Title</div>
             <div class="icon-style">
                    <span class="bold"><i class="fa-solid fa-bold"></i></span>
                    <span class="italic"><i class="fa-solid fa-italic"></i></span>
                    <span class="underline"><i class="fa-solid fa-underline"></i></span>
                     <span class="Strikethrough"><i class="fa-solid fa-strikethrough"></i></span>
                     <span class="remove-format"><i class="fas fa-remove-format"></i></i></span>
                </div>

            <div class="desc">
                <div class="title-input editable" contenteditable="true">Description</div>
                 <div class="icon-style">
                    <span class="bold"><i class="fa-solid fa-bold"></i></span>
                    <span class="italic"><i class="fa-solid fa-italic"></i></span>
                    <span class="underline"><i class="fa-solid fa-underline"></i></span>
                     <span class="Strikethrough"><i class="fa-solid fa-strikethrough"></i></span>
                     <span class="remove-format"><i class="fas fa-remove-format"></i></i></span>
                </div>
            </div>
        </div>
    `;

    $(".title").append(newTitle);
});

// adding option
$(document).on("click", ".option-text", function () {


    if ($(this).closest(".preview-mode").length) return;

    let text = $(this).text();

    $(this).replaceWith(
        `<input type="text" class="option-input" value="${text}">`
    );
});



$(document).on("click", ".add-option", function () {

    let container = $(this).closest(".form-title");
    let area = container.find(".question-area");
    let type = container.find(".question-type").val();

    let count = area.find(".option-item").not(".add-option").length + 1;

    if (type === "dropdown") {

        let wrapper = area.find(".dropdown-builder");

        let newOption = `
            <div class="option-item">
                <input type="text" class="dropdown-input" value="Option ${count}">
            </div>
        `;

        $(this).before(newOption);
        updateDropdownNew(wrapper);
        return;
    }

    let inputType = (type === "checkbox") ? "checkbox" : "radio";
    let groupName = "q_" + container.index();

    let newOption = `
        <div class="option-item">
            <label>
                <input type="${inputType}" name="${groupName}">
                <span class="option-text">Option ${count}</span>
            </label>
        </div>
    `;

    $(this).before(newOption);
});



function updateDropdownNew(container) {

    let select = container.find(".dropdown-preview");

    select.empty();

    container.find(".dropdown-input").each(function () {
        let val = $(this).val().trim();
        if (val !== "") {
            select.append(`<option>${val}</option>`);
        }
    });
}


$(document).on("input", ".dropdown-input", function () {

    let wrapper = $(this).closest(".dropdown-builder");
    updateDropdownNew(wrapper);
});

$(document).on("click", "#generateHTML", function () {

    let clone = $(".main").clone();

    clone.find(".option-input").each(function () {
        let val = $(this).val();
        $(this).replaceWith(`<span class="option-text">${val}</span>`);
    });

    
    clone.find("input[type='text']").each(function () {
        let val = $(this).val();
        $(this).replaceWith(`<span>${val}</span>`);
    });

    clone.find("input[type='text']").remove();

  
    clone.find("[contenteditable]").removeAttr("contenteditable");

   
    clone.find(".icon-style").remove();
    clone.find(".icon-delete-copy-required").remove();
    clone.find(".drag-handle").remove();
    clone.find(".image").remove();
    clone.find(".question-type").remove();
    clone.find(".add-option").remove();
    clone.find(".dropdown-input").remove();

   
    clone.find(".dropdown-builder").each(function () {
        let options = "";
        $(this).find(".dropdown-preview option").each(function () {
            options += `<option>${$(this).text()}</option>`;
        });
        $(this).replaceWith(`<select>${options}</select>`);
    });

    let html = clone.html();


    $(".preview").html(`<div class="main preview-mode">${html}</div>`);
});