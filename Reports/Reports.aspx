<%@ Page Language="C#" MasterPageFile="~/Master/MasterReports.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports_Reports" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                <asp:Label ID="lblrep" runat="server" Font-Underline="true" Font-Names="Arial" Text="Reports" Font-Bold="true" Font-Size="19px" ForeColor="White"></asp:Label>
            </td>
        </tr>
    </table>
        <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td width="100%">
                    <table align="left" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="4%" align="center">
                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                            <td width="96%">&nbsp;
                            <asp:LinkButton ID="lnkrptAsset" 
                                OnClientClick="javascript:window.open('AssetReport.aspx','popupwindow','Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Generate Asset Report
                            </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkCallSheetReport" 
                                OnClientClick="javascript:window.open('CallSheetReport.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Generate Call Sheet Report
                            </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image2" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="LinkButton1" 
                                OnClientClick="javascript:window.open('TechnicianPerformance.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Technician Performance Report
                            </asp:LinkButton>
                            </td>
                        </tr>
                         <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image3" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="LinkButton2" 
                                
                                runat="server" 
                                ForeColor="#0066cc" onclick="LinkButton2_Click">CSM Old History
                            </asp:LinkButton>
                            </td>
                        </tr>
                       <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image4" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="rptrepeat" 
                                OnClientClick="javascript:window.open('RepeatcallAnalysis.aspx','popupwindow','width=1300,height=900,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Repeat Call Analysis
                            </asp:LinkButton>
                            </td>
                        </tr>
                         <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image5" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkpending" 
                                OnClientClick="javascript:window.open('PendingCallReport.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Pending Call Report
                            </asp:LinkButton>
                            
                            </td>
                        </tr>
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image6" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="LinkButton3" 
                                OnClientClick="javascript:window.open('MailNotification.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Selective Mail Notification Report
                            </asp:LinkButton>
                            
                            </td>
                        </tr>
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image7" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="LinkButton4" 
                                OnClientClick="javascript:window.open('CSatSurvey.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">C-Sat Survey Report
                            </asp:LinkButton>
                            
                            </td>
                        </tr>
                         <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image8" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="LinkButton5" 
                                OnClientClick="javascript:window.open('CSatCustomer.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Selective C-Sat Customer Report
                            </asp:LinkButton>
                            
                            </td>
                        </tr>
                         <tr>
                             <td width="4%" align="center">
                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">
                             <asp:LinkButton ID="LnkUserTrackReport" 
                                OnClientClick="javascript:window.open('PreviousUserRecord.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Previous User Track Report
                            </asp:LinkButton>
                            
                            </td>
                        </tr>
                         <tr>
                             <td width="4%" align="center">
                                    <asp:Image ID="Image10" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">
                             <asp:LinkButton ID="LinkButton6" 
                                OnClientClick="javascript:window.open('AssetReportInStock.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Stock Asset Report
                            </asp:LinkButton>
                             <tr>
                             <td width="4%" align="center">
                                    <asp:Image ID="Image12" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">
                             <asp:LinkButton ID="LinkButton8" 
                                OnClientClick="javascript:window.open('Severity1.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Severity1 Report
                            </asp:LinkButton>
                            
                          <tr>
                             <td width="4%" align="center">
                                    <asp:Image ID="Image11" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                             <td width="96%">
                             <asp:LinkButton ID="LinkButton7" 
                                OnClientClick="javascript:window.open('AMCCall.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">AMCCall
                            </asp:LinkButton>
                            
                            </td>
                        </tr>
                            
                            </td>
                        </tr>
                            
                          <tr>
                             <td width="4%" align="center">
                              <asp:Image ID="Image13" runat="server" ImageUrl="~/images/arrow.jpg" /></td> 
                              </td> 
                             <td width="96%">
                               <asp:LinkButton ID="LinkButton9" 
                                OnClientClick="javascript:window.open('OldCallsheetReport.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                runat="server" 
                                ForeColor="#0066cc">Old Call Sheet Report
                            </asp:LinkButton></td>
                        </tr>
                            
                            </table>
                </td>
            </tr>
           </table>
</asp:Content>
