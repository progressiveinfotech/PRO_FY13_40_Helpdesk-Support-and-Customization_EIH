<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddEmail.aspx.cs" Inherits="admin_AddEmail" Title="Untitled Page" %>

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
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="15%">&nbsp;Add Email Id for Escalate</td>
                                <td width="85%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>    
                            <tr>
                                <td align="right">
                                    <font class="mandatory">*</font>Email ID&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>         
                                    <asp:TextBox ID="txtEmailid" runat="server" MaxLength="50" Width="175px"></asp:TextBox> &nbsp;
                                    <asp:RequiredFieldValidator ID="rqvemail" 
                                        runat="server" 
                                        ControlToValidate="txtEmailid" 
                                        EnableClientScript="true" 
                                        ValidationGroup="Group1"
                                        ForeColor="Red" 
                                        ErrorMessage="Enter Email">
                                    </asp:RequiredFieldValidator>    &nbsp;
                                    <asp:RegularExpressionValidator ID="regExtxtEmailId" 
                                        runat="server" 
                                        EnableClientScript="true" 
                                        ControlToValidate="txtEmailid"
                                        ValidationGroup="Group1"
                                        ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" 
                                        ErrorMessage="Enter Valid Email-Id">
                                    </asp:RegularExpressionValidator>
                                         
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                    <asp:Button ID="btnEmailadd" ValidationGroup="Group1" CausesValidation="true" runat="server" onclick="btnEmailadd_Click" Text="Save"/>      
                                    <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" Text="Reset" onclick="btnReset_Click" />  
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></td>
                            <tr>
                                <td colspan="5" align="center"> 
                                    <asp:GridView ID="Emailgrdvw"
                                        runat="server"
                                        CssClass="grid-view"
                                        OnRowDeleting="Emailgrdvw_RowDeleting"
                                        OnRowEditing="Emailgrdvw_RowEditing"
                                        OnRowCancelingEdit="Emailgrdvw_RowCancelingEdit"
                                        OnRowUpdating="Emailgrdvw_RowUpdating"
                                        OnPageIndexChanging="Emailgrdvw_PageIndexChanging"
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
                                        PageSize="10"
                                        AllowPaging="true">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <RowStyle BackColor="white"/>
                                        <Columns>
                                        <asp:BoundField HeaderText="Id"  DataField="Id" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Email" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmailid" Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate >
                                                    <asp:TextBox ID="txtEmail" Width="175px" runat="server" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="regEmailId"
                                                        runat="server"
                                                        EnableClientScript="true"
                                                        ControlToValidate="txtEmail"
                                                        ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" 
                                                        ErrorMessage="Enter Valid Email-Id">
                                                    </asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="true"/>
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

