<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayProblem.aspx.cs" Inherits="Problem_DisplayProblem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Incident To Problem Mapping</title>
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
        <td colspan="4" height="20px"  background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;All Problems
        <%--<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="right" >&nbsp;&nbsp;&nbsp;</td>--%>
            
    </tr>
   
  <%--  <tr><td colspan="2">&nbsp;&nbsp;<asp:Button 
            ID="btnReset" runat="server" Text=" Reset " onclick="btnReset_Click" /></td></tr>--%>
    <tr><td>&nbsp;</td></tr>
     <tr><td align="center"  colspan="2">
    
   <asp:GridView ID="grdvwProblem" runat="server"  CssClass="grid-view"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="1px" 
           OnPageIndexChanging="grdvwProblem_PageIndexChanging" OnRowDataBound="grdvwProblem_RowDataBound"
           PageSize="15" AllowPaging=true Width="984px">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
     <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
     </HeaderTemplate>
     <ItemTemplate>
    <asp:Label ID="ProblemId" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "ProblemId") %>'
    runat="server" />
    <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                           runat="server" />
</ItemTemplate>
</asp:TemplateField>
            <asp:BoundField HeaderText="Id"  DataField="ProblemId" ReadOnly="true" />
            <asp:BoundField HeaderText="Title"  DataField="title" ReadOnly="true" />
            <asp:BoundField HeaderText="Requester Name" DataField="requesterid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Created By" DataField="createdbyid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Assigned to" DataField="technicianid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Status" DataField="statusid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Priority" DataField="priorityid" ReadOnly="true"  />
             <asp:BoundField HeaderText="Category" DataField="categoryid" ReadOnly="true"  />
            <asp:BoundField HeaderText="CreatedDate" DataField="createdatetime" ReadOnly="true"  />
            
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
    <td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"><asp:Button ID="btnAttach" runat="server" 
            Text="Attach to Problem" onclick="btnAttach_Click" />&nbsp;<asp:Button ID="btnClose" runat="server" OnClientClick="javascript:window.close();" Text="Close" /></td>
    </tr>
    </table>
    

    </div>
   

   
</form>
</body>
</html>
