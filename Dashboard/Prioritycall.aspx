<%@ Page Language="C#" MasterPageFile="~/Dashboard/MasterPage.master" AutoEventWireup="true" CodeFile="Prioritycall.aspx.cs" Inherits="Dashboard_Prioritycall" Title="Untitled Page" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
        <table  width="100%" cellpadding="0" cellspacing="0" align="center">
         <tr><td>&nbsp;</td></tr>
         <tr>
        <td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;
        </td>
       
            
    </tr>
     <tr><td>&nbsp;</td></tr>
            <tr style="padding-top:10px;">
                 <td width="50%" align="left"><font style="color:Red;">*</font>
                From &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
              
                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
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
                 <td width="50%" align="left"><font style="color:Red;">*</font>
                    To &nbsp;&nbsp;
               
                    <asp:TextBox ID="txttoDate" runat="server"></asp:TextBox>
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
                                        </asp:RegularExpressionValidator>
                                       
                </td>
                
               
            </tr>
           
             <tr><td>&nbsp;</td></tr>
            <tr >
            <td align="right" colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"  align="left">
             <asp:Button ID="btnViewreport" runat="server" Text="View Report" onclick="btnViewreport_Click" 
                         /> &nbsp;&nbsp;&nbsp;
            </td>
            </tr>
            
       <tr><td>&nbsp;</td></tr>
    
            <tr>
                <td align="center" colspan="5">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="LightSteelBlue" ShowParameterPrompts="false"
                        BorderColor="Black" Font-Names="Verdana" Font-Size="8pt" Width="100%"   ShowBackButton="true" ShowDocumentMapButton="true" 
                        ShowFindControls="true" ShowPrintButton="true" ShowToolBar="true">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

