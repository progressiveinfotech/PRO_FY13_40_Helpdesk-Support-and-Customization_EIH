<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolutionandWorkaroundWindow.aspx.cs" Inherits="Problem_SolutionandWorkaroundWindow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SolutionandWorkAroundWindow</title>
      <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
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
 <tr><td><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></td></tr>
 <tr><td>

    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
     <tr><td>&nbsp;</td></tr>
    <tr>
        <td height="20px"  colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
           <%-- <td width="80%" class="tdheader"></td>--%>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading" valign="top">
        <font class="mandatory">*</font>Title
        </td>
        <td >
         
         <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" TextMode="MultiLine" Width="594" Height="30px"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValTitle" runat="server" ControlToValidate="txtTitle" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> 
         
            
        </td>
       
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp;Content  
        </td>
        <td >
          <div id="EditorPanel">
          
            <cc:HtmlEditor ID="Editor" runat="server" Height="300px" Width="600px" />
            </div>
        </td>
        
    </tr>
     <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp; Topic  
        </td>
        <td  >
         <asp:DropDownList ID="drpTopic" runat="server"></asp:DropDownList>
        
        </td>
        
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp;Keywords
        </td>
        <td  >
         <asp:TextBox ID="txtKeywords" runat="server" MaxLength="50" TextMode="MultiLine" Width="594px" Height="30px"></asp:TextBox>
        
        </td>
        
    </tr>
      
      <tr><td>&nbsp;</td></tr>
  
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnSolutionAdd" runat="server"  
                Text="Save" OnClick="btnSolutionAdd_Click"   />      
           <asp:Button ID="btnclose"  CausesValidation="false"   
                Text="Close"  runat="server" onclick="btnbtnclose_Click"/>  
               
               
         
           
    
        </td>
    </tr></table>
  
    <tr><td>&nbsp;</td></td></tr>
    
   
   <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
        
   
   




 </table>
    
    <div>
    
    </div>
    </form>
    
</body>
</html>
