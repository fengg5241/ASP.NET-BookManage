<%@ Page Title="" Language="C#" MasterPageFile="~/nosidebar.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="ChapterB2B.Test2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    table, th, td {
        border: 1px solid black;
    }
</style>
    <script type="text/javascript" src="./scripts/jquery-3.2.1.min.js"></script>
    <script>
        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "SupplierWebService.asmx/showOrderList",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var trList = "";
                    $.each(result.d, function (index, customerOrder) {
                        var productListHtml = "";
                        $.each(customerOrder.productList, function (index, product) {
                            productListHtml += product.productName + "(" + product.qty + ")";
                        });
                        var milli = customerOrder.orderDate.replace(/\/Date\((-?\d+)\)\//, '$1');
                        var orderDate = new Date(parseInt(milli));
                        var orderDateStr = orderDate.getUTCFullYear() + "-" + orderDate.getUTCMonth() + "-" + orderDate.getUTCDate();
                        var status = customerOrder.status == "1" ? "approve" : "reject";
                        trList += "<tr><td>" + customerOrder.orderNo + "</td><td>" + orderDateStr + "</td>" +
                            "<td>" + productListHtml + "</td><td>" + customerOrder.totalAmount + "</td><td>" + customerOrder.companyName + "</td>"+
                        "<td>" + status + "</td></tr>";
                    });

                    $("#orderTbody").html(trList);

                }
            });
        });


    </script>
    <table id="orderTable" border="1" style="text-align:center">
        <thread>
            <tr>
                <th>order no</th>
                 <th>order date</th>
                 <th>product name(qty)</th>
                 <th>amount</th>
                <th>company name</th>
                <th>status</th>

            </tr>

        </thread>
        <tbody id="orderTbody">

        </tbody>


    </table>
</asp:Content>
