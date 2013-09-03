<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Asset_Default" Title="Untitled Page" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<br />
--%><table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td align="center">

<table align="center" width="99%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="2%" background="../images/dashleft.bmp"></td>
<td width="95%" height="20px" background="../images/dashtd.bmp" align="left" >

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lbl1" Font-Size="14px" runat="server" Text="Dashboard" Font-Bold="true" ForeColor="black "></asp:Label></td>
<td width="3%" background="../images/dashright.bmp"></td>
</tr>

</table>
<table align="center" width="99%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td>
<asp:Panel ID="pnl1" runat="server"  BorderWidth=1 BorderColor="#3399ff" BorderStyle=Outset>
<table width="95%" align="center" cellpadding="0" cellspacing="0" border="0">


<tr><td>&nbsp</td></tr>

<tr>
<td width="50%" >
<table align="left" width="50%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="2%" height="30px" background="../images/dashtd1.bmp" ></td>
<td width="94%" height="29px" background="../images/dashmiddle1.bmp" align="left"><asp:Label id="lblAsset" runat="server" Text="Total Assets" Font-Bold="true"></asp:Label> </td>
<td width="4%" height="30px" background="../images/dashtd2.bmp"></td>

</tr>
</table>


</td>
<td width="50%" align="left" class="tdLeftPad">
<table align="left" width="50%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="2%" height="30px" background="../images/dashtd1.bmp" ></td>
<td width="94%" height="29px" background="../images/dashmiddle1.bmp"><asp:Label id="Label1" runat="server" Text="Workstations And Network Devices" Font-Bold="true"></asp:Label> </td>
<td width="4%" height="30px" background="../images/dashtd2.bmp"></td>

</tr>
</table>
</td>

</tr>



<tr>

<td align="left">
<asp:Panel ID="panel2" Width="80%" runat="server" BorderWidth="1"  BorderColor="Black" BackColor="White">
<table width="100%" align="center" cellpadding="1" border="0" cellspacing="1">
<tr><td  background="../images/subhdtd1.png"><asp:Label ID="lblAsset2" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="white" Text="Organization Assets"></asp:Label></td></tr>
</table>
<table width="100%" align="center" cellpadding="0" border="0" cellspacing="0">
<tr bgcolor=Gainsboro>
<td width="50%"><asp:Label ID="lblasset3" runat="server" Text="Workstations"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblWorkStations" runat="server" Font-Bold="true" Text="100"></asp:Label></td>

</tr>
<tr bgcolor=white>
<td width="50%"><asp:Label ID="Label4" runat="server" Text="Network Devices"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblNetworkdevices" runat="server" Font-Bold="true" Text="15"></asp:Label></td>

</tr>

<tr bgcolor=Gainsboro> 
<td width="50%"><asp:Label ID="Label5" runat="server" Text="Other Devices"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblOtherdevices" runat="server" Font-Bold="true" Text="0"></asp:Label></td>

</tr>
<tr >
<td width="50%"><asp:Label ID="Label6" runat="server" Text="Total"  Font-Bold="true"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblTotal" runat="server" Font-Bold="true" Text="0"></asp:Label></td>

</tr>
<tr bgcolor=Gainsboro> 
<td width="50%"><asp:Label ID="Label8" runat="server" Text="&nbsp;"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblScanners" runat="server" Font-Bold="true" Text=""></asp:Label></td>

</tr>
<tr>
<td width="50%"><asp:Label ID="Label7" runat="server" Text="&nbsp;"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblPrinters" runat="server" Font-Bold="true" Text=""></asp:Label></td>

</tr>

<tr bgcolor=Gainsboro>
<td width="50%"><asp:Label ID="Label9" runat="server" Text="&nbsp;"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblProjectors" runat="server" Font-Bold="true" Text=""></asp:Label></td>

</tr>
</table>

</asp:Panel>

</td>
<td valign="top" align="left" width="50%" class="tdLeftPad">


<asp:Panel ID="panel1" Width="80%" runat="server" BorderWidth=1  BorderColor=black BackColor=white>
<table width="100%" align="left" cellpadding="1" border=0 cellspacing="1">
<tr><td   background="../images/subhdtd1.png" align="left"  valign="top"><asp:Label ID="Label10" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="white" Text=" Assets"></asp:Label></td></tr>

<tr><td ><asp:Image ID="imgAsset" runat="server" /></td></tr>

</table>


