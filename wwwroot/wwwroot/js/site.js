$(function () {
    $('table').tablesorter({
        widgets: ['zebra', 'columns'],
        usNumberFormat: false,
        sortReset: true,
        sortRestart: true
    });

    var questionToggle = new funkanu.ariatoggle({
        container: ".jsToggleCardContainer",
        triggerSelector: ".jsToggleCardButton",
        target: function ($elem) {
            return $elem.parents(".jsToggleCardContainer").find('.jsToggleCardTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function () { });
        }
    });

    var helpToggle = new funkanu.ariatoggle({
        container: ".jsAnswerItem",
        triggerSelector: ".jsToggleHelpButton",
        target: function ($elem) {
            return $elem.parents(".jsAnswerItem").find('.jsToggleHelpTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function () { });
        }
    });

    var profileToggle = new funkanu.ariatoggle({
        container: ".jsProfileContainer",
        triggerSelector: ".jsProfileTrigger",
        target: function () {
            return $('.jsProfileToggleTarget');
        },
        toggleAction: function ($target) {
            var trigger = $('.jsProfileTrigger');
            trigger.toggleClass('minus');
            trigger.toggleClass('plus');

            $target.slideToggle("300", function () { });
        }
    });
});