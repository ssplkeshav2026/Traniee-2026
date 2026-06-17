function myfunction(element) {
  let allAnswers = document.getElementsByClassName("answer");
  let currentAnswer = element.nextElementSibling;


  let isOpen = currentAnswer.style.display === "block";

 
  for (let i = 0; i < allAnswers.length; i++) {
    allAnswers[i].style.display = "none";
    let question = allAnswers[i].previousElementSibling;
    let icon = question.getElementsByClassName("icon")[0];
    icon.classList.remove("rotate");
  }
 
 
  if (!isOpen) {
    currentAnswer.style.display = "block";
    let icon = element.getElementsByClassName("icon")[0];
    icon.classList.add("rotate");
  }
}