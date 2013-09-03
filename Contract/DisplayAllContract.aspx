<%@ Page Language="C#" MasterPageFile="~/Master/MasterContract.master" AutoEventWireup="true" CodeFile="DisplayAllContract.aspx.cs" Inherits="Contract_DisplayAllContract" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">

    function check_uncheck(Val) {
        var ValChecked = Val.checked;
        var ValId = Val.id;
        var frm = document.forms[0];
        // Loop through all elements
        for (i = 0; i < frm.length; i++) {
            // Look for Header Template's Checkbox
            //As we have not other control other than checkbox we just check following statement
            if (this != null) {
                if (ValId.indexOf('CheckAll') != -1) {
                    // Check if main checkbox is checked,
                    // then select or deselect datagrid checkboxes
                    if (ValChecked)
                        frm.elements[i].checked = true;
                    else
                        frm.elements[i].checked = false;
                }
                else if (ValId.indexOf('deleteRec') != -1) {
                    // Check if any of the checkboxes are not checked, and then uncheck top select all checkbox
                    if (frm.elements[i].checked == false)
                        frm.elements[1].checked = false;
                }
            } // if
        } // for
    } // function



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
 <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
            &nbsp;Contracts</td>
           
    </tr>
   
     <tr style="padding-top:10px;">
        <td >
            &nbsp;&nbsp;<b>Showing</b>&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="drpFilter" AutoPostBack="true" runat="server" 
                onselectedindexchanged="drpFilter_SelectedIndexChanged">
            <asp:ListItem Text="Open Contracts" Value="1"></asp:ListItem>
            <asp:ListItem Text="All Expired Contracts" Value="2"></asp:ListItem>
            <asp:ListItem Text="Contracts Expired in last 7 Days" Value="3"></asp:ListItem>
            <asp:ListItem Text="Contracts Expiring in next 7 Days" Value="4"></asp:ListItem>
             <asp:ListItem Text="Contracts Expiring in next 15 Days" Value="5"></asp:ListItem>
            </asp:DropDownList>
            </td>
           
    </tr>
      <tr><td>&nbsp;</td></tr>
    <tr>
    <td align="center">
     <asp:GridView ID="grvwContract" runat="server"  CssClass="grid-view"
     OnRowDataBound="grvwContract_RowDataBound" OnRowEditing="grvwContract_RowEditing" OnRowDeleting="grvwContract_RowDeleting"
              AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
             BorderStyle="None" BorderWidth="1px" Width="984px" 
           PageSize="10" AllowPaging=true>
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            
     <Columns>
     <asp:TemplateField>
           <HeaderTemplate>
     <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
     </HeaderTemplate>
     <ItemTemplate>
    <asp:Label ID="contractid" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "contractid") %>' runat="server" />
    <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                           runat="server" />
    </ItemTemplate>
    </asp:TemplateField>
          <asp:BoundField HeaderText="Contract Id"  DataField="contractid" ReadOnly="true" />
          <asp:BoundField HeaderText="Contract Name" DataField="contractName" ReadOnly="true"  />
          <asp:BoundField HeaderText="From Date" DataField="activefrom" ReadOnly="true"  />
          <asp:BoundField HeaderText="To Date" DataField="activeTo" ReadOnly="true"  />
          <asp:BoundField HeaderText="Maintenance Vendor" DataField="vendorid" ReadOnly="true"  />
            <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
            <asp:Label ID="lblActive"  runat="server" ></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
          
          <asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="View Details"  DeleteText="View Details" CausesValidation="false" />
           <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"   />
           
        
     </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 
           
           
 
        </asp:GridView>
    </td>
    </tr>
    <tr height="4px"><td >&nbsp;</td></tr>
     <tr>
        <td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
            &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button  ID="btnDelete" runat="server" 
                Text="Delete" onclick="btnDelete_Click" />
                &nbsp;&nbsp;<asp:Button ID="btnRenew" runat="server" Text="Renew Contract" 
                onclick="btnRenew_Click" />
                </td>
           
    </tr>
    <tr><td>
   </td></tr>
   
 
 </table> 
</ContentTemplate> 
</asp:UpdatePanel> 
</asp:Content>

