
$(document).ready(function () {
    $('.clickableArea').click(function () {

        if ($(this).find("a").attr("href").length > 1) {

            if ($(this).find("a").attr("target")) {
                window.open($(this).find("a").attr("href"), $(this).find("a").attr("target"))
            } else {
                window.location = $(this).find("a").attr("href");
            }
        }

        return false;
    });

    $(".clickableArea a").focusin(function () {
        $(this).parents(".clickableArea").addClass("highlightTabbing");

    }).focusout(function () {
        $(this).parents(".clickableArea").removeClass("highlightTabbing");
    })

});