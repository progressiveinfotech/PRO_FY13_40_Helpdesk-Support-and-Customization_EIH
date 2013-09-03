<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EscalateUsersList.aspx.cs" Inherits="admin_EscalateUsersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <link type="text/css" href="../Include/section.css" rel="Stylesheet" />
     <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="../Include/MasterJSFile.js"></script>
    <script type="text/javascript" language="javascript">
    function refreshParent() {
  window.opener.location.href = window.opener.location.href;

  if (window.opener.progressWindow)
		
 {
    window.opener.progressWindow.close()
  }
  window.close();
}
    
    </script>
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
      <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr><td>&nbsp;</td></tr>
    <tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;&nbsp;Select Users</td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td align="left" style="padding-left:5px;" >
   
           <asp:GridView ID="grdvwEscalate" runat="server"  CssClass="grid-view"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="1px" 
           
           PageSize="20" AllowPaging=true Width="484px">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
             <asp:TemplateField HeaderStyle-Width="25px">
             <HeaderTemplate >
             <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
             </HeaderTemplate>
             <ItemTemplate>
            <asp:Label ID="id" Visible="false"  Text='<%# DataBinder.Eval (Container.DataItem, "id") %>'     runat="server" />
            <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                                   runat="server" />
        </ItemTemplate>
</asp:TemplateField>
            <asp:BoundField HeaderText="Id"  DataField="id" ReadOnly="true" />
            <asp:BoundField HeaderText="Email"  DataField="Email" ReadOnly="true" />
                
        
    </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 </asp:GridView>
       
    </td></tr>
    
 <tr><td>&nbsp;</td></tr>
    <tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" 
             />
        <asp:Button ID="btnCancel" runat="server" Text="Close" 
            OnClientClick="javascript:window.close();"   />
    </td></tr>
    
    </table>
    </div>
    </form>
</body>
</html>
