<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddColorScheme.aspx.cs" Inherits="admin_AddColorScheme" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;Add Color Scheme</td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td align="left"><font class="mandatory">*</font>Color 
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtcolorname" Width="138px"  runat="server"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="reqValcolor" 
                                        runat="server" 
                                        ControlToValidate="txtcolorname" 
                                        EnableClientScript="true"  
                                        SetFocusOnError="true"  
                                        ForeColor="Red" 
                                        ErrorMessage="Enter Color Name"> 
                                    </asp:RequiredFieldValidator>
                                </td>
                                </tr>
                                <tr>
                                    <td align="left"><font class="mandatory">*</font>Percent 
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtPercent" Width="138px"  runat="server"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqValPercent" 
                                            runat="server" 
                                            ControlToValidate="txtPercent" 
                                            EnableClientScript="true"  
                                            SetFocusOnError="true"  
                                            ForeColor="Red" 
                                            ErrorMessage="Enter Parcent Value">
                                        </asp:RequiredFieldValidator>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="regexvalPaercent"  
                                            ControlToValidate="txtPercent"  
                                            ValidationExpression="\d+"  
                                            Display="Static"  
                                            EnableClientScript="true"  
                                            ErrorMessage="Please enter numbers only"  
                                            runat="server">
                                        </asp:RegularExpressionValidator> 
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left"><font class="mandatory">*</font>Percent To &nbsp;
                                        <asp:TextBox ID="txtPercentTo" Width="138px"  runat="server"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqValPercentTo" 
                                            runat="server" 
                                            ControlToValidate="txtPercentTo" 
                                            EnableClientScript="true"  
                                            SetFocusOnError="true"  
                                            ForeColor="Red" 
                                            ErrorMessage="Enter value of Parcent To">
                                        </asp:RequiredFieldValidator>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="regexvalPaercentTo"  
                                            ControlToValidate="txtPercentTo"  
                                            ValidationExpression="\d+"  
                                            Display="Static"  
                                            EnableClientScript="true"  
                                            ErrorMessage="Please enter numbers only"  
                                            runat="server">
                                        </asp:RegularExpressionValidator> 
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left"><font class="mandatory">*</font>Call Status 
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtcallstatus" Width="138px"  runat="server"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqValcallstatus" 
                                            runat="server" 
                                            ControlToValidate="txtcallstatus" 
                                            EnableClientScript="true"  
                                            SetFocusOnError="true"  
                                            ForeColor="Red" 
                                            ErrorMessage="Enter Call Status">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>
                                <tr>
                                    <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnColorAdd" runat="server" onclick="btnColorAdd_Click" Text="Save"  /> &nbsp;  
                                        <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" Text="Reset" onclick="btnReset_Click" /> 
                                    </td>
                                </tr>
                                <tr><td>&nbsp;</td></tr>        
                                <tr>
                                    <td align="center" width="80%">
                                        <asp:GridView ID="grdvwColor" 
                                             runat="server" 
                                             AllowPaging="true" 
                                             AutoGenerateColumns="False" 
                                             BackColor="White" 
                                             BorderColor="#DEDFDE" 
                                             BorderStyle="None" 
                                             BorderWidth="1px" 
                                             CellPadding="0" 
                                             CellSpacing="0" 
                                             CssClass="grid-view" 
                                             ForeColor="Black" 
                                             GridLines="Vertical" 
                                             OnPageIndexChanging="grdvwColor_PageIndexChanging" 
                                             OnRowDeleting="grdvwColor_RowDeleting"
                                             OnRowEditing="grdvwColor_RowEditing"
                                             PageSize="10" 
                                             Width="984px">
                                             <FooterStyle BackColor="#CCCC99" />
                                             <RowStyle BackColor="white" />
                                             <Columns>
                                                 <asp:BoundField DataField="colorid" HeaderText="Color Id" ReadOnly="true" />
                                                 <asp:BoundField DataField="colorname" HeaderText="Color Name" ReadOnly="true" />
                                                 <asp:BoundField DataField="percnt" HeaderText="Percent" ReadOnly="true" />
                                                 <asp:BoundField DataField="percnt_to" HeaderText="Percent To" ReadOnly="true" />
                                                 <asp:BoundField DataField="callStatus" HeaderText="Call Status" ReadOnly="true" />
                                                 <asp:CommandField CausesValidation="false" HeaderText="Edit" ShowEditButton="True" />
                                                 <asp:CommandField CausesValidation="false" HeaderText="Delete" NewText="" ShowDeleteButton="True" />
                                             </Columns>
                                             <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
                                             <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                             <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                                             <AlternatingRowStyle BackColor="Silver" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                        </table> 
                    </ContentTemplate> 
                </asp:UpdatePanel> 
             </td> 
        </tr> 
    </table> 
</asp:Content>

