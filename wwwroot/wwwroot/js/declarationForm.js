$(function () {
    $('[data-hide="True"]').hide();

    $('.jsAnswerItem').change(function () {
        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();
        //var min = $(this).data("min");
        //var max = $(this).data("max");
        
        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    $('[data-ViewIfParentCorrectId="' + id + '"]').show();
                    $('[data-ViewIfParentFailedId="' + id + '"]').hide();
                } else {
                    $('[data-ViewIfParentCorrectId="' + id + '"]').hide();
                    $('[data-ViewIfParentFailedId="' + id + '"]').show();
                }
            });
        }
    });
});