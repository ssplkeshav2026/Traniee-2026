  $(document).ready(function () {
        $('h5').click(function () {
          const currAnswer = $(this).find('.answer')
          const currIcon = $(this).find('.icons')
          $('.answer').not(currAnswer).slideUp(500);
          $('.icons').not(currIcon).removeClass('rotate');
          
          currAnswer.slideToggle(500);
          currIcon.toggleClass('rotate');

        });
       
      });   