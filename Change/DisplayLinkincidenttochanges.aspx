<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayLinkincidenttochanges.aspx.cs" Inherits="Change_DisplayLinkincidenttochanges" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Link Incident To Change</title>
     <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
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
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td>
     <asp:UpdatePanel ID="updatepanel3" runat="server"><ContentTemplate>
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td>&nbsp;</td></tr>
    <tr>
    <td>&nbsp;&nbsp;<asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label></td>
    </tr>
     <tr>
        <td  class="tdheader" >
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;All Changes
        <td class="tdheader" align="right" >&nbsp;&nbsp;&nbsp;</td>
            
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td colspan="2">&nbsp;&nbsp;<asp:Button ID="btnAttach" runat="server" 
            Text="Attach to Change" onclick="btnAttach_Click" />&nbsp;&nbsp;<asp:Button 
            ID="btnReset" runat="server" Text=" Reset " onclick="btnReset_Click" /></td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td align="center"  colspan="2">
    
   <asp:GridView ID="grdvwChange" runat="server"  CssClass="grid-view"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="1px" 
           OnPageIndexChanging="grdvwChange_PageIndexChanging" OnRowDataBound="grdvwChange_RowDataBound"
           PageSize="20" AllowPaging=true Width="984px">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
     <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
     </HeaderTemplate>
     <ItemTemplate>
    <asp:Label ID="Changeid" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "Changeid") %>'
    runat="server" />
    <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                           runat="server" />
</ItemTemplate>
</asp:TemplateField>
            <asp:BoundField HeaderText="Id"  DataField="Changeid" ReadOnly="true" />
            <asp:BoundField HeaderText="Title"  DataField="Title" ReadOnly="true" />
            <asp:BoundField HeaderText="Requester Name" DataField="RequestedBy" ReadOnly="true"  />
            <asp:BoundField HeaderText="Created By" DataField="CreatedByID" ReadOnly="true"  />
            <asp:BoundField HeaderText="Assigned to" DataField="Technician" ReadOnly="true"  />
            <asp:BoundField HeaderText="Status" DataField="Statusid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Priority" DataField="Priority" ReadOnly="true"  />
             <asp:BoundField HeaderText="Category" DataField="Categoryid" ReadOnly="true"  />
            <asp:BoundField HeaderText="CreatedDate" DataField="CreatedTime" ReadOnly="true"  />
            
        <%-- <asp:CommandField ShowEditButton="True" HeaderText="View Details" EditText="View Details" CausesValidation="false"   />--%>
        
         
    </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 </asp:GridView>
    
    </td></tr>
    
    
   </table> 
</ContentTemplate></asp:UpdatePanel> 
    </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td align="center"><asp:Button ID="btnClose" runat="server" OnClientClick="javascript:window.close();" Text="Close" /></td>
    </tr>
    </table>
    

    </div>
   

   
</form>
</body>
</html>
