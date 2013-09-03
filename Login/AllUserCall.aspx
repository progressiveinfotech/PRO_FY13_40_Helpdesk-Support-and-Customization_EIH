<%@ Page Language="C#" MasterPageFile="~/Master/MasterUser.master" AutoEventWireup="true" CodeFile="AllUserCall.aspx.cs" Inherits="Login_AllUserCall" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" width="100%" cellspacing="0" cellspacing="0">

<tr>
        <td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;All My Tickets 
        </td>
       
            
    </tr>
   <tr><td>&nbsp;</td></tr>
     <tr><td align="center"  colspan="5">
    
   <asp:GridView ID="grdvwRequest" runat="server"  CssClass="grid-view"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="1"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="0px" 
          OnRowDataBound="grdvwRequest_RowDataBound" OnPageIndexChanging="grdvwRequest_PageIndexChanging"
           PageSize="10" AllowPaging="true" Width="984px">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
     <asp:TemplateField HeaderText="SNo.">
                    <ItemTemplate>
                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
         
            <asp:BoundField HeaderText="Ticket id"  DataField="incidentid" ReadOnly="true" />
            <asp:BoundField HeaderText="Title"  DataField="title" ReadOnly="true" />
            <asp:BoundField HeaderText="Requester Name" DataField="requesterid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Created By" DataField="createdbyid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Assigned to" DataField="technicianid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Status" DataField="statusid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Priority" DataField="priorityid" ReadOnly="true"  />
            <asp:BoundField HeaderText="Customer/Site" DataField="siteid" ReadOnly="true"  />
            <asp:BoundField HeaderText="createdatetime" DataField="createdatetime" ReadOnly="true"  />
  <asp:TemplateField>
  <ItemTemplate>
    <asp:Label ID="incidentid" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "incidentid") %>' runat="server" />
   
    </ItemTemplate>
  </asp:TemplateField>                        

    </Columns>
    <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
    <HeaderStyle  BackColor="#E1E1E1E1"  Font-Bold="True" ForeColor="Black" />
    </asp:GridView>
    
    </td></tr>
</table>

</asp:Content>