</asp:Panel>

</td>


</tr>
<tr><td>&nbsp</td></tr>
<tr><td>&nbsp</td></tr>

<tr>
<td width="50%" >
<table align="left" width="50%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="2%" height="30px" background="../images/dashtd1.bmp" ></td>
<td width="94%" height="29px" background="../images/dashmiddle1.bmp" align="left"><asp:Label id="Label2" runat="server" Text="Total Operating System" Font-Bold="true"></asp:Label> </td>
<td width="4%" height="30px" background="../images/dashtd2.bmp"></td>

</tr>
</table>


</td>
<td width="50%" align="left" class="tdLeftPad">
<table align="left" width="50%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td width="2%" height="30px" background="../images/dashtd1.bmp" ></td>
<td width="94%" height="29px" background="../images/dashmiddle1.bmp"><asp:Label id="Label3" runat="server" Text="Assets Operating System" Font-Bold="true"></asp:Label> </td>
<td width="4%" height="30px" background="../images/dashtd2.bmp"></td>

</tr>
</table>
</td>

</tr>

<tr>

<td align="left">
<asp:Panel ID="panel3" Width="80%" runat="server" BorderWidth="1"  BorderColor="Black" BackColor="White">
<table width="100%" align="center" cellpadding="2" border=0 cellspacing="1">
<tr><td  background="../images/subhdtd1.png"><asp:Label ID="Label11" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="white" Text="Assets Operating System"></asp:Label></td></tr>
</table>
<table width="100%" align="center" cellpadding="0" border=0 cellspacing="0">
<tr bgcolor=Gainsboro>
<td width="50%"><asp:Label ID="Label12" runat="server" Text="Windows XP  Professional"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblWindowsXp" runat="server" Font-Bold="true" Text="80"></asp:Label></td>

</tr>
<tr bgcolor=white>
<td width="50%"><asp:Label ID="Label14" runat="server" Text="Windows Server 2003 Enterprise"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblWindows2003" runat="server" Font-Bold="true" Text="15"></asp:Label></td>

</tr>
<tr bgcolor=Gainsboro>
<td width="50%"><asp:Label ID="Label16" runat="server" Text="Windows 2000  Enterprise Server"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblWindows2000" runat="server" Font-Bold="true" Text="0"></asp:Label></td>

</tr>
<tr> 
<td width="50%"><asp:Label ID="Label18" runat="server" Text="Windows Vista Business Edition 32-bit"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblWindowsVista" runat="server" Font-Bold="true" Text="0"></asp:Label></td>

</tr>
<tr> 
<td width="50%"><asp:Label ID="Label50" runat="server" Text="Microsoft Window 7"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="Labelwindow7" runat="server" Font-Bold="true" Text="0"></asp:Label></td>

</tr>


<tr bgcolor=Gainsboro>
<td width="50%"><asp:Label ID="Label24" runat="server" Text="Others"  Font-Bold="false"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblOsOthers" runat="server" Font-Bold="true" Text="0"></asp:Label></td>

</tr>
<tr> 
<td width="50%"><asp:Label ID="Label13" runat="server" Text="Total"  Font-Bold="true"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="lblTotalOS" runat="server" Font-Bold="true" Text=""></asp:Label></td>

</tr>

<tr bgcolor=Gainsboro>
<td width="50%"><asp:Label ID="Label17" runat="server" Text="&nbsp;"  Font-Bold="true"   Font-Size="11px"></asp:Label></td>
<td width="50%"><asp:Label ID="Label19" runat="server" Font-Bold="true" Text=""></asp:Label></td>

</tr>
</table>

</asp:Panel>

</td>
<td valign="top" align="left" width="50%" class="tdLeftPad">
<asp:Panel ID="panel4" Width="80%" runat="server" BorderWidth=1   BorderColor=black >
<table width="100%" align="left" cellpadding="1" border=0 cellspacing="1">
<tr><td  background="../images/subhdtd1.png"  valign="top"><asp:Label ID="Label26" runat="server" Font-Size="13px" Font-Bold="true" ForeColor="white" Text=" Operating Systems"></asp:Label></td></tr>
<tr><td><asp:Image ID="imageOS" runat="server" /></td></tr>
</table>


</asp:Panel>

</td>


</tr>



<tr><td>&nbsp</td></tr>



</table>

</asp:Panel>

</td>

</tr>

</table>


</td>
</tr>

</table>

</asp:Content>

