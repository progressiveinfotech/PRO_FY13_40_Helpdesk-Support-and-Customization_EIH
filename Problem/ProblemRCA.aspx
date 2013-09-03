<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProblemRCA.aspx.cs" Inherits="Problem_ProblemRCA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table><tr><td>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
     <tr><td bgcolor="#333399"></td><td  bgcolor="#333399" style=" font-family:Verdana; font-size:medium;" width="100%"><font color="white">Root Cause Analysis (RCA) Template</font>  
 </td><td bgcolor="#333399"></td><td bgcolor="#333399"></td></tr></table></td></tr>

 <tr><td>
 <table border="1">
 <tr>
 <td bgcolor="#99ccff">Problem No</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lbltcktno"></asp:Label></td>
 <td  bgcolor="#99ccff">Date</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lblcreatedate"></asp:Label></td></tr>
 <tr>
 <td  bgcolor="#99ccff">Start Time</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lblstarttime"></asp:Label></td>
 <td  bgcolor="#99ccff">Service Effected</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lblserviceeffected"></asp:Label></td></tr>
 <tr>
 <td  bgcolor="#99ccff">End Time</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lblendtime"></asp:Label></td>
 <td bgcolor="#99ccff">Component Effected</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lblcomponenteffected"></asp:Label></td></tr>
 <tr>
 <td  bgcolor="#99ccff">Problem Owner:</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lblengineer"></asp:Label></td>
 <td  bgcolor="#99ccff">Customer/ Group Affected:</td>
 <td align="left" bgcolor="#ccffff"><asp:Label runat="server" ID="lblcustomer"></asp:Label></td></tr>
 </table>
 </td></tr>
 <tr><td>
 <table>
 <tr>
 <td bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399" ></td>
 <td  bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td></tr>

 
 </table>
 </td></tr>
 <tr><td>
  <table  width="1000px" >
  <tr>
 <td  bgcolor="#99ccff" width="300 px">Issue Description</td>
 <td width="65px" bgcolor="#ccffff"><asp:Label runat="server" ID="lbldescription"></asp:Label></td>
  <td bgcolor="#ccffff"></td>
 <td bgcolor="#ccffff"></td>
 </tr>
  </table>
 </td></tr>
 <tr><td>
 <table>
 <tr>
 <td bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td>
 <td  bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td></tr>

 
 </table>
 </td></tr>
 <tr><td>
  <table  width="1000px">
  <tr>
 <td bgcolor="#99ccff">Symptom</td>
 <td bgcolor="#ccffff"><asp:Label runat="server" ID="lblsymptom"></asp:Label></td>
  <td bgcolor="#ccffff"></td>
 <td bgcolor="#ccffff"></td>
 </tr>
  </table>
 </td></tr>
 <tr><td>
 <table>
 <tr>
 <td bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td>
 <td  bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td></tr>

 
 </table>
 </td></tr>
 <tr><td>
  <table  width="1000px">
  <tr>
 <td  bgcolor="#99ccff">Actual Cause/Observation:</td>
 <td bgcolor="#ccffff"><asp:Label runat="server" ID="lblcause"></asp:Label></td>
  <td bgcolor="#ccffff"></td>
 <td bgcolor="#ccffff"></td>
 </tr>

  </table>
 </td></tr>
 <tr><td>
 <table>
 <tr>
 <td bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td>
 <td  bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td></tr>

 
 </table>
 </td></tr>
 <tr><td>
  <table  width="1000px">
  <tr>
 
 <td  bgcolor="#99ccff">RCA Result:</td>
 <td bgcolor="#ccffff"><asp:Label runat="server" ID="lblrcaresult"></asp:Label></td>
 <td bgcolor="#ccffff"></td>
 <td bgcolor="#ccffff"></td>
 </tr>
  </table>
 </td></tr>
 <tr><td>
 <table>
 <tr>
 <td bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td>
 <td  bgcolor="#333399"></td>
 <td align="left" bgcolor="#333399"></td></tr>

 
 </table>
 </td></tr>
 <tr><td>
 <table>
  
 <tr>
 <td  bgcolor="#99ccff">Issue Resolution Steps:</td>
 <td bgcolor="#ccffff"><asp:Label runat="server" ID="lblresolution"></asp:Label></td>
  <td bgcolor="#ccffff"></td>
 <td bgcolor="#ccffff"></td>
 </tr>
 
    </table>
    </td></tr>
    </table>
    <div>
    
    </div>
    </form>
</body>
</html>
