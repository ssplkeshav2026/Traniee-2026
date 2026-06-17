$(document).ready(function () {
    $("#questions-container").sortable();

    function updateOptions(questionEditor, type) {
        const selectOptions = questionEditor.find(".options");

        selectOptions.empty();
        console.log("Options: ", selectOptions);

        if (type === "paragraph") {
            selectOptions.append(
                '<textarea placeholder="Long answer text" disabled></textarea>',
            );
        } else if (type === "short") {
            selectOptions.append(
                '<input type="text" class="short-answer-input" placeholder="Short answer text" disabled />',
            );
        } else if (type === "radio") {
            selectOptions.append(
                '<p class="add-option">Add option or <span>add "Other"</span></p>',
            );
        } else if (type === "checkbox") {
            selectOptions.append(
                '<p class="add-option add-checkbox-option">Add option or <span>add "Other"</span></p>',
            );
        } else if (type === "dropdown") {
            selectOptions.append(
                '<p class="add-option add-dropdown-option">Add option</p>',
            );
        } else if (type === "date") {
            selectOptions.append('<input type="date" class="date-input" disabled />');
        } else if (type === "time") {
            selectOptions.append('<input type="time" class="time-input" disabled />');
        }
    }

    $(".side-toolbar button:nth-child(2)").click(function () {
        let newTitle = $("#title-bar").clone();
        newTitle.removeAttr("id");
        newTitle.find('input[type="text"]').val("");
        newTitle.css("display", "block");
        $("#questions-container").append(newTitle);
        $("#questions-container").sortable("refresh");
    });

    $(document).on("click", ".delete-question", function () {
        $(this).closest(".question-editor").remove();
    });

    $(document).on("click", ".delete-title", function () {
        $(this).closest(".form-title").remove();
    });

    $(document).on("click", ".copy-title", function () {
        const original = $(this).closest(".form-title");
        const copy = original.clone(true, true);
        copy.removeAttr("id");
        copy.css("display", "block");
        original.after(copy);
        $("#questions-container").sortable("refresh");
    });

    $(document).on("click", ".copy-question", function () {
        const original = $(this).closest(".question-editor");
        const copy = original.clone(true, true);

        const originalText = original.find(".question-input").html();
        copy.find(".question-input").val(originalText);

        const selectedType = original.find(".question-type").val();
        copy.find(".question-type").val(selectedType);

        copy.removeData("radio-name");
        copy.find('input[type="radio"]').each(function () {
            $(this).attr("name", "q" + Date.now());
        });

        copy.removeAttr("id");
        copy.css("display", "block");

        original.after(copy);
        $("#questions-container").sortable("refresh");
    });

    $(".side-toolbar button:first-child").click(function () {
        let newQn = $("#question-template").clone();
        newQn.removeAttr("id");
        newQn.find('input[type="text"]').val("");
        newQn.find(".question-type").val("short");
        newQn.css("display", "block");

        updateOptions(newQn, "short");

        $("#questions-container").append(newQn);
        $("#questions-container").sortable("refresh");
    });

    $(document).on("click", ".toolbar span", function () {
        const toolbar = $(this).closest(".toolbar");
        let input = toolbar.prevAll('input[type="text"], textarea').first();

        if (!input.length) {
            input = toolbar
                .closest(".question-editor, .form-title, .form-header")
                .find('input[type="text"], textarea')
                .first();
        }

        const idx = $(this).index();
        console.log("Index: ", idx);

        if (idx === 0) {
            input.toggleClass("bold-text");
            $(this).toggleClass("active");
        } else if (idx === 1) {
            input.toggleClass("italic-text");
            $(this).toggleClass("active");
        } else if (idx === 2) {
            input.toggleClass("underline-text");
            $(this).toggleClass("active");
        } else if (idx === 3) {
            input.removeClass("bold-text italic-text underline-text");
            toolbar.find("span").removeClass("active");
        }
    });

    $(document).on("change", ".question-type", function () {
        const questionEditor = $(this).closest(".question-editor");
        const type = $(this).val();
        console.log("Type: ", type);
        updateOptions(questionEditor, type);
    });

    $(document).on(
        "click",
        ".add-option:not(.add-checkbox-option):not(.add-dropdown-option)",
        function (e) {
            if ($(e.target).is("span")) return;

            const options = $(this).closest(".options");
            const question = $(this).closest(".question-editor");

            if (!question.data("radio-name")) {
                question.data("radio-name", "q" + Date.now());
            }
            const radioName = question.data("radio-name");

            const optionCount = options.find(".option-row").length + 1;

            const newRow = $(`
            <div class="option-row">
                <input type="radio" disabled />
                <input type="text" class="option-text" value="Option ${optionCount}" />
                <span class="delete-option"><i class="fa-solid fa-xmark"></i></span>
            </div>
        `);

            $(this).before(newRow);
        },
    );

    $(document).on("click", ".add-checkbox-option", function (e) {
        if ($(e.target).is("span"))
            return;

        const options = $(this).closest(".options");
        const optionCount = options.find(".option-row").length + 1;

        const newRow = $(`
            <div class="option-row">
                <input type="checkbox" disabled />
                <input type="text" class="option-text" value="Option ${optionCount}" />
                <span class="delete-option"><i class="fa-solid fa-xmark"></i></span>
            </div>
        `);

        $(this).before(newRow);
    });

    $(document).on("click", ".add-dropdown-option", function (e) {
        const options = $(this).closest(".options");
        const optionCount = options.find(".option-row").length + 1;
        console.log("OPTIONS COUNT: ", optionCount)

        const newRow = $(`
            <div class="option-row">
                <span class="option-number" style="font-size: 15px;">${optionCount}.</span>
                <input type="text" class="option-text" value="Option ${optionCount}" />
                <span class="delete-option"><i class="fa-solid fa-xmark"></i></span>
            </div>
        `);

        $(this).before(newRow);
    });

    $(document).on("click", ".add-option span", function (e) {
        e.stopPropagation();

        const options = $(this).closest(".options");

        if (options.find(".other-row").length > 0) return;

        const otherRow = $(`
            <div class="option-row other-row">
                <input type="radio" disabled />
                <input type="text" class="option-text" value="Other" />
                <span class="delete-option"><i class="fa-solid fa-xmark"></i></span>
            </div>
        `);

        $(this).closest("p").before(otherRow);
    });

    $(document).on("click", ".delete-option", function () {
        $(this).closest(".option-row").remove();
    });

    $("#generate-btn").click(function () {
        console.log("Generated clicked!")
        const out = $("#generated-output").empty();

        const title = $(".form-header .header").val().trim() || "Untitled Form";
        const description = $(".form-header .description").val().trim();
        out.append(`<div class="form-header" style="height:auto"><div class="header">${title}</div>${description ? `<div class="description">${description}</div>` : ""}</div>`);

        $("#questions-container").children().each(function () {
            const currElement = $(this);


            if (currElement.hasClass("form-title")) {
                const t = currElement.find("input.title").val().trim() || "Untitled Title";
                const d = currElement.find("input.description").val().trim();
                out.append(`<div class="form-title" style="display:block;height:auto"><div class="title" style="width:100%">${t}</div>${d ? `<div class="description">${d}</div>` : "Description"}</div>`);
                return;
            }

            if (!currElement.hasClass("question-editor")) return;

            const qText = currElement.find(".question-input").val().trim() || "Untitled Question";
            const type = currElement.find(".question-type").val();
            let body = "";
            let counter = 1;
            if (type === "short")
                body = `<input type="text" placeholder="Your answer" />`;
            else if (type === "paragraph")
                body = `<textarea  placeholder="Your answer"></textarea>`;
            else if (type === "date")
                body = `<input type="date"/>`;
            else if (type === "time")
                body = `<input type="time"/>`;
            else if (type === "dropdown") {
                const options = currElement.find(".option-row").map((_, r) => `<option>${$(r).find(".option-text").val() || "Option"}</option>`).get().join("");
                body = `<select>${options}</select>`;
            } else {
                const inputType = type === "radio" ? "radio" : "checkbox";
                const radioName = "rg" + counter++;
                console.log("COUNTER: ", counter)
                body = currElement.find(".option-row").map(function (i) {
                    const val = $(this).find(".option-text").val() || "Option";
                    return `<div><input type="${inputType}" name="${radioName}" id="${radioName + i}" /><label for="${radioName + i}">${val}</label></div>`;
                }).get().join("");

            }

            out.append(`<div class="question-editor" style="border-left-color:#673ab7"><div class="question-text">${qText}</div><div class="options" style="font-size:16px">${body}</div></div>`);
        });

        $("#generated-form-section").slideDown(300);
    });
});
