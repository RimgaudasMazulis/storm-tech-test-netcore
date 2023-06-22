$(document).ready(function () {
    $('#hideDoneItems').change(function () {
        if (this.checked) {
            $('.isDone').hide();
        } else {
            $('.isDone').show();
        }
    });   

    $('#showAddTodoModalBtn').click(function () {
        $('#addNewItemModal').modal('show');
    });

    $('#orderByRankBtn').off('click').click(function () {
        var todoListId = $('#TodoListId').val();
        orderListByRank(todoListId);
    }); 
});

function orderListByRank(todoListId) {
    $.ajax({
        url: '/TodoList/GetDetailsByRank',
        type: 'GET',
        data: {
            todoListId: todoListId
        },
        success: function (response) {
            $("#todo-list").html(response);
        },
        error: function (xhr, status, error) {
        }
    });
}

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
        }
    });
}