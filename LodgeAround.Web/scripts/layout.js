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