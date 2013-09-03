<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterNetwork.master" AutoEventWireup="true"
    CodeFile="Network_Discovery.aspx.cs" Inherits="Asset_Network_Discovery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
           #loading
        {
            position: absolute;
            left: 45%;
            top: 50%;
            border: 3px solid #B2D0F7;
            padding: 10px;
            font: bold 14px verdana,tahoma,helvetica;
            color: #003366;
            width: 180px;
            text-align: center;
        }
        .loading-indicator
        {
            font-size: 8pt;
            background-repeat: no-repeat;
            background-position: top left;
            padding-left: 20px;
            height: 73px;
            text-align: left;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                &nbsp;&nbsp;Network Scan
            </td>
        </tr>
    </table>
    <table><tr><td>
    <asp:UpdatePanel ID="CategoryPanal2" runat="server">
        <ContentTemplate>
            <div style="text-align: center;">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="CategoryPanal2"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <div id="loading" class="loading-indicator">
                            <table>
                                <tr>
                                    <td>
                                        <%--   <img src="../images/loader_icon.gif">--%>
                                    </td>
                                    <td>
                                        <img src="../images/loader_icon.gif">
                                        <br />
                                        <b>Page loading please wait...</b>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </td></tr></table>
    <br />
    <table align="center" style="width: 90%;">
        <tr>
            <td colspan="2" style="height: 15px">
                &nbsp;&nbsp;
            </td>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 15px">
                <asp:Label ID="Label2" runat="server" Text="Network Address:" Font-Bold="True" Font-Size="Larger"
                    Font-Underline="False"></asp:Label>
            </td>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
            </td>
            <td style="width: 282px; height: 15px;">
                <asp:Label ID="lbl_range_from" runat="server" Text="Range From:" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txt_range_from" Width="112px" runat="server" ToolTip="Enter the IP address."></asp:TextBox>
            </td>
            <td colspan="2" style="height: 15px">
                <asp:Label ID="lbl_Manufacturer" runat="server" Text="To:" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txt_range_to" Width="112px" runat="server" ToolTip="Enter the IP address."></asp:TextBox>&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 14px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 14px;">
                &nbsp;
            </td>
            <td style="width: 15%; height: 14px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 14px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
            </td>
            <td style="width: 282px; height: 15px;">
                <asp:Label ID="lbl_user_name" runat="server" Text="Community: " Font-Bold="True"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txt_community" runat="server" ToolTip="Enter the community string."
                    Width="112px"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 15px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnScan" OnClick="btnScan_Click" OnClientClick="return verifyIP();"
                    Font-Bold="true" runat="server" ToolTip="Click to scan." Text="Scan Now" BackColor="ButtonFace">
                </asp:Button>
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
            </td>
            <td style="width: 282px; height: 15px;">
                <asp:Label ID="lbl_status" runat="server" Text="" Font-Bold="True"></asp:Label>
            </td>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
            <td style="width: 15%; height: 15px;" align="left">
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                &nbsp;
            </td>
            <td colspan="2" align="left">
                &nbsp;
            </td>
            <td align="left">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
            </td>
            <td style="height: 15px; width: 282px;">
            </td>
            <td align="left" valign="top" colspan="2" style="height: 15px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 282px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
            </td>
            <td style="width: 282px; height: 15px;">
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <%--<tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>--%>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
            <td style="width: 15%; height: 15px;" align="left">
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
                &nbsp;
            </td>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 35%; height: 15px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 15%; height: 15px;" align="left">
                &nbsp;
            </td>
            <td style="width: 282px; height: 15px;">
            </td>
            <td style="width: 15%; height: 15px;" align="left">
            </td>
            <td style="width: 35%; height: 15px;">
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">

        function verifyIP() {
            var ipaddr = document.getElementById("<%=txt_range_from.ClientID%>").value;
            var re = /^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/;
            if (re.test(ipaddr)) {
                var parts = ipaddr.split(".");
                if (parseInt(parseFloat(parts[0])) == 0) { alert("Enter the valid IP address."); return false; }
                for (var i = 0; i < parts.length; i++) {
                    if (parseInt(parseFloat(parts[i])) > 255) { alert("Enter the valid IP address."); return false; }
                }



            }
            else {
                alert("Enter the valid IP address.");
                return false;

            }




            var ipaddrto = document.getElementById("<%=txt_range_to.ClientID%>").value;
            var reto = /^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/;
            if (reto.test(ipaddrto)) {
                var parts = ipaddrto.split(".");
                if (parseInt(parseFloat(parts[0])) == 0) { alert("Enter the valid IP address."); return false; }
                for (var i = 0; i < parts.length; i++) {
                    if (parseInt(parseFloat(parts[i])) > 255) { alert("Enter the valid IP address."); return false; }
                }

                return true;

            }
            else {
                alert("Enter the valid IP address.");
                return false;

            }

        }



    </script>

</asp:Content>
