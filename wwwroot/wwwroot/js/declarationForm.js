$(function () {
    $('[data-hide="True"]').hide();

    $('.jsAnswerItem').change(function () {
        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();
        
        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    $('[data-ViewIfParentCorrectId="' + id + '"]').slideDown("fast");
                    $('[data-ViewIfParentFailedId="' + id + '"]').slideUp("fast");
                } else {
                    $('[data-ViewIfParentCorrectId="' + id + '"]').slideUp("fast");
                    $('[data-ViewIfParentFailedId="' + id + '"]').slideDown("fast");
                }
            });
        }
    });

    $('.jsAnswerItem').each(function () {
        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();

        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    $('[data-ViewIfParentCorrectId="' + id + '"]').slideDown("fast");
                    $('[data-ViewIfParentFailedId="' + id + '"]').slideUp("fast");
                } else {
                    $('[data-ViewIfParentCorrectId="' + id + '"]').slideUp("fast");
                    $('[data-ViewIfParentFailedId="' + id + '"]').slideDown("fast");
                }
            });
        }
    });

    $(".jsButtonRemoveImage").click(function (e) {
        e.preventDefault();
        var id = $(this).data("id");

        $("#answer_image_" + id).val("");
        $("#old_" + id).hide();
    });
});