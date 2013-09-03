<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="admin_AddUser" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td class="tdsubheading" align="left">

 <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
 <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Visible="true" ForeColor="Red"></asp:Label>
 <asp:RegularExpressionValidator ID="regxtxtPassword" runat="server"  EnableClientScript="true"    ControlToValidate="txtPassword" ValidationExpression="(?=^.{5,15}$)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ></asp:RegularExpressionValidator>
 </ContentTemplate></asp:UpdatePanel> 
</td></tr>

    <tr>
    <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Add User</td>
       <td width="80%" align="right" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"><asp:LinkButton ID="lnkViewuser" 
                    runat="server" Text="[View User]" ForeColor="White" CausesValidation="false" OnClick="lnkViewUser_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;</td>
         
    </tr>
    
    
  </table> 
</td>
</tr>
<tr><td>
<asp:Panel ID="panelUserLogin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    </tr __designer:mapid="14e5">
    <tr style="padding-top:8px;"><td class="tdsubheading" width="17%"><font class="mandatory">*</font>Enter 
        UserName</td>
        <td width="83%">
            <asp:TextBox ID="txtUserName" runat="server"  Width="155px" MaxLength="50"></asp:TextBox>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValUsername" runat="server" 
                ControlToValidate="txtUserName" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td  class="tdsubheading"><font class="mandatory">*</font>Enter Password</td>
        <td>
           
            <asp:TextBox ID="txtPassword" runat="server" Width="155px" TextMode="Password"></asp:TextBox>
            <font Style=" font-size:smaller; font-family:Tahoma;" >(Length(5-15),Include one special character ie.!@#$%^&*-)</font>&nbsp;<asp:RequiredFieldValidator ID="reqValPassword" runat="server" 
                ControlToValidate="txtPassword" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr><td></td><td></td></tr>
     <tr>
        <td class="tdsubheading"><font class="mandatory">*</font>Re-Type Password</td>
        
         <td>
             <asp:TextBox ID="txtRetypePassword" runat="server" Width="155px" TextMode="Password"></asp:TextBox>
             &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtRetypePassword" runat="server" 
                 ControlToValidate="txtRetypePassword" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator>
                 
                 
                 <asp:CompareValidator  ID="cmpPassw" runat="server" ControlToCompare="txtPassword"    EnableClientScript="true"     ControlToValidate="txtRetypePassword" 
                Operator="Equal" SetFocusOnError="true"></asp:CompareValidator>
                 
                 </td>
        
    </tr>
   
     <tr>
        <td  class="tdsubheading"><font class="mandatory">*</font>Select Role</td>
        <td>
            <asp:DropDownList ID="dropRole" runat="server" Width="160px">
                   
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdropRole" runat="server" 
                ControlToValidate="dropRole" EnableClientScript="true" ForeColor="Red" 
                InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
        
    </tr>
    <tr>
        <td>&nbsp;</td>
        
    </tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Personal Details
        </td>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;</td>
    </tr>
    <tr style="padding-top:8px;">
        <td class="tdsubheading">
            <font class="mandatory">*</font>Enter First Name</td>
        <td>
            <asp:TextBox ID="txtFname" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtFname" runat="server"  
                ControlToValidate="txtFname" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="tdsubheading">
            <font class="mandatory">*</font>Enter Last Name</td>
        <td> <asp:TextBox ID="txtLname" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
          
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtLname" runat="server" 
                ControlToValidate="txtLname" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Enter Employee Id</td>
            <td>
                <asp:TextBox ID="txtEmpId" runat="server" Width="155px" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Enter Description</td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" Height="30px"  MaxLength="500" TextMode="MultiLine" 
                    Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                &nbsp;Contact Information
            </td>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                &nbsp;</td>
        </tr>
        <tr  style="padding-top:8px;">
            <td class="tdsubheading">
                <font class="mandatory">*</font>Enter Email-Id</td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" Width="155px" MaxLength="50"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regExtxtEmailId" 
                    runat="server" 
                    EnableClientScript="true" 
                    ControlToValidate="txtEmailId" 
                    ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" 
                    ErrorMessage="Enter Valid Email-Id">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rqvemail" 
                    runat="server" 
                    ControlToValidate="txtEmailId" 
                    EnableClientScript="true" 
                    ForeColor="Red" 
                    ErrorMessage="Enter Email_id">
                </asp:RequiredFieldValidator>
                
            </td>
        </tr>
    </tr>
    <tr>
        <td class="tdsubheading">&nbsp;&nbsp;Enter Mobile.No
        </td>
        <td>
             <asp:TextBox ID="txtMobile" Width="155px" runat="server" MaxLength="50"></asp:TextBox>
        </td>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Enter Landline.No</td>
            <td>
                <asp:TextBox ID="txtLandline" Width="155px" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr >
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                &nbsp;Organization Details</td>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                  
                              </td>
        </tr>
       <tr  style="padding-top:8px;">
            <td class="tdsubheading">
                <font class="mandatory">*</font>Select Customer</td>
            <td>
                <asp:DropDownList ID="drpCustomer" AutoPostBack="true" runat="server" 
                                        Width="160px" onselectedindexchanged="drpCustomer_SelectedIndexChanged" 
               ></asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCustomer" runat="server" EnableClientScript="true" ControlToValidate="drpCustomer"  ErrorMessage="Select Customer"  InitialValue="0"></asp:RequiredFieldValidator> 
           </td>
        </tr>
    </tr>
    <tr>
            <td class="tdsubheading">
                <font class="mandatory">*</font>Select Site</td>
            <td>
                <asp:DropDownList ID="DrpSite" runat="server" Width="160px" OnSelectedIndexChanged="Drpsite_SelectedIndexChanged" AutoPostBack="true">
                    
                </asp:DropDownList>
                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="true" ControlToValidate="DrpSite"  ErrorMessage="Select Site"  InitialValue="0"></asp:RequiredFieldValidator> 
           </td>
        </tr>
    </tr>
    <tr>
        <td class="tdsubheading">
            &nbsp;&nbsp;Enter Department Name</td>
        <td>
             <asp:DropDownList ID="DrpDepartment" runat="server" Width="160px" >
                    
                </asp:DropDownList></td></tr>
                
           <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Company</td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server" MaxLength="50"></asp:TextBox>
                &nbsp;&nbsp;</td>
           
        </tr>       
       <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;City</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" MaxLength="50"></asp:TextBox>
                &nbsp;</td>
           
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                &nbsp;&nbsp;</td>
            <td align="left" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                &nbsp;<asp:Button ID="btnSave" runat="server"    onclick="btnSave_Click" Text="Save" />
                &nbsp;<asp:Button ID="btnReset" runat="server" CausesValidation="false" 
                    onclick="btnReset_Click" Text="Reset" />
            </td>
        </tr>
    
   
   
    </table> 
    </ContentTemplate>
    </asp:UpdatePanel> 
    </asp:Panel>
</td></tr>
<tr><td>

</td></tr>
</table> 
 
  

</asp:Content>

