<%@ Page Language="C#" MasterPageFile="~/Master/HELP.master" AutoEventWireup="true" CodeFile="Loginhelp.aspx.cs" Inherits="HELP_Loginhelp" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" width="100%" >
<tr><td  style="background-color:Blue" height="45px">

<font color="white"><b>&nbsp; 2.Login Page</b></font>
</td>

</tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr>

<td>&nbsp;&nbsp;&nbsp;<asp:Image ID="imgimflow" runat="server" ImageUrl="~/images/loginhelp.JPG"  /> </td>
</tr>


<tr><td>&nbsp;&nbsp;&nbsp;Every user logs into Helpdesk Software with their individual User ID & Password.</td></tr>
<tr>
<td>
&nbsp;&nbsp;&nbsp;The application maintains a Privilege class and hence each user logging in has their own privilege. When the user is created they are provided with a privilege, User ID and Password. Each user can access the application based on his privilege.
</td></tr>
<tr>
<td>
&nbsp;&nbsp;&nbsp;[Login]
</td>
</tr>
<tr>
<td>

&nbsp;&nbsp;&nbsp;l Enter the required fields and click on the [Log-in] button to enter the application.</td></tr>
<tr><td>&nbsp;&nbsp;&nbsp;l User ID and Password are all mandatory fields.</td></tr>

<tr><td>&nbsp;&nbsp;&nbsp;2 Only authorized Users can login to the application</td></tr>

<tr><td>&nbsp;&nbsp;&nbsp;3 If the User ID/Password is invalid then you will be redirected to the Login Error Page.</td></tr>
<tr><td>
&nbsp;&nbsp;&nbsp;2.When the session expires you will be redirected to the login page</td></tr>



<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
</table>

</asp:Content>

