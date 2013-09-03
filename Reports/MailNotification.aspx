<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailNotification.aspx.cs" Inherits="Reports_MailNotification" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   
    <title>Untitled Page</title>
   <%--  <link href="../Include/styles.css" type="text/css" rel="stylesheet" />--%>
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div >
        <table  width="100%" cellpadding="0" cellspacing="0" align="center">
         <tr><td>&nbsp;</td></tr>
         <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;
        </td>
       
            
    </tr>
     <tr><td>&nbsp;</td></tr>
            
             <tr><td>&nbsp;</td></tr>
            
       <tr><td>&nbsp;</td></tr>
    
            <tr>
                <td align="center">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="LightSteelBlue" ShowParameterPrompts="false"
                        BorderColor="Black" Font-Names="Verdana" Font-Size="8pt" Width="100%"   ShowBackButton="true" ShowDocumentMapButton="true" 
                        ShowFindControls="true" ShowPrintButton="true" ShowToolBar="true">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
