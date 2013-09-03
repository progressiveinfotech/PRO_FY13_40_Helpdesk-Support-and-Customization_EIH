<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="ViewCI.aspx.cs" Inherits="CMDB_ViewCI" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="100%">View CI
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;
   
    
    <asp:LinkButton ID="lnkadd" runat="server" Text="[Add CI]" Font-Bold="true" ForeColor="White" OnClick="lnkadd_Click"></asp:LinkButton>
    
    
    </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="100%">Select Item&nbsp;&nbsp;<asp:DropDownList ID="drpitem" runat="server"  OnSelectedIndexChanged="drpitem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>  </tr>
    <tr>
    <td> <asp:GridView ID="grdvwCI" runat="server"  CssClass="grid-view"  OnRowDataBound="grdvwCI_RowDataBound" 
   
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="1px" 
          
           PageSize="20" AllowPaging=true Width="984px"   >
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            <Columns>
            <asp:HyperLinkField  HeaderText="ItemId" DataTextField="Itemid" 
           DataNavigateUrlFields="ItemId" datanavigateurlformatstring="~/cmdb/EditCI.aspx?itemid={0}" />
          <asp:BoundField HeaderText="ItemId" DataField="Itemid" ReadOnly="true" />
            <asp:BoundField HeaderText="Param1" DataField="Param1" ReadOnly="true" />
            <asp:BoundField HeaderText="Param2" DataField="Param2" ReadOnly="true"  />
            <asp:BoundField HeaderText="Param3" DataField="Param3" ReadOnly="true"  />
            <asp:BoundField HeaderText="Param4" DataField="Param4" ReadOnly="true"  />
            <asp:BoundField HeaderText="Param5" DataField="Param5" ReadOnly="true"  />
            <asp:BoundField HeaderText="Param6" DataField="Param6" ReadOnly="true"  />
       </Columns>
       
         <EmptyDataTemplate >
 <table  cellpadding="1" cellspacing="1" width="100%" >
<tr>
<td class="tdheader" > Id </td><td class="tdheader">Param1</td><td class="tdheader">Param2</td><td class="tdheader">Param3</td><td class="tdheader">Param4</td><td class="tdheader">Param5</td><td class="tdheader">Param6</td>

</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td> No record Found</td>
<td></td>
<td></td>
<td></td>
<td></td>

</tr>


</table>
</EmptyDataTemplate>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />   
            </asp:GridView>
            </td>
    </tr>
  
    
    
    
    </table>
</asp:Content>

