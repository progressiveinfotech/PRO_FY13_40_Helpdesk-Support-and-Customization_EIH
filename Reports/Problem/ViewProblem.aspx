<%@ Page Language="C#" MasterPageFile="~/Master/MasterProblem.master" AutoEventWireup="true" CodeFile="ViewProblem.aspx.cs" Inherits="Problem_ViewProblem" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
<script language="JavaScript"   type="text/javascript">
    function dateValidation() {

        var obj = document.getElementById("<%=TextBox1.ClientID%>");

        var jsDay = obj.value.split("/")[0];
        var jsMonth = obj.value.split("/")[1];
        var jsYear = obj.value.split("/")[2];

        var finaldate = new Date(jsYear, jsMonth - 1, jsDay);
        var today = new Date();

        if (jsDay != "") {

            if (jsDay != finaldate.getDate()) {

                alert('Day is not valid!');
                return false;
            }
        }





        if (jsYear < 1900) {
            alert('Year must be greater than 1900.');
            return false;
        }



        if (finaldate == 'undefined') {
            alert("you have entered invalid date!");
            return false;
        }



        var obj1 = document.getElementById("<%=TextBox2.ClientID%>");

        var jsDay1 = obj1.value.split("/")[0];
        var jsMonth1 = obj1.value.split("/")[1];
        var jsYear1 = obj1.value.split("/")[2];

        var finaldate1 = new Date(jsYear1, jsMonth1 - 1, jsDay1);
        var today1 = new Date();

        if (jsDay1 != "") {
            if (jsDay1 != finaldate1.getDate()) {
                alert('Day is not valid!');
                return false;
            }
        }





        if (jsYear1 < 1900) {
            alert('Year must be greater than 1900.');
            return false;
        }



        if (finaldate1 == 'undefined') {
            alert("you have entered invalid date!");
            return false;
        }


    }

       

   
            
    </script>
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
<asp:UpdatePanel ID="updatepanel3" runat="server"><ContentTemplate>

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
   
     <tr>
        <td colspan="5"  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select Parameter 
        </td>
       
            
    </tr>
     <tr><td>&nbsp;</td></tr>
    <tr>
    <td colspan="5">
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList 
                ID="drpFilter"  runat="server" width="150px">
     
    <asp:ListItem Text="All " Value="0"></asp:ListItem>
    <asp:ListItem Text="Open" Value="1"></asp:ListItem>
    <asp:ListItem Text="On Hold" Value="2"></asp:ListItem>
    <asp:ListItem Text="Closed" Value="3"></asp:ListItem>
    <asp:ListItem Text="Resolved" Value="4"></asp:ListItem>
    <asp:ListItem Text="Unassigned" Value="5"></asp:ListItem>
    <asp:ListItem Text="Assigned" Value="6"></asp:ListItem>
    </asp:DropDownList>
    
    
   
    
   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTechnician" runat="server" Text="Technician"></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="drpTechnician" width="150px" runat="server" ></asp:DropDownList>
    
    
    
    </td>
    </tr>
    
    <tr><td colspan="5" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sort by&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="drpSort" width="150px" runat="server"><asp:ListItem Text="Select Parameter" Value="0"></asp:ListItem>
    <asp:ListItem Text="Priority" Value="priorityid"></asp:ListItem>
    <asp:ListItem Text="CreateDatetime" Value="createdatetime"></asp:ListItem>
    <asp:ListItem Text="Problemid" Value="incidentid"></asp:ListItem>
    </asp:DropDownList>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Height="17px" runat="server" ToolTip="DD/MM/YYYY" Width="145px"  MaxLength="10"></asp:TextBox>
                         <img id="img1" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox1.ClientID%>'),this);" src="../images/cal.gif" alt="date"/>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         To &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="TextBox2" Height="17px" Width="145px" runat="server" ToolTip="DD/MM/YYYY"  MaxLength="10"></asp:TextBox>
                         <img id="img2" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox2.ClientID%>'),this);" src="../images/cal.gif" alt="date"/>
                         
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
                         
    
    
    </td></tr>

   
   <%-- <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Incident Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox Height="17px" ID="txtId" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFind" runat="server" Text="Find" onclick="btnFind_Click" />
    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtId" runat="server" ControlToValidate="txtId" ForeColor="Red"  ErrorMessage="Enter Request Id"></asp:RequiredFieldValidator></td></tr>--%>
    
      <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers" TargetControlID="txtId" runat="server">
        </cc1:FilteredTextBoxExtender>--%>
      <tr>
    <td >&nbsp; </td>
    </tr>
     <tr>
       
        <td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="right" ><asp:Button ID="btnShow" runat="server" Text="Show" 
            OnClientClick="return dateValidation();"  CausesValidation="false" OnClick="btnShow_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancell" runat="server" Text="Cancel Call" 
              CausesValidation="false"  OnClick="btnCancell_Click" />
            &nbsp;&nbsp;&nbsp;</td>
            
    </tr>
   
        <%--  <tr style="padding-top:8px;">
        
        <td colspan="5"  align="right" >
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTechnician1" runat="server" Text="Select Technician" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList 
                ID="drpTechnician1" runat="server" 
                ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                ID="btnAssigned" runat="server" Text="Assigned" OnClick="btnAssigned_Click"  />&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            
    </tr>--%>
   
       <tr><td>&nbsp;</td></tr>
    

    <tr><td align="center"  colspan="5">
    
   <asp:GridView ID="grdvwProblem" runat="server"  CssClass="grid-view"  OnRowDataBound="grdvwProblem_RowDataBound" 
   
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="1px" 
          
           PageSize="20" AllowPaging=true Width="984px" >
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
            <asp:HyperLinkField  HeaderText="Problem Id" DataTextField="Problemid" 
           DataNavigateUrlFields="Problemid" datanavigateurlformatstring="~/Problem/EditProblem.aspx?problemid={0}" />
           <%-- <asp:BoundField HeaderText="Id"  DataField="Problemid" ReadOnly="true" />--%>
            <asp:BoundField HeaderText="Title" DataField="title" ReadOnly="true" />
            <asp:BoundField HeaderText="Requested By" DataField="requesterid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Created By" DataField="createdbyid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Assigned to" DataField="technicianid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Status" DataField="statusid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Priority" DataField="priorityid" ReadOnly="true"  />
         <%--   <asp:BoundField HeaderText="Site" DataField="siteid" ReadOnly="true"  />--%>
            <asp:BoundField HeaderText="CreatedDateTime" DataField="createdatetime" ReadOnly="true"  />
            
        
         <%--<asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />--%>
         <asp:TemplateField>
    <HeaderTemplate>
     <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
     </HeaderTemplate>
     <ItemTemplate>
   
     <asp:Label ID="Problemid" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "Problemid") %>' runat="server" />
    <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                           runat="server" />
                                          
</ItemTemplate>

</asp:TemplateField>
    </Columns>
 <EmptyDataTemplate >
 <table  cellpadding="1" cellspacing="1" width="100%" >
<tr>
<td class="tdheader" > Id </td><td class="tdheader"> title </td><td class="tdheader">Requested By</td><td class="tdheader">Created By</td><td class="tdheader">Assigned to</td><td class="tdheader">Status</td><td class="tdheader">Priority</td><td class="tdheader">createdatetime</td>

</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td> No record Found</td>
<td></td>
<td></td>
<td></td>
<td></td>

</tr>


</table>
</EmptyDataTemplate>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 </asp:GridView>
    
    </td></tr>
    <tr><td>&nbsp;</td></tr>
   
    <tr><td>&nbsp;</td></tr>
    
       
      
         
         
      
    
         </table>
 </ContentTemplate></asp:UpdatePanel> 

</asp:Content>

