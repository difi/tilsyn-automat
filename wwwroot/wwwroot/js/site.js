$(function () {
    $('table').tablesorter({
        widgets: ['zebra', 'columns'],
        usNumberFormat: false,
        sortReset: true,
        sortRestart: true
    });

    attachEvents();
});



function attachEvents() {


    $("body").on("click", ".jsToggleCardButton", function (e) {

        e.preventDefault();
        var $self = $(this),
            $container = $self.closest(".jsToggleCardContainer"),
            $target = $container.find(".jsToggleCardTarget");
            $target.slideToggle("300", function () {
            $target.toggleAttr("aria-hidden");
            $self.toggleAttr("aria-expanded");

            //$self.parent().parent().parent().addClass("small-collapse");
        });
    });

    $("body").on("click", ".jsToggleHelpButton", function (e) {

        e.preventDefault();
        var $self = $(this),
            $container = $self.closest(".jsAnswerItem"),
            $target = $container.find(".jsToggleHelpTarget");
            $target.slideToggle("300", function () {
            $target.toggleAttr("aria-hidden");
            $self.toggleAttr("aria-expanded");
        });
    });


}