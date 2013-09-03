<%@ Page Language="C#" MasterPageFile="~/Master/HELP.master" AutoEventWireup="true" CodeFile="PmRegistration.aspx.cs" Inherits="HELP_PmRegistration" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" width="100%" >
<tr><td  style="background-color:Blue" height="45px">

<font color="white"><b>&nbsp;4 Problem Management Module</b></font>
</td>

</tr>
<tr><td>&nbsp;</td></tr>
<tr><td style="font-family:verdana;font-weight:bold; font-size:10pt">

&nbsp;<u>4.1 &nbsp; &nbsp;Problem Registration</u>
</td>

</tr>
<tr><td>&nbsp;</td></tr>
<tr>

<td >&nbsp;&nbsp;<asp:Image ID="imgimflow" runat="server" ImageUrl="~/images/PManagement.bmp" /> </td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Register New Incident</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Incident ---> New Ticket </td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Call Type</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;The Call Type Incident or Request For Information</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold ;font-size:10pt">&nbsp;&nbsp;Mode</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Select The Mode of incident<ul><li>Email</li><li>Web</li><li>Phone</li></ul></td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold ;font-size:10pt">&nbsp;&nbsp;Status</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Default Status of the Incident is open.</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold ;font-size:10pt">&nbsp;&nbsp;Priority</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Select the priority as per the incident</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Requester Details</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Provide the username and search. if its avialable in database then it will fetch all </td></tr> 
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;the value and if not then it will ask to create. </td></tr> 
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Site </td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Select user location </td></tr>

<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Technician </td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Select Technician for the incident </td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Department</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Select User department</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Category</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Select incdent category</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Subcategory</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Select Subcategory for incident</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Title</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Write the incident title</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Description</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Incident information details</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Add Request</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Click on this button will add the request</td></tr>
<tr><td style="font-family:verdana;color:#003db2;font-weight:bold; font-size:10pt">&nbsp;&nbsp;Reset</td></tr>
<tr><td style="font-family:verdana; font-size:10pt">&nbsp;&nbsp;Clear selected Fields.</td></tr>
</table>
</asp:Content>

