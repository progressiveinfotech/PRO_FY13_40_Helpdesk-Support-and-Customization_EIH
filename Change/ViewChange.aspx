<%@ Page Language="C#" MasterPageFile="~/Master/MasterChange.master" AutoEventWireup="true" CodeFile="ViewChange.aspx.cs" Inherits="Change_ViewChange" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
   
     <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select Parameter
        </td>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="right" >&nbsp;&nbsp;&nbsp;</td>
            
    </tr>
     <tr><td>&nbsp;</td></tr>
    <tr>
    <td colspan="5">
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="drpFilter"  runat="server" width="150px"> 
                
     
    <asp:ListItem Text="----------Select----------" Value="0"></asp:ListItem>
    <asp:ListItem Text="Requested" Value="1"></asp:ListItem>
    <asp:ListItem Text="Completed" Value="2"></asp:ListItem>
    <asp:ListItem Text="Approved" Value="3"></asp:ListItem>
    <asp:ListItem Text="Planning" Value="4"></asp:ListItem>
    <asp:ListItem Text="Testing" Value="5"></asp:ListItem>
    <asp:ListItem Text="Release" Value="6"></asp:ListItem>
    <asp:ListItem Text="Implemented" Value="7"></asp:ListItem>
    <asp:ListItem Text="Approval" Value="8"></asp:ListItem>
    <asp:ListItem Text="Rejected" Value="9"></asp:ListItem>
    </asp:DropDownList>
    
    
   
    
   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTechnician" runat="server" Text="Technician"></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="drpTechnician" width="150px" runat="server" ></asp:DropDownList>
    
    
    
    </td>
    </tr>
    
    <tr><td colspan="5" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sort by&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="drpSort" width="150px" runat="server"><asp:ListItem Text="Select Parameter" Value="0"></asp:ListItem>
    <asp:ListItem Text="Priority" Value="priorityid"></asp:ListItem>
    <asp:ListItem Text="CreateDatetime" Value="createdatetime"></asp:ListItem>
    <asp:ListItem Text="Changeid" Value="incidentid"></asp:ListItem>
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
            OnClientClick="return dateValidation();"  CausesValidation="false" OnClick="btnShow_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancell" runat="server" Text="Cancel Call" 
              CausesValidation="false" OnClick="btnCancell_Click"   />
            &nbsp;&nbsp;</td>
            
    </tr>
   
          <%--<tr style="padding-top:10px;">
        
        <td colspan="5"  align="right" >
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTechnician1" runat="server" Text="Select Technician" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList 
                ID="drpTechnician1" runat="server" 
                ></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                ID="btnAssigned" runat="server" Text="Assigned" OnClick="btnAssigned_Click"   />&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            
    </tr>--%>
   
       <tr><td>&nbsp;</td></tr>
    

    <tr><td align="center"  colspan="5">
    
   <asp:GridView ID="grdvwChange" runat="server"  CssClass="grid-view"  
   
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  
            BorderStyle="None" BorderWidth="1px" 
          
           PageSize="10" AllowPaging=true Width="984px" 
            OnRowDataBound="grdvwChange_RowDataBound"  
            OnPageIndexChanging="grdvwChange_PageIndexChanging" 
            onselectedindexchanged="grdvwChange_SelectedIndexChanged">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
            <asp:HyperLinkField  HeaderText="Change Id" DataTextField="Changeid" 
           DataNavigateUrlFields="Changeid" datanavigateurlformatstring="~/Change/EditChange.aspx?problemid={0}" />
           <%-- <asp:BoundField HeaderText="Id"  DataField="Problemid" ReadOnly="true" />--%>
            <asp:BoundField HeaderText="Title" DataField="Title" ReadOnly="true" />
            <asp:BoundField HeaderText="RequestedBy" DataField="RequestedBy" ReadOnly="true"  />
            <asp:BoundField HeaderText="CreatedBy" DataField="CreatedByID" ReadOnly="true"  />
            <asp:BoundField HeaderText="Technician" DataField="Technician" ReadOnly="true"  />
            <asp:BoundField HeaderText="Statusid" DataField="Statusid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Priority" DataField="Priority" ReadOnly="true"  />
         <%--   <asp:BoundField HeaderText="Site" DataField="siteid" ReadOnly="true"  />--%>
            <asp:BoundField HeaderText="CreatedTime" DataField="CreatedTime" ReadOnly="true"  />
            
        
         <%--<asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />--%>
         <asp:TemplateField>
    <HeaderTemplate>
     <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
     </HeaderTemplate>
     <ItemTemplate>
   
     <asp:Label ID="Changeid" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "Changeid") %>' runat="server" />
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

