<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncidentLog1.aspx.cs" Inherits="Incident_IncidentLog1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Add Work Log</title>
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
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    
    <tr><td class="tdheader">&nbsp;&nbsp;Add Work Log</td></tr>
    
    <tr><td align="center">
    <asp:UpdatePanel ID="AddWorklog" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="txtcomments" TextMode="MultiLine" Columns="62" runat="server" Height="180px" ></asp:TextBox>
        </ContentTemplate>
    </asp:UpdatePanel>
    </td></tr>
    
    <tr><td>&nbsp;</td></tr>
 
    <tr><td class="tdheader" align="center">
        <asp:Button ID="btnapprove" runat="server" Text="Submit" onclick="btnapprove_Click"/>&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Close" OnClientClick="javascript:window.close();" onclick="btnCancel_Click" />
    </td></tr>
    
    </table>
    </div>
    </form>
</body>
</html>
