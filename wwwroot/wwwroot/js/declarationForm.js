$(function () {
    console.log($('[data-ViewIfParentFailed="True"]').length);

    $('[data-ViewIfParentFailed="True"]').hide();

    $(".jsAnswerItem").change(function () {
        var answerItem = $(this);

        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool");
        var min = $(this).data("min");
        var max = $(this).data("max");

        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    answerItem.data("correct", true);
                    answerItem.next().next().hide();
                } else {
                    answerItem.data("correct", false);
                    answerItem.next().next().show();
                }
            });
        }

        console.log(id);
        console.log(type);
    });
});