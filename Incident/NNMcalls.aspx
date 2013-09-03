<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="NNMcalls.aspx.cs" Inherits="Incident_NNMcalls" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<asp:UpdatePanel ID="updatepanel3" runat="server">
<ContentTemplate>--%>
<asp:Label ID="Lblmsg" runat="server" Visible="false"></asp:Label>
 <asp:GridView ID="gdvNNMcalls" runat="server" CssClass="Gridview" AutoGenerateColumns="false"
            CellPadding="0" ForeColor="Black"  CellSpacing="0" onrowcommand="gdvNNMcalls_RowCommand"
            GridLines="Both" BackColor="White" BorderColor="Black" BorderStyle="None" BorderWidth="1px" 
            PageSize="10" AllowPaging="true" Width="100%" onpageindexchanging="gdvNNMcalls_PageIndexChanging" onrowdatabound="gdvNNMcalls_RowDataBound">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
    <Columns>
    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="4%" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
    <asp:Label ID="lblSerial" runat="server"></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Id" HeaderStyle-Width="4%" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
    <asp:LinkButton ID="LnkId" runat="server" Text='<%#Eval("Id") %>' CommandName="click" CommandArgument='<%#Eval("Id")%>'></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="Subject" HeaderStyle-Width="22%">
    <ItemTemplate>
    <asp:Label ID="Lblsubject" runat="server" Text='<%#Eval("subject") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <%--<asp:BoundField DataField="" HeaderText="Subject" />--%> 
    
    <asp:TemplateField HeaderText="Body" HeaderStyle-Width="40%">
    <ItemTemplate>
    <asp:Label ID="Lblbody" runat="server" Text='<%#Eval("body") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Created Date" HeaderStyle-Width="15%">
    <ItemTemplate>
    <asp:Label ID="Lblcreateddatetime" runat="server" Text='<%#Eval("createddatetime") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
  <%--  <asp:BoundField DataField="createddatetime" HeaderText="Created Date Time" ItemStyle-HorizontalAlign="Center"/>--%>
  
   <asp:TemplateField HeaderText="Mail From" HeaderStyle-Width="15%">
    <ItemTemplate>
    <asp:Label ID="LblMailfrom" runat="server" Text='<%#Eval("MailFrom") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    
  <%--  <asp:BoundField DataField="MailFrom" HeaderText="User Email" ItemStyle-HorizontalAlign="Center" />--%>
    </Columns> 
            
    <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
    <HeaderStyle  BackColor="#E1E1E1E1"  Font-Bold="True" ForeColor="Black" />
  </asp:GridView>
    <%--</ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="gdvNNMcalls" EventName="RowCommand" />
    </Triggers>

    </asp:UpdatePanel>--%>

</asp:Content>

