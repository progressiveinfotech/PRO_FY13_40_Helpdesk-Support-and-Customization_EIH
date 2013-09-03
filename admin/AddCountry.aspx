<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddCountry.aspx.cs" Inherits="admin_AddCountry" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="CategoryPanal1" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="CategoryPanal2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="15%">&nbsp;Add Country</td>
                                <td width="85%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
                            </tr> 
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td align="left" class="tdsubheading">
                                    <font class="mandatory">*</font>Enter Country Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCountryName" runat="server" MaxLength="50"></asp:TextBox> &nbsp;
                                    <asp:RequiredFieldValidator ID="reqValCountry" 
                                        runat="server" 
                                        ControlToValidate="txtCountryName" 
                                        EnableClientScript="true"  
                                        SetFocusOnError="true"  
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator> 
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                    <asp:Button ID="btnCountryadd" runat="server" Text="Save" onclick="btnCountryadd_Click"  />      
                                    <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" Text="Reset" onclick="btnReset_Click"  />  
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="2" align="center"> 
                                    <asp:GridView ID="grvwCountry" 
                                        runat="server"  
                                        CssClass="grid-view"
                                        AutoGenerateColumns="False" 
                                        CellPadding="0" 
                                        ForeColor="Black"  
                                        CellSpacing="0"
                                        GridLines="Vertical" 
                                        BackColor="White" 
                                        BorderColor="#DEDFDE"  
                                        OnPageIndexChanging="grvwCountry_PageIndexChanging"
                                        OnRowDeleting="grvwCountry_RowDeleting" 
                                        OnRowEditing="grvwCountry_RowEditing" 
                                        OnRowCancelingEdit="grvwCountry_RowCancelingEdit" 
                                        OnRowUpdating="grvwCountry_RowUpdating"
                                        BorderStyle="None" 
                                        BorderWidth="1px" 
                                        Width="984px" 
                                        PageSize="10" 
                                        AllowPaging="true">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="white"/>
                                        <Columns>
                                            <asp:BoundField HeaderText="Country Id"  DataField="countryid" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Country Name" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCountryName" Text='<%# Eval("countryname") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate >
                                                    <asp:TextBox ID="txtCountryName" runat="server" Text='<%# Bind("countryname") %>' MaxLength="50"></asp:TextBox>
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

