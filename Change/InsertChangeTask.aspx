<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertChangeTask.aspx.cs" Inherits="Change_InsertChangeTask" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
      <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
      
      <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
      <script language="javascript" type="text/javascript" src="../JScript/datetimepicker.js"></script>
     
    <title>Insert Change Task</title>
    <script language="javascript" type="Text/Javascript">
     
function refreshParent() {
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
   
      <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></td></tr>
<tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" height="25px">&nbsp;&nbsp;Task</td></tr>
 <tr><td>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  
    <tr><td>&nbsp;</td></tr>
        <tr>
       <td>
   
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
   
    <td Columns="50" ><font class="mandatory">*</font>Title</td>
     <td ><asp:TextBox ID="txttitle" runat="server" ></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ForeColor="Red" ErrorMessage="Enter Subject"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
    <td>&nbsp;&nbsp;Description</td>
     <td ><asp:TextBox ID="txtdescription" TextMode="MultiLine"  Columns="70" Height="40px" runat="server" ></asp:TextBox>
     
     
     </td>
    </tr>
    </table>
    
   </td></tr>
   <tr><td>&nbsp;&nbsp;</td></tr>

    <tr><td>
   
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
       <tr>
         <td>
           
         <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
         
     
    
     
    <tr>
     <td >&nbsp;Scheduled Start Time</td>
    <td align="left">
   <asp:TextBox ID="txtschedlstarttime" runat="server" Width="130px"></asp:TextBox>&nbsp;<a href="javascript:NewCal('txtschedlstarttime','ddmmmyyyy',true,12)"><img src="../images/calender.gif" width="16" height="16" border="0" alt="Pick a date"></a>
       
   
    </td>
    <td >&nbsp;Scheduled End Time

</td>
    <td align="left"><asp:TextBox ID="txtschdlendtime" runat="server" Width="130px"></asp:TextBox>&nbsp;<a href="javascript:NewCal('txtschdlendtime','ddmmmyyyy',true,12)"><img src="../images/calender.gif" width="16" height="16" border="0" alt="Pick a date"></a>
     
       
    </td>
    </tr>
    <tr>
    <td >&nbsp;&nbsp; Actual Start Time</td>
    <td  align="left">
    <asp:TextBox ID="txtatsttime" runat="server" Width="130px"> </asp:TextBox>&nbsp;<a href="javascript:NewCal('txtatsttime','ddmmmyyyy',true,12)"><img src="../images/calender.gif" width="16" height="16" border="0" alt="Pick a date"></a>
    </td>
    
    <td >Actual End time</td>
    <td  align="left">
   
    <asp:TextBox ID="txtatendtime" runat="server" Width="130px" > </asp:TextBox>&nbsp;<a href="javascript:NewCal('txtatendtime','ddmmmyyyy',true,12)"><img src="../images/calender.gif" width="16" height="16" border="0" alt="Pick a date"></a>
                         
    </td>
        
    </tr>
     <tr>
    <td  align="left">&nbsp; Owner</td>
    <td  align="left">
     <asp:DropDownList ID="drpTechnician1" runat="server"></asp:DropDownList> 
    </td>
    <td >Status</td>
    <td align="left">
       <asp:DropDownList ID="drptaskstatus" runat="server">
       <asp:ListItem Text="Open" Value="1"></asp:ListItem>
       <asp:ListItem Text="Closed" Value="2"></asp:ListItem>
       </asp:DropDownList> 
    </td>
    </tr>
         </table>
          
         </td>
         
         </tr>
    <tr>
    
   
     
   
    </table>
  
   
   </td></tr>
      <tr><td>&nbsp;</td></tr>
       
   
  
   
   
    <tr><td>&nbsp;</td></tr>
    
       <tr><td>&nbsp;</td></tr>

        

         
         <tr><td>&nbsp;</td></tr>
         <tr><td>&nbsp;</td></tr>
          <tr>
        <td  class="tdheader" align="center">
        
            <asp:Button ID="btnAdd" runat="server" Text="Save"   
                OnClick="btnAdd_Click" />&nbsp;&nbsp;
                 <asp:Button ID="btnUpdate" runat="server" Text="Update" visible="false"  
                OnClick="btnUpdate_Click" />
            <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset"   />
         
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
