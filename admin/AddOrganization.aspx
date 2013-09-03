<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddOrganization.aspx.cs" Inherits="admin_AddOrganization" Title="BEST" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
   

    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr><td colspan="5">
     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
     <ContentTemplate>
    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
    </ContentTemplate></asp:UpdatePanel> 
    </td></tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Organization Details</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Organization Name
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate><asp:TextBox ID="txtorgname" runat="server" Width="235px" MaxLength="50"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValOrg" runat="server" ControlToValidate="txtorgname" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
       
    </tr>
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Description  
        </td>
        <td >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate> <asp:TextBox ID="txtorgdesc" runat="server" Height="30px" 
                    Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox></ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        
    </tr>
   
     <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate> <asp:Button ID="btnorgadd" runat="server" onclick="btnorgadd_Click" 
                Text="Save"  />      
            <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" 
                Text="Reset" onclick="btnReset_Click" />  
               
                </ContentTemplate>
            </asp:UpdatePanel>
         
           
                
       
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr><td colspan="5" align="center"> 
     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
     <ContentTemplate>
        <asp:GridView ID="Orggrdvw" runat="server"  CssClass="grid-view"
             OnRowDeleting="Orggrdvw_RowDeleting" OnRowEditing="Orggrdvw_RowEditing" OnRowCancelingEdit="Orggrdvw_RowCancelingEdit" 
            OnRowUpdating="Orggrdvw_RowUpdating"  
            onselectedindexchanged="Orggrdvw_SelectedIndexChanged" 
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
             BorderStyle="None" BorderWidth="1px" Width="984px" 
             OnPageIndexChanging="Orggrdvw_PageIndexChanging" PageSize="3" AllowPaging=true>
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            
     <Columns>
    
         
          <asp:BoundField HeaderText="Organization Id" DataField="Orgid"  ReadOnly="true"/>
          <asp:BoundField HeaderText="Organization Name"    DataField="orgname" />
           <asp:BoundField HeaderText="Description" DataField="Description" />
            <asp:BoundField HeaderText="CreateDateTime" DataField="Createdatetime" ReadOnly="true" />
            <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"  />
           <asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />
     
       
     
        
     </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 
           
           
 
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel> 
        </td></tr>
       

   <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
        
   
   

</table>

 

</asp:Content>

