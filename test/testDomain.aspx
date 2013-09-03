<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="testDomain.aspx.cs" Inherits="test_testDomain" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center" width="100%" border="0">
<tr><td><asp:Button ID="btnClick" Text="Click" runat="server" 
        onclick="btnClick_Click" /></td></tr>
</table>
</asp:Content>

