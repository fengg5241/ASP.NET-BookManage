<%@ Page Title="Test" Language="C#" MasterPageFile="~/nosidebar.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ChapterB2B.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btn_Session" runat="server" Text="Login Test" OnClick="btn_Session_Click" />
    <asp:Button ID="btn_Admin" runat="server" Text="I'm An Admin Test" OnClick="btn_Admin_Click" />

</asp:Content>
