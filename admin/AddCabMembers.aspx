<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddCabMembers.aspx.cs" Inherits="admin_AddCabMembers" Title="Untitled Page" %>

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
            
                    <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                
        </td>
    </tr>
    <tr>
    <td>
        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                    &nbsp;Add Cab Member
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>
                    
                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td width="10%" class="style1">
                                        <font class="mandatory">*</font>Member Name
                                    </td>
                                    <td width="18%" align="left" class="style1">
                                        <asp:TextBox ID="txtmembername" Width="135px"  runat="server" AutoPostBack="true" ></asp:TextBox>&nbsp;
                                        <asp:RequiredFieldValidator ID="reqValMemberName" 
                                            runat="server" 
                                            ControlToValidate="txtmembername" 
                                            EnableClientScript="true"   
                                            SetFocusOnError="true"  
                                            ForeColor="Red"
                                            ErrorMessage="Enter Member Name">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td width="10%" class="style1">&nbsp;&nbsp;Phone Number</td>
                                    <td width="25%" align="left" class="style1">
                                        <asp:TextBox ID="txtphone" Width="135px"  runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                <td width="10%"><font class="mandatory">*</font>Change Type</td>
                                    <td width="18%" align="left">
                                        <asp:DropDownList ID="drpCab" 
                                            runat="server" Height="20px" Width="140px">
                                         </asp:DropDownList>&nbsp;
                                         <asp:RequiredFieldValidator ID="reqValDrpCab" 
                                            runat="server" 
                                            EnableClientScript="true" 
                                            ControlToValidate="drpCab"  
                                            InitialValue="0" 
                                            ErrorMessage="Select Change Type">
                                         </asp:RequiredFieldValidator>   
                                    </td>
                                    
                                    <td width="10%"><font class="mandatory">*</font>Email Id</td>
                                    <td width="25%" align="left">
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
                <asp:RequiredFieldValidator ID="rqvemail" 
                    runat="server" 
                    ControlToValidate="txtemail" 
                    EnableClientScript="true" 
                    ForeColor="Red" 
                    ErrorMessage="Enter Email Id">
                </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                               
                            </table>
                       
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
                   
                            <asp:Button ID="btnAdd" runat="server" Text="Add Details" OnClick="btnAdd_click"/>&nbsp;&nbsp;
                            <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset" OnClick="btnReset_Click" />
                      
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            
            
            <tr>
                <td colspan="5" align="center"> 
                    <asp:GridView ID="Cabgrdvw" 
                        runat="server"  
                        CssClass="grid-view"
                        OnRowEditing="Cabgrdvw_RowEditing" 
                        OnRowCancelingEdit="Cabgrdvw_RowCancelingEdit"
                        OnRowUpdating="Cabgrdvw_RowUpdating"  
                        OnRowDeleting="Cabgrdvw_RowDeleting"
                        OnPageIndexChanging="Cabgrdvw_PageIndexChanging" 
                        OnRowDataBound="Cabgrdvw_RowDataBound"
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
                            <asp:BoundField HeaderText="Cab Id"  DataField="Cabid" ReadOnly="true" />        
                            <asp:TemplateField HeaderText="Member Name" >
                                <ItemTemplate>
                                    <asp:Label ID="lblmembername1" Text='<%# Eval("membername") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate >
                                    <asp:TextBox ID="txtmembername1" runat="server" Text='<%# Bind("membername") %>' MaxLength="50"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="ChangeType">
                                <ItemTemplate>     
                                    <asp:label id="lblchangetypeid1" runat="server" Text='<%# Eval("changetypeid") %>'  />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="drpcab1" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" >
                                <ItemTemplate>
                                    <asp:Label ID="lblemail1" Text='<%# Eval("emailid") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate >
                                    <asp:TextBox ID="txtemail1" runat="server" Text='<%# Bind("emailid") %>' MaxLength="500"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone" >
                                <ItemTemplate>
                                    <asp:Label ID="lblphone1" Text='<%# Eval("phone") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate >
                                    <asp:TextBox ID="txtphone1" runat="server" Text='<%# Bind("phone") %>' MaxLength="500"></asp:TextBox>
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
        </table>
    </td>
</tr>
</table>
</asp:Content>

