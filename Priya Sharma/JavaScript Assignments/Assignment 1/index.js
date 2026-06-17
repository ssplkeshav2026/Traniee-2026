function myfunction(element) {

    var isVisisble = element.nextElementSibling.style.display === 'block';

    var answers = document.getElementsByClassName('answer');

    for (let i = 0; i < answers.length; i++) {
        var answer = answers[i];
        answer.style.display = "none";

        var icon = answer.previousElementSibling.getElementsByClassName("icon")[0].getElementsByTagName('i')[0];
        icon.classList.remove("rotate");
    }

    var answwer = element.nextElementSibling;

    if (!isVisisble) {
        console.log(answer.style.display);
        answwer.style.display = "block";

        var icon = element.getElementsByClassName("icon")[0].getElementsByTagName('i')[0];
        icon.classList.add("rotate");
    }
    else {
        answwer.style.display = "none";
        var icon = element.getElementsByClassName("icon")[0].getElementsByTagName('i')[0];
        icon.classList.remove("rotate");
    }
}