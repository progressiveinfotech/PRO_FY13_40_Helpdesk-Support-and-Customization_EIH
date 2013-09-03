<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MasterAdmin.master" CodeFile="AppSetting.aspx.cs" Inherits="admin_AppSetting" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            background-color: white;
            font-family: Tahoma;
            font-size: small;
            height: 22px;
        }
        .style2
        {
            height: 22px;
        }
    </style>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td class="tdsubheading" align="left" width="60%">

 <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
 <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Visible="true" ForeColor="Red"></asp:Label>
 </ContentTemplate></asp:UpdatePanel> 
</td></tr>

    <tr>
    <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" 
            width="60%">
            &nbsp;Edit Application Setting</td>
       <td width="80%" align="right" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;</td>
   </tr>
  </table> 
</td>
</tr>
<tr><td>
<asp:Panel ID="panelUserLogin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr><td width="35%" align="center">Change ServerName<font color="red">
        *</font></td>
        <td width="65%">
            <asp:TextBox ID="txtservername" runat="server"  Width="155px" MaxLength="50"></asp:TextBox>
             <asp:RequiredFieldValidator ID="reqValUsername" runat="server" 
                ControlToValidate="txtservername" EnableClientScript="true" 
                ForeColor="Red" ErrorMessage="please enter server name"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td width="35%" align="center">Change Email Server<font color="red">*</font></td>
        <td width="65%">
           
            <asp:TextBox ID="txtmailserver" runat="server" Width="155px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="reqValPassword" runat="server" 
                ControlToValidate="txtmailserver" EnableClientScript="true" 
                ForeColor="Red" ErrorMessage="please enter mail server name"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td width="35%" align="center">Change Admin Email Id<font color="red">*</font></td>
        
         <td width="65%">
             <asp:TextBox ID="txtadminmailid" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
             <asp:RequiredFieldValidator ID="reqValtxtRetypePassword" runat="server" 
                 ControlToValidate="txtadminmailid" EnableClientScript="true" 
                 ForeColor="Red" ErrorMessage="please enter admin email id"></asp:RequiredFieldValidator>
          </td>
    </tr>
    <tr>
        <td width="35%" align="center">
            Change Level1EscalateMail<font color="red">*</font></td>
        <td width="65%">
            <asp:TextBox ID="txtlevel1esc" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqValtxtFname" runat="server"  
                ControlToValidate="txtlevel1esc" EnableClientScript="true" ForeColor="Red" 
                ErrorMessage="please enter email for Level1 escalation"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td width="35%" align="center">
            Change Level2EscalateMail<font color="red">*</font></td>
        <td width="65%"> <asp:TextBox ID="txtlevel2esc" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
          
            <asp:RequiredFieldValidator ID="reqValtxtLname" runat="server" 
                ControlToValidate="txtlevel2esc" EnableClientScript="true" ForeColor="Red" 
                ErrorMessage="please enter email for Level2 escalation"></asp:RequiredFieldValidator></td>
    </tr>
        <tr>
            <td width="35%" align="center">
                Change Level3EscalateMail<font color="red">*</font></td>
            <td width="65%">
                <asp:TextBox ID="txtlevel3esc" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtlevel3esc" EnableClientScript="true" ForeColor="Red" 
                    ErrorMessage="please enter email for Level3 escalation"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="35%" align="center">
                Change Contact No</td>
            <td width="65%">
                <asp:TextBox ID="txtcontactno" runat="server" MaxLength="20" Width="155px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="35%" align="center">
                Enable Call Reporting Date</td>
            <td width="65%">
                <asp:DropDownList ID="DdlCallReportingTime" runat="server">
                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="trautocalls" runat="server">
            <td  width="35%" align="center">
                Enable Auto Calls Logging</td>
            <td width="65%">
                <asp:DropDownList ID="DdlAutoCallLogging" runat="server">
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="True" Text="No" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
           <tr id="tr1" runat="server">
            <td width="35%" align="center">
                Enable Technician Mapping</td>
            <td width="65%">
                <asp:CheckBox ID="chkbxtechmapping"  runat="server"/>
            </td>
        </tr>
        <tr runat="server">
            <td width="35%" align="center">
           User Feedback Mode</td>
            <td width="65%">
                <asp:DropDownList ID="Ddlfeedbackmode" runat="server">
                <asp:ListItem Text="Default" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Call wise" Value="1"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
      
     <tr>
        <td align="center" background="../images/tdimg.bmp" 
            style="color:White;font-weight:bold;" width="35%">
            </td>
        <td align="left" background="../images/tdimg.bmp" 
            style="color:White;font-weight:bold;" width="65%">
            
            <asp:Button ID="BtnSave" runat="server" onclick="BtnSave_Click" Text="Save" 
                Font-Bold="True" Width="60px" />
        </td>
    </tr>
    </table> 
    </ContentTemplate>
    </asp:UpdatePanel> 
    </asp:Panel>
</td></tr>
<tr><td>&nbsp;</td></tr>
</table> 
 
  

</asp:Content>
