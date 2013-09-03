<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestLogin.aspx.cs" Inherits="TestLogin" %>
--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><link href="Include/styles.css" rel="stylesheet" />
    <title>Progressive Helpdesk</title>
    <link href="Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <link href="Include/styles.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
    function SetFocus()
    {
   
 ;
    
    }
    </script>
</head>
<body onload="javascript: document.getElementById('txtUserName').focus();">
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <table border="0" cellpadding="0" width="100%" cellspacing="0" align="center">
     <tr>
     <td style="padding-top:5px;" align="left"> &nbsp;&nbsp;<img id="img13" src="images/newlogo.gif" /></td>
     <td>&nbsp;</td>
     </tr>
      <tr>
          <td><img alt="" src="images/headerz.gif"   /></td>
          <td  width="50%" background="images/headerz.gif"></td>
          
          </tr>
      <tr><td>&nbsp;</td></tr>
   
    </table>
    <table style="background-image: url('images/tablebg.JPG')" width="100%" height="432px" align="center"> 
        <tr>
            <td>
             <asp:UpdatePanel ID="CategoryPanal2" runat="server">
<ContentTemplate>
                <table cellpadding="0" cellspacing="0" height="296px" 
                    align="center" width="660px"  border="1"
                 >
                    <tr>
                        <td width="30%">
                            <img id="img"    src="images/HelpSupport.jpg" />
                            
                            </td>
                        <td    style="background-image: url('images/shade 2.JPG')" valign="top" align="left">
                          
                            <img style="padding-top:2px;"  id="images3" src="images/logohelp.jpeg"/>
                          
                                <table cellpadding="1" cellspacing="0" border="0" width="205" height="75" align="center">
                                <tr><td>&nbsp;</td></tr><tr><td>&nbsp;</td></tr>
                                   
                                    <tr>
                                        <th colspan="2" style="color: White; font-size: smaller">
                                            Please enter your details to proceed</th>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="middle">
                                                <asp:Label ID="Label1" runat="server" BorderStyle="None" style="color: White" 
                                                    Text="&lt;b&gt; Username&lt;/b&gt;"></asp:Label>
                                            </td>
                                            <td align="left" valign="middle">
                                                &nbsp;&nbsp;
                                                <asp:TextBox ID="txtUserName" runat="server" Height="20px" MaxLength="50"></asp:TextBox>
                                                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValUsername" runat="server" 
                                                    ControlToValidate="txtUserName" EnableClientScript="true" 
                                                    ErrorMessage="Enter User Name" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="">
                                                <asp:Label ID="Label2" runat="server" BorderStyle="None" style="color: White" 
                                                    Text="&lt;b&gt; Password&lt;/b&gt;"></asp:Label>
                                            </td>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                                <asp:TextBox ID="txtPassword" runat="server" Height="20px" MaxLength="50" 
                                                    TextMode="Password"></asp:TextBox>
                                                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqtxtPassword" runat="server" 
                                                    ControlToValidate="txtPassword" EnableClientScript="true" 
                                                    ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                                                    Text=" Login " />
                                                &nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" CausesValidation="false" 
                                                    onclick="btnReset_Click1" Text="Cancel" />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                        </td>
                     </tr>
                </table>
                </ContentTemplate> 
                </asp:UpdatePanel> 
              </td>
             </tr>
           </table>
           <table align="center" width="100%" cellspacing="0" cellpadding="0">
           <tr><td>&nbsp;</td></tr>
           <tr><td>&nbsp;</td></tr>
           <tr><td>&nbsp;</td></tr>
        
           
          <tr>
        <td>&nbsp;</td>
        <td align="right">&copy;    </div>
    </form>
</body>
</html>
