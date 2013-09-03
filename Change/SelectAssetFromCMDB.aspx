<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectAssetFromCMDB.aspx.cs" Inherits="Change_SelectAssetFromCMDB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript">

        function refreshParent() 
        {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow)
	        {
                window.opener.progressWindow.close()
            }
                window.close();
        }
    
        </script>
        
         <script type="text/javascript" language="javascript">

    function check_uncheck(Val)
     {
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
    <div>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td  height="20px" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%" >
            &nbsp;Add Assets</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" colspan="5" class="tdsubheading">
          <b>Search for Assets</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:TextBox ID="txtAssets" runat="server" Height="20px"  Width="200">
         </asp:TextBox> &nbsp;&nbsp;&nbsp; <asp:Button ID="btnSearch" runat="server"  OnClick="btnSearch_Click" Text="Search"  />
          
        </td>
       
       
    </tr>
   <tr><td>&nbsp;</td></tr>
    
   
 <tr><td align="center" colspan="5" width="80%">
    
   <asp:GridView ID="grdvwViewAsset" runat="server" AllowPaging="true"  OnRowDataBound="grdvwViewAsset_RowDataBound" OnPageIndexChanging="grdvwViewAsset_PageIndexChanging"
                               
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                CssClass="grid-view" FooterStyle-BackColor="Red" FooterStyle-Font-Bold="true" 
                                ForeColor="Black" GridLines="Vertical" 
                                PageSize="10" 
                                ShowFooter="true" Width="984px">
                                <FooterStyle BackColor="white" />
                                <RowStyle BackColor="white" />
                                <AlternatingRowStyle BackColor="Silver" />
                                    <Columns>
                                    <asp:TemplateField>
    <HeaderTemplate>
     <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
     </HeaderTemplate>
     <ItemTemplate>
    <asp:Label ID="assetid" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "assetid") %>' runat="server" />
    <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                           runat="server" />
    </ItemTemplate>
    </asp:TemplateField>
                                        <asp:BoundField DataField="assetid" HeaderText="Asset Id" ReadOnly="true" />
                                        <asp:BoundField DataField="SerialNo" HeaderText="Serial No" ReadOnly="true" />
                                        <asp:BoundField DataField="ItemId" HeaderText="ItemName" ReadOnly="true" />
                                         <asp:BoundField DataField="Vendorid" HeaderText="Vendor Name" ReadOnly="true" />
                                        <%--<asp:CommandField CausesValidation="false" ShowEditButton="true" EditText="View Details" HeaderText="ViewDetails" />--%>

                                    </Columns>
                                <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>
    
    </td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr>
         <td  colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%"  align="center">
        
         
         &nbsp;&nbsp;<asp:Button ID="btnAddAsset" runat="server" Text="Add to list" OnClick="btnAddAsset_Click" 
                  />
                 &nbsp;
          </td>
           
     </tr>
     <tr><td>&nbsp;</td></tr>
    <tr><td height="20px" colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%" >&nbsp;&nbsp;Selectd Items</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr>
         <td  colspan="5"  align="left">&nbsp;&nbsp;&nbsp;
         
       <asp:ListBox ID="listAsset" Height="120px" Width="900px" runat="server" SelectionMode="Multiple"></asp:ListBox>
          </td>
           
     </tr>
     <tr><td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center"><asp:Button ID="btnAsset" 
             runat="server" Text="Add Asset to Change" OnClick="btnAsset_Click"/>&nbsp;<asp:Button ID="btnClose" runat="server" OnClientClick="javascript:window.close();" Text=" Close " /> </td></tr>
    </table> 
    </div>
    </form>
</body>
</html>
