<%@ Page Language="C#" MasterPageFile="~/Dashboard/MasterPage.master" AutoEventWireup="true" CodeFile="todayactivity.aspx.cs" Inherits="Dashboard_todayactivity" Title="Untitled Page" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
&nbsp;
</td>
</tr>
<tr>
<td>
&nbsp;
</td>
</tr>

            <tr>
                <td align="center" colspan="5">
                    <rsweb:reportviewer ID="ReportViewer1" runat="server" BackColor="LightSteelBlue"
                        BorderColor="Black" Font-Names="Verdana" Font-Size="8pt" Width="100%"   
                        ShowBackButton="true" ShowDocumentMapButton="true" ShowParameterPrompts="false"
                        ShowFindControls="true" ShowPrintButton="true" ShowToolBar="true">
                    </rsweb:reportviewer>
                </td>
            </tr>
            <tr>
<td>
&nbsp;
</td>
</tr>
<tr>
<td>
&nbsp;
</td>
</tr>
</table>
</asp:Content>

