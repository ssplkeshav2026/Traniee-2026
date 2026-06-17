
$(".dupq").click(function () {

  const newblock = `
      <div class="question">
      <div class="question-title"><input class="ques" type="text" placeholder="Question"><span
          class="material-icons icon-btn" onclick="addImageInput(this)">image</span>

        <select onchange="changeType(this)">
          <option value="radio">Multiple Choice</option>
          <option value="checkbox">Checkbox</option>
          <option value="dropdown">Drop-down</option>
          <option value="Short answer">Short answer</option>
          <option value="Paragraph">Paragraph</option>
          <option value="Date">Date</option>
        </select>

      </div>
      <div class="options">
        <div class="option">
          <input type="radio" name="q1"> <input type="text" name="q1" class="fd">
          <span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>
          <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
        </div>
        <div class="option">
          <input type="radio" name="q1"> <input type="text" name="q1" class="fd">
          <span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>
          <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
        </div>
        <div class="option">
          <input type="radio" name="q1"> <input type="text" name="q1" class="fd">
          <span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>
          <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
        </div>
      </div>
      <div class="add-option">+ Add option</div>
      <div class="required"> <i class="fa-solid fa-toggle-off"></i></div>
      <i class="fa-solid fa-delete-left"></i><i class="fa-regular fa-clone clone-btn"></i>

    </div>
  <br><br><br>
  </div>
  `;

 $(newblock).insertBefore("#preview");
});

