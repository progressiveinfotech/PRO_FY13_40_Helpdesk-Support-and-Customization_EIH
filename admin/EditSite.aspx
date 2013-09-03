<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="EditSite.aspx.cs" Inherits="admin_EditSite" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  <tr><td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td colspan="5" class="style1"><asp:Label ID="lblErrorMsg" Font-Bold="true" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Update Site</td>
            <td width="80%" align="right" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;</td>
    </tr>
   
    
    <tr style="padding-top:8px;">
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Site Name
        </td>
        <td>
         <asp:TextBox ID="txtSitename" runat="server" MaxLength="100"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValSiteName" runat="server" ControlToValidate="txtSiteName" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> 
        </td>
    </tr>
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Description  
        </td>
        <td >
          
           <asp:TextBox ID="txtSitedesc" runat="server" Height="30px" 
                    Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
            
        </td>
        
    </tr>
   <tr><td class="tdsubheading" align="left"><font class="mandatory">*</font>Customer</td>                             
     <td> <asp:DropDownList ID="drpCustomer" runat="server" Width="155px"></asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCust" runat="server" EnableClientScript="true" ControlToValidate="drpCustomer" ErrorMessage="Select Customer"   InitialValue="0"></asp:RequiredFieldValidator></td>
     
     </tr>
    <tr><td class="tdsubheading" align="left"><font class="mandatory">*</font>Region</td>                             
     <td> <asp:DropDownList ID="drpRegion" runat="server" Width="155px"></asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpRgn" runat="server" EnableClientScript="true" ControlToValidate="drpRegion"    InitialValue="0"></asp:RequiredFieldValidator></td>
     
     </tr>
      <tr><td class="tdsubheading" align="left">&nbsp;&nbsp;Enable</td>                             
     <td> <asp:DropDownList ID="dropEnable" runat="server">
     <asp:ListItem Text="True" Value="1"></asp:ListItem>
     <asp:ListItem Text="False" Value="0"></asp:ListItem>
     </asp:DropDownList></td>
     
     </tr>
       
         <tr>
         <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Site Address</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            
            </td>
         </tr>
         
        <tr style="padding-top:8px;">
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter Address
        </td>
        <td>
        <asp:TextBox ID="txtAddress" Height="30px"    Columns="45" TextMode="MultiLine" runat="server" MaxLength="500"></asp:TextBox> 
        </td>
        </tr>
        <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter City
        </td>
        <td>
        <asp:TextBox ID="txtCity" runat="server" MaxLength="50"></asp:TextBox> 
        </td>
        </tr>
        <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter Postal Code
        </td>
        <td>
        <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="50"></asp:TextBox> 
        </td>
        </tr>
        <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter State
        </td>
        <td>
        <asp:TextBox ID="txtState" runat="server" MaxLength="50"></asp:TextBox> 
        </td>
        </tr>
         <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Select Country
        </td>
        <td>
       <asp:DropDownList ID="drpCountry" runat="server"></asp:DropDownList>
        </td>
        </tr>
         <tr>
         <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Site Information</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            
            </td>
         </tr>
      
        <tr style="padding-top:8px;">
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter Phone No
        </td>
        <td>
        <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="50"></asp:TextBox> 
        </td>
        </tr>
        <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter Fax No
        </td>
        <td>
        <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="50"></asp:TextBox> 
        </td>
        </tr>
        <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter Email Id
        </td>
        <td>
        <asp:TextBox ID="txtEmailId" runat="server" MaxLength="50"></asp:TextBox>&nbsp;
        <asp:RegularExpressionValidator ID="regExtxtEmailId" 
            runat="server" 
            EnableClientScript="true" 
            ControlToValidate="txtEmailId" 
            ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" 
            ErrorMessage="Enter Valid Email-Id">
       </asp:RegularExpressionValidator> 
       
        </td>
        </tr>
        <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter WebSite url
        </td>
        <td>
        <asp:TextBox ID="txtWebSiteUrl" runat="server" MaxLength="100"></asp:TextBox>&nbsp;<asp:RegularExpressionValidator ID="RegExpWebUrl" runat="server" EnableClientScript="true" ControlToValidate="txtWebSiteUrl" ValidationExpression="^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$" ></asp:RegularExpressionValidator>  
        </td>
        </tr>
        <tr >
         <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Person to Contact</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            
            </td>
         </tr>
       
        <tr style="padding-top:8px;">
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter Person Name
        </td>
        <td>
        <asp:TextBox ID="txtPersonName" runat="server" MaxLength="50"></asp:TextBox> 
        </td>
        </tr>
         <tr>
        <td align="left" class="tdsubheading">
        &nbsp;&nbsp;Enter Mobile No
        </td>
        <td>
        <asp:TextBox ID="txtMobileno" runat="server" MaxLength="50"></asp:TextBox> 
        </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

         <asp:Button ID="btnUpdate" runat="server" 
                Text="Update" onclick="btnUpdate_Click"   />      
           <asp:Button ID="btnCancel"  CausesValidation="false"  runat="server" 
                Text="Cancel" onclick="btnCancel_Click"   /> 
               
          </td>
    </tr>
  
      
   
   

</table>
</ContentTemplate>
</asp:UpdatePanel>
 </td></tr>
 </table>
</asp:Content>

