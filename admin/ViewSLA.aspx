<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="ViewSLA.aspx.cs" Inherits="admin_ViewSLA" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
       
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <tr>
                            <td width="32%">&nbsp;</td>
                            <td width="78%"> &nbsp;</td>
                        </tr>
                        <tr>
                            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;&nbsp;&nbsp;&nbsp;View Service Level Aggrement (SLA)</td>
                            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="right" ><asp:LinkButton ID="lnkAddSLA" 
                                    runat="server" 
                                    Text="[Add SLA]"
                                    Font-Bold="true" ForeColor="White"
                                    CausesValidation="false" 
                                    onclick="lnkAddSLA_Click">
                                </asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                       
                        <tr style="padding-top:10px;">
                            <td width="50%" align="left">
                                <Font class="mandatory"></Font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select Customer &nbsp;&nbsp;
                                <asp:DropDownList ID="drpRegion"  Width="155px"
                                    AutoPostBack="true" 
                                    runat="server" 
                                    onselectedindexchanged="drpRegion_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>                             
                        </tr>
                        <tr>
                            <td width="50%"  align="left">
                                <font class="mandatory"></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="drpSites"  Width="155px"
                                    AutoPostBack="true" 
                                    runat="server" 
                                    onselectedindexchanged="drpSites_SelectedIndexChanged">
                                </asp:DropDownList>&nbsp;&nbsp;
                            </td>
                        </tr>
                     
                        <tr style="padding-top:8px;">
                            <td align="center"  colspan="5">
                                <asp:GridView ID="grdvwSla" 
                                    runat="server"  CssClass="grid-view"
                                    AutoGenerateColumns="False" 
                                    CellPadding="0" 
                                    ForeColor="Black"  
                                    CellSpacing="0"
                                    GridLines="Vertical" 
                                    BackColor="White" 
                                    BorderColor="#DEDFDE"  
                                    BorderStyle="None" 
                                    BorderWidth="1px" 
                                    OnRowDataBound="grdvwSla_RowDataBound" 
                                    OnRowDeleting="grdvwSla_RowDeleting"  
                                    OnRowEditing="grdvwSla_RowEditing" 
                                    OnPageIndexChanging="grdvwSla_PageIndexChanging"
                                    PageSize="10" 
                                    AllowPaging="true" 
                                    Width="984px">
                                    <FooterStyle BackColor="#CCCC99" />
                                    <RowStyle BackColor="white"/>
                                    <Columns>
                                        <asp:BoundField HeaderText="SLA Id"  DataField="slaid" ReadOnly="true" />
                                        <asp:BoundField HeaderText="SLA Name"  DataField="slaname" ReadOnly="true" />
                                        <asp:BoundField HeaderText="Site Name" DataField="siteid" ReadOnly="true"  />
                                        <asp:BoundField HeaderText="Enable" DataField="enable" ReadOnly="true"  />
                                        <asp:BoundField HeaderText="CreateDatetime" DataField="CreateDatetime" ReadOnly="true"  />
                                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"   />
                                        <asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />
                                    </Columns>
                                    <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                                    <AlternatingRowStyle  BackColor="Silver" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;</td>
                            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="right" > 
                                &nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>      
    </table>
</asp:Content>

