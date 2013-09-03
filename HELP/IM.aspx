<%@ Page Language="C#" MasterPageFile="~/Master/HELP.master" AutoEventWireup="true" CodeFile="IM.aspx.cs" Inherits="HELP_IM" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" width="100%" >
<tr><td  style="background-color:Blue" height="45px">

<font color="white"><b>&nbsp;Incident Management Module</b></font>
</td>

</tr>
<tr>

<td ><asp:Image ID="imgimflow" runat="server" ImageUrl="~/images/IM.JPG"  /> </td>
</tr>
<tr><td>Register New Incident</td></tr>
<tr><td>Incident ---> New Ticket </td></tr>
<tr><td>Select The Call Type Incide or Request For Information</td></tr>
<tr><td>Mode</td></tr>
<tr><td>Select The Mode of incident<ul><li>Email</li><li>Web</li><li>Phone</li></ul></td></tr>
</table>
</asp:Content>

