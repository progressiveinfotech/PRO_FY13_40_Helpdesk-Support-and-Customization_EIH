<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewcsmData.aspx.cs" Inherits="admin_ViewcsmData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;&nbsp;&nbsp;&nbsp;Call History 
        </td>
       
            
    </tr>
     
      <tr><td>&nbsp;</td></tr>
        <tr>
        <td>
         <asp:GridView ID="grdvwdate" runat="server"  CssClass="grid-view"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="0"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  
             BorderStyle="None" BorderWidth="1px" Width="984px"   
             
           PageSize="10" AllowPaging=true>
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
         <asp:BoundField HeaderText="ComplaintID"  DataField="ComplaintId" ReadOnly="true" />
         <asp:BoundField HeaderText="ItemID"  DataField="ItemId" ReadOnly="true" />
         <asp:BoundField HeaderText="Complaint Status" DataField="ComplaintStatus" ReadOnly="true"  />
          <asp:BoundField HeaderText="EngineerID" DataField="EngineerId" ReadOnly="true"  />
           <asp:BoundField HeaderText="call log Note" DataField="CallLogNotes" ReadOnly="true"  />
       
    </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 </asp:GridView>
        
        
        
        </td>
        </tr>
        
           </table>
    <div>
    
    </div>
    </form>
</body>
</html>
