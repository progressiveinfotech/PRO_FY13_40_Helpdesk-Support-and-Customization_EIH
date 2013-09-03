<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingCallReport.aspx.cs" Inherits="Reports_PendingCallReport" %>

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
        <td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;
        </td>
       
            
    </tr>
     <tr><td>&nbsp;</td></tr>
            
            <tr style="padding-top:10px;">
             <td>&nbsp;&nbsp;Select Site &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:DropDownList ID="drpsite" runat="server" Width="155px" ></asp:DropDownList>
            </td>
            </tr>
             <tr><td>&nbsp;</td></tr>
            <tr >
            <td align="right" colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"  align="left">
             <asp:Button ID="btnViewreport" runat="server" Text="View Report" 
                        onclick="btnViewreport_Click" /> &nbsp;&nbsp;&nbsp;
            </td>
            </tr>
            
       <tr><td>&nbsp;</td></tr>
    
            <tr>
                <td align="center" colspan="5">
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
