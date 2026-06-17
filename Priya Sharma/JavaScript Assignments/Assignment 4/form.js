

$(document).ready(function () {

  //Create new Question-Box
  function newQuestion() {
    return `
<div class="question-box">

  <div class="ques-header">
    <div class="header-left">
      <input type="text" placeholder="Question" class="question">
    </div>

    <div>
      <div style="display:flex; justify-content:space-between; margin-top:10px;">
        <i class="fa-regular fa-image upload-img"></i>
        <input type="file" class="img-input" hidden>

        <div class="Question-type">
          <select class="questionType">
            <option value="short">Short Answer</option>
            <option value="paragraph">Paragraph</option>
            <option value="mcq">Multiple Choice</option>
            <option value="checkbox">Checkboxes</option>
            <option value="dropdown">Dropdown</option>
            <option value="file">File Upload</option>
            <option value="date">Date</option>
          </select>
        </div>
      </div>

    </div>
  </div>

  <div class="image-preview"></div>

  <div class="options"></div>

  <input type="text" placeholder="Answer" class="answer">

  <div class="bottom">
    <div class="right-icons">
      <i class="fa-solid fa-copy duplicate"></i>
      <i class="fa-solid fa-trash delete"></i>
    </div>

    <div class="right">
      <label>Required</label>
      <input type="checkbox" class="toggle">
    </div>
  </div>

</div>
`;
  }
//Creates nwe Description-Box
  function newDescription() {
    return `
 <div class="Description">
            <div class="header">
                <div class="desc-head" >
                    <input type="text" placeholder="Untitled Title" style="border: none;">
                </div>

                <div class="desc-mid">
                    <i class="fa-solid fa-copy duplicate"></i>
                    <i class="fa-solid fa-trash delete"></i>
                </div>
            </div>
            <div class="desc-foot">
                <input type="text" placeholder="Description (optional)" style="border : none;">
            </div>
        </div>
`;
  }
 // add-option in radio type qusetions
  function addOption(box, type) {
    let inputType = type === "checkbox" ? "checkbox" : "radio";

    box.find(".options").append(`
    <div class="option">
      <input type="${inputType}">
      <input type="text" placeholder="Option">
    </div>
  `);

    if (box.find(".add-option").length === 0) {
      box.find(".options").append(`<button class="add-option">+ Add option</button>`);
    }
  }

  // change answer type according to drop-down
  function handleType(box, type) {
    let options = box.find(".options");
    let answer = box.find(".answer");

    options.empty();

    if (type === "mcq") {
      addOption(box, "radio");
      answer.hide();
    }
    else if (type === "checkbox") {
      addOption(box, "checkbox");
      answer.hide();
    }
    else if (type === "dropdown") {
      addOption(box, "radio");
      answer.hide();
    }
    else if (type === "short") {
      answer.replaceWith(`<input type="text" class="answer" placeholder="Short answer">`);
    }
    else if (type === "paragraph") {
      answer.replaceWith(`<textarea class="answer" placeholder="Long answer"></textarea>`);
    }
    else if (type === "file") {
      answer.replaceWith(`<input type="file" class="answer">`);
    }
    else if (type === "date") {
      answer.replaceWith(`<input type="date" class="answer">`);
    }
    else {
      box.find(".answer").replaceWith(`<input type="text" placeholder="Answer" class="answer">`);
      box.find(".answer").show();
    }
  }


//side bar add new question-box
  $(".fa-plus").click(function () {
    let q = $(newQuestion());
    $(".container").append(q);
    q.find("#question").focus();
  });


  $(document).on("click", ".duplicate", function () {
    let clone = $(this).closest(".question-box").clone();
    $(".container").append(clone);
  });


  $(document).on("click", ".delete", function () {
    $(this).closest(".question-box").remove();
  });

  //side bar add new title box
  $(".fa-t").click(function () {
    let a = $(newDescription());
    $(".container").append(a);
    a.find("#description").focus();
  });

  $(document).on("click", ".duplicate", function () {
    let clone = $(this).closest(".Description").clone();
    $(".container").append(clone);
  });

  $(document).on("click", ".delete", function () {
    $(this).closest(".Description").remove();
  });


  $(document).on("change", ".questionType", function () {
    let box = $(this).closest(".question-box");
    handleType(box, $(this).val());
  });


  $(document).on("click", ".add-option", function () {
    let box = $(this).closest(".question-box");
    let type = box.find(".questionType").val();
    addOption(box, type);
  });


  $(document).on("click", ".upload-img", function () {
    $(this).siblings(".img-input").click();
  });

  $(document).on("change", ".img-input", function (e) {
    let file = e.target.files[0];
    let reader = new FileReader();
    let preview = $(this).closest(".question-box").find(".image-preview");

    reader.onload = function (ev) {
      preview.html(`<img src="${ev.target.result}" style="max-width:100%; margin-top:10px;">`);
    }

    if (file) reader.readAsDataURL(file);
  });


  $(document).on("click", ".ques-header .icons i", function () {
    let input = $(this).closest(".question-box").find(".question");
    applyFormat($(this), input);
  });

// Preview button
  $("#preview-button").click(() => {

    var headingHtml = GetFormHeading();
    var questionHtml = GetQuestionPreview();
    var titleHtml = GetDescription();
    
    var previewContainer = $("#form-preview-container");
    

     if(headingHtml === "" && titleHtml === "" && questionHtml === ""){
        previewContainer.html("<p>No content to preview</p>");
    } else {
        previewContainer.html(headingHtml + titleHtml + questionHtml);
    }

  
  });

  // Heading Preview
  function GetFormHeading() {
    let formHeading = $("#formTitle").val().trim();
    let formDescription = $("#formDesc").val().trim();
     
    if(formHeading === "" && formDescription === ""){
        return "";
    }

    var html = `
      <div class = 'previewForm-header'>
      
      <div class="previewFormTitle">
      <span class="previewFormTitle-text">${formHeading}</span>
      </div>

      <div class="previewForm-desc">
      <span class="previewForm-desc-text">${formDescription}</span>
      </div>


      </div> `

    return html;

  };

  //Description Preview
  function GetDescription() {
    let formTitle = $("#desc-head").val()?.trim() || "";
    let titleDescription = $("#desc-foot").val()?.trim() || "";
     if(formTitle === "" && titleDescription === ""){
        return "";
    }

    var html = `
      <div class = 'previewdesc-header'>
      
      <div class="previewDesc-head">
      <span class="previewDesc-head-text">${formTitle}</span>
      </div>

      <div class="previewDesc-foot">
      <span class="previewDesc-foot-text">${titleDescription}</span>
      </div>


      </div> `

    return html;
  }
  
// Question Preview
    function GetQuestionPreview() {

      var html = "";

      $(".question-box:visible").each(function () {

        let question = $(this).find(".question").val();
        if(question.trim() === ""){
        return;
    }
        let questionType = $(this).find(".questionType").val();

        let imageHtml = $(this).find(".img-input").html();

        var answerHtml = "";

        if (questionType == "short") {
          answerHtml = `
                <div class="answer">
                    <input type="text" style="border:none;" placeholder="Your answer">
                </div>
            `;
        }

        else if (questionType == "paragraph") {
          answerHtml = `
                <div class="answer">
                    <textarea style="border:none;" placeholder="Your answer"></textarea>
                </div>
            `;
        }

        else if (questionType == "mcq") {

          answerHtml = `<div class="answer">`;

          $(this).find(".options input[type='text']").each(function () {
            let optionText = $(this).val();

            answerHtml += `
                    <div>
                        <input type="radio" name="question_${Date.now()}"> ${optionText}
                    </div>
                `;
          });

          answerHtml += `</div>`;
        }

        else if (questionType == "checkbox") {

          answerHtml = `<div class="answer">`;

          $(this).find(".options input[type='text']").each(function () {
            let optionText = $(this).val();

            answerHtml += `
                    <div>
                        <input type="checkbox"> ${optionText}
                    </div>
                `;
          });

          answerHtml += `</div>`;
        }

        else if (questionType == "dropdown") {

          answerHtml = `
                <div class="answer">
                    <select>
            `;

          $(this).find(".options .option input[type='text']").each(function () {
            let optionText = $(this).val();

            answerHtml += `
                    <option>${optionText}</option>
                `;
          });

          answerHtml += `
                    </select>
                </div>
            `;
        }

        else if (questionType == "file") {
          answerHtml = `
                <div class="answer">
                    <input type="file">
                </div>
            `;
        }

        else if (questionType == "date") {
          answerHtml = `
                <div class="answer">
                    <input type="date">
                </div>
            `;
        
        }


        html += `
        <div class="previewQuestion-box">

            <div class="previewQues-header">
                <div>
                    <input type="text" class="question" value="${question}" readonly>

                    <div class="previewImg">
                        ${imageHtml}
                    </div>

                    <div class="previewOption"></div>
                </div>
            </div>

            ${answerHtml}

        </div>
        `;
      });

      return html;
    }


  });



