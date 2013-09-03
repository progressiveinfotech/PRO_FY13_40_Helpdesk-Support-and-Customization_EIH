<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GeneralReportAll.aspx.cs" Inherits="Reports_GeneralReportAll" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
    <%--<script language="JavaScript"   type="text/javascript">
	function dateValidation()
    {
        var obj = document.getElementById("<%=TextBox1.ClientID%>"); 
        var jsDay = obj.value.split("/")[0];
        var jsMonth = obj.value.split("/")[1]; 
        var jsYear = obj.value.split("/")[2];
        var finaldate= new Date(jsYear,jsMonth-1,jsDay); 
        var today = new Date();
        if(jsDay != finaldate.getDate())
        {
            alert('Day is not valid!');
            return false;
        }
        if(jsMonth != finaldate.getMonth()+1)
        {
            alert('Month is not valid!');
            return false;
        }
        if(jsYear != finaldate.getFullYear())
        {
            alert('Year is not valid!');
            return false;
        }
        if(jsYear < 1900)
        {
            alert('Year must be greater than 1900.');
            return false;
        }
        if(finaldate=='undefined')
        {
            alert("you have entered invalid date!");
            return false;
        }
        if(finaldate>today)
        {
            alert("The date must be smaller than current date.");
            return false;
        }
    }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<table align="center"  width="1550px" >
     
            <tr>
                <td  align="left">
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lable1" runat="server" Text="Select Inventory Date" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" ToolTip="DD/MM/YYYY" Width="120px" MaxLength="10"></asp:TextBox>
                    <img id="img1" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox1.ClientID%>'),this);" src="../Images/cal.gif" alt="date"/>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Show" OnClientClick="return dateValidation();" OnClick="Button1_Click"  />
                </td>
            </tr>                   
        </table>
    --%>
        <table align="center" width="1550px" cellpadding="0" cellspacing="0" border="0">
            <tr><td>&nbsp;</td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td  align="left" style="height: 19px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblinfo" runat="server" Text="All General Systems Information" Font-Underline="true" Font-Bold="true" Font-Size="Medium"  ></asp:Label>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr><td style="height: 13px">&nbsp;</td></tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>
                    <asp:Button ID="btnExcel" runat="server" BackColor="white"  Text="Export to Excel" OnClick="btnExcel_Click" />
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
        </table>
   
        <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
               
                    <asp:DataGrid ID="dtgrid"   runat="server"
                        EnableViewState="False" CellSpacing="4"   Width="1550px" OnItemDataBound="dtgrid_ItemDataBound"
    
    AutoGenerateColumns="False" GridLines="none" CellPadding="2" BackColor="White" BorderWidth="1px" BorderStyle="None">
                       <HeaderStyle  ForeColor="black"    Font-Underline="true"   BackColor="#a9a9a9"></HeaderStyle>
                        <Columns>
                            <asp:TemplateColumn>
                                <HeaderTemplate><strong>Sr.No </strong></HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblsrno" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
   
                            <asp:BoundColumn DataField="computername" HeaderText="Computer Name">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="150px" ></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
	                        </asp:BoundColumn>
	
	                        <asp:BoundColumn DataField="osname" HeaderText="Operating System">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="350px"></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left"  Width="350px"></ItemStyle>
	                        </asp:BoundColumn>
	
	                        <asp:BoundColumn DataField="username" HeaderText="User Name">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="100px"></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="100px"></ItemStyle>
	                        </asp:BoundColumn>
	
	                        <asp:BoundColumn DataField="productkey" HeaderText="Product Key">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="300px"></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
	                        </asp:BoundColumn>
	
	                        <asp:BoundColumn DataField="productname" HeaderText="Product Name">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="300px"></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="300px"></ItemStyle>
	                        </asp:BoundColumn>

	                        <asp:BoundColumn DataField="productmanu" HeaderText="Product Manufacturer">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="200px"></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
	                        </asp:BoundColumn>
                        	
	                        <asp:BoundColumn DataField="serialno" HeaderText="Serial Number">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="200px" ></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle>
	                        </asp:BoundColumn>
                        	
	                        <asp:BoundColumn DataField="processorname" HeaderText="Processor Name">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="350px"></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="350px"></ItemStyle>
	                        </asp:BoundColumn>
	                        
                            <asp:BoundColumn DataField="physicalmemory" HeaderText="Physical Memory">
	                            <HeaderStyle HorizontalAlign="Left" Font-Bold="true" Width="150px"></HeaderStyle>
	                            <ItemStyle HorizontalAlign="Left" Width="150px"></ItemStyle>
	                        </asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
