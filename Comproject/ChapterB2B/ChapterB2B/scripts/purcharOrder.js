$(document).ready(function () {

    var bookMap = {};
    $.ajax({
        type: "POST",
        url: "CompanyWebService.asmx/getAllBooks",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var optionHtml = "";
            $.each(result.d, function (index, book) {
                optionHtml += "<option value='" + book.id + "'>" + book.productName + "</option>";
                bookMap[book.id] = { productName: book.productName, price: book.price, qty: 1, id: book.id }
            });

            $("#bookSelect").html(optionHtml);
        }
    });

    var selectedBookMap = {};
    $("#addButton").click(function () {
        var bookId = $("#bookSelect").val();
        if (!selectedBookMap[bookId]) {
            selectedBookMap[bookId] = true;
            var book = bookMap[bookId];
            book.qty = 1;
            var trHtml = "<tr><td>" + bookId + "</td><td>" + book.productName + "</td><td class='qtyTD'>1</td><td>" + book.price + "</td>"+
                "<td data-bookId=" + bookId + "><input type='button' class='updateButton' value='Update' /><input type='button' class='saveButton hidden' value='Save' /><input type='button' class='deleteButton' value='Delete' /></tr>";
            $("#orderTbody").append(trHtml);

            calTotalPrice();
        }
    })

    function calTotalPrice() {
        var totalAmount = 0;
        for (var bookId in selectedBookMap) {
            var book = bookMap[bookId];
            totalAmount += parseInt(book.qty) * parseFloat(book.price);
        }

        $("#totalPriceSpan").html(totalAmount);
    }

    $(document).on("click", ".updateButton", function () {
        $parentTR = $(this).parent().parent();
        $(this).addClass("hidden");
        $parentTR.find(".saveButton").removeClass("hidden");

        var $qtyTD = $parentTR.find(".qtyTD");
        var currentQty = $qtyTD.html();
        $qtyTD.html("<input type='number' min=0 value=" + currentQty + ">");
    })

    $(document).on("click", ".saveButton", function () {
        $parentTR = $(this).parent().parent();
        $(this).addClass("hidden");
        $parentTR.find(".updateButton").removeClass("hidden");

        var $qtyTD = $parentTR.find(".qtyTD");
        var currentQty = $qtyTD.find("input").val();
        $qtyTD.html(currentQty);

        //update qty for total price cal
        var bookId = $(this).parent().attr("data-bookId");
        bookMap[bookId].qty = currentQty;

        calTotalPrice();
    })

    $(document).on("click", ".deleteButton", function () {
        var bookId = $(this).parent().attr("data-bookId");
        selectedBookMap[bookId] = false;
        $(this).parent().parent().remove();
    })

    $("#confirmButton").click(function () {
        var bookArray = [];
        for (var bookId in selectedBookMap) {
            var book = bookMap[bookId];
            bookArray.push(book);
        }

        var bookParam = {
            bookArray: bookArray,
            orderNo: $("#oderNoInput").val(),
            orderDate:$("#orderDateInput").val()
        }

        $.ajax({
            type: "POST",
            url: "CompanyWebService.asmx/purchaseOrder",
            data: JSON.stringify({ order: bookParam }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert("Successful!");
            }
        });
    })


});