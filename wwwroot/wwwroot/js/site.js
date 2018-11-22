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

        //$('.jsToggleCardButton').addClass("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwaria-expanded");
        //$('.jsToggleCardButton').colorbox({ rel: $(this).attr('rel'), alt: $(this).data("alt") });

        e.preventDefault();
        var $self = $(this),
            $container = $self.closest(".jsToggleCardContainer"),
            $target = $container.find(".jsToggleCardTarget");
            $target.slideToggle("300", function () {
            $target.toggleAttr("aria-hidden");
            $self.toggleAttr("aria-expanded");

            $self.parent().parent().parent().addClass("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwaria-expanded");
        });
    });


}