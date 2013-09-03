<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddChangeType.aspx.cs" Inherits="admin_AddChangeType" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="StatusPanal1" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="StatusPanal2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
                                    &nbsp;Add Change Type
                                </td>
                                <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>    
                            <tr>
                                <td align="left" class="tdsubheading">
                                    <font class="mandatory">*</font>Change Type Name
                                </td>
                            <td>         
                                <asp:TextBox ID="txtChangeTypeName" runat="server" MaxLength="50"></asp:TextBox> &nbsp;
                                <asp:RequiredFieldValidator ID="reqValStatus" 
                                    runat="server" 
                                    ControlToValidate="txtChangeTypeName" 
                                    EnableClientScript="true"  
                                    SetFocusOnError="true"  
                                    ForeColor="Red">
                                </asp:RequiredFieldValidator>                      
                            </td>       
                        </tr> 
                        <tr>
                            <td align="left" class="tdsubheading">
                                &nbsp;&nbsp;Description  
                            </td>
                            <td>          
                                <asp:TextBox ID="txtChangeTypeDesc" runat="server" Height="30px" Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>            
                            </td>    
                        </tr>
                        <tr><td>&nbsp;</td></tr>              
                        <tr>
                            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>           
                            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                <asp:Button ID="btnChangeTypeAdd" runat="server" onclick="btnChangeTypeAdd_Click" Text="Save"  />      
                                <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" Text="Reset" onclick="btnReset_Click" />      
                            </td>
                        </tr>  
                        <tr><td>&nbsp;</td></tr>    
                        <tr>
                            <td colspan="5" align="center"> 
                                <asp:GridView ID="ChangeTypegrdvw" 
                                    runat="server"  
                                    OnRowDeleting="ChangeTypegrdvw_RowDeleting" 
                                    OnRowEditing="ChangeTypegrdvw_RowEditing"
                                    OnRowCancelingEdit="ChangeTypegrdvw_RowCancelingEdit" 
                                    OnRowUpdating="ChangeTypegrdvw_RowUpdating"  
                                    OnPageIndexChanging="ChangeTypegrdvw_PageIndexChanging"
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
                                        <asp:BoundField HeaderText="ChangeType Id"  DataField="changetypeid" ReadOnly="true" />
                                        <asp:TemplateField HeaderText="ChangeType Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusName" Text='<%# Eval("ChangeTypename") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate >
                                                <asp:TextBox ID="txtStatusName" runat="server" Text='<%# Bind("ChangeTypename") %>' MaxLength="50"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ChangeType Description" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusdesc" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate >
                                                <asp:TextBox ID="txtStatusdesc" runat="server" Text='<%# Bind("Description") %>' MaxLength="500"></asp:TextBox>
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

