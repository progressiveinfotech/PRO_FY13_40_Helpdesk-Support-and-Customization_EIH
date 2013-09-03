﻿<%@ Page Language="C#" MasterPageFile="~/Master/MasterUser.master" AutoEventWireup="true" CodeFile="Usercall.aspx.cs" Inherits="Login_Usercall" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td>
 <asp:UpdatePanel ID="CategoryPanal1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel>
 
 </td></tr>
 <tr><td>


    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr id="trtn" runat="server" visible="false">
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;New Ticket</td>
           
    </tr>
   
    <tr id="trnt" runat="server" visible="false" style="padding-top:17px;"><td>
    <asp:UpdatePanel ID="CategoryPanal2" runat="server">
<ContentTemplate>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="10%">&nbsp;&nbsp;Call type</td>
    <td width="18%" align="left"><asp:DropDownList Width="170px" ID="drpRequestType" runat="server">
    
    </asp:DropDownList></td>
    <td width="10%">Mode</td>
    <td width="25%" align="left">
     <asp:DropDownList ID="drpMode" Width="170px" runat="server">
    </asp:DropDownList>
    
    </td>
    </tr>
    <tr>
    <td width="10%">&nbsp;&nbsp;Status</td>
    <td width="18%" align="left"><asp:DropDownList Width="170px" ID="drpStatus" runat="server">
    
    </asp:DropDownList></td>
    <td width="10%">Priority</td>
    <td width="25%" align="left">
   <asp:DropDownList ID="drpPriority" Width="170px" runat="server">
     
    </asp:DropDownList>
    </td>
    </tr>
    
    </table>
  
    </ContentTemplate>
</asp:UpdatePanel>
    
    </td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Requester Details</td>
           
    </tr>
   
    <tr style="padding-top:17px;">
    <td>
     <table width="100%"  cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td style="width:135px;" ><font class="mandatory">*</font>User Name</td>
    <td  align="left">
    <asp:TextBox ID="txtUsername" Enabled="false" Width="165px"  runat="server" AutoPostBack="true" 
             ></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValUserName" runat="server" ControlToValidate="txtUsername" ForeColor="Red" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
    </td>
    
     <td></td>
    <td align="left">
     </td>
    </tr>
    <tr style="height:15px;"><td></td></tr>
    <tr>
    <td style="width:135px;"><font class="mandatory">*</font>Email</td>
    <td align="left">
   <asp:TextBox ID="txtEmail" Width="165px" Enabled="false"  runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator ID="regExtxtEmailId" runat="server" EnableClientScript="true" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ErrorMessage="Enter Valid Email-Id"></asp:RegularExpressionValidator>
   
  
    </td>
   <td></td>
    <td align="left">
     </td>
    
    </tr>
    <tr style="height:15px;"><td></td></tr>
    <tr>
    <td style="width:133px;">Assigned Asset</td>
    <td  align="left">
        <asp:TextBox ID="txtassignasset" Width="165px"  runat="server" ReadOnly ="true"></asp:TextBox>
  
       
      
  
    </td>
   <td></td>
    <td align="left">
     </td>
    
    </tr>
   </table> 
    </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
       <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Other Details</td>
         </tr>
       
         <tr style="padding-top:17px;">
         <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <table width="100%"  cellpadding="0" cellspacing="0" border="0">
         <tr id="trcustomer" runat="server" visible="false">
    <td ><font class="mandatory">*</font>Customer</td>
    <td align="left">
    <asp:DropDownList ID="drpCustomer" Width="170px" AutoPostBack="true" runat="server" onselectedindexchanged="drpCustomer_SelectedIndexChanged" 
             >
    
    </asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCustomer" runat="server" EnableClientScript="true" ControlToValidate="drpCustomer"  ErrorMessage="Select Customer"  InitialValue="0"></asp:RequiredFieldValidator></td>
    <td></td>
    <td align="left">
     </td>
    </tr>
    </table>
     <table width="100%"  cellpadding="0" cellspacing="0" border="0">
    <tr valign="top"><td><font class="mandatory">*</font>Location</td><td align="left"> <asp:DropDownList ID="drpSite" Width="170px" AutoPostBack="true" runat="server" 
            >
    
    </asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="true" ControlToValidate="drpSite"  ErrorMessage="Select Location"  InitialValue="0"></asp:RequiredFieldValidator>
  </td><td>Phone Number</td>
   <td align="left"><asp:TextBox ID="TxtExtension" Width="170px" runat="server"></asp:TextBox></td></tr>
          <%--<tr>
    <td>&nbsp;&nbsp;Technician</td>
    <td align="left">
    
  <asp:DropDownList ID="drpTechnician" Width="170px" runat="server">
    
    </asp:DropDownList>
    </td>
    <td>Department</td>
    <td align="left">
    <asp:DropDownList ID="drpDepartment" Width="170px" runat="server">
    
    </asp:DropDownList>
    </td>
    </tr>--%>
          <tr valign="top">
    <td width="10%"><font class="mandatory">*</font>Category</td>
    <td width="18%" align="left">
    <asp:DropDownList ID="drpCategory" Width="170px" AutoPostBack="true" runat="server" 
            onselectedindexchanged="drpCategory_SelectedIndexChanged" >
            
     
    </asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCategory" runat="server" EnableClientScript="true" ControlToValidate="drpCategory"  ErrorMessage="Select Category"  InitialValue="0"></asp:RequiredFieldValidator></td>
    <td width="10%"><font class="mandatory">*</font>Sub Category</td>
    <td width="25%" align="left">
    <asp:DropDownList ID="drpSubcategory" Width="170px" runat="server">
    
    </asp:DropDownList>&nbsp;
    <asp:RequiredFieldValidator ID="reqValdrpSubCategory" runat="server" EnableClientScript="true" ControlToValidate="drpSubcategory"  ErrorMessage="Select Sub Category"  InitialValue="0"></asp:RequiredFieldValidator>
    </td>
    </tr>
    
   <tr valign="top">
    <td><font class="mandatory">*</font>Title</td>
     <td colspan="3"><asp:TextBox ID="txtTitle" runat="server" Width="620px"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValSubject" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="Enter Title"></asp:RequiredFieldValidator>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
        </td>
    </tr>
    
     <tr valign="top">
    <td>&nbsp;&nbsp;Description</td>
     <td colspan="3"><asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="50px" runat="server" Width="620px"></asp:TextBox>
     
     
     </td>
    </tr>
    <tr style="height:15px;"><td></td></tr>
    <tr valign="top"><td>&nbsp; Upload File</td><td> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
    <td></td>
   <td align="left"></td>
    </tr>
         </table>
           </ContentTemplate>
          </asp:UpdatePanel>
         </td>
         
         </tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
          <tr>
        <td  background="../images/tdimg.bmp" align="center">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnAdd" runat="server" Text="Add Request" onclick="btnAdd_Click" 
                />&nbsp;&nbsp;
            <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset" 
                    />
            </ContentTemplate>
              <Triggers>
                    <asp:PostBackTrigger ControlID="btnAdd" />
                </Triggers>
               

          </asp:UpdatePanel>
            </td>
         </tr>
    
    
    
    <tr><td align="center"> 
   
       
        </td></tr>
       

 
        
   
   

</table>

 </td></tr>
 </table>

</asp:Content>

