$(document).ready(function () {

    var headerFunctionLinksToggle = new funkanu.ariatoggle({
        container: ".function-links",
        triggerSelector: ".function-links-toogle-button",
        target: function ($elem) {
            return $('#' + $elem.attr('aria-controls'));
        },
        toggleAction: function ($target) {
            $target.slideToggle("300");
            $('.headerToggleableArea').not($target).hide();

            if ($target.is(':visible')) {
                $target.find('input').first().focus();
            }
            //Override ariatoggle package, special case when toggling functionlinks
            $target.siblings("div").each(function () {
                if (!$(this).is(":visible")) {
                    $(this).attr("aria-hidden", "true");
                }
            });
        },

        clickEvent: function ($currentTarget) {
            $('.function-links-toogle-button').not($currentTarget).attr('aria-expanded', 'false');
            var $closestLi = $currentTarget.closest('li');
            $('.function-links').find('li').not($closestLi).removeClass('active');
            $closestLi.toggleClass('active');

            if ($currentTarget.attr('aria-expanded') === "false") {
                $currentTarget.focus();
            }
        },
    });

    //$('.teaserText').matchHeight();
    
});