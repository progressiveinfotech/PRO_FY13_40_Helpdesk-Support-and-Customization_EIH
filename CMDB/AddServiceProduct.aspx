<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true"
    CodeFile="AddServiceProduct.aspx.cs" Inherits="Change_AddServiceProduct" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript" type="text/javascript" src="../JScript/scw.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="CategoryPanal1" runat="server">
                    <ContentTemplate>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <font color="red">
                    <asp:Label ID="lblmsg" runat="Server" Visible="false"></asp:Label></font>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                            &nbsp;New Service Product
                        </td>
                    </tr>
                    <tr style="padding-top: 17px;">
                        <td>
                            <asp:UpdatePanel ID="CategoryPanal2" runat="server">
                                <ContentTemplate>
                                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td width="10%">
                                                <font class="mandatory">*</font>&nbsp;&nbsp;Customer Name
                                            </td>
                                            <td width="18%" align="left">
                                                <asp:DropDownList Width="170px" ID="drpCustomer" runat="server" OnSelectedIndexChanged="drpCustomer_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="reqvalCustomerName" runat="server" ControlToValidate="drpVendor"
                                                    ForeColor="Red" ErrorMessage="Enter Customer name" EnableClientScript="true"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="10%">
                                                <font class="mandatory">*</font>Site
                                            </td>
                                            <td width="25%" align="left">
                                                <asp:DropDownList ID="drpSites" Width="170px" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="reqValsite" runat="server" ControlToValidate="drpSites"
                                                    ForeColor="Red" ErrorMessage="Enter Site name" EnableClientScript="true" InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                <font class="mandatory">*</font>&nbsp;&nbsp;Vedor Name
                                            </td>
                                            <td width="18%" align="left">
                                                <asp:DropDownList Width="170px" ID="drpVendor" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="reqvalvendor" runat="server" ControlToValidate="drpVendor"
                                                    ForeColor="Red" ErrorMessage="Enter Vendor name" EnableClientScript="true" InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="10%">
                                                ItemSerialNo
                                            </td>
                                            <td width="25%" align="left">
                                                <asp:TextBox ID="txtitemsrlno" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                <font class="mandatory">*</font>&nbsp;&nbsp;PurchaseDate
                                            </td>
                                            <td width="18%" align="left">
                                              <%--  <asp:TextBox ID="txtpdate" runat="server"></asp:TextBox><img src="../images/cal.gif"
                                                    id="imgdate" onclick="scwShow(document.getElementById('<%=txtpdate.ClientID%>'),this);"
                                                    alt="Date" /><asp:RequiredFieldValidator ID="reqvalpdate" runat="server" ControlToValidate="txtpdate"
                                                        ForeColor="Red" ErrorMessage="Enter PurchaseDate" EnableClientScript="true"></asp:RequiredFieldValidator>
                                       --%>  
                                         <asp:TextBox ID="txtpdate" runat="server"></asp:TextBox><img src="../images/cal.gif"
                                                    id="imgdate" onclick="scwShow(document.getElementById('ctl00_ContentPlaceHolder1_txtpdate'),this);"
                                                    alt="Date" /><asp:RequiredFieldValidator ID="reqvalpdate" runat="server" ControlToValidate="txtpdate"
                                                        ForeColor="Red" ErrorMessage="Enter PurchaseDate" EnableClientScript="true"></asp:RequiredFieldValidator>
                                          </td>
                                            <td width="10%">
                                                Severity
                                            </td>
                                            <td width="25%" align="left">
                                                <asp:DropDownList Width="170px" ID="drpPriority" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                            &nbsp;Item Details
                        </td>
                    </tr>
                    <tr style="padding-top: 17px;">
                        <td>
                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td width="10%">
                                        Item Name
                                    </td>
                                    <td width="18%" align="left">
                                        <asp:DropDownList Width="170px" ID="drpitem" runat="server" OnSelectedIndexChanged="drpitem_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10%">
                                    </td>
                                    <td width="25%" align="left">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pan2" runat="server">
                                <asp:PlaceHolder ID="PlaceHolderParams" runat="server"></asp:PlaceHolder>
                                <asp:PlaceHolder ID="pl1" runat="server"></asp:PlaceHolder>
                                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;" align="center">
                            <asp:Button runat="server" ID="btnsave" Text="Save" OnClick="btnsave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
  
</asp:Content>
