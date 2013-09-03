<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="UserToMultipleSiteMapping.aspx.cs" Inherits="admin_UserToMultipleSiteMapping" Title="Untitled Page" %>

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
                if (ValId.indexOf('chkbxcheckall') != -1) {
                    // Check if main checkbox is checked,
                    // then select or deselect datagrid checkboxes
                    if (ValChecked)
                        frm.elements[i].checked = true;
                    else
                        frm.elements[i].checked = false;
                }
                else if (ValId.indexOf('chkbxcheck') != -1) {
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
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  <tr>
    <td>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>
    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
    </ContentTemplate> </asp:UpdatePanel> 
    </td>
        </tr>
     <tr><td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
 <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
   <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="17%"> &nbsp;User to Sites Mapping </td>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="83%">&nbsp;</td>
            
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td>&nbsp;&nbsp;Select Site</td>
    <td><asp:DropDownList ID="drpRegion"  runat="server" width="155px" 
            AutoPostBack="True" onselectedindexchanged="drpRegion_SelectedIndexChanged"
            ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
    </tr>
   
    
    <tr>
    
      <td></td></tr>
     <tr>
         <td align="right" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
             &nbsp;&nbsp;</td>
         <td align="left" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
             &nbsp;&nbsp;<asp:Button 
            ID="btnMapping" runat="server" Text="Map" onclick="btnMapping_Click" />
            &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text=" Reset "  CausesValidation="false"
                 onclick="btnReset_Click" />
            </td>
     </tr>
         </table> 
    
</ContentTemplate> 
</asp:UpdatePanel></td></tr> 
<tr><td>&nbsp;</td></tr>
<tr>
<td align="center">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:GridView ID="grdvwSitetest" runat="server"  CssClass="grid-view" DataKeyNames="UserId"
             AutoGenerateColumns="false" OnPageIndexChanging="grdvwSitetest_PageIndexChanging"             
            CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  
             BorderStyle="None" BorderWidth="1px" Width="984px"   
             PageSize="15" AllowPaging=true 
       onrowdatabound="grdvwSitetest_RowDataBound"
        >
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/> 
<Columns>
<asp:TemplateField>
<HeaderTemplate>
<asp:CheckBox ID="chkbxcheckall" onclick="return check_uncheck (this )" runat="server" />
</HeaderTemplate>
<ItemTemplate>
<%--<asp:Label ID="SiteID" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "siteid") %>'
    runat="server" />--%>
<asp:CheckBox ID="chkbxcheck" runat="server" />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField >
<ItemTemplate>
<asp:Label ID="Lbluserid" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<%--<asp:BoundField HeaderText="User Id" DataField="UserId" ReadOnly="true" />--%>
<asp:BoundField HeaderText="User Name" DataField="Username" ReadOnly="true" />
 <asp:BoundField HeaderText="Enable" DataField="enable" ReadOnly="true"  />
 <asp:BoundField HeaderText="CreateDatetime" DataField="createdatetime" ReadOnly="true"  />
           
</Columns>     
<PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
<SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
</asp:GridView>
</ContentTemplate> 
</asp:UpdatePanel>
</td>
</tr>
<tr><td>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
</asp:UpdatePanel>

</td></tr>
    </table> 
</asp:Content>

