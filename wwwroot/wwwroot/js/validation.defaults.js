$.validator.setDefaults({
    highlight: function(element) {
        $(element).closest('.form-field').addClass('errorOnThis');
    },
    unhighlight: function(element) {
        $(element).closest('.form-field').removeClass('errorOnThis');
    }
});