<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncidentResolution.aspx.cs" Inherits="Incident_IncidentResolution" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
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
    <style type="text/css">
        .style1
        {
            background-color: #E1E1E1;
            font-weight: bold;
            height: 13px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr><td>&nbsp;</td></tr>
    <tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add Resolution</td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td align="left" style="padding-left:20px;" >
    <asp:UpdatePanel ID="AddResolution" runat="server">
        <ContentTemplate>
           <div  id="EditorPanel">
          
            <cc:HtmlEditor ID="Editor" runat="server" Height="300px" Width="600px" />&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="reqValEditor" runat="server" ControlToValidate="Editor" EnableClientScript="true" ErrorMessage="Enter Resolution"></asp:RequiredFieldValidator>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </td></tr>
    <tr><td>&nbsp;</td></tr>
 
    <tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Close" 
            OnClientClick="javascript:window.close();" />
    </td></tr>
   <%-- <tr><td>&nbsp;</td></tr>
     <tr><td class="style1">&nbsp;&nbsp;&nbsp;Show  Resolution</td></tr>--%>
     <%--<tr><td>&nbsp;</td></tr>
    <tr><td><asp:Panel ID="panelResolution" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolderResolution" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
     <tr><td>&nbsp;</td></tr>
    --%>
    </table>
    </div>
    </form>
</body>
</html>
