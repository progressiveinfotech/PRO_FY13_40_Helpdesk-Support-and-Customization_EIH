<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddHub.aspx.cs" Inherits="admin_AddHub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">&nbsp;Add Mode</td>
                                <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td align="left" class="tdsubheading">
                                    <font class="mandatory">* </font>&nbsp;HuB Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHubName" runat="server" Height="20px" MaxLength="70"></asp:TextBox> &nbsp;
                                    <asp:RequiredFieldValidator ID="reqValMode" 
                                        runat="server" 
                                        ControlToValidate="txtHubName" 
                                        EnableClientScript="true"  
                                        SetFocusOnError="true"  
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdsubheading">&nbsp;HuB Description </td>
                                <td>
                                    <asp:TextBox ID="txtHubDescription" runat="server" runat="server" Height="30px" 
                                        Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
                                </td>
                            </tr>
                                <tr>
                                    <td class="tdsubheading" align="left">&nbsp;</td>                             
                                    <td> &nbsp;</td>
                                </tr>
                                <tr>
                                    <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
                                        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                            <asp:Button ID="btnHubadd" runat="server" onclick="btnHubadd_Click" 
                                                Text="Save"  />      
                                            <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" Text="Reset" onclick="btnReset_Click" />  
                                        </td>
                                </tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr>
                                        <td colspan="5" align="center"> 
                                            <asp:GridView ID="Modegrdw" 
                                                runat="server" 
                                                CssClass="grid-view"  
                                                AutoGenerateColumns="false" 
                                                CellPadding="0" 
                                                ForeColor="Black"  
                                                CellSpacing="0" 
                                                GridLines="Vertical" 
                                                BackColor="White" 
                                                BorderColor="#DEDFDE" 
                                                BorderStyle="None" 
                                                BorderWidth="1px" 
                                                Width="984px" 
                                                
                                                PageSize="10" 
                                                AllowPaging="true" >
                                                <FooterStyle BackColor="#CCCC99" />
                                                <RowStyle BackColor="white"/>
                                                <Columns>
                                                    <asp:BoundField HeaderText="Hub ID"  DataField="Hubid" ReadOnly="true" />
                                                    <asp:TemplateField HeaderText="Hub Name" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblModeame" Text='<%# Eval("Hubname") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtModeName" runat="server" Text='<%# Bind("Hubname") %>' MaxLength="50"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                   <%-- <asp:TemplateField HeaderText="Hub Description" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesc" Text='<%# Eval("Hubdescription") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>Hubdescription
                                                        <EditItemTemplate >
                                                            <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Hubdescription") %>' ></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField> --%>
                                                   <%-- <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"  />
                                                    <asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />--%>
                                                </Columns>
                                                <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                                                <AlternatingRowStyle  BackColor="Silver" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
