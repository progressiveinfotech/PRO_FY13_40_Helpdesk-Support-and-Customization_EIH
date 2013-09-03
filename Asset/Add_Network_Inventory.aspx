<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="Add_Network_Inventory.aspx.cs" Inherits="Asset_Add_Network_Inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%"><tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
 &nbsp;&nbsp;Add Network Device
 </td></tr></table>
<table align="left" width="100%" cellpadding="0"  border="0" cellspacing="0">




<tr>
<td width="30%" align="left">&nbsp;&nbsp;<asp:Label ID="lblinfo" runat="server" Text="Add General Information" Font-Underline="true" Font-Bold="true" Font-Size="15px"></asp:Label></td>
<td width="30%" align="left"></td>
<td width="20%" align="left"></td>
<td width="20%" align="left"></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td  align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblInv" runat="server" Text="IP Address" Font-Bold="true"></asp:Label></td>
<td  align="left"><asp:TextBox ID="txtinv" runat="server" ></asp:TextBox></td>
<td  align="left"><asp:Label ID="lblDevice" runat="server" Text="Device Name" Font-Bold="true"></asp:Label></td>
<td  align="left"><asp:TextBox ID="txtdeviceName" runat="server" ></asp:TextBox></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td  align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblInventorydate" runat="server" Text="Inventory Date" Font-Bold="true"></asp:Label></td>
<td  align="left"><asp:TextBox ID="txtInvntDate" runat="server" ToolTip="DD/MM/YYYY" Width="120px" MaxLength="10" ></asp:TextBox>
 <img id="img1" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=txtInvntDate.ClientID%>'),this);" src="../Images/cal.gif" alt="date"/>
</td>
<td  align="left"><asp:Label ID="lblDesc" runat="server" Text="Description" Font-Bold="true"></asp:Label></td>
<td  align="left"><asp:TextBox ID="txtDesc" runat="server" Columns="30" Rows="2" TextMode="MultiLine"></asp:TextBox></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td  align="left">&nbsp;&nbsp;<asp:Label ID="lblAddInfo" runat="server" Text="Add Additional Information" Font-Underline="true" Font-Bold="true" Font-Size="15px"></asp:Label></td>
<td  align="left"></td>
<td  align="left"></td>
<td  align="left"></td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>

<tr>
<td  align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblContact" runat="server" Text="Contact" Font-Bold="true"></asp:Label></td>
<td  align="left"><asp:TextBox ID="txtContact" runat="server" ></asp:TextBox></td>
<td  align="left"><asp:Label ID="lblLocation" runat="server" Text="Location" Font-Bold="true"></asp:Label></td>
<td  align="left"><asp:TextBox ID="txtLocation" runat="server" ></asp:TextBox></td>
</tr>


<tr><td>&nbsp;</td></tr>
<tr>
<td  align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPlatform" runat="server" Text="Platform Id" Font-Bold="true"></asp:Label></td>
<td  align="left"><asp:TextBox ID="txtPlatform" runat="server" ></asp:TextBox></td>
<td  align="left"><asp:Label ID="lbluptime" runat="server"  Text="Up Time" Font-Bold="true"></asp:Label>

</td>
<td  align="left"><asp:TextBox ID="txtuptime"   runat="server" ></asp:TextBox>

</td>
</tr>

<tr><td>&nbsp;</td></tr>
<tr><td>&nbsp;</td></tr>
<tr>
<td  align="left"></td>
<td  align="left"></td>
<td  align="left"></td>
<td  align="left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnsave" runat="server"  Font-Bold="true" OnClientClick="return verifyIP();"  Text="   Add   " OnClick="btnsave_Click"  /></td>
</tr>

</table>


 <script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
<script language="javascript" type="text/javascript">
              
              
                        
                function verifyIP() 
                {
                
                   var ipaddr = document.getElementById("<%=txtinv.ClientID%>").value;                 
                   var re = /^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/;
                   if (re.test(ipaddr)) 
                      {
                      var parts = ipaddr.split(".");
                      if (parseInt(parseFloat(parts[0])) == 0) {alert ("Enter the valid IP address.");  return false; }
                      for (var i=0; i<parts.length; i++) 
                      {
                         if (parseInt(parseFloat(parts[i])) > 255) {alert ("Enter the valid IP address.");  return false; }
                      }
                      
                    

                   } 
                   else 
                      {
                      alert ("Enter the valid IP address.");
                      return false;

                      }
                      
                                            
                     var obj = document.getElementById("<%=txtInvntDate.ClientID%>"); 

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

  

                </script>

</asp:Content>

