
$(document).ready(function () {
    $("#posted-jobs-dataTable").DataTable();
});

function InitializeItems(ItemId, Name, Description, Price, Quantity) {

    this.ItemId = ItemId;
    this.Name = Name;
    this.Description = Description;
    this.Price = Price;
    this.Quantity = Quantity;

}

function AddItem() {
    var form = $('#AddItemForm')[0];
    var formData = new FormData(form);
    $.ajax({
        type: 'POST',
        url: '/Admin/AddItem',
        dataType: 'JSON',
        data: formData,
        processData: false,
        contentType: false,
        success: function (resp) {
            if (resp.responseMsg == 200) {
                ShowSnackBarMessages("Item added Successfully", "lightgrey", "green");
                window.setTimeout(function () {
                    location.reload(true)
                }, 2000);
            }
        },
        error: function (response) {
            alert("AJAX : Error occured during adding the Item.");
        }
    });
}

function GetListOfItems(itemId) {

    
    $.ajax({
        type: "GET",
        url: "/Admin/GetListOfItems?itemId=" + parseInt(itemId),
        contentType: "html",
        success: function (value) {
            if (value.length == 0) {
            }
            else {
                $('input[name=ItemId]').val(value.ItemId);
                $('input[name=Name]').val(value.Name);
                $('input[name=Description]').val(value.Description);
                $('input[name=Quantity]').val(value.Quantity);
                $('input[name=Price]').val(value.Price);
                
            }
        },
        error: function (response) {
            alert("AJAX - Error while fetching company details.");
        }
    });

    $('#ModalEditItem').modal('show');
}

function ConfirmationToUpdateItem(field) {

    var updateItemObj = {
        "ItemId": field.parentNode.parentNode.childNodes[3].childNodes[1].childNodes[1].childNodes[3].value,
        "Name": field.parentNode.parentNode.childNodes[3].childNodes[1].childNodes[3].childNodes[3].value,
        "Description": field.parentNode.parentNode.childNodes[3].childNodes[1].childNodes[5].childNodes[3].value,
        "Price": field.parentNode.parentNode.childNodes[3].childNodes[1].childNodes[7].childNodes[3].value,
        "Quantity": field.parentNode.parentNode.childNodes[3].childNodes[1].childNodes[9].childNodes[3].value,
    }
    //var updateItemObj = new InitializeItems($('input[name=ItemId]').val(), $('input[name=Name]').val(), $('input[name=Description]').val(),
    //                                        $('input[name=Price]').val(), $('input[name=Quantity]').val())
    $.ajax({
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        url: "/Admin/UpdateItem",
        data: JSON.stringify(updateItemObj),
        success: function (resp) {
            if (resp.responseMsg == 200) {
                ShowSnackBarMessages("Item Updated Successfully !!", "lightgrey", "green");
                window.setTimeout(function () {
                    location.reload(true)
                }, 2000);
            }
        },
        error: function (response) {
            alert("AJAX - Error while updating the Item");
        }
    });
}

function DeleteItem(CompanyId) {
    $('#DeleteItemBtn').attr('data-DeleteItemId', CompanyId);
    $('#ModalDeleteItem').modal('show');
}

function ConfirmationToDeleteItem(field) {

    $.ajax({
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        url: "/Admin/DeleteItem?itemId=" + parseInt(field.getAttribute("data-DeleteItemId")),
        success: function (resp) {
            if (resp.responseMsg == 200) {
                ShowSnackBarMessages("Item Deleted Successfully !!", "lightgrey", "red");
                window.setTimeout(function () {
                    location.reload(true)
                }, 2000);
            }
        },
        error: function (response) {
            alert("AJAX - Error while deleting the item");
        }
    });

}

function ShowSnackBarMessages(message, backgroundColor, color) {
    var x = document.getElementById("snackbar");
    $(document.getElementById("snackbar")).css({ "backgroundColor": backgroundColor, "color": color });
    x.className = "show";
    x.innerHTML = message;
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 2000);
}