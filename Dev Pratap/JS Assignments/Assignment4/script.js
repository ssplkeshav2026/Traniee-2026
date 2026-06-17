

let question_html = `
                <div class="container question-box">
            <div>
                <i class="fa-solid fa-grip"></i>
            </div>

            <div class="question-first-container">
                <div class="input-container question-input">
                    <input type="text" class="inputs" value="Untitled form">
                    <div class="input-edit-tile " style="display:none;">
                        <hr>
                        <div class="heading-options">
                            <i class="fa-solid fa-bold" title=""></i>
                            <i class="fa-solid fa-italic" title=""></i>
                            <i class="fa-solid fa-underline" title=""></i>
                            <i class="fa-solid fa-text-slash" title=""></i>
                        </div>
                    </div>
                </div>
                <div class="input-side-tile">
                    <i class="fa-regular fa-image"></i>
                    <select class="option-box">
    <option value="short">Short answer</option>
    <option value="paragraph">Paragraph</option>
    <option value="mcq">Multiple choice</option>
    <option value="checkbox">Checkbox</option>
    <option value="dropdown">Dropdown</option>
    <option value="date">Date</option>
</select>
                    <hr>
                </div>
            </div>




            <div class="ans-box">
                <div class="optionBox">
                    <i class="fa-solid fa-grip "></i>
                    <input type="text" class="option-input-box">
                    <i class="fa-regular fa-circle-xmark"></i>
                </div>
            </div>
            <div class=" lastOption">
                <p class="addOption">Add option</p>
            </div>
            <div class=" toHide option-footer ">
                <i class="fa-regular fa-copy"></i>
                <i class="fa-solid fa-trash-can delete"></i>
                
            </div>
        </div>
                `


