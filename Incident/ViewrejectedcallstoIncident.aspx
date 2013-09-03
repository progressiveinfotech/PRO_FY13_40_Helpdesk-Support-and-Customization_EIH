<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewrejectedcallstoIncident.aspx.cs" Inherits="Incident_ViewrejectedcallstoIncident" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RejectCalls to Incident</title>
    <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">

        function redirect() 
        {
            window.opener.location.href ="../Incident/IncidentRequest.aspx";
//            if (window.opener.progressWindow)
//	          {
//                window.opener.progressWindow.close()
//            }
               window.close();
//             window.location.href="../Incident/IncidentRequest.aspx";          
        }
        function refreshParent()
        {
          
            window.opener.location.href =window.opener.location.href;
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
    <div>
    
        <table align="center" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="center" width="100" class="tdheader">
                    Subject</td>
                <td class="tdheader">
                    <asp:TextBox ID="TxtSubject" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="tdheader">
                    Mail From </td>
                <td class="tdheader">
                    <asp:TextBox ID="TxtMailFrom" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="tdheader">
                    Description</td>
                <td class="tdheader">
                    <asp:TextBox ID="TxtBody" runat="server" Height="200px" TextMode="MultiLine" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="tdheader">
                    &nbsp;</td>
                <td class="tdheader">
                    <asp:Button ID="BtnClick" runat="server" Text="Convert To Call" 
                        onclick="BtnClick_Click" />&nbsp;
                   
                <asp:Button ID="BtnCancel" runat="server" Text="Delete" 
                            onclick="BtnCancel_Click" /> &nbsp;
                    
                        
                    <asp:Button ID="Btnclose" OnClientClick="javascript:window.close()" 
                        runat="server" Text="Close" onclick="Btnclose_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
