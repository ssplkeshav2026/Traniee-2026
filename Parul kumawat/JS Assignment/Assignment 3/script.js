const step1 = document.querySelector(".form-info");
const step2 = document.querySelector(".form-info-2");
const step3 = document.querySelector(".form-info-3");
const step4 = document.querySelector(".form-info-4");
const nextBtns = document.querySelectorAll(".next");
const prevBtns = document.querySelectorAll(".prev");


const step = document.querySelectorAll(".step");
const userinputs = document.querySelectorAll("input, select");
const form = document.querySelector("form");

const msg = document.querySelector("#msg")





const arr = [step1, step2, step3, step4];
let current = 0;

function showSteps(i){
    arr.forEach((item, index) =>{
        if(index === i){
            item.style.display="block"
        }else{
            item.style.display="none"
        }
    });
    step.forEach((step, index) => {
        if(index <= i){
            step.classList.add("active")
           
        } else {
            step.classList.remove("active");
        }
        
    });
}


showSteps(current)


nextBtns.forEach(btn => {
    btn.addEventListener("click",()=>{
        if(current < arr.length-1){
            current++;
            showSteps(current)
        }
    })
})


prevBtns.forEach(btn => {
    btn.addEventListener("click",()=>{
        if(current > 0){
            current--;
            showSteps(current)
        }
    })
})


userinputs.forEach(input => {
    input.addEventListener("input",()=>{
        localStorage.setItem(input.id, input.value)
    })
})

form.addEventListener("submit",(i) => {
 i.preventDefault();

     const obj = {};
    userinputs.forEach(input => {
       obj[input.id] = input.value;
    });

      let ls = JSON.parse(localStorage.getItem("form-data")) || [];
        ls.push(obj);
          localStorage.setItem("form-data", JSON.stringify(ls));
        

    msg.style.display = "block";
     form.reset();
     userinputs.forEach(input => {
    localStorage.removeItem(input.id);
});
})

