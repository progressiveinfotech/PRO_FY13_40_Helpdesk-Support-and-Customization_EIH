<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterReports.master" AutoEventWireup="true"
    CodeFile="HelpdeskReports.aspx.cs" Inherits="Reports_HelpdeskReports" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                &nbsp;&nbsp;Reports
            </td>
        </tr>
    </table>
    <cc1:Accordion ID="Accordion2" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250" AutoSize="none"
        Height="425px" RequireOpenedPane="false" SuppressHeaderPostbacks="true" HeaderSelectedCssClass="accordionHeaderSelected">
        <Panes>
            <%--    <cc1:AccordionPane ID="AccordionPane1" runat="server">
       <Header>
      <table width="100%" align="center" cellpadding="0" cellspacing="0">
    <tr>
    <td width="2%" background="../images/left.bmp">
    <td  height="25px" width="96%" background="../images/qwe.bmp"><a href="#"><strong><font  color="#0066cc">General Report </font> </strong></a></td>
    <td width="2%" background="../images/right.bmp"></td>
    </tr>
   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center">
              
                  
                  <tr>
                 
                 <td  height="18px" width="2%" background="../images/report.bmp" ></td>
                  <td width="98%" bgcolor=LightGrey  valign="top" ><asp:LinkButton ID="comp_info_br" runat="server" ForeColor="#0099cc" Font-Bold="True" >General Computer Information(Brief)</asp:LinkButton></td>
                 
                  
                  </tr>
                  <tr>
                 
                 <td  height="18px" width="2%" background="../images/report.bmp" ></td>
                  <td width="98%" bgcolor="" valign="top" > <asp:LinkButton ID="main_report" ForeColor="#0099cc" runat="server" Font-Bold="true">General Computer Information(Detail)</asp:LinkButton></td>
                 
                  
                  </tr>
                  <tr>
                 
                 <td  height="18px" width="2%" background="../images/report.bmp" ></td>
                  <td width="98%"  bgcolor=LightGrey valign="top" ><asp:LinkButton ID="lnkAllinfo" ForeColor="#0099cc" runat="server" Font-Bold="True" >All Systems Information Report</asp:LinkButton> </td>
                 
                  
                  </tr>
                  <tr>
                 
                 <td  height="18px" width="2%" background="../images/report.bmp" ></td>
                  <td width="98%"  bgcolor="" valign="top" ><asp:LinkButton ID="inventory_statistic" ForeColor="#0099cc" runat="server" Font-Bold="True" >Inventory Statistic Report</asp:LinkButton>  </td>
                 
                  
                  </tr>
                   <tr>
                 
                 <td  height="18px" width="2%" background="../images/report.bmp" ></td>
                  <td width="98%"  bgcolor=LightGrey valign="top" ><asp:LinkButton ID="lnkAssetDiff" ForeColor="#0099cc" runat="server" Font-Bold="true">Asset Comparison Report by Computer Name</asp:LinkButton>  </td>
                 
                  
                  </tr>
                   <tr>
                 
                 <td  height="18px" width="2%" background="../images/report.bmp" ></td>
                  <td width="98%"  bgcolor="" valign="top" ><asp:LinkButton ID="lnkAssetdiffhrdw" ForeColor="#0099cc" runat="server" Font-Bold="true">Asset Comparison Report</asp:LinkButton></td>
                 
                  
                  </tr>
                   
                     
                  </table>
       
       </Content>
       
       </cc1:AccordionPane>--%>
            <cc1:AccordionPane ID="AccordionPane2" runat="server">
                <Header>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="2%" background="../images/left.bmp">
                                <td height="25px" width="96%" background="../images/qwe.bmp">
                                    <a href="#"><strong><font color="#0066cc">Incident Report </font></strong></a>
                                </td>
                                <td width="2%" background="../images/right.bmp">
                                </td>
                        </tr>
                    </table>
                </Header>
                <Content>
                    <table width="100%" align="center">
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="lnkCallSheetReport" OnClientClick="javascript:window.open('CallSheetReport.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Generate Call Sheet Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="LinkButton1" OnClientClick="javascript:window.open('TechnicianPerformance.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Technician Performance Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="#0066cc" OnClick="LinkButton2_Click">CSM Old History
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="rptrepeat" OnClientClick="javascript:window.open('RepeatcallAnalysis.aspx','popupwindow','width=1300,height=900,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Repeat Call Analysis
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="lnkpending" OnClientClick="javascript:window.open('PendingCallReport.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Pending Call Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="LinkButton3" OnClientClick="javascript:window.open('MailNotification.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Selective Mail Notification Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="LinkButton4" OnClientClick="javascript:window.open('CSatSurvey.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">C-Sat Survey Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="LinkButton5" OnClientClick="javascript:window.open('CSatCustomer.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Selective C-Sat Customer Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="LnkUserTrackReport" OnClientClick="javascript:window.open('PreviousUserRecord.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Previous User Track Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="LinkButton8" OnClientClick="javascript:window.open('Severity1.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Severity1 Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="LinkButton7" OnClientClick="javascript:window.open('AMCCall.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">AMCCall
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="AccordionPane3" runat="server">
                <Header>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="2%" background="../images/left.bmp">
                                <td height="25px" width="96%" background="../images/qwe.bmp">
                                    <a href="#"><strong><font color="#0066cc">Asset Report </font></strong></a>
                                </td>
                                <td width="2%" background="../images/right.bmp">
                                </td>
                        </tr>
                    </table>
                </Header>
                <Content>
                    <table width="100%" align="center">
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="lnkrptAsset" OnClientClick="javascript:window.open('AssetReport.aspx','popupwindow','Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Generate Asset Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="LinkButton6" OnClientClick="javascript:window.open('AssetReportInStock.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Stock Asset Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                       
                  <%--      <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="LinkButton9" OnClientClick="javascript:window.open('AssetReportInStock.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">General Computer Information(Detail)
                                </asp:LinkButton>
                            </td>
                        </tr>--%>
                     <%--   <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor=""  valign="top">
                                <asp:LinkButton ID="LinkButton10" OnClientClick="javascript:window.open('AssetReportInStock.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">All Systems Information Report
                                </asp:LinkButton>
                            </td>
                        </tr>--%>
                     <%--   <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="LinkButton11" OnClientClick="javascript:window.open('AssetReportInStock.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Inventory Statistic Report
                                </asp:LinkButton>
                            </td>
                        </tr>--%>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="LinkButton12" OnClientClick="javascript:window.open('AssetDiffReport.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Asset Comparison Report by Computer Name
                                </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="LinkButton13" OnClientClick="javascript:window.open('AssetComparisonReport.aspx','popupwindow','width=1000,height=850,left=150,top=40,Scrollbars=yes');"
                                    runat="server" ForeColor="#0066cc">Asset Comparison Report
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="AccordionPane4" runat="server">
                <Header>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="2%" background="../images/left.bmp">
                                <td height="25px" width="96%" background="../images/qwe.bmp">
                                    <a href="#"><strong><font color="#0066cc">Problem Management Report </font></strong>
                                    </a>
                                </td>
                                <td width="2%" background="../images/right.bmp">
                                </td>
                        </tr>
                    </table>
                </Header>
                <Content>
                    <table width="100%" align="center">
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="os_reg_info" runat="server" Font-Bold="True">Operating System Registration Info</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="lnkhotfix" runat="server" Font-Bold="true">Hotfixes Report</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="AccordionPane5" runat="server">
                <Header>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="2%" background="../images/left.bmp">
                                <td height="25px" width="96%" background="../images/qwe.bmp">
                                    <a href="#"><strong><font color="#0066cc">Others Report </font></strong></a>
                                </td>
                                <td width="2%" background="../images/right.bmp">
                                </td>
                        </tr>
                    </table>
                </Header>
                <Content>
                    <table width="100%" align="center">
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="LightGrey" valign="top">
                                <asp:LinkButton ID="lnksoftware" Font-Bold="true" runat="server"> Software Report</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="18px" width="2%" background="../images/report.bmp">
                            </td>
                            <td width="98%" bgcolor="" valign="top">
                                <asp:LinkButton ID="lnkSoftDiff" Font-Bold="true" runat="server"> Software Difference Report</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </Content>
            </cc1:AccordionPane>
        </Panes>
    </cc1:Accordion>
    <br />
    <cc1:Accordion ID="cs" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader"
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250" AutoSize="none"
        Height="425px" RequireOpenedPane="false" SuppressHeaderPostbacks="true" HeaderSelectedCssClass="accordionHeaderSelected">
        <Panes>
            <cc1:AccordionPane ID="a" runat="server">
                <Header>
                </Header>
                <Content>
                </Content>
            </cc1:AccordionPane>
        </Panes>
    </cc1:Accordion>
</asp:Content>
