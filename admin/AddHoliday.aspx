<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddHoliday.aspx.cs" Inherits="admin_Addholiday" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript" src="../JScript/scw.js"></script>
    <style type="text/css">
        .style1
        {
            height: 32px;
        }
    </style></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="Subcategorypanel" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="Subcategorypane2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">&nbsp;Add Holiday</td>
                                <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"  align="right">
                                    <asp:LinkButton ID="lnkeditholiday" Text="[Edit Holiday]" runat="server" ForeColor="White" CausesValidation="false"
                                        onclick="lnkeditholiday_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                </td>
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
                                    <Font class="mandatory">*</Font>Select site
                                </td>                             
                                <td>
                                    <asp:DropDownList ID="drpsite" Width="155px" runat="server"></asp:DropDownList>&nbsp;
                                    <asp:RequiredFieldValidator ID="reqValdrpsite" 
                                            runat="server" 
                                            EnableClientScript="true" 
                                            ControlToValidate="drpsite"  
                                            InitialValue="0" 
                                            ErrorMessage="Select Site">
                                    </asp:RequiredFieldValidator>   
                                </td>
                            </tr>
                            <tr>
                                <td class="tdsubheading" align="left">
                                    <Font class="mandatory">*</Font>Holiday date
                                </td>  
                                <td>
                                    <asp:TextBox ID="txtHolidayDate" runat="server" ToolTip="DD/MM/YYYY" 
                                        Width="126px" ></asp:TextBox>
                                    <img src="../images/cal.gif" id="imgdate" onclick="scwShow(document.getElementById('<%=txtHolidayDate.ClientID%>'),this);" alt="Date" />
                                    &nbsp;
                                    <asp:RegularExpressionValidator ID="regDate" 
                                            runat="server" 
                                            ControlToValidate="txtHolidayDate" 
                                            ErrorMessage="Enter date into right formate" 
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="ReqvalDate" 
                                            runat="server" 
                                            ErrorMessage="Enter Date" 
                                            ControlToValidate="txtHolidayDate">
                                        </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tdsubheading">
                                    <Font class="mandatory">*</Font>Description  
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHolidaydesc" runat="server" Height="30px" Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="reqValholidaydesc" 
                                            runat="server" 
                                            ControlToValidate="txtHolidaydesc" 
                                            EnableClientScript="true"   
                                            SetFocusOnError="true"  
                                            ForeColor="Red"
                                            ErrorMessage="Enter Holiday Description">
                                    </asp:RequiredFieldValidator>
                                   
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                    <asp:Button ID="btnHolidayadd"  runat="server" Text="Save" onclick="btnHolidayadd_Click"  />      
                                    <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" Text="Reset" onclick="btnReset_Click" /> 
                                </td>
                            </tr>
      
                            <tr><td>&nbsp;</td></tr>
        
                            <tr>
                                <td colspan="5" align="center"> 
                                    <asp:GridView ID="subcategorygrdvw" 
                                        runat="server"  
                                        CssClass="grid-view"
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
                                            <asp:BoundField HeaderText="Subcategory Id"  DataField="subcategoryid" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Subcategory Name" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcategoryname" Text='<%# Eval("subcategoryname") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtcategoryName" runat="server" Text='<%# Bind("subcategoryname") %>' MaxLength="50"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subcategory Description" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRegiondesc" Text='<%# Eval("subcategorydescription") %>' runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate >
                                                    <asp:TextBox ID="txtRegiondesc" runat="server" Text='<%# Bind("subcategorydescription") %>' MaxLength="500"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Category Name">
                                                <ItemTemplate>     
                                                    <asp:label id="lblcategory" runat="server" Text='<%# Eval("categoryid") %>'  />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="drpcategoryname" runat="server"></asp:DropDownList>
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

