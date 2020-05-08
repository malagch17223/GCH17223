function submitForm(formName, formHandlerUrl, redirectUrl) {
    $.ajax({
        type: "POST",
        url: formHandlerUrl,
        data: $("#" + formName).serialize(), // serializes the form's elements.
        success: function (data) {
            if (data.length > 2) {
            swal({
                title: 'Field Validation Error',
                text: data,
                type: 'error'
            });
            }
            else {
                window.location = redirectUrl;
            }
        },
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Time out error.';
            } else if (exception === 'abort') {
                msg = 'Ajax request aborted.';
            } else {
                msg = 'Uncaught Error.\n' + jqXHR.responseText;
            }
            swal({
                title: 'Delete Request Error',
                text: msg,
                type: 'error'
            })
        }
    });
}


function DeleteRequest(deleteUrl, container) {
    swal({
        title: 'Are you sure ?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then(function () {
        $.ajax({
            type: "POST",
            url: deleteUrl,
            success: function (data) {
                document.getElementById(container).hidden = true;
            },
            error: function (jqXHR, exception) {
                var msg = '';
                if (jqXHR.status === 0) {
                    msg = 'Not connect.\n Verify Network.';
                } else if (jqXHR.status == 404) {
                    msg = 'Requested page not found. [404]';
                } else if (jqXHR.status == 500) {
                    msg = 'Internal Server Error [500].';
                } else if (exception === 'parsererror') {
                    msg = 'Requested JSON parse failed.';
                } else if (exception === 'timeout') {
                    msg = 'Time out error.';
                } else if (exception === 'abort') {
                    msg = 'Ajax request aborted.';
                } else {
                    msg = 'Uncaught Error.\n' + jqXHR.responseText;
                }
                swal({
                    title: 'Delete Request Error',
                    text: msg,
                    type: 'error'
                })
            }
        });
      
    })

}



function DisApproveBook(bookid, uri) {

    $.ajax({
        type: 'POST',
        url: uri,
        data: { bookid: bookid },
        success: function (response) {
            $("#pendingcount").html(response);
        }
    })

}

function ApproveBook(bookid, uri) {

    $.ajax({
        type: 'POST',
        url: uri,
        data: { bookid: bookid },
        success: function (response) {
            $("#pendingcount").html(response);
            document.getElementById("book_"+bookid).hidden = true;
        }
    })

}