$(document).ready(function () {
    $(document).on("click", ".container", function () {
        // alert("hel")
        $(".container").removeClass("sideAnimation")
        $(this).addClass("sideAnimation")
    })
    // $(".option-box").trigger("change");

    $(".sort").not($(".heading-box")).sortable();
    $(".ans-box").sortable();

    $('.main').on("click", ".delete", function () {

        $(this).parentsUntil(".sort").remove()
    });

    $('.main').on("click", ".inputs", function () {
        $(".input-edit-tile").slideUp()
        $(this).siblings(".input-edit-tile").slideDown()

    });

    $('.main').on("click", ".lastOption", function () {
        $(".input-edit-tile").slideUp();

        let ansBox = $(this).prev(".ans-box");
        let newOption = ansBox.children().first().clone();
        newOption.children("input").val("")

        ansBox.append(newOption);
    });


    $(document).on("click", ".fa-bold", function () {
        let input = $(this).closest('.input-container').find('.inputs');
        input.css("font-weight", input.css("font-weight") === "400" ? "700" : "400");
    });




    $('.main').on("click", ".fa-italic", function () {
        let input = $(this).closest('.input-container').find('.inputs');
        input.css("font-style", input.css("font-style") === "italic" ? "normal" : "italic");
    });

    $('.main').on("click", ".fa-underline", function () {
        let input = $(this).closest('.input-container').find('.inputs');
        input.css("text-decoration", input.css("text-decoration").includes("underline") ? "none" : "underline");
    });

    $('.main').on("click", ".fa-text-slash", function () {
        let input = $(this).closest('.input-container').find('.inputs');
        input.css("text-decoration", input.css("text-decoration").includes("line-through") ? "none" : "line-through");
    });

    $('.main').on("click", ".fa-circle-xmark", function () {
        $(this).closest(".optionBox").remove();
    });

    $(document).on("change", ".option-box", function () {

        let value = $(this).val();
        let questionBox = $(this).closest(".question-box");

        let ansBox = questionBox.find(".ans-box");
        let addOption = questionBox.find(".lastOption");


        questionBox.find(".dynamic-input").remove();

        if (value === "short") {
            ansBox.hide();
            addOption.hide();

            questionBox.append(`
            <input type="text" class="dynamic-input" placeholder="Short answer text" disabled>
        `);
        }

        else if (value === "paragraph") {
            ansBox.hide();
            addOption.hide();

            questionBox.append(`
            <textarea class="dynamic-input" placeholder="Paragraph text" disabled></textarea>
        `);
        }
        else if (value === "date") {
            ansBox.hide();
            addOption.hide();

            questionBox.append(`
            <input class="dynamic-input" type="date" disabled>
        `);
        }
        else if (value === "mcq") {
            ansBox.show()
            ansBox.empty();
            addOption.show();

            ansBox.append(`
            <div class="optionBox">
                <i class="fa-solid fa-grip"></i>
                   <input type="radio" style="width: 25px;" disabled> <input type="text" class="option-input-box">
                <i class="fa-regular fa-circle-xmark"></i>
            </div>
        `);
        }

        else if (value === "checkbox") {
            ansBox.show()
            ansBox.empty();
            addOption.show();

            ansBox.append(`
            <div class="optionBox">
                <i class="fa-solid fa-grip"></i>
                   <input type="checkbox" style="width: 25px;" disabled> <input type="text" class="option-input-box">
                <i class="fa-regular fa-circle-xmark"></i>
            </div>
        `);
        }

        else if (value === "dropdown") {
            ansBox.show();
            addOption.show();

            ansBox.empty();


            ansBox.append(`
        <div class="optionBox">
            <i class="fa-solid fa-grip"></i>
            <input type="text" class="option-input-box" placeholder="Option 1">
            <i class="fa-regular fa-circle-xmark"></i>
        </div>
    `);
        }
    });


    $(".main").on("click", ".add-question", function () {
        let newQ = $(question_html);
        $(".sort").append(newQ);


        newQ.find(".option-box").trigger("change");
    });




    $(document).on("click", ".add-text", function () {
        var heading_box = `
                <div class="container text-box" ">
            <div>
                <i class="fa-solid fa-grip"></i>
            </div>

            <div class="input-container">
                <input type="text" class="inputs text-container" value="Untitled form">
                <div class="input-edit-tile" style="display:none;">
                    <hr>
                    <div class="heading-options ">
                        <i class="fa-solid fa-bold" title=""></i>
                        <i class="fa-solid fa-italic" title=""></i>
                        <i class="fa-solid fa-underline" title=""></i>
                        <i class="fa-solid fa-text-slash" title=""></i>
                    </div>
                </div>
            </div>

            <div class="input-container">
                <input type="text" class="inputs" value="Untitled form">
                <div class="input-edit-tile " style="display:none;">
                    <hr>
                    <div class="heading-options">
                        <i class="fa-solid fa-bold" title=""></i>
                        <i class="fa-solid fa-italic" title=""></i>
                        <i class="fa-solid fa-underline" title=""></i>
                        <i class="fa-solid fa-text-slash" title=""></i>
                    </div>
                </div>
            </div>

            <div class="option-footer">
                <i class="fa-regular fa-copy"></i>
                <i class="fa-solid fa-trash-can delete"></i>

            </div>



        </div>`;
        $(".sort").append(heading_box)
    });



    $(document).on("change", ".img-input", function () {
        const file = this.files[0];

        if (file) {
            const reader = new FileReader();

            reader.onload = function (e) {
                $(this).closest(".question-first-container").next("img").attr('src', e.target.result).show();
            };

            reader.readAsDataURL(file);
        }
    });

    $('.main').on("click", ".fa-copy", function () {
        let newOption = $(this).closest(".container").clone();

        $(".sort").append(newOption);
    });

    // to apear the form page 
    $(document).on("click", ".genPage", function () {

        let formHtml = `
        <div class="container heading-box">
    
        
        <h2 class="dynamic-headers" >${$(".heading-box").find(".inputs").eq(0).val()}</h2>
    <h3 class="dynamic-headers" >${$(".heading-box").find(".inputs").eq(1).val()}</h3>
        </div>
    <form>
    `;

        // (questions + headings)
        $(".sort").children(".container").each(function (index) {


            if ($(this).hasClass("text-box")) {
                let title = $(this).find(".inputs").eq(0).val();
                let desc = $(this).find(".inputs").eq(1).val();

                // console.log(title,desc)
                formHtml += `<div class="container">`
                formHtml += `<h2 >${title}</h2>`;
                formHtml += `<p >${desc}</p>`;
                formHtml += `</div>`;

            }


            if ($(this).hasClass("question-box")) {

                let question = $(this).find(".question-input input").val();
                let type = $(this).find(".option-box").val();
                // console.log(question,type)

                formHtml += `<div class="container question-box">`;
                formHtml += `<label>${question}</label><br>`;


                if (type === "short") {
                    formHtml += `<input type="text" class="dynamic-in"><br>`;
                }


                else if (type === "paragraph") {
                    formHtml += `<textarea></textarea><br>`;
                }


                else if (type === "date") {
                    formHtml += `<input type="date"><br>`;
                }


                else if (type === "mcq") {
                    $(this).find(".option-input-box").each(function () {
                        // formHtml += ` <div class="optionBox dynamic-optionBox" >`
                        let val = $(this).val().trim();
                        if (val === "") formHtml += `<span> no option given </ span>`
                        else formHtml += `  <input type="radio" class="dynamic-checkbox" name="${index}"> ${val}<br>    `;
                    });
                }


                else if (type === "checkbox") {
                    $(this).find(".option-input-box").each(function () {
                        let val = $(this).val().trim();
                        if (val === "") formHtml += `<input type=" checkbox"> no-value given<br>`
                        formHtml += `<input type="checkbox" class="dynamic-checkbox">  ${val}<br>`;
                    });
                }


                else if (type === "dropdown") {
                    formHtml += `<select>`;

                    let hasOption = false;

                    $(this).find(".option-input-box").each(function () {
                        let val = $(this).val().trim();
                        formHtml += `<option>${val}</option> `
                        hasOption = true;
                    });

                    if (!hasOption) {
                        formHtml += `<option>No options</option>`;
                    }

                    formHtml += `</select><br>`;
                }

                formHtml += `</div>`;
            }

        });

        formHtml += `
        <button type="submit">Submit</button>
    </form>
    </div>
    `;

        $("#result").empty()
        $("#result").append(formHtml)

    });

});