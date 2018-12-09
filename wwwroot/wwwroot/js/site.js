﻿$(function () {
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
});