<%--Page Created by Lalit--%>
<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="EditHoliday.aspx.cs" Inherits="admin_EditHoliday" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="EditHoliday" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" Font-Bold="true" ForeColor="red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
 <tr>
 <td>
    <asp:UpdatePanel ID="editholoday1" runat="server">
    <ContentTemplate>
        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
           &nbsp;&nbsp;View Holidays
        </td>
        <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="right">
            <asp:LinkButton ID="lnkaddholiday" Text="[Add Holiday]" runat="server" ForeColor="White" CausesValidation="false"
                onclick="lnkaddholiday_Click"></asp:LinkButton> &nbsp; &nbsp; &nbsp;
        </td>
        </tr>
       <tr style="padding-top:10px;"><td colspan="4" class="tdsubheading" align="left">
    Select Customer&nbsp;&nbsp;&nbsp;                          
     <asp:DropDownList ID="drpCustomer" AutoPostBack="true" runat="server" Width="155px" 
               onselectedindexchanged="drpCustomer_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCustomer" runat="server" EnableClientScript="true" ControlToValidate="drpCustomer"   InitialValue="0"></asp:RequiredFieldValidator></td>
     
     </tr>
     <tr style="padding-top:10px;padding-bottom:10px;">
     <td colspan="4" align="left" class="tdsubheading" align="center">
        Select Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     
        <asp:DropDownList ID="drpsite" 
            runat="server"  Width="155px"
            AutoPostBack="true" 
            onselectedindexchanged="drpsite_SelectedIndexChanged1">
        </asp:DropDownList>
        &nbsp;
        <asp:RequiredFieldValidator ID="reqValDrpSite" 
            runat="server" 
            EnableClientScript="true" 
            ControlToValidate="drpSite"  
            InitialValue="0">
        </asp:RequiredFieldValidator>
      </td>
      </tr>
    <tr ><td colspan="4" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">&nbsp;</td></tr>

    <tr style="padding-top:10px;">
    <td colspan="5" align="center">
    
        <asp:GridView ID="grdvwEdit" runat="server" CssClass="grid-view" AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
                GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
                BorderStyle="None" BorderWidth="1px" Width="984px"      PageSize="3" 
                OnRowUpdating="grdvwEdit_RowUpdating" OnRowEditing="grdvwEdit_RowEditing" 
                OnRowCancelingEdit="grdvwEdit_RowCancelingEdit" OnRowDeleting="grdvwEdit_RowDeleting"
                OnPageIndexChanging="grdvwEdit_PageIndexChanging" OnRowDataBound="grdvwEdit_RowDataBound"
                AllowPaging="true">
                <FooterStyle BackColor="#CCCC99" />
                <RowStyle BackColor="white"/>      
        <Columns>
                <asp:BoundField HeaderText="Holiday Id"  DataField="holidayid" ReadOnly="true" />
                <asp:TemplateField HeaderText="Holiday Date">
                <ItemTemplate>
                    <asp:Label ID="lblDateHoliday" runat="server" Text='<%# Eval("holidaydate") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDateHoliday" runat="server" Text='<%# Bind("holidaydate") %>' ></asp:TextBox>
                    <img src="../images/cal.gif" id="imgdate" alt="Date"/>
                </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Holiday Description" >
                <ItemTemplate>
                    <asp:Label ID="lblHdesc" Text='<%# Eval("description") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate >
                    <asp:TextBox ID="txtHdesc" runat="server" Text='<%# Bind("description") %>' MaxLength="500"></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Site Name">
                <ItemTemplate>     
                    <asp:label id="lnlsname" runat="server" Text='<%# Eval("siteid") %>'  />
                </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" HeaderText="Edit" CausesValidation="false"   />
                <asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />
     
        </Columns>
        
        <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
        <HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
        <AlternatingRowStyle  BackColor="Silver" />
        </asp:GridView>
    </td>
    </tr>
   <tr><td>&nbsp;</td></tr>
   <tr><td>&nbsp;</td></tr>
   <tr><td>&nbsp;</td></tr>
   <tr><td>&nbsp;</td></tr>
   <tr><td>&nbsp;</td></tr>
     </table> 
    </ContentTemplate>
    </asp:UpdatePanel>
</td>
</tr>
</table> 
</asp:Content>

