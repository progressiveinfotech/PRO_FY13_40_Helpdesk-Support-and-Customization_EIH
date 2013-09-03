<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="ViewUser.aspx.cs" Inherits="admin_ViewUser" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
     <tr><td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
 <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
     <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;&nbsp;&nbsp;All Users
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:LinkButton ID="lnkbtnBack" runat="server" Text="[Add User]" ForeColor="White"
                 onclick="lnkbtnBack_Click">
          </asp:LinkButton>
            
            </td>
            
    </tr>
     <tr style="padding-top:8px;">
     <td class="tdsubheading" align="left">
     &nbsp;&nbsp;
     Search By Name
     &nbsp;&nbsp;
        <asp:TextBox ID="txtname" runat="server">
        </asp:TextBox>
     &nbsp;&nbsp;
     <asp:Button ID="btnsearch" runat="server" Text="Search"  OnClick="btnsearch_Click" />

      </td>
      </tr>
    
    
   
    <tr style="padding-top:8px;"><td align="center" width="80%">
    
   <asp:GridView ID="grdvwUser" runat="server"  CssClass="grid-view"
             OnRowDeleting="grdvwUser_RowDeleting" OnPageIndexChanging="grdvwUser_PageIndexChanging" 
             OnRowEditing="grdvwUser_RowEditing"   OnRowCommand="grdvwUser_RowCommand" OnRowCreated="grdvwUser_RowCreated"                 
             AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
             GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  
             BorderStyle="None" BorderWidth="1px" Width="984px" ShowFooter="true"    
             FooterStyle-BackColor="Red" FooterStyle-Font-Bold="true"
             AllowPaging=true  PageSize="20"  >
            <FooterStyle  BackColor="white" />
            <RowStyle BackColor="white"/>
            <AlternatingRowStyle  BackColor="Silver" />
     <Columns>
         <asp:BoundField HeaderText="User Id"  DataField="userid" ReadOnly="true" />
         <asp:BoundField HeaderText="User Name"  DataField="username" ReadOnly="true" />
         <asp:BoundField HeaderText="Enable" DataField="enable" ReadOnly="true"  />
          <asp:BoundField HeaderText="CreateDatetime" DataField="createdatetime" ReadOnly="true"  />
           
         <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"   />
         <asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />
         
    </Columns>
   

 
 



 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />

 </asp:GridView>
    
    </td></tr>
       <tr><td>&nbsp;</td></tr>
     <tr>
         <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="right">
          &nbsp;&nbsp;
          </td>
           
     </tr>
         </table> 
    
</ContentTemplate> 
</asp:UpdatePanel> </td> </tr> 
    </table> 
</asp:Content>

