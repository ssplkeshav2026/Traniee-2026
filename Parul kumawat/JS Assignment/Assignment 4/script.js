$(document).ready(function () {

    $(".title, .description").click(function () {

        $(".title-line, .header-icons").show();

        $(this).after($(".title-line"));
        $(".title-line").after($(".header-icons"));

    });


    $(document).on("focus", ".option", function () {
        $(this).closest(".options").next(".option-line").show();
    });

    $(document).on("focus", ".title, .description, .question, .section-title, .option", function () {
        inputText = $(this);
    });
    $(".boldText").click(function () {
        if (inputText) {
            inputText.css("font-weight", "bold");
        }

    });
    $(".italicText").click(function () {
        if (inputText) {
            inputText.css("font-style", "italic");
        }

    });
    $(".underlineText").click(function () {
        if (inputText) {
            inputText.css("text-decoration", "underline");
        }
    })

    $(".formatText").click(function () {
        if (inputText) {
            inputText.css("text-decoration", "none");
            inputText.css("font-style", "normal");
            inputText.css("font-weight", "normal");
        }
    })

    $(document).on("focus", ".question, .option, .section-title, .sectionDesc", function () {

        $(".textIcons, .textIcons2").hide();

        $(this)
            .closest(".question-box, .title-box")
            .find(".textIcons, .textIcons2")
            .show();
    });

    $(document).on("click", ".imgIcon", function () {
        $(this).next(".img").click();
    });


    $(document).on("change", ".img", function (e) {

        const file = e.target.files[0];
        if (!file){
            return;
        } 

        let reader = new FileReader();

        let questionBox = $(this).closest(".question-box");

        reader.onload = function (i) {

            let inputImg = `
            <img src="${i.target.result}" style="max-width:400px; height:auto;">
        `;

            questionBox
                .find(".viewImg")
                .empty()
                .append(inputImg);
        };

        reader.readAsDataURL(file);
    });


    $(document).on("click", ".optionImgIcon", function () {
        $(this).next(".option-img").click();
    });
    $(document).on("change", ".option-img", function (e) {

        const file = e.target.files[0];
        if (!file) return;

        let reader = new FileReader();

        let optionBox = $(this).closest(".options");

        reader.onload = (e) => {

            let inputImg = `
            <img src="${e.target.result}" style="max-width:160px; height:100px;">
        `;

            optionBox
                .find(".view-img")
                .empty()
                .append(inputImg);
        };

        reader.readAsDataURL(file);
    });


    $(document).on("click", ".add-option", function () {

        let box = $(this).closest(".question-box");
        let selected = box.find(".drop-down-icons option:selected").attr("class");
        let inputType = (selected == "check") ? "checkbox" : "radio";
        let inputClass = (selected == "check") ? "checkBtn" : "radioBtn";
        let countOptions = box.find(".options").length + 1;
        let appendNewOptions = `<div class="options">

                        <input type="${inputType}" class="${inputClass}" disabled>
                        <input type="text" placeholder="Option ${countOptions}" class="option">

                        <i class="fa-regular fa-image img-icon optionImgIcon" title="Add Image"></i>
                        <input type="file" class="option-img" hidden>

                        <span class="cross" style="cursor:pointer; margin-left:10px;"><i class="fa-regular fa-circle-xmark" style="border-radius:50%; padding:5px;"  title="Remove"></i></span>
                        <div class="view-img"></div>


                    </div>
                    <hr class="option-line">`;
        box.find(".add").before(appendNewOptions);
        if (selected == "drop-down") {
            box.find(".options input:first-child, .add input:first-child").hide();
            box.find(".options").each(function (i) {

                if ($(this).find(".optionNum").length === 0) {
                    $(this).prepend(`<span class="optionNum"></span>`);
                }

                $(this).find(".optionNum").show().text((i + 1) + ".");
            });

            let addDiv = box.find(".add");

            if (addDiv.find(".optionNum").length === 0) {
                addDiv.prepend(`<span class="optionNum"></span>`);
            }
            let count = box.find(".options").length + 1;
            box.find(".add .optionNum").text(count + ".");

        }

    })


    $(document).on("click", ".cross", function () {
        $(this).closest(".options").remove();
    })


    $(document).on("click", ".deleteQue", function () {
        $(this).closest(".question-box").first().remove()
    })


    $(document).on("click", ".copy", function () {
        let currentQue = $(this).closest(".question-box");

        let duplicate = currentQue.clone(true);

        duplicate.find(".textIcons").hide();
        duplicate.find(".textIcons2").hide();
        duplicate.find(".viewImg").empty();
        duplicate.find(".view-img").empty();
        duplicate.find(".optionNum").remove();
        duplicate.find("input[type='file']").val("");
        duplicate.find("input[type='text']").val("");

        currentQue.after(duplicate);
    });

    $(document).on("click", ".addQue", function () {
        let lastQue = $("#questions .question-box:last");
        let duplicate = lastQue.clone(true)
        duplicate.find(".textIcons").hide();
        duplicate.find(".textIcons2").hide();
        duplicate.find(".viewImg").empty();
        duplicate.find(".view-img").empty();
        duplicate.find(".optionNum").remove();
        duplicate.find("input[type='file']").val("");
        duplicate.find("input[type='text']").val("");
        $("#questions").append(duplicate);
    })


    $(document).on("focus", ".section-title", function () {
        let box = $(this).closest(".title-box");

        $(".textIcons2").removeClass("active");
        $(".titleLine").removeClass("active");


        box.find(".textIcons2").addClass("active");
    });
    $(document).on("focus", ".sectionDesc", function () {
        let box = $(this).closest(".title-box");

        $(".textIcons2").removeClass("active");
        $(".titleLine").removeClass("active");


        box.find(".titleLine").after(box.find(".textIcons2"));



        box.find(".textIcons2").addClass("active");
    });

    $(document).on("click", ".title-box .copy", function () {
        let currentQue = $(this).closest(".title-box")
        let duplicate = currentQue.clone(true)
        currentQue.after(duplicate);
    })

    $(document).on("click", ".title-box .deleteQue", function () {
        let all = $(".title-box");
        if (all.length > 1) {
            $(this).closest(".title-box").remove();
        } else {
            alert("At least one title required");
        }
    })

    $(document).on("click", ".addTitle", function () {
        let lastQue = $(".title-box:last");
        let duplicate = lastQue.clone(true)
        $("#questions").append(duplicate);
    })

    $(document).on("change", ".drop-down-icons", function () {
        let selected = $(this).find("option:selected").attr("class");
        let box = $(this).closest(".question-box")

        box.find(".optionNum").remove();
        box.find(".options").show();
        box.find(".add").show();

        box.find(".shortAns-input, .paraAns-input, .date-input").hide();

        box.find(".options input:first-child, .add input:first-child")
            .attr("type", "radio")
            .removeClass("checkBtn")
            .addClass("radioBtn")
            .show();

        box.find(".optionImgIcon, .cross").show();

        if (selected == "short-ans" || selected == "para") {
            box.find(".options").hide();
            box.find(".option-line").hide();
            box.find(".add").hide();
            box.find(".radioBtn").hide();
            box.find(".optionImgIcon").hide();
            box.find(".cross").hide();
        }

        if (selected == "short-ans") {
            box.find(".date-input").hide();
            box.find(".paraAns-input").hide();
            if (box.find(".shortAns-input").length === 0) {

                box.find(".que-options").append(
                    `<input type="text" placeholder="Short answer" class="shortAns-input" disabled>`
                );
            } else {
                box.find(".shortAns-input").show();
            }


        }
        else if (selected == "para") {
            box.find(".shortAns-input").hide();
            box.find(".date-input").hide();
            if (box.find(".paraAns-input").length === 0) {
                box.find(".que-options").append(
                    `<input type="text" placeholder="Long-answer text" class="paraAns-input"disabled>`
                );
            } else {
                box.find(".paraAns-input").show();
            }

        }
        else if (selected == "date") {
            box.find(".options").hide();
            box.find(".add").hide();
            box.find(".shortAns-input").hide();
            box.find(".paraAns-input").hide();
            box.find(".options input[type='radio'],.options input[type='checkbox']").hide();
            box.find(".add input[type='radio'], .add input[type='checkbox']").hide();
            if (box.find(".date-input").length === 0) {
                box.find(".que-options").append(
                    `<input type="date" placeholder="Day,month,year" class="date-input"disabled>`
                );
            } else {
                box.find(".date-input").show();
            }


        }


        else if (selected == "drop-down") {
            box.find(".options input:first-child, .add input:first-child").hide()
            box.find(".options").each(function (i) {
                if ($(this).find(".optionNum").length === 0) {
                    $(this).prepend(`<span class="optionNum"></span>`)
                }
                $(this).find(".optionNum").show().text((i + 1) + ".")

            })

            let addDivOpt = box.find(".add")
            if (addDivOpt.find(".optionNum").length === 0) {
                addDivOpt.prepend(`<span class="optionNum"></span>`)

            }
            let count = box.find(".options").length + 1;
            addDivOpt.find(".optionNum").show().text(count + ".");
        }

        else {
            box.find(".options").show();
            box.find(".add").show();
            box.find(".radioBtn").show();
            box.find(".optionImgIcon").show();
            box.find(".cross").show();

            box.find(".shortAns-input").hide();
            box.find(".paraAns-input").hide();
            box.find(".date-input").hide();

            if (selected == "check") {

                box.find(".options input:first-child, .add input:first-child").each(function () {
                    $(this).attr("type", "checkbox")
                        .removeClass("radioBtn")
                        .addClass("checkBtn")
                        .show();
                });

            } else if (selected == "Multiple-choice") {

                box.find(".options input:first-child, .add input:first-child").each(function () {
                    $(this).attr("type", "radio")
                        .removeClass("checkBtn")
                        .addClass("radioBtn")
                        .show();
                });
            }


        }
    });

    $(document).on("click", "#generateHtmlForm", function () {
        // alert("hi")
     let htmlForm = `<div class="container">`;

     let head = $(".title").val();
    let desc = $(".description").val();

    htmlForm += `
        <div class="form-header">
            <h2>${head}</h2>
            <p>${desc}</p>
        </div>
    `;
        $(".question-box").each(function (index) {

            let queText = $(this).find(".question").val();
             let selected = $(this).find(".drop-down-icons option:selected").attr("class");

            htmlForm += `<div class="question-box">`;
            htmlForm += `<p class="question"><b>${queText}</b></p>`;

            if (selected == "short-ans") {
            htmlForm += `<input type="text" class="shortAns">`;

        } else if (selected == "para") {
            htmlForm += `<textarea class = "paraAns"></textarea>`;
        }
        else if (selected == "date") {
            htmlForm += `<input type="date" class="date-input">`;
        }
        else {

            let inputType = "radio";

            if (selected == "check"){
                inputType = "checkbox";
            } 

            if (selected == "drop-down") {
                htmlForm += `<select class="drop-down-icons">`;
            }
        
            $(this).find(".options").each(function () {

                let option = $(this).find(".option").val();
                if (!option){
                    return;
                } 

                if (selected == "drop-down") {
                    htmlForm += `<option>${option}</option>`;
                } 
                else {
                    htmlForm += `
                        <div class="options">
                        <input type="${inputType}" name="que${index}">
                         <span class="option">${option}</span>
                        </div>
                    `;
                }
            });
             if (selected == "drop-down") {
                htmlForm += `</select>`;
            }
        }
              htmlForm += `</div>`;


              
        });

        $(".title-box").each(function(){
        let tHead = $(this).find(".section-title").val();
        let tDesc = $(this).find(".sectionDesc").val();
            
        htmlForm +=`
                 <div class="title-box">
            <h3 class="section-title">${tHead}</h3>
            <p class="sectionDesc">${tDesc}</p>
        </div>`;
            })
        
       
        
         htmlForm += `</div>`;
        
         $("#generatedForm").empty()
        $("#generatedForm").append(htmlForm);
    })
   
});