$("#fd").click(function(){
$(".toolbar1").slideToggle();
});
function addImageInput(el) {
  const parent = el.parentElement;

  if (parent.querySelector('.img-input')) {
    parent.querySelector('.img-input').click();
    return;
  }

  const input = document.createElement('input');
  input.type = 'file';
  input.accept = 'image/*';
  input.className = 'img-input';

  const img = document.createElement('img');
  img.style.maxWidth = '80px';
  img.style.marginTop = '10px';
  img.style.display = 'block';

  input.onchange = function () {
    const file = this.files[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = function (e) {
      img.src = e.target.result;
    };
    reader.readAsDataURL(file);
  };

  parent.appendChild(input);
  parent.appendChild(img);

  input.click();
}
function removeOption(el) {
  const option = el.parentElement;
  option.remove();
}
$(document).on("click", ".add-option", function () {

  const question = $(this).closest(".question");
  const type = question.find("select").val();

  addOption(question[0], type);  
});
$(document).on("click", ".remove-btn", function () {
  $(this).closest(".option").remove();
});
$("#addText").click(function () {

  const newBlock = `
    <div class="para1">
      <div contenteditable="true" class="desc title">
        Untitled Title
      </div>
      <div contenteditable="true" class="desc">
        Description optional
      </div>
      <i class="fa-solid fa-delete-left"></i>
    </div>
  `;

   $(newBlock).insertBefore("#preview");
});
 function changeType(select){
  let question = select.closest('.question');
  let options = question.querySelector('.options');
  let addBtn = question.querySelector('.add-option');

  options.innerHTML = '';
  let type = select.value;

  addBtn.style.display = "none";

  if(type === 'radio'){
    addOption(question, 'radio');
    addBtn.style.display = "block";  
  }

  else if(type === 'checkbox'){
    addOption(question, 'checkbox');
    addBtn.style.display = "block";   
  }

  else if(type === 'dropdown'){
    addOption(question, 'dropdown');   
    addBtn.style.display = "block";    
  }

  else if(type==='Short answer'){
    options.innerHTML=`<input class="input" placeholder="Short answer text">`;
  }

  else if(type==='Paragraph'){
    options.innerHTML=`<textarea class="input" placeholder="Long answer text" style="height:80px"></textarea>`;
  }

  else if(type==='Date'){
    options.innerHTML=`<input type="date" class="input">`;
  }
}
function addOption(question, type){
  let options = question.querySelector('.options');

  let d = document.createElement('div');
  d.className = 'option';

  if(type === 'dropdown'){
    d.innerHTML = `
      <input type="text" class="fd" placeholder="Option">
      <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
    `;
  } else {
    d.innerHTML = `
      <input type="${type}" name="q1">
      <input type="text" class="fd" placeholder="">
      <span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>
      <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
    `;
  }

  options.appendChild(d);
}
let toolbarOpen = false;
$(document).on("click", ".fa-delete-left", function () {
  $(this).closest(".question").remove();
});
$(document).on("click", ".fa-delete-left", function () {
  $(this).closest(".para1").remove();
});
$(".fa-regular").click(function () {

  const newblock = `
  <br><br><br>
     <div class="question">
      <div class="question-title"><input id="ques" type="text" placeholder="Question"><span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>

      <select onchange="changeType(this)">
  <option value="radio">Multiple Choice</option>
  <option value="checkbox">Checkbox</option>
  <option value="checkbox">Drop-down</option>
</select>  
    
    </div>
    <div class="options">
      <div class="option">
        <input type="radio" name="q1">   <input type="text" name="q1" class="fd">
          <span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>
            <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
      </div>
      <div class="option">
         <input type="radio" name="q1">   <input type="text" name="q1" class="fd">
          <span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>
            <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
      </div>
      <div class="option">
          <input type="radio" name="q1">   <input type="text" name="q1" class="fd">
           <span class="material-icons icon-btn" onclick="addImageInput(this)">image</span>
             <span class="material-icons remove-btn" onclick="removeOption(this)">close</span>
      </div>
     </div>
     <div class="add-option">+ Add option</div>
      requird<i class="fa-solid fa-toggle-off"></i>
      <i class="fa-solid fa-delete-left"></i>
      <i class="fa-regular fa-clone clone-btn"></i>
      </div>
    <br><br><br>

  
  </div>
  `;

  $(".container").append(newblock);
});
$(document).on("click", ".clone-btn", function () {
  const clone = $(this).closest(".question").clone();
  $(".container").append(clone);
});
$(document).on("click", ".clone-btn", function () {
  const clone = $(this).closest(".para1").clone();
  $(".container").append(clone);
});
$("#showForm").click(function () {

  let data = [];
   let formTitle = $("#uf").clone().find(".toolbar").remove().end().text();
let formDesc = $("#fd").clone().find(".toolbar1").remove().end().text();
let formTitle1 = $(".para1 .title").length 
  ? $(".para1 .title").text().trim() 
  : "Untitled Title";

let formDesc1 = $(".para1 .desc").not(".title").length 
  ? $(".para1 .desc").not(".title").text().trim() 
  : "Description optional";

if(formTitle === "Untitled form") formTitle = "";
if(formDesc === "Form description") formDesc= "";

if(formTitle1 === "Untitled Title") formTitle1 = "Untitled Title";
if(formDesc1 === "Description optional") formDesc1 = "Description optional";

  $(".question").each(function () {

    let qInput = $(this).find(".ques");

    let question = qInput.length ? qInput.val() : "";
     if (question === "") return;

  let type = $(this).find("select").val();

  let options = [];
  $(this).find(".fd").each(function () {
    let val = $(this).val().trim();
    if (val !== "") options.push(val); 
  });

    data.push({
      question: question,
      type: type,
      options: options
    });
  });
let output = "";
output += `<div style="margin-bottom:20px;">`;

output += `<h2>${formTitle}</h2>`;
output += `<p>${formDesc}</p>`;
output += `<h2>${formTitle1}</h2>`;
output += `<p>${formDesc1}</p>`;
output += `</div>`;
  data.forEach(function (item) {

    output += `<div style="margin-bottom:20px;">`;
    output += `<p><b>${item.question}</b></p>`;

    if (item.type === "radio" || item.type === "checkbox") {

      item.options.forEach(function (opt) {
        output += `
          <label>
            <input type="${item.type}">
            ${opt}
          </label><br>
        `;
      });

    }
    else if (item.type === "dropdown") {

      output += `<select>`;
      item.options.forEach(function (opt) {
        output += `<option>${opt}</option>`;
      });
      output += `</select>`;
    } 
    
    else if (item.type === "Short answer") {
      output += `<input type="text"><br>`;
    } 
    
    else if (item.type === "Paragraph") {
      output += `<textarea></textarea>`;
    } 
    
    else if (item.type === "Date") {
      output += `<input type="date">`;
    }

    output += `</div>`;
  });


  $("#preview").html(output).show();

});
$(document).on("click", "#preview input[type=radio]", function () {
  if ($(this).data("checked")) {
    $(this).prop("checked", false);
    $(this).data("checked", false);
  } else {
    $(this).data("checked", true);
  }
});