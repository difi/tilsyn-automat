$(function () {
    console.log($('[data-viewifotherfailed="True"]').length);

    $('[data-viewifotherfailed="True"]').hide();

    $(".jsAnswerItem").change(function () {
        var answerItem = $(this);

        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();
        var min = $(this).data("min");
        var max = $(this).data("max");
        var viewifotherfailed = $(this).data("data-viewifotherfailed");
        
        if (type === "bool") {

            console.log("Hmmm1");

            $(this).find("input:checked").each(function () {

                console.log("Hmmm2");

                if ($(this).val() === bool) {
                    //answerItem.removeClass("errorOnThis");
                    answerItem.data("correct", true);
                    answerItem.next().next().hide();
                } else {
                    //answerItem.addClass("errorOnThis");
                    answerItem.data("correct", false);
                    answerItem.next().next().show();
                }
            });
        }

        console.log(id);
        console.log(type);
        console.log(bool);
    });
});