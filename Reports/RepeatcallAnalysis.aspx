<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepeatcallAnalysis.aspx.cs" Inherits="Reports_RepeatcallAnalysis" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
   <%--  <link href="../Include/styles.css" type="text/css" rel="stylesheet" />--%>
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
    <style type="text/css">
        .style2
        {
            width: 61px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <table  width="100%" cellpadding="0" cellspacing="0" align="center">
         <tr><td class="style2">&nbsp;</td></tr>
         <tr>
        <td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;
        </td>
       
            
    </tr>
     <tr><td class="style2">&nbsp;</td></tr>
           
            <tr>
            <td><table>
            <tr>
             <td  align="left">&nbsp;</td>
            <td valign="top" >&nbsp;</td>
             <td align="left" >Asset</td>
             <td valign="top" >
                <%--added by lalit--%>
                 <asp:DropDownList ID="DrpAsset" runat="server" 
                    >
                 </asp:DropDownList>
                </td>
                <%--endded by lalit--%>
             </tr>
            <tr>
             <td  align="left">Category 
            
            </td>
            <td valign="top" ><asp:DropDownList ID="drpcategory" runat="server"  OnSelectedIndexChanged="drpcategory_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList></td>
             <td align="left" >Subcategory </td>
             <td valign="top" ><asp:DropDownList ID="drpsubcategory" runat="server" OnSelectedIndexChanged="drpsubcategory_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList></td>
             </tr>
             <tr>
             <td align="left" >Title &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td valign="top"> <asp:DropDownList ID="drptitle" runat="server"  ></asp:DropDownList></td>
            <td align="left" >User
            </td>
            <td valign="top"> <asp:DropDownList ID="drpuser" runat="server"  ></asp:DropDownList></td>
            </tr>
            <tr><td valign="top">From</td>
            <td  valign="middle"><asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                    <img id="img1" style="vertical-align: middle;" onclick="scwShow(document.getElementById('<%=txtFromDate.ClientID%>'),this);"
                        src="../images/cal.gif" alt="date" />&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="ReqvalDate" 
                                            runat="server" 
                                            ErrorMessage="Enter the Date" 
                                            ControlToValidate="txtFromDate">
                                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regDate" 
                                            runat="server" 
                                            ControlToValidate="txtFromDate" 
                                            ErrorMessage="Enter date into right format" 
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">
                                        </asp:RegularExpressionValidator>
                                        </td>
            <td valign="top">To</td>
            <td valign="middle"> <asp:TextBox ID="txttoDate" runat="server"></asp:TextBox>
                    <img id="img2" style="vertical-align:  middle;" onclick="scwShow(document.getElementById('<%=txttoDate.ClientID%>'),this);"
                        src="../images/cal.gif" alt="date" />&nbsp;&nbsp;
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                            runat="server" 
                                            ErrorMessage="Enter the Date" 
                                            ControlToValidate="txttoDate">
                                        </asp:RequiredFieldValidator>
                        
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                            runat="server" 
                                            ControlToValidate="txttoDate" 
                                            ErrorMessage="Enter date into right format" 
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">
                                        </asp:RegularExpressionValidator></td></tr>
            
            
            </table></td></tr>
            <tr><td>
            <table>
            <tr>
            
            </tr></td></tr></table>
            <td></td>

            <tr >
            <td align="left" colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"  align="left">
             <asp:Button ID="btnViewreport" runat="server" Text="View Report" 
                        onclick="btnViewreport_Click" /> &nbsp;&nbsp;&nbsp;
            </td>
            </tr>
            
       <tr><td class="style2">&nbsp;</td></tr>
    
            <tr>
                <td align="center" colspan="5">
                    <rsweb:reportviewer ID="ReportViewer1" runat="server" 
                        BackColor="LightSteelBlue" ShowParameterPrompts="false"
                        BorderColor="Black" Font-Names="Verdana" Font-Size="8pt" Width="100%"   
                        ShowBackButton="true" ShowDocumentMapButton="true" 
                        ShowFindControls="true" ShowPrintButton="true" ShowToolBar="true" 
                        Height="620px">
                    </rsweb:reportviewer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
