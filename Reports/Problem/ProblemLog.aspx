<%@ Page Language="C#" MasterPageFile="~/Master/MasterProblem.master" AutoEventWireup="true" CodeFile="ProblemLog.aspx.cs" Inherits="Problem_ProblemLog" Title="Problem Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td><asp:UpdatePanel ID="CategoryPanal1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel></td></tr>
 <tr><td>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
            &nbsp;New Problem</td>
           
    </tr>
    <tr><td>&nbsp;</td></tr>
   
   
    <tr><td>
    <asp:UpdatePanel ID="CategoryPanal2" runat="server">
<ContentTemplate>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
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
   
   
     <tr>
    <td width="10%" align="left">&nbsp; Category</td>
    <td width="18%" align="left">
       <asp:DropDownList ID="drpCategory" Width="170px" 
            AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" >
     
    </asp:DropDownList>
    </td>
    <td width="10%">SubCategory</td>
    <td width="25%" align="left">
    <asp:DropDownList ID="drpSubcategory" Width="170px" runat="server" >
    
    </asp:DropDownList>
    </td>
    </tr>
     <tr>
    
    <td width="10%">&nbsp;Technician</td>
    <td width="25%" align="left">
     <asp:DropDownList ID="drpTechnician" Width="170px" runat="server">
    </asp:DropDownList>
    
    </td>
    <td width="10%">&nbsp;</td>
    <td width="25%" align="left">
    &nbsp;
     <%--<asp:DropDownList ID="drpservices" Width="170px" runat="server">
    
    </asp:DropDownList>--%>
    
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
   
    <tr style="padding-top:15px;">
    <td>
     <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="10%"><font class="mandatory">*</font>User Name</td>
    <td width="25%" align="left">
    <asp:TextBox ID="txtUsername" Width="165px"  runat="server" AutoPostBack="true" ontextchanged="txtUsername_TextChanged"> 
             </asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsername" ForeColor="Red" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
    </td>
    <td width="10%"><font class="mandatory">*</font>Email</td>
    <td width="25%" align="left">
   <asp:TextBox ID="txtEmail" Width="165px"  runat="server"></asp:TextBox>
    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqvalEmail" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>
   &nbsp;<asp:RegularExpressionValidator ID="regExtxtEmailId" runat="server" EnableClientScript="true" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ErrorMessage="Enter Valid Email-Id"></asp:RegularExpressionValidator>
    </td>
    </tr>
    
   </table> 
    </td>
    </tr> 
   
   
    <tr><td>&nbsp;</td></tr>
     
      
        
<tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;Problem Details</td></tr>
<tr><td>&nbsp;</td></tr>
         <tr>
         <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
         
          <tr>
   
    
   
    <td><font class="mandatory">*</font>Title</td>
     <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="txtTitle" runat="server" Width="350px"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValSubject" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="Enter Subject"></asp:RequiredFieldValidator></td>
    </tr>
    
     <tr>
    <td>&nbsp;&nbsp;Description</td>
     <td colspan="3">
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="50px" runat="server" Width="685px"></asp:TextBox>
     
     
     </td>
    </tr>
    
         </table>
           </ContentTemplate>
          </asp:UpdatePanel>
         </td>
         
         </tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
          <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnAdd" runat="server" Text="Add Problem"  OnClick="btnAdd_Click"
                 />&nbsp;&nbsp;
            <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset"  OnClick="btnReset_Click" />
            </ContentTemplate>
          </asp:UpdatePanel>
            </td>
         </tr>
    
    
      <tr><td>&nbsp;</td></tr>
  
  
  
    <tr><td>&nbsp;</td></td></tr> 
    
    <tr><td align="center"> 
   
       
        </td></tr>
       

 
        
   
   

</table>

 </td></tr>
 </table>
 
</asp:Content>

