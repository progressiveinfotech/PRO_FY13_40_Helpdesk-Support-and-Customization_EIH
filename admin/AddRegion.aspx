<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddRegion.aspx.cs" Inherits="admin_AddRegion" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td>
    <asp:UpdatePanel runat="server">
         <ContentTemplate>
            <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
         </ContentTemplate>
    </asp:UpdatePanel>
 </td></tr>
 <tr><td>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Add Region</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Region Name
        </td>
        <td>
         
         <asp:TextBox ID="txtregionname" runat="server" MaxLength="50"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValRegion" runat="server" ControlToValidate="txtregionname" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator></td>
       
    </tr>
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Description  
        </td>
        <td >
          
           <asp:TextBox ID="txtregiondesc" runat="server" Height="30px" 
                    Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
            
        </td>
        
    </tr>
   
    <tr><td class="tdsubheading" align="left">&nbsp;</td>                             
     <td> &nbsp;</td></tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnregionadd" runat="server" onclick="btnRegionadd_Click" 
                Text="Save"  />      
           <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" 
                Text="Reset" onclick="btnReset_Click" />  
               
               
         
           
    
        </td>
    </tr>
  
    <tr><td>&nbsp;</td></td>
    <tr><td>&nbsp;</td></td>

    <tr><td colspan="5" align="center"> 
       <asp:GridView ID="Regiongrdvw" runat="server"  CssClass="grid-view"
           OnRowDeleting="Regiongrdvw_RowDeleting" OnRowEditing="Regiongrdvw_RowEditing" OnRowCancelingEdit="Regiongrdvw_RowCancelingEdit" 
            OnRowUpdating="Regiongrdvw_RowUpdating"   OnPageIndexChanging="Regiongrdvw_PageIndexChanging"   OnRowCreated="Regiongrdvw_OnRowCreated" OnRowDataBound="Regiongrdvw_RowDataBound" 
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
             BorderStyle="None" BorderWidth="1px" Width="984px" 
           PageSize="10" AllowPaging=true>
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            
     <Columns>
    
         
          <asp:BoundField HeaderText="Region Id"  DataField="Regionid" ReadOnly="true" />
         <%-- <asp:BoundField HeaderText="Region Name"    DataField="RegionName" />--%>
         <asp:TemplateField HeaderText="Region Name" >
      <ItemTemplate><asp:Label ID="lblregionname" Text='<%# Eval("RegionName") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtRegionName" runat="server" Text='<%# Bind("RegionName") %>' MaxLength="50"></asp:TextBox>

</EditItemTemplate>
     </asp:TemplateField>
       
          <%--<asp:BoundField HeaderText="Organization ID" DataField="Orgid" ReadOnly="true"  />--%>
          <asp:BoundField HeaderText="Organization Name"  />
           <%--asp:BoundField HeaderText="Description" DataField="Description" />--%>
            <asp:TemplateField HeaderText="Description Name" >
      <ItemTemplate><asp:Label ID="lblRegiondesc" Text='<%# Eval("Description") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtRegiondesc" runat="server" Text='<%# Bind("Description") %>' MaxLength="500"></asp:TextBox>

</EditItemTemplate>
     </asp:TemplateField>
            <asp:BoundField HeaderText="CreateDateTime" DataField="Createdatetime" ReadOnly="true"  />
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

