<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectAsset.aspx.cs" Inherits="Change_Select_Asset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Asset</title>
    
    
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
   <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr>
 <td>
 Select Asset
 
 </td></tr>

   <tr>
 <td>
 <asp:ListBox ID="lstboxasset" runat="server" Height="400" Width="200" 
         SelectionMode="Multiple"></asp:ListBox>
 
 </td>
 <td align="center">
 <table><tr><td><asp:Button runat="server" Text="Add To List" ID="btnlisttoright" OnClick="btnlisttoright_Click"  /></td></tr>
 <tr><td><asp:Button runat="server" Text="Remove From List" ID="Button1" /></td></tr></table>
 

 
 </td>
  <td align="right">
 <asp:ListBox ID="lstboxselecasset" runat="server" Height="400" Width="200" SelectionMode="Multiple" ></asp:ListBox>
 
 </td>
 </tr>
     
   
   




 </table>
    </form>
</body>
</html>
