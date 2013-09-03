<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddServiceEffected.aspx.cs" Inherits="admin_AddServiceEffected" Title="Service Effected Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr>
     <td>
         <asp:UpdatePanel ID="ServicePanal1" runat="server">
             <ContentTemplate>
                <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
             </ContentTemplate>
         </asp:UpdatePanel>
     </td>
 </tr>
 <tr><td>
<asp:UpdatePanel ID="ServicePanal2" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Add Service</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    
    
    <tr style="padding-top:10px;">
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Service Name
        </td>
        <td>
         
         <asp:TextBox ID="txtServiceName" runat="server" MaxLength="50"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValService" runat="server" ControlToValidate="txtServiceName" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> 
         
            
        </td>
       
    </tr> 
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Description  
        </td>
        <td >
          
           <asp:TextBox ID="txtServiceDesc" runat="server" Height="30px" 
                    Columns="45" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
            
        </td>
        
    </tr>
      <tr><td>&nbsp;</td></tr>
  
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnServiceAdd" runat="server" onclick="btnServiceAdd_Click" 
                Text="Save"  />      
           <asp:Button ID="btnReset"  CausesValidation="false"  runat="server" 
                Text="Reset" onclick="btnReset_Click" />  
               
               
         
           
    
        </td>
    </tr>
  
    <tr><td>&nbsp;</td></tr>
    
    <tr><td colspan="5" align="center"> 
    <asp:GridView ID="Servicegrdvw" runat="server"  
      OnRowDeleting="Servicegrdvw_RowDeleting" OnRowEditing="Servicegrdvw_RowEditing"
        OnRowCancelingEdit="Servicegrdvw_RowCancelingEdit" OnRowUpdating="Servicegrdvw_RowUpdating"  OnPageIndexChanging="Servicegrdvw_PageIndexChanging"
               
                   AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
             BorderStyle="None" BorderWidth="1px" Width="984px" 
           PageSize="8" AllowPaging="true">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
            
    <Columns>
    
         
          <asp:BoundField HeaderText="Service Id"  DataField="Serviceid" ReadOnly="true" />
       
         <asp:TemplateField HeaderText="Service Name" >
      <ItemTemplate><asp:Label ID="lblServiceName" Text='<%# Eval("Servicename") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtServiceName" runat="server" Text='<%# Bind("Servicename") %>' MaxLength="50"></asp:TextBox>

</EditItemTemplate>
     </asp:TemplateField>
       
       
            <asp:TemplateField HeaderText="Service Description" >
      <ItemTemplate><asp:Label ID="lblServicedesc" Text='<%# Eval("description") %>' runat="server"></asp:Label></ItemTemplate>
     <EditItemTemplate ><asp:TextBox ID="txtServicedesc" runat="server" Text='<%# Bind("description") %>' MaxLength="500"></asp:TextBox>

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
       
        </td></tr>
       

   <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
        
   
   

</table>
</ContentTemplate>
</asp:UpdatePanel>
 </td></tr>
 </table>
</asp:Content>



