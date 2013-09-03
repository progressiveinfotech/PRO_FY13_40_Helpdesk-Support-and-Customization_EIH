<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="EditCI.aspx.cs" Inherits="CMDB_EditCI" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
<tr>
 <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="100%">
            &nbsp;Add Configurable Items</td></tr>
            <tr><td>&nbsp;&nbsp;</td></tr>
 <tr><td>
 
  <asp:Panel ID="panelshow" runat="server" Visible="true" BorderWidth="0">
  <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  
    <tr><td align="left" class="tdsubheading">
    Item Name
    </td>
    <td>
    <asp:DropDownList ID="drpitem" runat="server"></asp:DropDownList>
    </td>
    <td></td>
    <td><asp:LinkButton ID="lnkedit" runat="server" Text="[EDIT]" onclick="lnkedit_Click"></asp:LinkButton></td>
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
 </asp:Panel>
  <asp:Panel ID="panaledit" Visible="false" runat="server" BorderWidth="0">
  <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  
    <tr><td align="left" class="tdsubheading">
    Item Name
    </td>
    <td>
    <asp:DropDownList ID="drpedititem" runat="server"></asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td align="left" class="tdsubheading">Param1</td>
    <td><asp:TextBox ID="txteditparam1" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param2</td>
    <td><asp:TextBox ID="txteditparam2" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param3</td>
    <td><asp:TextBox ID="txteditparam3" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param4</td>
    <td><asp:TextBox ID="txteditparam4" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param5</td>
    <td><asp:TextBox ID="txteditparam5" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param6</td>
    <td ><asp:TextBox ID="txteditparam6" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param7</td>
    <td><asp:TextBox ID="txteditparam7" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param8</td>
    <td ><asp:TextBox ID="txteditparam8" runat="server"></asp:TextBox></td>
    </tr>
     <tr>
    <td align="left" class="tdsubheading">Param9</td>
    <td ><asp:TextBox ID="txteditparam9" runat="server"></asp:TextBox></td>
    <td align="left" class="tdsubheading">Param10</td>
    <td ><asp:TextBox ID="txteditparam10" runat="server"></asp:TextBox></td>
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
 </asp:Panel>
  
 </td></tr>
 <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="100%">
            &nbsp;<asp:Button ID="btnupdate" runat="server" Text="Save"  Visible="false" onclick="btnupdate_Click"  />
            <asp:Button ID="btncancell" runat="server" Text="Cancell"  Visible="false"  OnClick="btncancell_Click"  /></td>
          
    </tr>
 </table>
</asp:Content>

