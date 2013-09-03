<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="test1.aspx.cs" Inherits="test_test1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr><td><asp:PlaceHolder ID="place" runat="server"></asp:PlaceHolder>
<br />
<asp:Button ID="btn" runat="server" Text="Click" onclick="btn_Click" /></td></tr>
</table>
</asp:Content>

