$(document).ready(function(){
    $(".question").click(function () {
        const answer = $(this).next('.answer');
        const icon = $(this).find('.icons');
        console.log("Answer: " + answer);
        console.log("Icon: " +icon);
       

  

    if (answer.is(":visible")){
        answer.slideUp(400);
        icon.removeClass('rotate')
    }
    else{
        $(".answer").slideUp(400); 
            $(".icons").removeClass('rotate'); 
            
            answer.slideDown(400); 
            icon.addClass('rotate');

    }



});
})