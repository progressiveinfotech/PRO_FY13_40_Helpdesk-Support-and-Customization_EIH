<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddConfigurableitems.aspx.cs" Inherits="admin_AddConfigurableitems" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr><td><asp:Label ID="lblmessage" runat="server" Visible="false" ForeColor="Red"></asp:Label></td></tr>
<tr>
 <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="100%">
            &nbsp;Add Configurable Items</td></tr>
            <tr><td>&nbsp;&nbsp;</td></tr>
 <tr><td>
 
  
  <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  
    <tr><td align="left" class="tdsubheading">
    Item Name
    </td>
    <td>
    <asp:DropDownList ID="drpitem" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpitem_SelectedIndexChanged"></asp:DropDownList>
    </td>
    <td></td>
    <td><asp:LinkButton ID="lnkedit" runat="server" Text="[EDIT]" Visible="false"></asp:LinkButton></td>
    </tr>
    <tr>
    <td align="left" class="tdsubheading">Param1</td>
    <td><asp:TextBox ID="txtparam1" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param2</td>
    <td><asp:TextBox ID="txtparam2" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param3</td>
    <td><asp:TextBox ID="txtparam3" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param4</td>
    <td><asp:TextBox ID="txtparam4" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param5</td>
    <td><asp:TextBox ID="txtparam5" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param6</td>
    <td ><asp:TextBox ID="txtparam6" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param7</td>
    <td><asp:TextBox ID="txtparam7" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param8</td>
    <td ><asp:TextBox ID="txtparam8" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param9</td>
    <td ><asp:TextBox ID="txtparam9" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param10</td>
    <td ><asp:TextBox ID="txtparam10" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    
    </tr>
    <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    
    </tr>
   
    </table>
 
  
  
 </td></tr>
 <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="100%">
            &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Save" OnClick="btnAdd_Click" Visible="true"   /></td>
          
    </tr>
 </table>
</asp:Content>

