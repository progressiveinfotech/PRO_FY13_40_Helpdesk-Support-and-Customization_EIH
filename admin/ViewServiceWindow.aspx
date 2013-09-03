<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="ViewServiceWindow.aspx.cs" Inherits="admin_ViewServiceWindow" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
     <tr>
     <td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td>
            <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
        </td>
        </tr>
     <tr>
     <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
        &nbsp;&nbsp;Service Window
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:LinkButton ID="lnkAddServiceWindow" runat="server" ForeColor="White" 
             Text="[Add Service Window]" onclick="lnkAddServiceWindow_Click"></asp:LinkButton>
     </td>
     </tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
     <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select Customer &nbsp;
        <asp:DropDownList ID="drpRegion" AutoPostBack="true" runat="server" Width="155px" onselectedindexchanged="drpRegion_SelectedIndexChanged">
        </asp:DropDownList>
     </td>
     </tr>
    
     <tr><td>&nbsp;</td></tr>
     
     <tr>
     <td align="center" width="80%">
    
     <asp:GridView ID="grdvwViewServiceWindow" runat="server"  CssClass="grid-view"              
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            OnRowDataBound="grdvwViewServiceWindow_RowDataBound" OnRowEditing="grdvwViewServiceWindow_RowEditing"
            OnRowDeleting="grdvwViewServiceWindow_RowDeleting"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  
            BorderStyle="None" BorderWidth="1px" Width="984px"   
            PageSize="10" AllowPaging="true" onpageindexchanging="grdvwViewServiceWindow_PageIndexChanging"  
           >
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            
     <Columns>
     
         <asp:BoundField HeaderText="Service Window Id" HeaderStyle-Width="200px"  DataField="ServiceWindowid" ReadOnly="true" />
         <asp:BoundField HeaderText="Site Name" HeaderStyle-Width="300px" DataField="siteid" ReadOnly="true" />
         <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"   />
         <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false"   />
         
     </Columns>
    
    <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
    <HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
    <AlternatingRowStyle  BackColor="Silver" />
    </asp:GridView>
    
        </td>
        </tr>
        </table> 
    </ContentTemplate> 
    </asp:UpdatePanel> 
    </td> 
    </tr> 
    </table> 
</asp:Content>

