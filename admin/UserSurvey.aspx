<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="UserSurvey.aspx.cs" Inherits="UserSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">

    function check_uncheck(Val) {
        var ValChecked = Val.checked;
        var ValId = Val.id;
        var frm = document.forms[0];
        // Loop through all elements
        for (i = 0; i < frm.length; i++) {
            // Look for Header Template's Checkbox
            //As we have not other control other than checkbox we just check following statement
            if (this != null) {
                if (ValId.indexOf('CheckAll') != -1) {
                    // Check if main checkbox is checked,
                    // then select or deselect datagrid checkboxes
                    if (ValChecked)
                        frm.elements[i].checked = true;
                    else
                        frm.elements[i].checked = false;
                }
                else if (ValId.indexOf('deleteRec') != -1) {
                    // Check if any of the checkboxes are not checked, and then uncheck top select all checkbox
                    if (frm.elements[i].checked == false)
                        frm.elements[1].checked = false;
                }
            } // if
        } // for
    } // function



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
  <tr>
    <td>
    
    </td>
        </tr>
     <tr><td>
</td></tr> 
<tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">&nbsp;User Information</td></tr>
<tr>
<td align="left">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:GridView ID="grdvwSite" runat="server"  CssClass="grid-view"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  
             BorderStyle="None" BorderWidth="1px" Width="984px"  DataKeyNames="UserId" 
              
           PageSize="20" AllowPaging=true ShowFooter="true" OnRowCreated="grdvwsite_RowCreated" 
        OnRowCommand="grdvwSite_RowCommand" OnPageIndexChanging="grdvwSite_PageIndexChanging" >
            <FooterStyle BackColor="white" />
            <RowStyle BackColor="white"/> 
     <Columns>
    <asp:TemplateField HeaderText="Select">
    <%--<HeaderTemplate >
     <asp:CheckBox ID="CheckAll"  runat="server" onclick="return check_uncheck (this );"  />
     </HeaderTemplate>--%>
     <ItemTemplate>
   <%--<asp:Label ID="UserId" Visible="false" runat="server" />--%>
    <asp:CheckBox ID="CheckAll"  runat="server"   />
                                           
</ItemTemplate>
</asp:TemplateField>
         <asp:BoundField HeaderText="UserId"  DataField="Userid" ReadOnly="true" />
         <asp:BoundField HeaderText="Firstname"  DataField="Firstname" ReadOnly="true" />
          <asp:BoundField HeaderText="Lastname"  DataField="Lastname" ReadOnly="true" />
          <asp:BoundField HeaderText="Email"  DataField="Emailid" ReadOnly="true" />
         
          
        
    </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 </asp:GridView>
 
</ContentTemplate> 
</asp:UpdatePanel>
</td>
</tr>
<tr><td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"><asp:Button runat="server" ID="btnsave" OnClick=" btnsave_Click" Text="Send Email for Survey" />&nbsp;</td></tr>
<tr><td>
<asp:UpdatePanel ID="UpdatePanel3" runat="server">
<ContentTemplate>

</ContentTemplate> 
</asp:UpdatePanel>

</td></tr>
    </table> 

</asp:Content>

