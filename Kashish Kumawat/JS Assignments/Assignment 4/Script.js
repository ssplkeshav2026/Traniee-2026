function showToolbar(el){
  const tb = el.parentNode.querySelector('.toolbar');
  if(tb) tb.style.display='block';
}
function previewImage(e,input){
  let file=e.target.files[0];
  if(!file) return;

  let reader=new FileReader();

  reader.onload=function(ev){
    let card = input.closest('.card');

    let preview = card.querySelector('.preview');
    preview.innerHTML=`<img src="${ev.target.result}">`;

    card.setAttribute('data-image', ev.target.result);
  };

  reader.readAsDataURL(file);
}
function addOption(el){
  let parent = el.closest ? el.closest('.card') : el;
  let opt = parent.querySelector('.options');

  let normalOptions = Array.from(opt.children).filter(o=>!o.classList.contains('other'));
  if(normalOptions.length>=3) return;

  let d=document.createElement('div');
  d.className='option';
  let count=normalOptions.length+1;
  d.innerHTML=`<input type="radio" name="choice"><input type="text" value="Option ${count}"><i class="material-icons" onclick="this.parentNode.remove()">close</i>`;

  let other=opt.querySelector('.other');
  if(other){ opt.insertBefore(d, other); }
  else{ opt.appendChild(d); }
}
function changeType(select){
  let card = select.closest('.card');
  let options = card.querySelector('.options');
  let addBtn = card.querySelector('span[onclick="addOption(this)"]');

  options.innerHTML = '';

  let type = select.value;

  if(   type === 'Short answer' ||  type === 'Paragraph' ||  type === 'Date' ||  type === 'Time' ||  type === 'Dropdown'   ){
  if(addBtn) addBtn.innerHTML = ''; 

  if(type === 'Short answer'){
    options.innerHTML=`<input class="input" placeholder="Short answer text">`;
  }
  else if(type === 'Paragraph'){
    options.innerHTML=`<textarea class="input" placeholder="Long answer text"></textarea>`;
  }
  else if(type === 'Date'){
    options.innerHTML=`<input type="date" class="input">`;
  }
  else if(type === 'Time'){
    options.innerHTML=`<input type="time" class="input">`;
  }
  else if(type === 'Dropdown'){
    options.innerHTML=`
      <input type="text" placeholder="Option 1" style="border:none;"><br><br>
      <input type="text" placeholder="Option 2" style="border:none;"><br><br>
      <input type="text" placeholder="Option 3" style="border:none;"><br>
    `;
  }
  return;
}
  if(addBtn) addBtn.innerHTML = 'Add option';

  if(type === 'Multiple choice'){
    addOption(card);
    ensureOther(options);
  }
  else if(type === 'Checkboxes'){
    let d=document.createElement('div');
    d.className='option';
    d.innerHTML=`<input type="checkbox"><input type="text" value="Option">`;
    options.appendChild(d);
  }
  else if(type === 'Dropdown'){
    let d=document.createElement('div');
    d.className='option';
    d.innerHTML=`<select><option>Option 1</option></select>`;
    options.appendChild(d);
  }
}
function duplicate(el){
  let clone=el.closest('.card').cloneNode(true);
  document.getElementById('questions').appendChild(clone);
}
function removeQ(el){ 
  el.closest('.card').remove();
 }
