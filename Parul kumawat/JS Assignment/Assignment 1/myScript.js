// const a = document.querySelectorAll(".faq-body");

// for (let i = 0; i < a.length; i++) {
//     a[i].addEventListener("click", function () {

//         const content = this.querySelector('.faq-ans');
//         const icon = this.querySelector(".faq-icon i");
//         const open = content.style.display === "block"; 

//         for (let j = 0; j < a.length; j++) {
//             a[j].querySelector('.faq-ans').style.display = "none";
//             a[j].querySelector(".faq-icon i").style.transform = "rotate(0deg)";
//         }

//         if(!open){
//              content.style.display = "block";
//         icon.style.transform = "rotate(90deg)";
//         }

//     });
// }

$(document).ready(function () {
    $('.faq-body').click(function () {
        $(this).children(('.faq-ans')).slideToggle()
        $(this).children(('.faq-icon')).toggleClass('rotate-icon')
        $('.faq-ans').not($(this).children('.faq-ans')).hide()
        $('.faq-icon').not($(this).children('.faq-icon')).removeClass('rotate-icon')

    });
})
