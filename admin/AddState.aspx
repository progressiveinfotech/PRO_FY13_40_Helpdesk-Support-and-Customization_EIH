<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddState.aspx.cs" Inherits="admin_AddState" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td><asp:UpdatePanel ID="Subcategorypanel" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel></td></tr>
 
 <tr><td>
<asp:UpdatePanel ID="Subcategorypane2" runat="server">
<ContentTemplate>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Add State</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>State Name
        </td>
        <td>
         
         <asp:TextBox ID="txtStateName" runat="server" MaxLength="50"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValtxtStateName" runat="server" ControlToValidate="txtStateName" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> 
         
            
        </td>
       
    </tr>
   
   
    <tr><td class="tdsubheading" align="left">&nbsp;&nbsp;Select Country</td>                             
     <td><asp:DropDownList ID="drpCountry" runat="server"></asp:DropDownList> </td></tr>
     <tr><td>&nbsp;</td></tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnAdd" runat="server" 
                Text="Save" onclick="btnAdd_Click"   />      
           <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" 
                Text="Reset" onclick="btnReset_Click"  />  
               
               
         
           
    
        </td>
    </tr>
  
    <tr><td>&nbsp;</td></tr>
    <tr><td colspan="5" align="center"> 
       <asp:GridView ID="grvwObj" runat="server"  CssClass="grid-view"
             
             OnPageIndexChanging="grvwObj_PageIndexChanging" OnRowDeleting="grvwObj_RowDeleting"
             OnRowDataBound="grvwObj_RowDataBound" OnRowEditing="grvwObj_RowEditing" OnRowCancelingEdit="grvwObj_RowCancelingEdit"
               OnRowUpdating="grvwObj_RowUpdating"
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
             BorderStyle="None" BorderWidth="1px" Width="984px" 
           PageSize="15" AllowPaging="true">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            
     <Columns>
    
         
          <asp:BoundField HeaderText="State Id"  DataField="stateid" ReadOnly="true" />
          <asp:TemplateField HeaderText="State Name" >
      <ItemTemplate><asp:Label ID="lblstatename" Text='<%# Eval("statename") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtstatename" runat="server" Text='<%# Bind("statename") %>' MaxLength="50"></asp:TextBox>

</EditItemTemplate>
     </asp:TemplateField>
            
          
     <asp:TemplateField HeaderText="Country Name">
     <ItemTemplate><asp:label id="lblCountry" runat="server" Text='<%# Eval("countryid") %>'  /></ItemTemplate>
     <EditItemTemplate>
            
           <asp:DropDownList ID="dropCountry" runat="server"></asp:DropDownList>


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
        
   
   

</table>
</ContentTemplate>
</asp:UpdatePanel>
 </td></tr>
 </table>



</asp:Content>

 