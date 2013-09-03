<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProblemNotes.aspx.cs" Inherits="Problem_ProblemNotes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     <%--<link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />--%>
    <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
    <%--<script type="text/javascript" language="javascript" src="../Include/MasterJSFile.js"></script>--%>
    
    <script language="javascript">

function refreshParent() {
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
  
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
   <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    
  
    
   
   <tr><td class="tdheader"> <asp:Label ID="lblapprove" runat="server" ></asp:Label>
       <asp:Label ID="lblreject" runat="server" ></asp:Label>
 </td></tr>
    
 <tr><td align="center">
<asp:UpdatePanel ID="AddComments" runat="server">
     <ContentTemplate>
       <asp:TextBox ID="txtcomments" TextMode="MultiLine" Columns="62" 
             runat="server" Height="180px" ></asp:TextBox>
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr><td>&nbsp;</td></tr>
 
 <tr><td class="tdheader" align="center">
 <%--<asp:UpdatePanel ID="ApproveActionWindow" runat="server">
 <ContentTemplate>--%>
 <asp:Button ID="btnadd" runat="server" Text="Add Comment"  OnClick="btnadd_Click"  />
 
 <asp:Button ID="btnCancel" runat="server" Text="Cancel"  OnClick="btnCancel_Click"  />
 <%--</ContentTemplate>
 </asp:UpdatePanel>--%>
 </td></tr>
  
     
 </table>

    </form>
</body>
</html>
