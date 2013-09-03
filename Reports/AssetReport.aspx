<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssetReport.aspx.cs" Inherits="Reports_AssetReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asset Report</title>
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%;height:100%">
        <table width="100%;height:100%" style="vertical-align:top;border: solid 1px gray">
            <tr>
                <td> 
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="LightSteelBlue" ShowParameterPrompts="false"
                        BorderColor="Black" Font-Names="Verdana" Font-Size="8pt" Width="100%" ShowBackButton="true" ShowDocumentMapButton="true" 
                        ShowFindControls="true" ShowPrintButton="true" ShowToolBar="true">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
