$(document).ready(function () {

    $('#hideDoneItems').change(function () {
        if (this.checked) {
            $('.isDone').hide();
        } else {
            $('.isDone').show();
        }
    });    

});

function getGravatarProfile(email, todoItemId) {
    $.ajax({
        url: '/Gravatar/GetProfile',
        data: { email: email },
        type: 'GET',
        success: function (response) {

            if (response && response.entry && response.entry.length > 0) {
                $('#username_' + todoItemId).text(response.entry[0].username);
            }
        },
        error: function (xhr, status, error) {
            // Handle the error here
        }
    });
}