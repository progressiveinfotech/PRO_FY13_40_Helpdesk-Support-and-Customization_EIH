<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Activate.aspx.cs" Inherits="admin_Activate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div2" runat="server">
    This tool is expired. Please contact at Progressive Infotech Noida.
    </div>
   <div id="div1" runat="server" visible="false">
   Please Activate this tool by entering key below.
    <table width="50%">
    <tr><td>Enter key</td><td><asp:TextBox ID="txtkey" runat="server" TextMode="Password" Width="281px"></asp:TextBox>
                    <asp:Label ID="Lblmsg" runat="server" ForeColor="Red"></asp:Label>
                    </td></tr>
    <tr><td></td><td><asp:Button ID="Btnclick" runat="server" Text="Submit" 
            onclick="Btnclick_Click" /></td></tr>
    </table>
    </div>    
    
    
    </form>
</body>
</html>
