<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectUser.aspx.cs" Inherits="admin_SelectUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Select User</title>
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
    <script type="text/javascript" language="javascript"> 
    function fnCheckUnCheck(objId) 
    {
        var grd = document.getElementById("<%= grdvwViewUser.ClientID %>"); 
        var rdoArray = grd.getElementsByTagName("input"); 
        for(i=0;i<=rdoArray.length-1;i++) 
        { 
            if(rdoArray[i].type == 'radio')
            {
                if(rdoArray[i].id != objId) 
                { 
                    rdoArray[i].checked = false; 
                } 
            }
        } 
    } 
    </script>
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
    <style type="text/css">
        .style1
        {
            height: 22px;
        }
    </style>
</head>

<body>
<form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr><td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td height="20px" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
                    </tr>
                    
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                    <td align="center" width="80%">
                        <asp:GridView ID="grdvwViewUser" 
                            runat="server" 
                            AllowPaging="true" 
                            OnPageIndexChanging="grdvwViewUser_PageIndexChanging" 
                            OnRowCommand="grdvwViewUser_RowCommand" 
                            OnRowCreated="grdvwViewUser_RowCreated" 
                            AutoGenerateColumns="False" 
                            BackColor="White" 
                            BorderColor="#DEDFDE" 
                            BorderStyle="None" 
                            BorderWidth="1px" 
                            CellPadding="0" 
                            CellSpacing="0" 
                            CssClass="grid-view" 
                            FooterStyle-BackColor="Red" 
                            FooterStyle-Font-Bold="true" 
                            ForeColor="Black" 
                            GridLines="Vertical" 
                            PageSize="20" 
                            ShowFooter="true" 
                            Width="500px">
                            <FooterStyle BackColor="white" />
                            <RowStyle BackColor="white" />
                            <AlternatingRowStyle BackColor="Silver" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserID" Visible="false" 
                                        Text='<%# DataBinder.Eval (Container.DataItem, "userid") %>'
                                        runat="server" />
                                        <asp:RadioButton ID="selectone"  onclick="fnCheckUnCheck(this.id);"  runat="server"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="userid" HeaderText="User Id" ReadOnly="true" />
                                <asp:BoundField DataField="username" HeaderText="User Name" ReadOnly="true" />
                            </Columns>
                            <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                    </tr>
                </table> 
            </ContentTemplate> 
            </asp:UpdatePanel> 
        </td> 
        </tr> 
        <tr>
        <td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            <asp:Button ID="btnmapped" runat="server" Text="Select" onclick="btnMapped_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Close" OnClientClick="javascript:window.close();" />
        </td>
        </tr>
    </table> 
    </div>
</form>
</body>
</html>
