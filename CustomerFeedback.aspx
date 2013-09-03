<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerFeedback.aspx.cs" Inherits="WithoutLoginPageAccess_CustomerFeedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
      <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <title>Customer Feedback</title>
    <script language="javascript" Type="text/javascript" >
     function refreshParent() 
        {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow)
	        {
                window.opener.progressWindow.close();
            }
                window.close();
        }
        function CloseWindow()

{

window.opener = self;

window.close();



}


    
    </script>
    <style type="text/css">
        .style1
        {
            width: 867px;
        }
        .style2
        {
            width: 286px;
        }
        .style4
        {
            width: 312px;
        }
        .style5
        {
            background-color: #E1E1E1;
            font-weight: bold;
            height: 20px;
            width: 520px;
        }
        .style6
        {
            width: 520px;
        }
        .style7
        {
            width: 339px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
 &nbsp;<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    
  
    
   
   <tr><td class="style4" /><td class="style5"> <asp:Label ID="lblapprove" runat="server" ></asp:Label>
 <%-- &nbsp;Kindly provide your valuable feedback by choosing one of the Options.&nbsp;&nbsp;&nbsp;--%>
       <asp:Label ID="lblApproved" runat="server" Text="Kindly provide your valuable feedback by choosing one of the Options"></asp:Label>
       <br />
       <br />
       <%--<asp:Label ID="lblapprove0" runat="server" ></asp:Label>
       &nbsp;feedback save.&nbsp;&nbsp;&nbsp;
       <br />
       <br />--%>
 </td></tr>
    
 <tr><td class="style4" />
 <td class="style6"><table><tr><td class="style7"><asp:Label ID="labGood" runat="server" Text="Good"></asp:Label></td>
     <td class="style2"><asp:RadioButton  ID="satisfiedrdbutton" 
         runat="server" GroupName="id" 
         oncheckedchanged="satisfiedrdbutton_CheckedChanged" AutoPostBack="true"  /></td>
     <td class="style1">
         &nbsp;</td></tr>
 <tr><td class="style7"><asp:Label ID="labVeryGood" runat="server" Text="Very Good"></asp:Label></td>
     <td class="style2"><asp:RadioButton  ID="verysatisfied" runat="server" 
         GroupName="id" AutoPostBack="true" 
         oncheckedchanged="verysatisfied_CheckedChanged" /></td><td class="style1">&nbsp;</td></tr>
 <tr><td class="style7"><asp:Label ID="labAverage" runat="server" Text="Average"></asp:Label></td>
     <td class="style2"><asp:RadioButton  ID="Rddisatisfied" runat="server" 
         GroupName="id" AutoPostBack="true" 
         oncheckedchanged="Rddisatisfied_CheckedChanged"/></td><td class="style1">&nbsp;</td></tr>
 <tr><td class="style7"><asp:Label ID="labPoor" runat="server" Text="Poor"></asp:Label></td>
     <td class="style2"><asp:RadioButton  ID="Rdverydissatisfied" runat="server" 
         GroupName="id" AutoPostBack="true" 
         oncheckedchanged="Rdverydissatisfied_CheckedChanged" /></td>
     <td class="style1">&nbsp;</td></tr>
 <tr id="Rmk" runat="server" visible="false"><td class="style7"><asp:Label ID="lblRemark" runat="server" Text="Remark"></asp:Label></td>
     <td class="style2">
     <asp:TextBox ID="TextRmk" runat="server" TextMode="MultiLine" Height="100px" Width="250px"
         ontextchanged="TextRmk_TextChanged"></asp:TextBox>
  </td><td class="style1">
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
             ControlToValidate="TextRmk" ErrorMessage="Please enter remark."></asp:RequiredFieldValidator>
  </td></tr></table>
 
 <td align="center">
<asp:UpdatePanel ID="AddSolution1" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td class="style4"><table>
 
 
 </table><td class="style6" />
  &nbsp;<asp:Label ID="Lblmsg" ForeColor="Red" Visible="false" runat="server"></asp:Label></td>
 <td align="center">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
      
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td class="style4"><table></table>
  &nbsp; </td>
 <td align="center" class="style6">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr>
 <td class="style4"><table></table>
 </td>
 <td align="center" class="style6">
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
     <ContentTemplate>
     
     </ContentTemplate>
 </asp:UpdatePanel>
   
 </td></tr>
 <tr><td class="style4">&nbsp;</td></tr>
 
 <tr><td class="style4"/><td class="style5" align="center">

 <asp:Button ID="btnFeedback" runat="server" Text="Vote Feedback" OnClick="btnFeedback_Click"   />
<%--<asp:Button ID="btnreject" runat="server" Text="Reject" OnClick="btnreject_Click" />--%>
 <%--<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="javascript:window.close();" />--%>

     <br />
&nbsp;<br />
       <asp:Label ID="Lblmsg0" ForeColor="Red" Visible="false" runat="server"></asp:Label>

 </td><td /></tr>
  
     
 </table>
    <div>
    
    </div>
    </form>
</body>
</html>
