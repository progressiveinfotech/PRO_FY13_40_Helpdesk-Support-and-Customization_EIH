<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddImpact.aspx.cs" Inherits="admin_AddImpact" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="AddImpactPanal1" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="ImpactPanal2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">&nbsp;Add Impact</td>
                                <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td align="left" class="tdsubheading">
                                    <font class="mandatory">*</font>Impact Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtImpactName" runat="server" MaxLength="50"></asp:TextBox> &nbsp;
                                    <asp:RequiredFieldValidator ID="reqValImpact" 
                                        runat="server" 
                                        ControlToValidate="txtImpactName" 
                                        EnableClientScript="true"  
                                        SetFocusOnError="true"  
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdsubheading">&nbsp;&nbsp;Description </td>
                                <td>
                                    <asp:TextBox ID="txtImpactDesc" runat="server" Height="30px" Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                    <asp:Button ID="btnImpactadd" runat="server" onclick="btnImpactadd_Click" Text="Save"  />      
                                    <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" Text="Reset" onclick="btnReset_Click" />  
                                </td>
                            </tr>
  
                            <tr><td>&nbsp;</td></td>
    
                            <tr>
                                <td colspan="5" align="center"> 
                                    <asp:GridView ID="Impactgrdvw" 
                                        runat="server"  
                                        CssClass="grid-view"
                                        OnRowDeleting="Impactgrdvw_RowDeleting" 
                                        OnRowEditing="Impactgrdvw_RowEditing"
                                        OnRowCancelingEdit="Impactgrdvw_RowCancelingEdit" 
                                        OnRowUpdating="Impactgrdvw_RowUpdating" 
                                        OnPageIndexChanging="Impactgrdvw_PageIndexChanging"
                                        AutoGenerateColumns="False" 
                                        CellPadding="0" 
                                        ForeColor="Black"  
                                        CellSpacing="0"
                                        GridLines="Vertical" 
                                        BackColor="White" 
                                        BorderColor="#DEDFDE" 
                                        BorderStyle="None" 
                                        BorderWidth="1px" 
                                        Width="984px" 
                                        PageSize="3" 
                                        AllowPaging="true"> 
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="white"/>
                                        <Columns>
                                            <asp:BoundField HeaderText="Impact Id"  DataField="impactid" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Impact Name" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpactName" Text='<%# Eval("ImpactName") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate >
                                                    <asp:TextBox ID="txtImpactName" runat="server" Text='<%# Bind("ImpactName") %>' MaxLength="50"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Impact Description" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpactdesc" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtImpactdesc" runat="server" Text='<%# Bind("Description") %>' MaxLength="500"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
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

