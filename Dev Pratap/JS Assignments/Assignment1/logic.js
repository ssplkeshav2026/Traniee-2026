
$(document).ready(function () {
    $(".questions").click(function () {
        $(this).next().slideToggle();
        $(this).children(".icon").toggleClass("rotated")
        $(".answers").not($(this).next()).hide();
        $(".icon").not($(this).children()).removeClass("rotated");
    });
});