<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerFeedback.aspx.cs" Inherits="WithoutLoginPageAccess_CustomerFeedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
      <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <title>Customer Feedback</title>
    <script language="javascript" Type="text/javascript" >
     function refreshParent() 
        {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow)
	        {
                window.opener.progressWindow.close();
            }
                window.close();
        }
        function CloseWindow()

{

window.opener = self;

window.close();



}


    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
 &nbsp;<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    
  
    
   
   <tr><td class="tdheader"> <asp:Label ID="lblapprove" runat="server" ></asp:Label>
    &nbsp;Kindly provide your valuable feedback by choosing one of the Options.  
 </td></tr>
    
 <tr>
 <td><table><tr><td>&nbsp;Satisfied</td><td><asp:RadioButton  ID="satisfiedrdbutton" runat="server" GroupName="id"  /></td></tr>
 <tr><td>&nbsp;Very Satisfied</td><td><asp:RadioButton  ID="verysatisfied" runat="server" GroupName="id" /></td></tr>
 <tr><td>&nbsp;Dissatisfied</td><td><asp:RadioButton  ID="Rddisatisfied" runat="server" GroupName="id" /></td></tr>
 <tr><td>&nbsp;Very Dissatisfied</td><td><asp:RadioButton  ID="Rdverydissatisfied" runat="server" GroupName="id" /></td></tr>
 </table> </td>
 
 <td align="center">
<asp:UpdatePanel ID="AddSolution1" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td><table>
 
 
 </table>
  &nbsp;</td>
 <td align="center">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
      
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td><table></table>
  &nbsp; </td>
 <td align="center">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td><table></table>
 </td>
 <td align="center">
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr><td>&nbsp;</td></tr>
 
 <tr><td class="tdheader" align="center">

 <asp:Button ID="btnFeedback" runat="server" Text="Vote Feedback" OnClick="btnFeedback_Click"   />
 <%--<asp:Button ID="btnreject" runat="server" Text="Reject" OnClick="btnreject_Click" />
 <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:window.close();" />--%>

 </td></tr>
  
     
 </table>
    <div>
    
    </div>
    </form>
</body>
</html>
