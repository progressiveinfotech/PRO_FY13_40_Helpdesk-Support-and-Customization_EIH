<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="ImportUserAD.aspx.cs" Inherits="admin_ImportUserAD" Title="Untitled Page" %>

<script runat="server">

   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td>
 
<asp:Label ID="lblErrMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>

</td></tr>
<tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Import Users From Active Directory </td>
         
 </tr>
 
</table></td></tr>
<tr><td>

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr style="padding-top:10px;"><td  width="15%"><font class="mandatory">*</font>Enter   Domain Name</td>
        <td width="85%" align="left">
            <asp:TextBox ID="txtDomainName" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValDomainname" runat="server" 
                ControlToValidate="txtDomainName" EnableClientScript="true" ErrorMessage="Enter Domain Name" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
<!-- <tr style="padding-top:10px;"><td  width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     OU1&nbsp;</td>
        <td width="85%" align="left">
            <asp:TextBox ID="TxtOU1" runat="server" Width="155px"></asp:TextBox>
     </td>
    </tr>
 <tr style="padding-top:10px;"><td  width="15%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
     OU2&nbsp;</td>
        <td width="85%" align="left">
            <asp:TextBox ID="TxtOU2" runat="server" Width="155px"></asp:TextBox>
     </td>
    </tr> -->
 <tr style="padding-top:10px;"><td  width="15%">User Name</td>
        <td width="85%" align="left">
            <asp:TextBox ID="txtUserName" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
            </td>
    </tr>
 <tr style="padding-top:10px;"><td  width="15%">Password</td>
        <td width="85%" align="left">
            <asp:TextBox ID="txtPassword" runat="server" Width="155px" MaxLength="50" 
                TextMode="Password"></asp:TextBox>
            </td>
    </tr>
 <tr style="padding-top:10px;"><td  width="15%" class="style1"></td>
        <td width="85%" align="left" class="style1">
            </td>
    </tr>
    <tr>
            <td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            </td>
            <td align="left" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
               <asp:Button ID="btnImport" runat="server" Text="Import" 
                    onclick="btnImport_Click" />&nbsp;
                   <asp:Button ID="btnReset" runat="server" 
                    Text="Reset" onclick="btnReset_Click" />
            </td>
     </tr>
            
</table>

</td>
 
</tr>
</table>
</asp:Content>

