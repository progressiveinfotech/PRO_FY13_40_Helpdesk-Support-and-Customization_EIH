<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddTitle.aspx.cs" Inherits="admin_AddTitle" Title="Untitled Page" %>

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
            &nbsp;Add Title</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
      
    <tr>
    <td class="tdsubheading" align="left">
    <font class="mandatory">*</font>Select Category</td>                             
     <td>
     <asp:DropDownList ID="drpCategory" AutoPostBack="true" runat="server" Width="155px" 
          onselectedindexchanged="drpCategory_SelectedIndexChanged">
     </asp:DropDownList>&nbsp;
     <asp:RequiredFieldValidator ID="reqValDrpCatg" 
     runat="server" EnableClientScript="true" ControlToValidate="drpCategory"  InitialValue="0"> 
     </asp:RequiredFieldValidator> 
     </td>
     </tr>
     <tr>
    <td class="tdsubheading" align="left">
    <font class="mandatory">*</font>Select Subcategory</td>                             
     <td>
     <asp:DropDownList ID="drpsubcategory"  runat="server" Width="155px" 
          >
     </asp:DropDownList>&nbsp;
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
     runat="server" EnableClientScript="true" ControlToValidate="drpsubcategory"  InitialValue="0"> 
     </asp:RequiredFieldValidator> 
     </td>
     </tr>
    
    
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Title
        </td>
        <td >
          
           <asp:TextBox ID="txttitle" runat="server" Height="30px" 
                    Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
            
        </td>
        
    </tr>
   <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnSubcategoryadd" runat="server" 
                Text="Save" onclick="btnSubcategoryadd_Click"   />      
           
               
               
         
           
    
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

