$(document).ready(function () {
    $('#hideDoneItems').change(function () {
        if (this.checked) {
            $('.isDone').hide();
        } else {
            $('.isDone').show();
        }
    });
});