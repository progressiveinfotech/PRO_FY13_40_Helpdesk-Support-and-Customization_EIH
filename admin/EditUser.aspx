<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="admin_EditUser" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            background-color: white;
            font-family: Tahoma;
            font-size: small;
            height: 20px;
        }
        .style2
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td class="tdsubheading" align="left">

 <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
 <asp:Label ID="lblMessage" runat="server" Visible="true" Font-Bold="true" ForeColor="Red"></asp:Label>
 <asp:RegularExpressionValidator ID="regxtxtPassword" runat="server"  EnableClientScript="true"    ControlToValidate="txtPassword" ValidationExpression="(?=^.{5,15}$)(?=.*\W+)(?![.\n])(?=.*[a-zA-Z]).*$" ></asp:RegularExpressionValidator>

 
                
 
 </ContentTemplate></asp:UpdatePanel> 
</td></tr>

    <tr>
    <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Update User</td>
       <td width="80%" align="right" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
         
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
    </tr>
    <tr><td class="tdsubheading" width="17%"><font class="mandatory">*</font>Enter 
        UserName</td>
        <td width="83%">
            <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValUsername" runat="server" 
                ControlToValidate="txtUserName" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td  class="tdsubheading"><font class="mandatory">*</font>Enter Password</td>
        <td>
           
            <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"></asp:TextBox>
            <font Style=" font-size:smaller; font-family:Tahoma;" >(Length(5-15),Include one special character ie.!@#$%^&*-)</font>&nbsp;<asp:RequiredFieldValidator ID="reqValPassword" runat="server" 
                ControlToValidate="txtPassword" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr><td></td><td></td></tr>
     <tr>
        <td class="tdsubheading"><font class="mandatory">*</font>Re-Type Password</td>
        
         <td>
             <asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password"></asp:TextBox>
             &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtRetypePassword" runat="server" 
                 ControlToValidate="txtRetypePassword" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator>
                 
                 
                 <asp:CompareValidator  ID="cmpPassw" runat="server" ControlToCompare="txtPassword"    EnableClientScript="true"     ControlToValidate="txtRetypePassword" 
                Operator="Equal" SetFocusOnError="true"></asp:CompareValidator>
                 
                 </td>
        
    </tr>
   
     <tr>
        <td  class="tdsubheading"><font class="mandatory">*</font>Select Role</td>
        <td>
            <asp:DropDownList ID="dropRole" runat="server" Width="136px">
                   
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdropRole" runat="server" 
                ControlToValidate="dropRole" EnableClientScript="true" ForeColor="Red" 
                InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
        
    </tr>
    <tr>
        <td  class="tdsubheading">&nbsp;&nbsp;Enable</td>
        <td>
            <asp:DropDownList ID="DropEnable" runat="server" Width="136px">
             <asp:ListItem Text="True" Value="1"></asp:ListItem>
     <asp:ListItem Text="False" Value="0"></asp:ListItem>      
            </asp:DropDownList>
            </td>
        
    </tr>
    <tr>
        <td  class="tdsubheading">&nbsp;&nbsp;AD User</td>
        <td>
           <asp:Label ID="lblAdUser" runat="server" Font-Bold="true"></asp:Label>
            </td>
        
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
    <tr>
        <td class="tdsubheading">
            <font class="mandatory">*</font>Enter First Name</td>
        <td>
            <asp:TextBox ID="txtFname" runat="server" MaxLength="50"></asp:TextBox>
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtFname" runat="server"  
                ControlToValidate="txtFname" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="tdsubheading">
            <font class="mandatory">*</font>Enter Last Name</td>
        <td> <asp:TextBox ID="txtLname" runat="server" MaxLength="50"></asp:TextBox>
          
            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtLname" runat="server" 
                ControlToValidate="txtLname" EnableClientScript="true" ForeColor="Red"></asp:RequiredFieldValidator></td>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Enter Employee Id</td>
            <td>
                <asp:TextBox ID="txtEmpId" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Enter Description</td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" Height="30px" MaxLength="500" TextMode="MultiLine" 
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
        <tr>
            <td class="tdsubheading">
                <font class="mandatory">*</font>Enter Email-Id</td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server" MaxLength="50"></asp:TextBox>
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
                    ErrorMessage="Enter Email_Id">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
    </tr>
    <tr>
        <td class="tdsubheading">&nbsp;&nbsp;Enter Mobile.No
        </td>
        <td>
             <asp:TextBox ID="txtMobile" runat="server" MaxLength="50"></asp:TextBox>
        </td>
        <tr>
            <td class="style1">
                &nbsp;&nbsp;Enter Landline.No</td>
            <td class="style2">
                <asp:TextBox ID="txtLandline" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                &nbsp;Organization Details</td>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Select Customer</td>
            <td>
                <asp:DropDownList ID="drpCustomer" AutoPostBack="true" runat="server" 
                                        Width="160px" 
               ></asp:DropDownList>&nbsp;&nbsp;
           </td>
        </tr>
    </tr>
    <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Select Site</td>
            <td>
                <asp:DropDownList ID="DrpSite" runat="server" Width="160px"   AutoPostBack="true" OnSelectedIndexChanged="DrpSite_SelectedIndexChanged">
                    
                </asp:DropDownList>
           </td>
        </tr>
    <tr>
        <td class="tdsubheading">
            &nbsp;&nbsp;Enter Department Name</td>
        <td>
             <asp:DropDownList ID="DrpDepartment" runat="server" Width="160px"   >
                    
                </asp:DropDownList></td></tr>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;Company</td>
            <td>
                <asp:TextBox ID="txtCompany" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                &nbsp;&nbsp;</td>
           
        </tr>
        <tr>
            <td class="tdsubheading">
                &nbsp;&nbsp;City</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" MaxLength="50" ReadOnly="true"></asp:TextBox>
                &nbsp;</td>
           
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
            <tr>
                <td align="center" background="../images/tdimg.bmp" 
                    style="color:White;font-weight:bold;">
                    &nbsp;&nbsp;</td>
                <td align="left" background="../images/tdimg.bmp" 
                    style="color:White;font-weight:bold;">
                    &nbsp;<asp:Button ID="btnSave" runat="server" onclick="btnSave_Click " 
                        Text="Update" />
                    &nbsp;<asp:Button ID="btnReset" runat="server" CausesValidation="false" 
                        onclick="btnReset_Click" Text="Cancel" />
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

