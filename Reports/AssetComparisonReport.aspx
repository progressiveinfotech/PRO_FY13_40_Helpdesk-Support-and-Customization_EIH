<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssetComparisonReport.aspx.cs" Inherits="Reports_AssetComparisonReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
        <link href="../Include/styles.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
   <%-- <script language="JavaScript"   type="text/javascript">
    
    
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
     <script language="javascript" type="text/javascript">
        function Clickheretoprint()
        { 
		        var disp_setting="toolbar=yes,location=no,directories=yes,menubar=yes,"; 
		            disp_setting+="scrollbars=yes,width=900, height=900, left=50, top=0"; 
		        var content_vlue = document.getElementById("print_content").innerHTML; 
        		
		        var docprint=window.open("","",disp_setting); 
			        
			        docprint.document.open(); 
			        docprint.document.write('<html><head><title>Progressive Infotech</title><link href="../Include/styles.css" rel="stylesheet" />'); 
			        docprint.document.write('</head><body onLoad="self.print()"><center>');          
			        docprint.document.write(content_vlue);          
			        docprint.document.write('</center></body></html>'); 
			        docprint.document.close(); 
			        docprint.focus(); 
        }
       
       
       </script>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  id="print_content">
    <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr><td>&nbsp;</td></tr>
    <tr><td  align="center" style="height: 19px" valign="top">&nbsp;&nbsp;<asp:Label ID="lblinfo" runat="server" Text="Asset Comparison Report " Font-Underline="true" Font-Bold="true" Font-Size="Medium"  ></asp:Label></td></tr>
   
    <tr><td>&nbsp;</td></tr>
        
    </table>
    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
     <tr><td>&nbsp;</td></tr>
     
     <tr>
     <td width="8%" style="height: 20px"></td>
     <td width="18%" style="height: 20px" ></td>
     <td width="18%" class="tdHeader" style="height: 20px" valign="middle">&nbsp;&nbsp;&nbsp;&nbsp;Select Hardware : </td>
     <td width="12%" style="height: 20px" >&nbsp;&nbsp;<asp:DropDownList ID="drphrdwList" DataTextField="Computer" DataValueField="Computer" runat="server">
     <asp:ListItem Text="Select All" Value="Select All"></asp:ListItem>
     <asp:ListItem Text="Processor" Value="Processor"></asp:ListItem>
     <asp:ListItem Text="Memory" Value="Memory"></asp:ListItem>
     <asp:ListItem Text="Adapter" Value="Adapter"></asp:ListItem>
     <asp:ListItem Text="Disk" Value="Disk"></asp:ListItem>
     </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
     <td width="20%" style="height: 20px" valign="top" align="left"><asp:Button ID="btnSelect" runat="server" BackColor="white" Text="  Show   " OnClick="btnSelect_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:Clickheretoprint()">	Click here to print.</a></td>
     <td width="14%" style="height: 20px" valign="top"  align="left"><asp:Button ID="Button1" runat="server" BackColor="white" Text="Export to Excel" OnClick="Button1_Click"  /> </td>
     </tr>
    </table> 
    
   <%--<table align="center"  style="width:100%;">
      <tr>
                    <td style="width:100%; height: 20px; background-color:dodgerblue;" align="center">
                     
                     </td>
                                                           
                    </tr> 
                    <tr>
                     <td style="width:100%; height: 15px;" align="center">
                      <asp:Label ID="lable1" runat="server" Text="Select From Date" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="TextBox1" runat="server" ToolTip="DD/MM/YYYY" Width="120px" MaxLength="10"></asp:TextBox>
                         <img id="img1" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox1.ClientID%>'),this);" src="../Images/cal.gif" alt="date"/>&nbsp;&nbsp;&nbsp;&nbsp;
                        
                         <asp:Label ID="Label2" runat="server" Text="Select To Date" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="TextBox2" runat="server" ToolTip="DD/MM/YYYY" Width="120px" MaxLength="10"></asp:TextBox>
                         <img id="img2" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox2.ClientID%>'),this);" src="../Images/cal.gif" alt="date"/>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    </tr>
                      <tr>
                     <td style="width:100%; height: 2px; background-color: #000000;" align="center">
                    
                     </td>                                         
                    </tr>
                   
                    
   </table>--%>
    <%-- <table>
 
    <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblmsg" Font-Underline="true" Font-Bold="true" Font-Size="Small" Visible="false" runat="server"></asp:Label>
    </td></tr>
     <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblmsg1" Font-Underline="true" Font-Bold="true" Font-Size="Small" Visible="true" runat="server"></asp:Label>
    </td></tr>
   
    </table>--%>
    <table align="center" width="100%" cellpadding="0" cellspacing="2" border="0">
    <tr><td>&nbsp;</td></tr>
     <tr>
    <td width="50%" align="center" bgcolor="#cccccc"><asp:Label ID="lblold" runat="server" Text="Old Asset" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
    <td width="50%" align="center" bgcolor="#cccccc"><asp:Label ID="lblnew" runat="server" Text="New Asset" Font-Bold="true" Font-Size="Medium"></asp:Label></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
     <tr><td width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblmsg" Font-Underline="true" Font-Bold="true" Font-Size="12px" Visible="false" runat="server"></asp:Label>
    </td></tr>
     <tr><td width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblmsg1" Font-Underline="true" Font-Bold="true" Font-Size="Small" Visible="true" runat="server"></asp:Label>
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
    <td width="50%">
      <asp:PlaceHolder ID="AssetCompare_placeholder_old" runat="server"></asp:PlaceHolder>
    </td>
     <td width="50%">
      <asp:PlaceHolder ID="AssetCompare_placeholder_new" runat="server"></asp:PlaceHolder>
    </td>
    
    </tr>
    </table>
    
   <%-- <table align="center" width="100%" cellpadding="0" cellspacing="0" border="1">
    <tr><td >
      <asp:PlaceHolder ID="Asset_Difference_Placeholder" runat="server"></asp:PlaceHolder>
    </td></tr>
    </table>--%>
    </div>
    </form>
</body>
</html>
