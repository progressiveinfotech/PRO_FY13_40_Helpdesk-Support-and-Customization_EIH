<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="AddAssetbyXML.aspx.cs" Inherits="Asset_AddAssetbyXML" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td>
            <asp:UpdatePanel ID="CategoryPanal1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel>
 
        </td>
        </tr>
        <tr>
        <td>
            <asp:Button ID="Ok" runat="server" Text="Submitt" Width="150px" onclick="Ok_Click" />
        </td>
        </tr>
    </table>
</asp:Content>

