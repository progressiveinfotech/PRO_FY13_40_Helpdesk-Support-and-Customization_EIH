<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproveorRejectChangeRequest.aspx.cs" Inherits="WithoutLoginPageAccess_ApproveorRejectChangeRequest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
      <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
      <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
      <script language="javascript" type="text/javascript">  
       function changeScreenSize(w,h)    
       {      
      window.resizeTo( w,h );
       }
         function CloseWindow()

{

window.opener = self;

window.close();



}
       
       </script>
</head>
<body onload="javascript:changeScreenSize(800,600);" >
   <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td class="tdheaderI">Following are the change details please Approve or Reject
 <asp:Panel ID="Alreadyapprovedpanal" runat="server">
    <table align="center" border="0" cellpadding="0" width="100%" cellspacing="0">
              <tr><td>This is Already Done</td></tr></table>
   </asp:Panel>
 
 
 </td></tr>
 <tr><td>Change ID:<asp:Label ID="lblchangeid" runat="server"></asp:Label></td>
 <td></td></tr>

 <tr><td>
<asp:Panel ID="Approvalpanal" runat="server" Visible="false" BorderWidth="1">
   <table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">
<tr>
<td class="tdheaderI">Title</td>
<td class="tdheaderI"><asp:Label ID="lbltitle" runat="server"></asp:Label></td>
<td class="tdheaderI"></td>
<td class="tdheaderI"></td>
</tr>
<tr>
<td>Solution Details</td>
<td><asp:Label ID="lbldescription" runat="server"></asp:Label> </td>
<td></td>
<td></td>
</tr>
    <tr>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Current Status</b></td>
    <td class="tdheaderI" width="18%" align="left"><asp:Label ID="lblStatus" runat="server" ></asp:Label></td>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Service Effected</b></td>
    <td class="tdheaderI" width="25%" align="left">
     <asp:Label ID="lblserviceeffected" runat="server" ></asp:Label>

    </td>
    </tr>
 <%--<tr>
    <td >&nbsp;&nbsp;<b>Current Status</b></td>
    <td  align="left"><asp:Label ID="lblStatus" runat="server" ></asp:Label></td>
    <td >&nbsp;&nbsp;<b>Priority</b></td>
    <td  align="left">
   <asp:Label ID="lblpriority" runat="server" ></asp:Label>
    </td>
 </tr>--%>
<tr>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Category</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblcategory" runat="server" ></asp:Label></td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Subcategory</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblsubcategory" runat="server" ></asp:Label>
  
    </td>
 </tr>
 <tr>
    <td >&nbsp;&nbsp;<b>Change Type</b></td>
    <td   align="left"><asp:Label ID="lblchangetype" runat="server" ></asp:Label></td>
    <td>&nbsp;&nbsp;<b>Created By</b></td>
    <td align="left"><asp:Label ID="lblCreatedby" runat="server" ></asp:Label>
   
    </td>
    </tr> 

 <tr>
    <td  class="tdheaderI">&nbsp;&nbsp;<b>Created date</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblCreatedDate" runat="server" ></asp:Label></td>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Completed Date</b></td>
    <td  class="tdheaderI" align="left"><asp:Label ID="lblCompletedDate" runat="server" ></asp:Label>
   
    </td>
    </tr> 
    
    <tr>
    <td  >&nbsp;&nbsp;<b>Asset Involved</b></td>
    <td  align="left" ><asp:ListBox ID="lstAsset" runat="server" Width="200px" Height="50px"></asp:ListBox></td>
    <td  >&nbsp;&nbsp;<asp:Label ID="lbltimespentonDisp" runat="server" Visible="false" Font-Bold="true" Text="Time Spent on Req"></asp:Label></td>
    <td  align="left">
   <asp:Label ID="lbltimespentonreq" runat="server"></asp:Label>
    </td>
 </tr>
  <tr>
    <td  >&nbsp;&nbsp;Comments<b></b></td>
    <td  align="left" ><asp:TextBox ID ="txtcomment" runat="server" TextMode="MultiLine"></asp:TextBox></td>
    <td  >&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Visible="false" Font-Bold="true" Text="Time Spent on Req"></asp:Label></td>
    <td  align="left">
   <asp:Label ID="Label2" runat="server"></asp:Label>
    </td>
 </tr>

    
</table>
</asp:Panel>
  
    <tr><td align="center">&nbsp;<asp:Button ID="btnApprove" runat="server" Visible="false" Text="Approve" OnClick="btnApprove_Click"/> <asp:Button ID="btnReject" runat="server" Visible="false" Text="Reject" OnClick="btnReject_Click"/> 
        </td></td></tr>
    
   
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
