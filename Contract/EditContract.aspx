<%@ Page Language="C#" MasterPageFile="~/Master/MasterContract.master" AutoEventWireup="true" CodeFile="EditContract.aspx.cs" Inherits="Contract_EditContract" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" src="../JScript/scw.js"></script>
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
        <script language="JavaScript"   type="text/javascript">
	function dateValidation()
    {

        var obj = document.getElementById("<%=txtActiveFrom.ClientID%>"); 

        var jsDay = obj.value.split("/")[0];
        var jsMonth = obj.value.split("/")[1]; 
        var jsYear = obj.value.split("/")[2];
        
        var finaldate= new Date(jsYear,jsMonth-1,jsDay); 
        var today = new Date();
           
         if(finaldate=='undefined')
        {
            alert("you have entered invalid date!");
            return false;
        }
        
        if(finaldate < today)
        {
            alert("The Active From date must be greater or equal to current date.");
            return false;
        }
        
        
        var obj1 = document.getElementById("<%=txtActiveTo.ClientID%>"); 

        var jsDay1 = obj1.value.split("/")[0];
        var jsMonth1 = obj1.value.split("/")[1]; 
        var jsYear1 = obj1.value.split("/")[2];
        
        var finaldate1= new Date(jsYear1,jsMonth1-1,jsDay1); 
        var today1 = new Date();
           
         if(finaldate1=='undefined')
        {
            alert("you have entered invalid date!");
            return false;
        }
        
        if(finaldate1 < today1)
        {
            alert("The Active to date must be greater or equal to current date.");
            return false;
        }
    }

   
            
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel></td></tr>
 <tr><td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
     <tr>
    <td><asp:Label ID="lblErrorMsg" runat="server"  Font-Bold="true"  ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td  class="tdheader" width="20%">
            &nbsp;Update Contract</td>
            <td width="80%" class="tdheader"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Contract  Name
        </td>
        <td>
         
         <asp:TextBox ID="txtContractName" runat="server"  Columns="70"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValRegion" runat="server" ControlToValidate="txtContractName" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator></td>
       
    </tr>
    <tr>
        <td align="left" class="tdsubheading">
          &nbsp;&nbsp;Description  
        </td>
        <td >
          
           <asp:TextBox ID="txtdesc" runat="server" Height="40px" 
                    Columns="95" TextMode="MultiLine" MaxLength="500" ></asp:TextBox>
            
        </td>
        
    </tr>
     <tr>
        <td align="left" class="tdsubheading">
        <font class="mandatory">*</font>Choose Vendor  
        </td>
        <td>
          
          <asp:DropDownList ID="drpVendor" runat="server">
          
          </asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpRgn" runat="server" EnableClientScript="true" ControlToValidate="drpVendor"  ErrorMessage="Select Vendor"  InitialValue="0"></asp:RequiredFieldValidator>&nbsp;&nbsp;<asp:LinkButton 
                ID="lnkAddVendor" runat="server" Text="Add Vendor" 
                 CausesValidation="false" Font-Bold="true" ForeColor="Blue" onclick="lnkAddVendor_Click" 
                 ></asp:LinkButton>
            
        </td>
        
    </tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
        <td  class="tdheader" colspan="5">
            &nbsp;Contract Rules <font style="font-size:9px">(Select the Assets that are covered under this contract.)</font></td>
          
    </tr>
   
    <tr>
        <td valign="top" align="left" class="tdsubheading">
          &nbsp;&nbsp;Select Assets 
        </td>
        <td>
          
       <asp:ListBox ID="ListAsset"  SelectionMode="Multiple" height="90px" Width="420px" runat="server"></asp:ListBox>&nbsp;&nbsp;<asp:LinkButton 
                ID="lnkAddAsset" runat="server" Text="[Add Asset]" 
                 CausesValidation="false" Font-Bold="true" ForeColor="Blue" onclick="lnkAddAsset_Click"  
                ></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkRemove" runat="server" 
                Font-Bold="true" ForeColor="Blue" Text="[Remove Asset]"  CausesValidation="false"
                onclick="lnkRemove_Click"></asp:LinkButton>
            
        </td>
        
    </tr>
    <tr>
     <td align="left" class="tdsubheading">
          <font class="mandatory">*</font>Active Period From 
        </td>
        <td>
         <asp:TextBox ID="txtActiveFrom" runat="server" ToolTip="DD/MM/YYYY" ></asp:TextBox>
            <img src="../images/cal.gif" id="imgdate" onclick="scwShow(document.getElementById('<%=txtActiveFrom.ClientID%>'),this);" alt="Date" />
            &nbsp;
            <asp:RequiredFieldValidator ID="Reqholidaydate" runat="server" EnableClientScript="true" 
                ControlToValidate="txtActiveFrom"  InitialValue="0">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexpDate" runat="server" ControlToValidate="txtActiveFrom" 
                ErrorMessage="Enter date into right formate" 
                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Required to enter the date!" ControlToValidate="txtActiveFrom">
            </asp:RequiredFieldValidator>
        </td>
      
      
        
    </tr>
   <tr>
        <td align="left" class="tdsubheading">
          <font class="mandatory">*</font>Active Period To
        </td>
        <td>
          
        <asp:TextBox ID="txtActiveTo" runat="server" ToolTip="DD/MM/YYYY" ></asp:TextBox>
            <img src="../images/cal.gif" id="img1" onclick="scwShow(document.getElementById('<%=txtActiveTo.ClientID%>'),this);" alt="Date" />
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="true" 
                ControlToValidate="txtActiveTo"  InitialValue="0">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtActiveTo" 
                ErrorMessage="Enter date into right formate" 
                ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Required to enter the date!" ControlToValidate="txtActiveTo">
            </asp:RequiredFieldValidator>
            
        </td>
        
    </tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
        <td  class="tdheader" colspan="5">
            &nbsp;Notification Rules <font style="font-size:9px">(Select the users to be notified before contract expiry)</font></td>
          
    </tr>
     <tr><td valign="top" width="15%">&nbsp;&nbsp;<asp:CheckBox ID="chkLevel1" runat="server" Font-Bold="true" Text=" Enable Notification" />
           </td>
            <td width="85%">
            <asp:ListBox ID="listLevel1"  SelectionMode="Multiple" height="50px" Width="470px" runat="server"></asp:ListBox> 
            
           </td></tr>
           <tr>
           <td align="left" class="tdsubheading">&nbsp;&nbsp;<b><font style="font-size:10px">Notify Before</font></b></td>
             <td><asp:TextBox ID="txtBeforeDays" runat="server"  MaxLength="3" Width="25px"></asp:TextBox>&nbsp;&nbsp;
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers" TargetControlID="txtBeforeDays"  runat="server">
                 </cc1:FilteredTextBoxExtender>
              
             </td>
           </tr>
        
   
    <tr><td class="tdsubheading" align="left">&nbsp;</td>                             
     <td> &nbsp;</td></tr>
    <tr>
        <td class="tdheader"></td> 
          
        <td class="tdheader" align="left">

             <asp:Button ID="btnUpdate" runat="server" 
                Text="Update Contract" onclick="btnUpdate_Click"   />      
           <asp:Button ID="btnCancel"  CausesValidation="false"  runat="server" 
                Text="Cancel" onclick="btnCancel_Click"   />  
                      
        </td>
    </tr>
  
 
  
   

</table>
</ContentTemplate>
</asp:UpdatePanel>
 </td></tr>
 </table>

</asp:Content>

