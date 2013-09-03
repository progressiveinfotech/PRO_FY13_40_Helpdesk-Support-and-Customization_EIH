<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddVendor.aspx.cs" Inherits="Contract_AddVendor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../Include/MasterCSSFile.css" type="text/css" rel="stylesheet" />
    <link href="../Include/styles.css" type="text/css" rel="stylesheet" />
     <script type="text/javascript" language="javascript">

        function refreshParent() 
        {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow)
	        {
                window.opener.progressWindow.close()
            }
                window.close();
        }
    
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">
            &nbsp;Add Vendor</td>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" class="tdheader"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Vendor Name
        </td>
        <td>
         
         <asp:TextBox ID="txtvendorname" runat="server" Height="20px" MaxLength="70">
         </asp:TextBox> &nbsp;
         <asp:RequiredFieldValidator ID="reqValVendor" runat="server" 
            ControlToValidate="txtvendorname" EnableClientScript="true"  
            SetFocusOnError="true"  ForeColor="Red">
         </asp:RequiredFieldValidator></td>
       
    </tr>
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Contact Person 
        </td>
        <td >
          
           <asp:TextBox ID="txtcontactperson" runat="server" Height="20px" MaxLength="70" >
           </asp:TextBox>
            
        </td>
        
    </tr>
   
    <tr><td class="tdsubheading" align="left">&nbsp;</td>                             
     <td> &nbsp;</td></tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;</td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnVendoradd" runat="server" 
                Text="Save" onclick="btnVendoradd_Click"  />      
           <asp:Button ID="btnClose"  CausesValidation="false"  runat="server" 
                Text="Close"  OnClientClick="javascript:window.close();"  />  
               
               
         
           
    
        </td>
    </tr>
    </table> 
    </div>
    </form>
</body>
</html>
