<%@ Page Language="C#" MasterPageFile="~/Master/MasterIndex.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Login_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">

<tr>
<td width="31%" valign="top">
        <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr><td> <img id="img1" src="../images/ticket.bmp"  /><b><asp:LinkButton ID="lnkNewTicket" runat="server" ForeColor="Blue" Text="New Ticket"   onclick="lnkNewTicket_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Submit a new ticket  </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td><img id="img2" src="../images/myticket.bmp"  /><b>  &nbsp;<asp:LinkButton    ID="lnkMyTicket" runat="server" ForeColor="Blue" Text="My Tickets"        onclick="lnkMyTicket_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;View your current helpdesk tickets </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td><img id="img4" src="../images/reports.bmp"  /><b>  &nbsp;<asp:LinkButton 
                ID="lnkReport" runat="server" ForeColor="Blue" Text="Reports & Analysis" 
                onclick="lnkReport_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Benchmark</td></tr>
        </table>

</td>
<td width="2%" >
        <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr><td><img id="imgLine1" src="../images/line2.bmp" /></td></tr>
        </table>
</td>
<td width="31%">
        <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr><td>
        <img id="img9" src="../images/problem.bmp"  /><b>  &nbsp;<asp:LinkButton 
                ID="lnkContact" runat="server" ForeColor="Blue" Text="Problem Management" 
                onclick="lnkContact_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add New problem
        </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr ><td><img id="img3" src="../images/knowledge.bmp"  /><b>  &nbsp;<asp:LinkButton  ID="lnkKedb" runat="server" ForeColor="Blue" Text="Knowledge Base"  onclick="lnkKedb_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Find an answer of your question </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td><img id="img11" src="../images/tutorials.bmp"  /><b>  &nbsp;<asp:LinkButton ID="lnkTutorials" runat="server" OnClientClick="javascript:window.open('../Help/Helpdekdocumentation.aspx','popupwindow','width=920,height=600,left=200,top=150,Scrollbars=yes')" ForeColor="Blue" Text="Tutorials & Manuals"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Explore our tutorials and manuals</td></tr>
        </table>
</td>
<td width="2%">
        <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr><td>
        <img id="imgLine2" src="../images/line2.bmp" />
        </td></tr>
        </table>
 </td>
 <td width="34%">
          <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
        <tr><td valign="bottom"><img id="img6" src="../images/asset.bmp"  /><b>  &nbsp;<asp:LinkButton  ID="lnkAsset" runat="server" ForeColor="Blue" Text="Asset Management"    onclick="lnkAsset_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Know your Assets</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td><img id="img8" src="../images/contract.bmp" /><b>  &nbsp;<asp:LinkButton   ID="lnkContract" runat="server" ForeColor="Blue" Text="Contract Management"   onclick="lnkContract_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Find your running contracts</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td><img id="img13" src="../images/change.bmp"  /><b>  &nbsp;<asp:LinkButton 
                ID="lnkChat" runat="server" ForeColor="Blue" Text="Change Management" 
                onclick="lnkChat_Click"></asp:LinkButton></b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add New Change</td></tr>
        </table>
</td>
</tr>
</table>
</asp:Content>

