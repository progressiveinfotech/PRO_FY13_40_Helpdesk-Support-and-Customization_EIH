<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateChangefromProblem.aspx.cs" Inherits="Change_CreateChangefromProblem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create New Change</title>
     <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
    <script  language="javascript">
    function Close()
    {
    window.close();
    }
    
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
      <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td><asp:UpdatePanel ID="CategoryPanal1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel></td></tr>
 <tr><td>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdheader">
            &nbsp;New Change</td>
           
    </tr>
    <tr><td>&nbsp;</td></tr>
   
   
    <tr><td>
    <asp:UpdatePanel ID="CategoryPanal2" runat="server">
<ContentTemplate>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    
    <td width="10%">&nbsp;Technician</td>
    <td width="25%" align="left">
     <asp:DropDownList ID="drpTechnician" Width="170px" runat="server">
    </asp:DropDownList>
    
    </td>
    <td width="10%">&nbsp;Service Effected</td>
    <td width="25%" align="left">
     <asp:DropDownList ID="drpservices" Width="170px" runat="server">
     <asp:ListItem>Email</asp:ListItem>
     <asp:ListItem>Voice and Telephone</asp:ListItem>
    </asp:DropDownList>
    
    </td>
    </tr>
    <tr>
    <td width="10%">&nbsp;&nbsp;Status</td>
    <td width="18%" align="left"><asp:DropDownList Width="170px" ID="drpStatus" runat="server">
    
    </asp:DropDownList></td>
    <td width="10%">Priority</td>
    <td width="25%" align="left">
   <asp:DropDownList ID="drpPriority" Width="170px" runat="server">
     
    </asp:DropDownList>
    </td>
    </tr>
     <tr>
    <td width="10%" align="left">&nbsp; Category</td>
    <td width="18%" align="left">
       <asp:DropDownList ID="drpCategory" Width="170px" 
            AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged" >
     
    </asp:DropDownList>
    </td>
    <td width="10%">SubCategory</td>
    <td width="25%" align="left">
    <asp:DropDownList ID="drpSubcategory" Width="170px" runat="server" >
    
    </asp:DropDownList>
    </td>
    </tr>
     <tr>
    <td width="10%" align="left">&nbsp;Change Type </td>
    <td width="18%" align="left">
       <asp:DropDownList ID="drpchangetype" Width="170px" 
            AutoPostBack="true" runat="server">
     
    </asp:DropDownList>
    </td>
    <td width="10%">AssetInvolved</td>
    <td width="25%" align="left">
    <asp:ListBox ID="ListAsset" runat="server"  Width="100" Height="80" ></asp:ListBox>
    <asp:LinkButton ID="lnkopennewwindow" Text="New Window" CausesValidation="false" runat="server" OnClick="lnkopennewwindow_Click"></asp:LinkButton>
    </td>
    </tr>
    <%--<tr>
    <td width="10%">&nbsp;&nbsp;External Ticket No</td>
    <td width="18%" align="left"><asp:TextBox ID="txtExternalTicket" runat="server" Width="165px" MaxLength="50"></asp:TextBox></td>
    <td width="10%">&nbsp;</td>
    <td width="25%" align="left">
   &nbsp;
    </td>
    </tr>--%>
    </table>
  
    </ContentTemplate>
</asp:UpdatePanel>
   </td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr>
        <td  class="tdheader">
            &nbsp;Requester Details</td>
           
    </tr>
   
    <tr>
    <td>
     <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="10%"><font class="mandatory">*</font>User Name</td>
    <td width="25%" align="left">
    <asp:TextBox ID="txtUsername" Width="165px"  runat="server" AutoPostBack="true" OnTextChanged="txtUsername_TextChanged"> 
             </asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsername" ForeColor="Red" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
    </td>
    <td width="10%">Email</td>
    <td width="25%" align="left">
   <asp:TextBox ID="txtEmail" Width="165px"  runat="server"></asp:TextBox>&nbsp;<asp:RegularExpressionValidator ID="regExtxtEmailId" runat="server" EnableClientScript="true" ControlToValidate="txtEmail" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ErrorMessage="Enter Valid Email-Id"></asp:RegularExpressionValidator>
    </td>
    </tr>
    
   </table> 
    </td>
    </tr> 
   
   
    <tr><td>&nbsp;</td></tr>
      <%-- <tr> <td class="tdheader">&nbsp;Service Effected</td> </tr>
       <tr><td>
       <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td width="14%">Service Name</td>
    <td width="25%" align="left">
   <asp:DropDownList ID="drpservices" runat="server" Width="165px" AutoPostBack="true">
   <asp:ListItem>Email</asp:ListItem>
    <asp:ListItem></asp:ListItem>
   </asp:DropDownList>
    </td>
    <td>&nbsp;&nbsp;</td>
    </tr>
    <tr><td>&nbsp;&nbsp;</td>
    
    <td>&nbsp;&nbsp;</td></tr>
    
   </table> 
       </td></tr>--%>
       <tr><td>&nbsp;</td></tr>
        <%-- <tr> <td class="tdheader">&nbsp;Asset Involved</td> </tr> 
        <tr><td>&nbsp;</td></tr>--%>
        
<tr><td class="tdheader">&nbsp;Change Details</td></tr>
<tr><td>&nbsp;</td></tr>
         <tr>
         <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
         
          <tr>
   
    
   
    <td><font class="mandatory">*</font>Title</td>
     <td colspan="3"><asp:TextBox ID="txtTitle" runat="server" Width="350px"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValSubject" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="Enter Subject"></asp:RequiredFieldValidator></td>
    </tr>
    
     <tr>
    <td>&nbsp;&nbsp;Description</td>
     <td colspan="3"><asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="50px" runat="server" Width="620px"></asp:TextBox>
     
     
     </td>
    </tr>
    
         </table>
           </ContentTemplate>
          </asp:UpdatePanel>
         </td>
         
         </tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
          <tr>
        <td  class="tdheader" align="center">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnAdd" runat="server" Text="Add Change"  OnClick="buttonadd_click" 
                 />&nbsp;&nbsp;
            <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset"   />
            </ContentTemplate>
          </asp:UpdatePanel>
            </td>
         </tr>
    
    
      <tr><td>&nbsp;</td></tr>
  
  
  
    <tr><td>&nbsp;</td></td></tr> 
    
    <tr><td align="center"> 
   
       
        </td></tr>
       

 
        
   
   

</table>
</td></tr>
</table>
    </form>
</body>
</html>
