<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddDepartment.aspx.cs" Inherits="admin_AddDepartment" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="Departmentpanel" 
                    runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="Departmentpane2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">&nbsp;Add Department</td>
                                <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>   
                             <tr>
                                <td class="tdsubheading" align="left">
                                    <Font class="mandatory">*</Font>Select Customer
                                </td>                             
                                <td>
                                    <asp:DropDownList ID="drpCustomer" AutoPostBack="true" runat="server" 
                                        Width="155px" onselectedindexchanged="drpCustomer_SelectedIndexChanged" 
               ></asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCustomer" runat="server" EnableClientScript="true" ControlToValidate="drpCustomer"  ErrorMessage="Select Customer"  InitialValue="0"></asp:RequiredFieldValidator>  
                                </td>
                            </tr> 
                            <tr>
                                <td class="tdsubheading" align="left">
                                    <font class="mandatory">*</font>Select Site
                                </td>                             
                                <td>
                                    <asp:DropDownList ID="drpSite" 
                                        AutoPostBack="true"   Width="155px"
                                        runat="server" 
                                        onselectedindexchanged="drpSite_SelectedIndexChanged">
                                    </asp:DropDownList>&nbsp;
                                    <asp:RequiredFieldValidator ID="reqValDrpSite" 
                                        runat="server" 
                                        EnableClientScript="true" 
                                        ControlToValidate="drpSite"  
                                        InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdsubheading">
                                    <font class="mandatory">*</font>Department Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDepartmentName" runat="server" Width="155px" MaxLength="50"></asp:TextBox> &nbsp;
                                    <asp:RequiredFieldValidator ID="reqValDepartment" 
                                        runat="server" 
                                        ControlToValidate="txtDepartmentName" 
                                        EnableClientScript="true"  
                                        SetFocusOnError="true"  
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdsubheading">&nbsp;&nbsp;Description </td>
                                <td>
                                    <asp:TextBox ID="txtDepartmentdesc" runat="server" Height="30px" Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                    <asp:Button ID="btnDepartmentadd" runat="server" Text="Save" onclick="btnDepartmentadd_Click"  />      
                                    <asp:Button ID="btnReset"  CausesValidation="false"  runat="server"  Text="Reset" onclick="btnReset_Click"  />  
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="5" align="center"> 
                                    <asp:GridView ID="departmentgrdvw" 
                                        runat="server"  
                                        CssClass="grid-view"
                                        OnRowEditing="departmentgrdvw_RowEditing" 
                                        OnRowCancelingEdit="departmentgrdvw_RowCancelingEdit"
                                        OnRowUpdating="departmentgrdvw_RowUpdating"  
                                        OnRowDeleting="departmentgrdvw_RowDeleting"
                                        OnPageIndexChanging="departmentgrdvw_PageIndexChanging" 
                                        OnRowDataBound="departmentgrdvw_RowDataBound"
                                        AutoGenerateColumns="False" 
                                        CellPadding="0" ForeColor="Black"  
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
                                            <asp:BoundField HeaderText="Department Id"  DataField="deptid" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Department Name" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsitename" Text='<%# Eval("departmentname") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate >
                                                    <asp:TextBox ID="txtsiteName" runat="server" Text='<%# Bind("departmentname") %>' MaxLength="50"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department Description" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDepartmentdesc" Text='<%# Eval("description") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate >
                                                    <asp:TextBox ID="txtDepartmentdesc" runat="server" Text='<%# Bind("description") %>' MaxLength="500"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Site Name">
                                                <ItemTemplate>     
                                                    <asp:label id="lblsite" runat="server" Text='<%# Eval("siteid") %>'  />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="drpsitename" runat="server"></asp:DropDownList>
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











