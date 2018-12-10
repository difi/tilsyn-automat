$(function () {
    $('[data-hide="True"]').hide();

    $(".jsAnswerItem").change(function () {
        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();
        
        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideDown("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideUp("fast");

                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').find("textarea").val("");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').find("input:text").val("");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').find("input:radio").prop("checked", false);
                } else {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideUp("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideDown("fast");

                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').find("textarea").val("");
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').find("input:text").val("");
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').find("input:radio").prop("checked", false);

                    $(this).parent().find(".jsNextAnswerItemPlaceHolder").find("input").focus();
                }
            });
        }
    });

    $(".jsAnswerItem").each(function () {
        var type = $(this).data("type");
        var id = $(this).data("id");
        var bool = $(this).data("bool").toLowerCase();
        var alwaysvisible = $(this).data("alwaysvisible").toLowerCase();

        if (alwaysvisible === "true") {
            $(this).appendTo($(this).prev().find(".jsNextAnswerItemPlaceHolder"));
        }

        if (type === "bool") {
            $(this).find("input:checked").each(function () {
                if ($(this).val() === bool) {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideDown("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideUp("fast");
                } else {
                    $('[data-hide="True"][data-LinkedParentCorrectId="' + id + '"]').slideUp("fast");
                    $('[data-hide="True"][data-LinkedParentFailedId="' + id + '"]').slideDown("fast");
                }
            });
        }
    });

    $("#answer_int_supplierandversion").change(function () {
        if ($("#answer_int_supplierandversion").val() === "99999") {
            $("#jsSupplierAndVersionOther").slideDown("fast");
        } else {
            $("#jsSupplierAndVersionOther").slideUp("fast");
            $("#jsSupplierAndVersionOther").find("input").val("");
        }
    });

    if ($("#answer_int_supplierandversion").val() === "99999") {
        $("#jsSupplierAndVersionOther").show();
    } else {
        $("#jsSupplierAndVersionOther").hide();
    }

    $(".uploader").each(function () {
        var uploader = new qq.azure.FineUploader({
            element: document.getElementById($(this).attr("id")),
            request: {
                endpoint: 'https://' + storageAccountName + '.blob.core.windows.net/' + storageContainer
            },
            signature: {
                endpoint: '/AzureHandler'
            },
            uploadSuccess: {
                endpoint: '/AzureHandler?id=' + $(this).attr("id")
            },
            retry: {
                enableAuto: true
            },
            deleteFile: {
                enabled: true
            },
            multiple: false,
            validation: {
                allowedExtensions: ['jpeg', 'jpg', 'png', 'gif']
            },
            debug: true
        });
    });

    $(".jsButtonRemoveImage").click(function (e) {
        e.preventDefault();
        var id = $(this).data("id");

        console.log(id);

        $("#" + id).val("");
        $("#old_" + id).hide();
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
        container: ".jsCard",
        triggerSelector: ".jsToggleHelpButton",
        target: function ($elem) {
            return $elem.parents(".jsCard").find('.jsToggleHelpTarget');
        },
        toggleAction: function ($target) {
            $target.slideToggle("300", function () { });
        }
    });
});