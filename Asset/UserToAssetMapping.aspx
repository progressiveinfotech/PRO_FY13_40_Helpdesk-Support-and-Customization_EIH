<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="UserToAssetMapping.aspx.cs" Inherits="Asset_UserToAssetMapping" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
    <script type="text/javascript" language="javascript"> 
        function fnCheckUnCheck(objId) 
        {
            var grd = document.getElementById("<%= grdvwViewAsset.ClientID %>"); 
            var rdoArray = grd.getElementsByTagName("input"); 
            for(i=0;i<=rdoArray.length-1;i++) 
            { 
                if(rdoArray[i].type == 'radio')
                {
                    if(rdoArray[i].id != objId) 
                    { 
                        rdoArray[i].checked = false; 
                    } 
                }
            } 
        } 

    </script>

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
                            <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true"  ForeColor="Red"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;Mapped  Asset to User</td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                       <%-- <tr>
                        <td class="tdsubheading" align="left">
                            &nbsp;&nbsp;&nbsp;Search Asset By Name &nbsp;&nbsp;
                            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                             &nbsp;&nbsp;
                              <asp:ImageButton ID="ImageButton1" CausesValidation="false" runat="server" 
        ImageUrl="~/images/Searchlogo.jpg" 
            OnClientClick="javascript:window.open('../Incident/SelectAsset.aspx','popupwindow','width=770,height=590,left=380,top=230,Scrollbars=yes');"/>
                            <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click"  />
                        </td>
                        </tr>--%>
                        <tr>
                        <td class="tdsubheading" align="left">
                            &nbsp;&nbsp;<font class="mandatory">*</font>Select Username &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                            <%--&nbsp;&nbsp;
                            <asp:Button ID="btngetuser" runat="server" Text="Get User" OnClick="btngetuser_Click"  />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click"  />--%>
                            
                            &nbsp;&nbsp;
                            <asp:ImageButton ID="imgselectasset" CausesValidation="false" runat="server" 
                ImageUrl="~/images/Searchlogo.jpg" 
                OnClientClick="javascript:window.open('../admin/SelectUser.aspx','popupwindow','width=870,height=590,left=250,top=230,Scrollbars=yes');" />
                &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValSubject" runat="server" ControlToValidate="txtusername"  ForeColor="Red" ErrorMessage="Select Username"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                      
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
                            <asp:Button ID="btnmapped" runat="server" Text="Mapped" onclick="btnMapped_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text=" Reset "  CausesValidation="false" onclick="btnReset_Click" />
                        </td>
                        </tr>
                    
                    
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                        <td align="center" width="80%">
                            <asp:GridView ID="grdvwViewAsset" runat="server" AllowPaging="true" 
                                OnPageIndexChanging="grdvwViewAsset_PageIndexChanging" OnRowCommand="grdvwViewAsset_RowCommand" 
                                OnRowCreated="grdvwViewAsset_RowCreated" 
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                CssClass="grid-view" FooterStyle-BackColor="Red" FooterStyle-Font-Bold="true" 
                                ForeColor="Black" GridLines="Vertical" 
                                PageSize="20" 
                                ShowFooter="true" Width="984px">
                                <FooterStyle BackColor="white" />
                                <RowStyle BackColor="white" />
                                <AlternatingRowStyle BackColor="Silver" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssetID" Visible="false" Text='<%# DataBinder.Eval (Container.DataItem, "assetid") %>' runat="server" />
                                                <asp:RadioButton ID="selectone"  onclick="fnCheckUnCheck(this.id);"  runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                
                                            <asp:BoundField DataField="assetid" HeaderText="Asset Id" ReadOnly="true" />
                                            <asp:BoundField DataField="computername" HeaderText="Computer Name" ReadOnly="true" />
                                            <asp:BoundField DataField="domain" HeaderText="Domain Name" ReadOnly="true" />
                                    </Columns>
                                    <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>
                    </table> 
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </td> 
        </tr> 
    </table> 
</asp:Content>

