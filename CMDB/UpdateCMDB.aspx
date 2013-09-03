<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCMDB.aspx.cs" Inherits="CMDB_UpdateCMDB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CMDB Update</title>
    <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript">
        function refreshParent() 
        {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow)
	        {
                window.opener.progressWindow.close()
            }
                window.close();
           }
          
        
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    
      <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
      <tr><td>&nbsp;</td></tr>
<tr><td><asp:UpdatePanel ID="CategoryPanal1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel></td></tr>
 <tr><td>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td height="20px" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Change Details</td>
           
    </tr>
    <tr><td>&nbsp;</td></tr>
   
   
    <tr><td>
    <asp:UpdatePanel ID="CategoryPanal2" runat="server">
<ContentTemplate>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr>
    
   <td width="10%">&nbsp;&nbsp;ChangeID</td>
    <td width="18%" align="left"><asp:Label ID="lblchangeid" runat="server"></asp:Label>
    
   </td>
    <td width="10%">&nbsp;&nbsp;Title</td>
    <td width="25%" align="left">
    <asp:Label ID="lbltitle" runat=server></asp:Label>
    
    </td>
    </tr>
  
    
     <tr>
    <td width="10%" align="left">&nbsp;&nbsp;Category</td>
    <td width="18%" align="left">
<asp:Label ID="lblcategory" runat="server"></asp:Label>
     
    
    </td>
    <td width="10%">&nbsp;&nbsp;SubCategory</td>
    <td width="25%" align="left">
    <asp:Label ID="lblsubcategory" runat="server"></asp:Label>
    </td>
    </tr>
     <tr>
    <td width="10%" align="left">&nbsp;&nbsp;Change Type </td>
    <td width="18%" align="left">
    
     
    <asp:Label ID="lblchangetype" runat="server"></asp:Label>
    </td>
    
    </table>
  
    </ContentTemplate>
</asp:UpdatePanel>
   </td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr>
        <td height="20px" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            Asset Details</td>
           
    </tr>
   
    <tr>
    <td>
     <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
    <tr >
    <td width="10%">&nbsp;&nbsp;AssetID</td>
    <td width="18%" align="left">
   <asp:Label ID="lblassetid" runat="server"></asp:Label>
    </td>
    <td width="10%">&nbsp;&nbsp;ItemSerialNo</td>
    <td width="25%" align="left">
   <asp:Label ID="lblserialno" runat="server"></asp:Label>&nbsp;&nbsp;
    </td>
    </tr>
    <tr >
    <td width="10%">&nbsp;&nbsp;Item</td>
    <td width="18%" align="left">
   <asp:Label ID="lblitemname" runat="server"></asp:Label>
    </td>
    <td width="10%">&nbsp;&nbsp;Vendor</td>
    <td width="25%" align="left">
   <asp:Label ID="lblvendor" runat="server"></asp:Label>&nbsp;&nbsp;
    </td>
    </tr>
    
   </table> 
    </td>
    </tr> 
   
   
    <tr><td>&nbsp;</td></tr>
     
       <tr><td>&nbsp;</td></tr>

        
<tr><td height="20px" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;CMDB Information</td></tr>
<tr><td>&nbsp;</td></tr>
         <tr>
         <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
         
        
    
         </table>
           </ContentTemplate>
          </asp:UpdatePanel>
         </td>
         
         </tr>
         <tr><td>&nbsp;</td></tr>
         <tr><td><asp:Panel id="panalupdatecmdb" runat="server">
    
    <asp:PlaceHolder ID="PlaceHolderParams" runat="server"></asp:PlaceHolder>
    
    </asp:Panel></td></tr>
          <tr>
        <td height="20px" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnupdate" runat="server" Text="Update Change"  OnClick="btnupdate_Click" />
                 &nbsp;&nbsp;
           
            </ContentTemplate>
          </asp:UpdatePanel>
            </td>
         </tr>
    
    
      <tr><td>&nbsp;</td></tr>
  
  
  
    <tr><td>&nbsp;</td></td></tr> 
    
    <tr><td align="center"> 
   
       
        </td></tr>
       

 
        
   
   

</table>
    
    </div>
    </form>
</body>
</html>
