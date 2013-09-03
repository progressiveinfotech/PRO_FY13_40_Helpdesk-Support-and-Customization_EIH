<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="Vendor.aspx.cs" Inherits="admin_Vendor" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr>
     <td>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
             </ContentTemplate>
         </asp:UpdatePanel>
     </td>
 </tr>
 <tr><td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Add Vendor</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Vendor Name
        </td>
        <td>
         
         <asp:TextBox ID="txtvendorname" runat="server" Height="20px" MaxLength="70">
         </asp:TextBox> &nbsp;
         <asp:RequiredFieldValidator ID="reqValVendor" runat="server" 
            ControlToValidate="txtvendorname" EnableClientScript="true"  
            SetFocusOnError="true"  ForeColor="Red">
         </asp:RequiredFieldValidator></td>
       
    </tr>
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Contact Person 
        </td>
        <td >
          
           <asp:TextBox ID="txtcontactperson" runat="server" Height="20px" MaxLength="70" >
           </asp:TextBox>
            
        </td>
        
    </tr>
   
    <tr><td class="tdsubheading" align="left">&nbsp;</td>                             
     <td> &nbsp;</td></tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnVendoradd" runat="server" onclick="btnVendoradd_Click" 
                Text="Save"  />      
           <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" 
                Text="Reset" onclick="btnReset_Click" />  
               
               
         
           
    
        </td>
    </tr>
        <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td colspan="5" align="center"> 
     <asp:GridView ID="Vendorgrdw" runat="server" CssClass="grid-view"  AutoGenerateColumns="false" CellPadding="0" ForeColor="Black"  CellSpacing="0" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" Width="984px" 
           OnRowDeleting="Vendorgrdw_RowDeleting" OnRowEditing="Vendorgrdw_RowEditing" OnRowCancelingEdit="Vendorgrdw_RowCancelingEdit" 
            OnRowUpdating="Vendorgrdw_RowUpdating"  OnPageIndexChanging="Vendrogrdw_Pageindexchanging"
            onselectedindexchanged="Vendorgrdw_SelectedIndexChanged"  PageSize="8" AllowPaging="true" >
      
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     
            
     <Columns>
    
         
          <asp:BoundField HeaderText="Vendor ID"  DataField="vendorid" ReadOnly="true" />
        
         <asp:TemplateField HeaderText="Vendor Name" >
      <ItemTemplate><asp:Label ID="lblvendorame" Text='<%# Eval("vendorname") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtRegionName" runat="server" Text='<%# Bind("vendorname") %>' MaxLength="50"></asp:TextBox>

</EditItemTemplate>
     </asp:TemplateField>
       
          
          
          <asp:TemplateField HeaderText="Contact Name" >
           
      <ItemTemplate><asp:Label ID="lblcontactprsondesc" Text='<%# Eval("contactperson") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtcontactprson" runat="server" Text='<%# Bind("contactperson") %>' ></asp:TextBox>

</EditItemTemplate></asp:TemplateField> 
     <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"  />
           <asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />
     
     
        
     </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 
           
           
 
        </asp:GridView>
        </td></tr>
   
       

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

