<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true"
    CodeFile="ViewAsset.aspx.cs" Inherits="Asset_ViewAsset" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                                    &nbsp;View Asset
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="tdsubheading" align="left">
                                    &nbsp;&nbsp; Search By Name &nbsp;&nbsp;
                                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServicePath="~/WebService.asmx"
                                        ServiceMethod="GetComputernameList" CompletionSetCount="15" MinimumPrefixLength="1"
                                        TargetControlID="txtname" UseContextKey="true">
                                    </asp:AutoCompleteExtender>
                                    <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="grdvwViewAsset" runat="server" AllowPaging="True" AutoGenerateEditButton="True"
                                        OnPageIndexChanging="grdvwViewAsset_PageIndexChanging" OnRowCommand="grdvwViewAsset_RowCommand"
                                        OnRowCreated="grdvwViewAsset_RowCreated" OnRowEditing="grdvwViewAsset_RowEdit"
                                        AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
                                        BorderWidth="1px" CellPadding="0" CssClass="grid-view" FooterStyle-BackColor="Red"
                                        FooterStyle-Font-Bold="true" ForeColor="Black" GridLines="Vertical" PageSize="20"
                                        ShowFooter="True"  DataKeyNames="assetid" OnRowCancelingEdit="grdvwViewAsset_RowCancelingEdit"
                                        OnRowUpdating="grdvwViewAsset_RowUpdating"  
                                        OnRowDataBound="grdvwViewAsset_RowDataBound">
                                        <FooterStyle BackColor="white" />
                                        <RowStyle BackColor="white" />
                                        <AlternatingRowStyle BackColor="Silver" />
                                        <Columns>    <%--<asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDel" runat="server" CommandName="Del" OnClientClick="javascript:return confirm('Are you sure you want to delete this record ?');"
                                                        CommandArgument='<%# Eval("assetid")%>' Text="Delete"></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="50px"  HorizontalAlign="Center"  />
                                                <ItemStyle Width="50px" HorizontalAlign="Center"  />
                                            </asp:TemplateField>--%>
                                           
                                            <%-- <asp:BoundField DataField="assetid" HeaderText="Asset Id" ReadOnly="true" />
                                        <asp:BoundField DataField="computername" HeaderText="Computer Name" ReadOnly="true" />
                                        <asp:BoundField DataField="TagNo" HeaderText="Tag Number" ReadOnly="true" />
                                         <asp:BoundField DataField="PONo" HeaderText="PO Number" ReadOnly="true" />
                                        <asp:BoundField DataField="domain" HeaderText="Domain Name" ReadOnly="true" />--%>
                                            <%-- <asp:CommandField CausesValidation="false" ShowEditButton="true" EditText="View Details" HeaderText="ViewDetails" />--%>
                                            <asp:TemplateField HeaderText="AssetId" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAssetid" runat="server" Text='<%# Eval("assetid") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="150px"/>
                                                <ItemStyle HorizontalAlign="Center"  Width="150px"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ComputerName" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="350px" ItemStyle-Width="350px" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComputername" runat="server" Text='<%# Eval("computername") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="150px"   />
                                                <ItemStyle HorizontalAlign="Left"   Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tag" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTagNo" runat="server" Text='<%# Eval("TagNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTagNo" runat="server" Text='<%# Eval("TagNo") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"  Width="150px" />
                                                <ItemStyle HorizontalAlign="Left"   Width="150px"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"   Width="150px"/>
                                                <ItemStyle HorizontalAlign="Left"  Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="AssetOwner" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOwner" runat="server" Text='<%# Eval("AssetOwner") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtOwner" runat="server" Text='<%# Eval("AssetOwner") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"   Width="250px"/>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px" />
                                            </asp:TemplateField>   <asp:TemplateField HeaderText="Location" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtLocation" runat="server" Text='<%# Eval("Location") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"  Width="250px" />
                                                <ItemStyle HorizontalAlign="Left"  Width="250px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IsinStock" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStock" runat="server" Text='<%# Eval("Isinstock") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlstock" runat="server" SelectedValue='<%# Bind("Isinstock") %>'>
                                                        <%-- <asp:ListItem Value="NULL" Text="Select"></asp:ListItem>--%>
                                                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                                                        <asp:ListItem Value="True" Text="Yes"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%--<asp:TextBox ID="txtOwner" runat="server" Text='<%# Eval("Is in stock") %>'></asp:TextBox>--%>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"  Width="350px" />
                                                <ItemStyle HorizontalAlign="Center"  Width="350px" />
                                            </asp:TemplateField>
                                         <asp:TemplateField HeaderText="CompanyCode" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyCode" runat="server" Text='<%# Eval("CompanyCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtCompanyCode" runat="server" Text='<%# Eval("CompanyCode") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"   Width="250px"/>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PurchaseDate" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPurchaseDate" runat="server" Text='<%# Eval("PurchaseDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtPurchaseDate" runat="server" Text='<%# Eval("PurchaseDate") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"   Width="250px"/>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="AssetCategory" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAssetCategory" runat="server" Text='<%# Eval("AssetCategory") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtAssetCategory" runat="server" Text='<%# Eval("AssetCategory") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"   Width="250px"/>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px" />
                                            </asp:TemplateField>
                                          
                                            <asp:TemplateField HeaderText="IsManaul" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmanual" runat="server" Text='<%# Eval("manaul") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"  Width="250px" />
                                                <ItemStyle HorizontalAlign="Center"  Width="250px" />
                                            </asp:TemplateField>  <asp:TemplateField HeaderText="DomainName" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldomain" runat="server" Text='<%# Eval("domain") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"  Width="250px"/>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px"/>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"   Width="250px"/>
                                                <ItemStyle HorizontalAlign="Left"  Width="250px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ViewDetails" HeaderStyle-Width="250px" ItemStyle-Width="250px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkViewDetails" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("assetid") +"," + Eval("computername")  %>'
                                                        Text="ViewDetails"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                         
                                        </Columns>
                                        <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
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
