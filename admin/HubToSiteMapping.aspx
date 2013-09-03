<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="HubToSiteMapping.aspx.cs" Inherits="admin_HubToSiteMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr>
     <td>
         <asp:UpdatePanel ID="Subcategorypanel" runat="server">
             <ContentTemplate>
                <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
             </ContentTemplate>
         </asp:UpdatePanel>
     </td>
 </tr>
 <tr><td>
<asp:UpdatePanel ID="Subcategorypane2" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Add Subcategory</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
    <td class="tdsubheading" align="left">
    <font class="mandatory">*</font>Select Site</td>                             
     <td>
     <asp:DropDownList ID="drpSite" AutoPostBack="true" runat="server" Width="155px" 
             onselectedindexchanged="drpSite_SelectedIndexChanged" >
     </asp:DropDownList>&nbsp;
     <asp:RequiredFieldValidator ID="reqValDrpCatg" 
     runat="server" EnableClientScript="true" ControlToValidate="drpSite"  InitialValue="0"> 
     </asp:RequiredFieldValidator> 
     </td>
     </tr>
    
    <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>&nbsp; Hub Name
        </td>
        <td>
          <asp:DropDownList ID="drpHub" AutoPostBack="true" runat="server" 
                Width="155px" >
          
     </asp:DropDownList>
         <%--<asp:TextBox ID="txtSubcategoryName" runat="server" Width="195" MaxLength="50"></asp:TextBox>--%> 
         &nbsp;<asp:RequiredFieldValidator ID="reqValSubcategory" runat="server" ControlToValidate="drpHub" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator></td>
       
    </tr>
   <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnSubcategoryadd" runat="server" 
                Text="Save" onclick="btnSubcategoryadd_Click" />      
           <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" 
                Text="Reset" onclick="btnReset_Click"  />  
               
               
         
           
    
        </td>
    </tr>
  
    <tr><td>&nbsp;</td></tr>
    

   <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
        
   
   

</table>
</ContentTemplate>
</asp:UpdatePanel>
 </td></tr>
 </table>
</asp:Content>


