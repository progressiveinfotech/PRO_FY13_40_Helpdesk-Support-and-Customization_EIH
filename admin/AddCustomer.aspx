<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddCustomer.aspx.cs" Inherits="admin_AddCustomer" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" src="../JScript/scw.js"></script>
    <style type="text/css">
        .style1
        {
            height: 32px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
            <asp:UpdatePanel ID="CustomerPanal1" runat="server">
                <ContentTemplate>
                    <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
    <td>
        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                    &nbsp;Create Customer 
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="CustomerPanal2" runat="server">
                        <ContentTemplate>
                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td width="10%" class="style1">
                                        <font class="mandatory">*</font>Customer Name
                                    </td>
                                    <td width="18%" align="left" class="style1">
                                        <asp:TextBox ID="txtCustomername" Width="135px"  runat="server"></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqValCustomerName" 
                                            runat="server" 
                                            ControlToValidate="txtCustomername" 
                                            EnableClientScript="true"   
                                            SetFocusOnError="true"  
                                            ForeColor="Red"
                                            ErrorMessage="Enter Customer Name">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td width="10%" class="style1">&nbsp;&nbsp;Address</td>
                                    <td width="25%" align="left" class="style1">
                                        <asp:TextBox ID="txtAddress" 
                                        runat="server" 
                                        Height="30px" 
                                        Columns="45" 
                                        TextMode="MultiLine" 
                                        MaxLength="500" >
                                    </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                <td width="10%">&nbsp;&nbsp;EmailId</td>
                                    <td width="18%" align="left">
                                        <asp:TextBox ID="txtemail" 
                                            Width="135px"  
                                            runat="server" 
                                            AutoPostBack="true" >
                                        </asp:TextBox>&nbsp;
                                         <asp:RegularExpressionValidator ID="regExtxtEmailId" 
                                            runat="server" 
                                            EnableClientScript="true" 
                                            ControlToValidate="txtemail" 
                                            ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" 
                                            ErrorMessage="Enter Valid Email-Id">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                    
                                    <td width="10%">&nbsp;&nbsp;Contact No.</td>
                                    <td width="25%" align="left">
                                        <asp:TextBox ID="txtphone" runat="server" Width="135px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="10%">&nbsp;&nbsp;Contact Person</td>
                                    <td width="18%" align="left">
                                        <asp:TextBox ID="txtperson" runat="server" Width="135px"></asp:TextBox>
                                    </td>
                                    
                                    <td width="10%">&nbsp;</td>
                                    <td width="25%" align="left">&nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="Add Details" OnClick="btnAdd_click"/>&nbsp;&nbsp;
                            <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset" OnClick="btnReset_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            
            
            <tr>
                <td colspan="5" align="center"> 
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="Customergrdvw" 
                        runat="server"  
                        CssClass="grid-view"
                        OnRowEditing="Customergrdvw_RowEditing" 
                        OnRowCancelingEdit="Customergrdvw_RowCancelingEdit"
                        OnRowUpdating="Customergrdvw_RowUpdating"  
                        OnRowDeleting="Customergrdvw_RowDeleting"
                        OnPageIndexChanging="Customergrdvw_PageIndexChanging" 
                        OnRowDataBound="Customergrdvw_RowDataBound"
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
                            <asp:BoundField HeaderText="Customer Id"  DataField="CustId" ReadOnly="true" />        
                            <asp:TemplateField HeaderText="Customer Name" >
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomername1" Text='<%# Eval("Customer_Name") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate >
                                    <asp:TextBox ID="txtCustomername1" runat="server" Text='<%# Bind("Customer_Name") %>' MaxLength="50"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>     
                                    <asp:label id="lbladdress1" runat="server" Text='<%# Eval("Address") %>'  />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtaddress1" runat="server" Text='<%# Bind("Address") %>' MaxLength="50"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" >
                                <ItemTemplate>
                                    <asp:Label ID="lblemail1" Text='<%# Eval("EmailId") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate >
                                    <asp:TextBox ID="txtemail1" runat="server" Text='<%# Bind("EmailId") %>' MaxLength="500"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone" >
                                <ItemTemplate>
                                    <asp:Label ID="lblphone1" Text='<%# Eval("Contact_No") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate >
                                    <asp:TextBox ID="txtphone1" runat="server" Text='<%# Bind("Contact_No") %>' MaxLength="500"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="Contact Person" >
                                <ItemTemplate>
                                    <asp:Label ID="lblperson1" Text='<%# Eval("Contact_Person") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate >
                                    <asp:TextBox ID="txtperson1" runat="server" Text='<%# Bind("Contact_Person") %>' MaxLength="500"></asp:TextBox>
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
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </td>
</tr>
</table>
</asp:Content>

