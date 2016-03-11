function showHowItWorks()
{
    $('#how_it_works').height($(window).height());
   // $('#background').css("top", $(window).height());

    $("#how_it_works").slideDown("slow");
}

function closeHowItWorks()
{
    $("#how_it_works").slideUp("slow");
}

function openReg(name)
{
    if ($('.' + name).is(":hidden")) {
        $('.regButton').addClass('open_reg_form');
        $('.' + name).slideDown("slow");
    }
    else
    {
        $('.regButton').removeClass('open_reg_form');
        $('.' + name).slideUp("slow");

    }
}