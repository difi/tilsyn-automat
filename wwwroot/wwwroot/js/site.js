$(function () {
    $('.jsNormalTableSort').tablesorter({
        widgets: ['zebra', 'columns'],
        usNumberFormat: false,
        sortReset: true,
        sortRestart: true,
        sortList: [[0, 0]]
    });

    $('.jsCompanyTableSort').tablesorter({
        widgets: ['zebra', 'columns'],
        usNumberFormat: false,
        sortReset: true,
        sortRestart: true,
        sortList: [[5, 1], [0, 0]],
        headers: {
            3: { sorter: false },
            4: { sorter: false }
        }
    });

    if ($.fn.numericInput) {
        try {
            $("input[type='number']:not([readonly])").numericInput({
                allowNegative: false,
                allowFloat: false
            });
        } catch (error) {
            //
        }
    }

    $('.jsLogTableSort').tablesorter({
        widgets: ['zebra', 'columns'],
        usNumberFormat: false,
        sortReset: true,
        sortRestart: true,
        sortList: [[0, 1]]
    });

    $(".jsPrintButton").click(function() {
        window.print();
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

    var excelToggle = new funkanu.ariatoggle({
        container: ".jsExcelImportContainer",
        triggerSelector: ".jsExcelImportButton",
        target: function ($elem) {
            return $elem.parents(".jsExcelImportContainer").find('.jsExcelImportTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function () { });
        }
    });

    var declarationListToggle = new funkanu.ariatoggle({
        container: ".jsDeclarationListToggleCardContainer",
        triggerSelector: ".jsDeclarationListToggleCardButton",
        target: function ($elem) {
            return $elem.parents(".jsDeclarationListToggleCardContainer").find('.jsDeclarationListToggleCardTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function () { });
        }
    });

    $(".jsClickIfFirst").click();

    var changeLanguageToggle = new funkanu.ariatoggle({
        container: ".jsChangeLanguageContainer",
        triggerSelector: ".jsToggleChangeLanguageButton",
        target: function ($elem) {
            return $elem.parents(".jsChangeLanguageContainer").find('.jsChangeLanguageToggleTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function () { });
        }
    });

    var viewStartInfo = new funkanu.ariatoggle({
        container: ".jsViewStartInfoContainer",
        triggerSelector: ".jsToggleViewStartInfoButton",
        target: function ($elem) {
            return $elem.parents(".jsViewStartInfoContainer").find('.jsViewStartInfoToggleTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function() {

                $target.parents(".jsViewStartInfoContainer").find(".jsToggleViewStartInfoButton").hide();
            });
        }
    });

    // Copy of code from declarationForm.js
    var questionReadToggle = new funkanu.ariatoggle({
        container: ".jsToggleCardReadContainer",
        triggerSelector: ".jsToggleCardReadButton",
        target: function ($elem) {
            return $elem.parents(".jsToggleCardReadContainer").find('.jsToggleCardReadTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function () { });
        }
    });
});


$("body").on("change", ".choose-file", function () {
    var value = this.value;
    if (this.value.indexOf("\\") > 0) {
        value = value.substr(value.lastIndexOf("\\") + 1, value.length - 1);
    }

    $(".jsFileName").html(value);
});