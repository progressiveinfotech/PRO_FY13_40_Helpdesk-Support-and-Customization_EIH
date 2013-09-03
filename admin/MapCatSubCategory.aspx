<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="MapCatSubCategory.aspx.cs" Inherits="admin_MapCatSubCategory" Title="Untitled Page" %>

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
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Subcategory Name
        </td>
        <td>
          <asp:DropDownList ID="drpSubCategory" AutoPostBack="true" runat="server" 
                Width="155px" onselectedindexchanged="drpSubCategory_SelectedIndexChanged" >
          
     </asp:DropDownList>
         <%--<asp:TextBox ID="txtSubcategoryName" runat="server" Width="195" MaxLength="50"></asp:TextBox>--%> 
         &nbsp;<asp:RequiredFieldValidator ID="reqValSubcategory" runat="server" ControlToValidate="drpSubCategory" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator></td>
       
    </tr>
    <tr>
        <td align="left" class="tdsubheading">
            &nbsp;&nbsp;Assign To  
        </td>
        <td >
          
            <asp:DropDownList ID="drpUserList" runat="server" Width="155px">
            </asp:DropDownList>
            
        </td>
        
    </tr>
   <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnSubcategoryadd" runat="server" 
                Text="Save" onclick="btnSubcategoryadd_Click"  />      
           <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" 
                Text="Reset" onclick="btnReset_Click"  />  
               
               
         
           
    
        </td>
    </tr>
  
    <tr><td>&nbsp;</td></tr>
    
    <tr><td colspan="5" align="center"> 
       <asp:GridView ID="subcategorygrdvw" runat="server"  CssClass="grid-view"
            
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
             BorderStyle="None" BorderWidth="1px" Width="984px" 
           PageSize="3" AllowPaging="true">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            
     <Columns>
    
         
          <asp:BoundField HeaderText="Subcategory Id"  DataField="subcategoryid" ReadOnly="true" />
         <%-- <asp:BoundField HeaderText="Region Name"    DataField="RegionName" />--%>
        <asp:TemplateField HeaderText="Subcategory Name" >
      <ItemTemplate><asp:Label ID="lblcategoryname" Text='<%# Eval("subcategoryname") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtcategoryName" runat="server" Text='<%# Bind("subcategoryname") %>' MaxLength="50"></asp:TextBox>

</EditItemTemplate>
     </asp:TemplateField>
       
          
       <%--   <asp:BoundField HeaderText="Organization Name"  />--%>
           <%--<asp:BoundField HeaderText="Description" DataField="subcategorydescription" />--%>
          <asp:TemplateField HeaderText="Subcategory Description" >
      <ItemTemplate><asp:Label ID="lblRegiondesc" Text='<%# Eval("subcategorydescription") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtRegiondesc" runat="server" Text='<%# Bind("subcategorydescription") %>' MaxLength="500"></asp:TextBox>

</EditItemTemplate>
 </asp:TemplateField>
     <asp:TemplateField HeaderText="Category Name">
     <ItemTemplate>
     <asp:label id="lblcategory" runat="server" Text='<%# Eval("categoryid") %>'  />
     </ItemTemplate>
     
<EditItemTemplate> 

          <asp:DropDownList ID="drpcategoryname" runat="server"></asp:DropDownList>
           
</EditItemTemplate>
     </asp:TemplateField>

       
           
            <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"   />
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

