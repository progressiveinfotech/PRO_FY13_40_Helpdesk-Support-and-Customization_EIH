<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterReports.master" AutoEventWireup="true" CodeFile="AllGeneralReport.aspx.cs" Inherits="Reports_AllGeneralReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table align="center"  width="1550px" >
      <%--<tr>
                     <td style="width:100%; height: 20px; background-color:dodgerblue;" align="center">
                     
                     </td>                                         
                    </tr> --%>
                    <tr>
                     <td  align="left">
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     
                      <asp:Label ID="lable1" runat="server" Text="Select Inventory Date" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="TextBox1" runat="server" ToolTip="DD/MM/YYYY" Width="120px" MaxLength="10"></asp:TextBox>
                         <img id="img1" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox1.ClientID%>'),this);" src="../Images/cal.gif" alt="date"/>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="Button1" runat="server" Text="Show" OnClientClick="return dateValidation();" OnClick="Button1_Click"  />
                     
                     </td></tr>
                    <%--  <tr>
                     <td style="width:1450px; height: 2px; background-color: #000000;" align="center">
                     
                     </td>                                         
                    </tr>--%>
                    
     </table>
    
    <table align="center" width="1550px" cellpadding="0" cellspacing="0" border="0">
         <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
    <tr><td  align="left" style="height: 19px">
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="lblinfo" runat="server" Text="All General Systems Information" Font-Underline="true" Font-Bold="true" Font-Size="Medium"  ></asp:Label></td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td style="height: 13px">&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
              
        <tr><td><asp:Button ID="btnExcel" runat="server" BackColor="white"  Text="Export to Excel" OnClick="btnExcel_Click" /></td></tr>
          <tr><td>&nbsp;</td></tr>
    </table>
   <%-- <table align="left"  style="width:100%;" >
    <tr><td>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    </td></tr>
    </table>
    --%>
     
  <%-- <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr><td>
      <asp:PlaceHolder ID="All_Info_Placeholder" runat="server"></asp:PlaceHolder>
    </td></tr>
    </table>--%>
    <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr><td>
    <asp:DataGrid ID="dtgrid" runat="server" EnableViewState="False" CellSpacing="4"   Width="1550px" OnItemDataBound="dtgrid_ItemDataBound"
    
    AutoGenerateColumns="False" GridLines="none" CellPadding="2" BackColor="White" BorderWidth="1px" BorderStyle="None">
    <HeaderStyle  ForeColor="black"    Font-Underline="true"   BackColor="#a9a9a9"></HeaderStyle>
    	
    <Columns>
   <asp:TemplateColumn>
   <HeaderTemplate><strong>Sr.No </strong></HeaderTemplate>
   <ItemTemplate>
   <asp:Label ID="lblsrno" runat="server"></asp:Label>
   </ItemTemplate>
   </asp:TemplateColumn>
   
   
    <asp:BoundColumn DataField="computer_name" HeaderText="Computer Name">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="150px" ></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
	</asp:BoundColumn>
	
	 <asp:BoundColumn DataField="os_name" HeaderText="Operating System">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="350px"></HeaderStyle>
	<ItemStyle HorizontalAlign="Left"  Width="350px"></ItemStyle>
	</asp:BoundColumn>
	
	<asp:BoundColumn DataField="user_name" HeaderText="User Name">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="100px"></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
	</asp:BoundColumn>
	
	
	
	<asp:BoundColumn DataField="product_key" HeaderText="Product Key">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="300px"></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
	</asp:BoundColumn>
	
	
	
	<asp:BoundColumn DataField="product_name" HeaderText="Product Name">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="300px"></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
	</asp:BoundColumn>

	<asp:BoundColumn DataField="product_manufacturer" HeaderText="Product Manufacturer">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="200px"></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
	</asp:BoundColumn>
	
	<asp:BoundColumn DataField="serial_number" HeaderText="Serial Number">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="200px" ></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
	</asp:BoundColumn>
	
	<asp:BoundColumn DataField="processor_name" HeaderText="Processor Name">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="350px"></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="350px"></ItemStyle>
	</asp:BoundColumn>
    <asp:BoundColumn DataField="physical_mem" HeaderText="Physical Memory">
	<HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="150px"></HeaderStyle>
	<ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
	</asp:BoundColumn>
    </Columns>
    </asp:DataGrid>
   
    </td></tr>
    
    </table>
</asp:Content>

