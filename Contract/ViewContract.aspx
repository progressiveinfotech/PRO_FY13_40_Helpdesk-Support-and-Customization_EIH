<%@ Page Language="C#" MasterPageFile="~/Master/MasterContract.master" AutoEventWireup="true" CodeFile="ViewContract.aspx.cs" Inherits="Contract_ViewContract" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
     
    <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;"colspan="5">
            &nbsp;&nbsp;View Contract
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    
    <asp:LinkButton ID="lnkEdit" runat="server" ForeColor="white" Text="[Edit]" 
                onclick="lnkEdit_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lnkRenew" runat="server" ForeColor="white" Text="[Back]" 
                onclick="lnkRenew_Click"></asp:LinkButton>
            
            </td>
            
    </tr>
  
    
    <tr style="padding-top:5px;">
        <td colspan="5" align="left" class="tdsubheading">
        <asp:Label ID="lblContractName" runat="server" Font-Bold="true" Font-Size="14px"  ForeColor="Blue"></asp:Label>
        </td>
       
    </tr>
    <tr>
        <td colspan="5" align="left" class="tdsubheading"><font style="font-weight:bold; font-size:small; ">Contract Id :</font>
        <asp:Label ID="lblContractId" runat="server" Font-Size="small" Font-Bold="true"   ForeColor="Blue"></asp:Label>
        </td>
       
    </tr>
    

     <tr><td>&nbsp;</td></tr>
     <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5">
            &nbsp;&nbsp;Vendor and Contract Information</td>
          
    </tr>
    <tr style="padding-top:5px;">
    <td colspan="5" align="left" class="tdsubheading"><font style="font-weight:bold; font-size:small; "> &nbsp;&nbsp;Active From </font>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblActiveFrom" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
    <font style="font-weight:bold; font-size:small; "> &nbsp;&nbsp;Valid Till </font>&nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp;  &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:Label ID="lblActiveTo" runat="server"></asp:Label>
     </td>
    </tr>
     <tr>
    <td colspan="5" align="left" class="tdsubheading"><font style="font-weight:bold; font-size:small; "> &nbsp;&nbsp;Vendor Name </font>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblVendorname" runat="server"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    <font style="font-weight:bold; font-size:small; "> &nbsp;&nbsp;<asp:Label ID="lblRen" runat="server" Visible="false" Text="Pre-Renewal Details"></asp:Label> </font>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblRenInfo" Visible="false" runat="server"></asp:Label>
    
    
     </td>
    </tr>
   <tr>
    <td colspan="5" align="left" class="tdsubheading"><font style="font-weight:bold; font-size:small; "> &nbsp;&nbsp;Description </font>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:Label ID="lblDesc" runat="server"></asp:Label>
    
     </td>
    </tr>
   
    <tr><td>&nbsp;</td></tr>
     <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5">
            &nbsp;&nbsp;Notification Rules</td>
          
    </tr>
    <tr>
    <td colspan="5" align="left" class="tdsubheading"><font style="font-weight:bold; font-size:small; "> &nbsp;&nbsp;Users to be Notified </font>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
    <asp:Label ID="lblUsers" runat="server"></asp:Label>
    
     </td>
    </tr>
    <tr>
    <td colspan="5" align="left" class="tdsubheading"><font style="font-weight:bold; font-size:small; "> &nbsp;&nbsp;Notify before </font>  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblDays" runat="server"></asp:Label>
    
     </td>
    </tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5">
            &nbsp;&nbsp;Assets Under Contract</td>
          
    </tr>
    
       
        <tr><td>&nbsp;</td></tr>
   
     <tr><td align="center" colspan="5" width="80%">
    
   <asp:GridView ID="grdvwViewAsset" runat="server" AllowPaging="true" 
                                   OnPageIndexChanging="grdvwViewAsset_PageIndexChanging"                            
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
                                BorderStyle="None" BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                CssClass="grid-view" FooterStyle-BackColor="Red" FooterStyle-Font-Bold="true" 
                                ForeColor="Black" GridLines="Vertical" 
                                PageSize="10" 
                                ShowFooter="true" Width="984px">
                                <FooterStyle BackColor="white" />
                                <RowStyle BackColor="white" />
                                <AlternatingRowStyle BackColor="Silver" />
                                    <Columns>
                                         <asp:BoundField DataField="assetid" HeaderText="Asset Id" ReadOnly="true" />
                                        <asp:BoundField DataField="computername" HeaderText="Computer Name" ReadOnly="true" />
                                        <asp:BoundField DataField="domain" HeaderText="Domain Name" ReadOnly="true" />
                                        
                                       
                                    </Columns>
                                     <EmptyDataTemplate >
 <table  cellpadding="1" cellspacing="1" width="100%" >
<tr>
<td class="tdheader" > Asset Id </td><td class="tdheader"> Computer Name </td><td class="tdheader">Domain Name</td>

</tr>
<tr>
<td></td>
<td><b>No Asset Under Contract</b></td>

<td> </td>


</tr>


</table>
</EmptyDataTemplate>
                                    
                                <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>
    
    </td></tr>

  
 
  
   

</table>
</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

