<%@ Page Title="" Language="C#" MasterPageFile="~/nosidebar.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="ChapterB2B.Test2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
.hidden{
    display:none !important;
}
</style>
<script type="text/javascript" src="./scripts/jquery-3.2.1.min.js"></script>
<script type="text/javascript" src="./scripts/purcharOrder.js"></script>

    <label>Supplier :</label>
<select>
    <option value="1">Supplier1</option>
</select>
    <br />
<label>PO ID :</label>
<input id="oderNoInput" type="text" value="1111"/> <br />
<label>PO Date :</label>
<input id="orderDateInput" type="text" value="2018-01-21"/> <br />
<label>Book Name :</label>
<select id="bookSelect">
   
</select>
<input id="addButton" type="button" value="Add"/>

    <br />
    <br />
<table id="orderTable" border="1" style="text-align:center">
        <thread>
            <tr>
                <th>BookID</th>
                <th>BookName</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Action</th>
            </tr>

        </thread>
        <tbody id="orderTbody">

        </tbody>


    </table>

    <div style="text-align:right">Total Price:<span id="totalPriceSpan"></span></div>
    <input id="confirmButton" type="button" value="Confirm"/>
</asp:Content>