function addTitleDesc(){
  let div = document.createElement('div');
  div.className = 'card';

  div.innerHTML = `
    <div class="input" contenteditable="true" onfocus="showToolbar(this)">
      Title
    </div>

    <div class="toolbar">
      <i class="material-icons" onclick="format('bold')">format_bold</i>
      <i class="material-icons" onclick="format('italic')">format_italic</i>
      <i class="material-icons" onclick="format('underline')">format_underlined</i>
    </div>

    <input class="input" placeholder="Description">
  `;

  document.getElementById('questions').prepend(div);
}
function addQuestion(){
  let q=document.createElement('div');
  q.className='card';
  q.innerHTML=`
  <div class="row">
    <div style="flex:1">
        <div class="input" contenteditable="true" onfocus="showToolbar(this)">  Untitled Question </div>
            <div class="toolbar" >
                <i class="material-icons" onclick="format('bold')">format_bold</i>
                <i class="material-icons" onclick="format('italic')">format_italic</i>
                <i class="material-icons" onclick="format('underline')">format_underlined</i>
            </div>
    </div>
    <div style="display:flex;align-items:center;gap:10px">
        <i class="material-icons img-left" onclick="triggerFile(this)">image</i>
        <input type="file" accept="image/*" style="display:none" onchange="previewImage(event,this)">
        <select onchange="changeType(this)" style="border:none;border-bottom:1px solid #ccc;padding:4px 8px;font-size:14px;background:transparent">
            <option>Multiple choice</option>
            <option>Checkboxes</option>
            <option>Dropdown</option>
            <option>Short answer</option>
            <option>Paragraph</option>
            <option>Date</option>
            <option>Time</option>
        </select>
    </div>
  </div>
  <div class="preview"></div>
  <div class="options"></div>
  <div style="margin-top:10px;font-size:14px">
        <span onclick="addOption(this)" style="cursor:pointer;color:#5f6368">Add option</span>
  </div>
  <div style="margin-top:10px;display:flex;justify-content:flex-end;align-items:center;gap:15px">
  <div class="req-btn">
        <span>Required</span>
        <label class="switch">
            <input type="checkbox">
            <span class="slider"></span>
        </label>
  </div>
  <i class="material-icons" onclick="duplicate(this)">content_copy</i>
  <i class="material-icons" onclick="removeQ(this)">delete</i>
  </div>`;
  document.getElementById('questions').appendChild(q);

  addOption(q);
  changeType(q.querySelector('select'));
}
addQuestion();
function submitForm() {
  let title = document.querySelector('.card [contenteditable]')?.innerText || '';
  let desc = document.querySelector('.card input')?.value || '';

  let answers = [];

  document.querySelectorAll('#questions .card').forEach(card => {

    let question = card.querySelector('[contenteditable]')?.innerText || '';
    let answer = '';
    let optionsHTML = '';

    let radios = card.querySelectorAll('input[type="radio"]');
    let checks = card.querySelectorAll('input[type="checkbox"]');

    if (radios.length > 0) {
      radios.forEach(radio => {
        let optionDiv = radio.closest('.option');
        let textInput = optionDiv.querySelector('input[type="text"]');
        let optionText = textInput ? textInput.value : '';

        if (radio.checked) {
          answer = optionText;
          optionsHTML += `<div style="color:#673ab7;font-weight:bold;">${optionText}</div>`;
        } else {
          optionsHTML += `<div style="color:black;">${optionText}</div>`;
        }
      });
    }

    else if (checks.length > 0) {
      checks.forEach(check => {
        let optionDiv = check.closest('.option');
        let textInput = optionDiv.querySelector('input[type="text"]');
        let optionText = textInput ? textInput.value : '';

        if (check.checked) {
          answer += optionText + ', ';
          optionsHTML += `<div style="color:#673ab7;font-weight:bold;">${optionText}</div>`;
        } else {
          optionsHTML += `<div style="color:black;">${optionText}</div>`;
        }
      });

      answer = answer.replace(/, $/, '');
    }

    else {
      let input = card.querySelector('.options input, .options textarea, .options select');
      if (input) answer = input.value;
    }

    if (question.trim() !== '') {
      answers.push({ question, answer, optionsHTML });
    }
  });

  let oldBox = document.getElementById('responseBox');
  if (oldBox) oldBox.remove();

  let box = document.createElement('div');
  box.id = 'responseBox';

  box.style.cssText = `
    background:#673ab7;
    color:white;
    padding:20px;
    border-radius:12px;
    margin:20px auto;
    width:80%;
    box-shadow:0 4px 10px rgba(0,0,0,0.2);
  `;

  box.innerHTML = `
    <h2 style="margin:0 0 10px 0">${title}</h2>
    <p style="margin:0 0 20px 0">${desc}</p>
  `;

  answers.forEach(item => {
    box.innerHTML += `
      <div style="
        background:white;
        color:black;
        padding:12px;
        border-radius:8px;
        margin-bottom:10px;
      ">
        <b>${item.question}</b><br><br>
        ${item.optionsHTML || item.answer || 'No answer'}
      </div>
    `;
  });

  document.querySelector('.container').appendChild(box);
}