<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddServiceWindow.aspx.cs" Inherits="admin_AddServiceWindow" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
     <tr><td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
 <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td><asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red" Width="300%"></asp:Label></td>
    </tr>
     <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="25%">
            &nbsp;Add Service Window</td> 
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"  width="75%"> </td>
            
    </tr>
 <tr><td class="tdsubheading" align="left">
    <Font class="mandatory">*</Font>&nbsp;&nbsp;Select Customer</td>                             
     <td> <asp:DropDownList ID="drpCustomer" runat="server" AutoPostBack="true" 
             Width="155px" onselectedindexchanged="drpCustomer_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValdrpCustomer" runat="server" EnableClientScript="true" ControlToValidate="drpCustomer" ErrorMessage="Select Customer"   InitialValue="0"></asp:RequiredFieldValidator></td>
     
     </tr>
     
    <tr><td class="tdsubheading" align="left">
    <Font class="mandatory">*</Font>&nbsp;&nbsp;Select Site to Define Operational Hours </td>                             
     <td width="80%"><asp:DropDownList ID="drpSites" Width="155px" AutoPostBack="true" runat="server" 
             onselectedindexchanged="drpSites_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValSite" runat="server" EnableClientScript="true" ControlToValidate="drpSites" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
              </td></tr>
       <tr><td>&nbsp;</td></tr>
        <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5" >
            &nbsp;Working Time  - &nbsp;<font style=" font-size:smaller;">(To specify your working hours, Select a start and end time)</font></td>
            <td class="tdheader"  > </td>
        </tr>
 <tr> <td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblErrorMsgWorkingTime" runat="server" ForeColor="Red"></asp:Label></td> </tr>
    <tr>
    <td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbtn24hr" runat="server" GroupName="rdwrkhr" Text=" &nbsp;Round the Clock(24 hours)" Font-Bold="true" /></td>
    </tr>
     <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     or</td></tr>
     
     <tr>
     <td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbtnSelect" runat="server" GroupName="rdwrkhr" Font-Bold="true" Text="&nbsp; Select operational hours" />
     &nbsp;&nbsp;&nbsp;&nbsp;<font style=" font-weight:bold;">Start Time</font>&nbsp;&nbsp;
     <asp:DropDownList ID="drpStarthour" runat="server">
     <asp:ListItem text="00" Value="0"></asp:ListItem>
      <asp:ListItem text="01" Value="1"></asp:ListItem>
      <asp:ListItem text="02" Value="2"></asp:ListItem>
      <asp:ListItem text="03" Value="3"></asp:ListItem>
      <asp:ListItem text="04" Value="4"></asp:ListItem>
      <asp:ListItem text="05" Value="5"></asp:ListItem>
       <asp:ListItem text="06" Value="6"></asp:ListItem>
       <asp:ListItem text="07" Value="7"></asp:ListItem>
       <asp:ListItem text="08" Value="8"></asp:ListItem>
       <asp:ListItem text="09" Value="9" Selected="True"></asp:ListItem>
       <asp:ListItem text="10" Value="10"></asp:ListItem>
       <asp:ListItem text="11" Value="11"></asp:ListItem>
       <asp:ListItem text="12" Value="12"></asp:ListItem>
       <asp:ListItem text="13" Value="13"></asp:ListItem>
       <asp:ListItem text="14" Value="14"></asp:ListItem>
       <asp:ListItem text="15" Value="15"></asp:ListItem>
       <asp:ListItem text="16" Value="16"></asp:ListItem>
       <asp:ListItem text="17" Value="17"></asp:ListItem>
       <asp:ListItem text="18" Value="18"></asp:ListItem>
       <asp:ListItem text="19" Value="19"></asp:ListItem>
       <asp:ListItem text="20" Value="20"></asp:ListItem>
       <asp:ListItem text="21" Value="21"></asp:ListItem>
       <asp:ListItem text="22" Value="22"></asp:ListItem>
       <asp:ListItem text="23" Value="23"></asp:ListItem>
     </asp:DropDownList>
     &nbsp;<font style="font-weight:bold;">:</font>&nbsp;&nbsp;
     <asp:DropDownList ID="drpStartmin" runat="server">
     <asp:ListItem Text="00" Value="0"></asp:ListItem>
     <asp:ListItem Text="15" Value="15"></asp:ListItem>
     <asp:ListItem Text="30" Value="30"></asp:ListItem>
     <asp:ListItem Text="45" Value="45"></asp:ListItem>
     </asp:DropDownList>
     </td>
     </tr>
     <tr>
     <td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <font style=" font-weight:bold;">End Time</font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:DropDownList ID="drpEndhr" runat="server">
   
      <asp:ListItem text="00" Value="0"></asp:ListItem>
      <asp:ListItem text="01" Value="1"></asp:ListItem>
      <asp:ListItem text="02" Value="2"></asp:ListItem>
      <asp:ListItem text="03" Value="3"></asp:ListItem>
      <asp:ListItem text="04" Value="4"></asp:ListItem>
      <asp:ListItem text="05" Value="5"></asp:ListItem>
       <asp:ListItem text="06" Value="6"></asp:ListItem>
       <asp:ListItem text="07" Value="7"></asp:ListItem>
       <asp:ListItem text="08" Value="8"></asp:ListItem>
       <asp:ListItem text="09" Value="9"></asp:ListItem>
       <asp:ListItem text="10" Value="10"></asp:ListItem>
       <asp:ListItem text="11" Value="11"></asp:ListItem>
       <asp:ListItem text="12" Value="12"></asp:ListItem>
       <asp:ListItem text="13" Value="13"></asp:ListItem>
       <asp:ListItem text="14" Value="14"></asp:ListItem>
       <asp:ListItem text="15" Value="15"></asp:ListItem>
       <asp:ListItem text="16" Value="16"></asp:ListItem>
       <asp:ListItem text="17" Value="17"></asp:ListItem>
       <asp:ListItem text="18" Value="18" Selected="True"></asp:ListItem>
       <asp:ListItem text="19" Value="19"></asp:ListItem>
       <asp:ListItem text="20" Value="20"></asp:ListItem>
       <asp:ListItem text="21" Value="21"></asp:ListItem>
       <asp:ListItem text="22" Value="22"></asp:ListItem>
       <asp:ListItem text="23" Value="23"></asp:ListItem>
     </asp:DropDownList>
     &nbsp;<font style="font-weight:bold;">:</font>&nbsp;&nbsp;
     <asp:DropDownList ID="drpEndmin" runat="server">
     <asp:ListItem Text="00" Value="0"></asp:ListItem>
     <asp:ListItem Text="15" Value="15"></asp:ListItem>
     <asp:ListItem Text="30" Value="30"></asp:ListItem>
     <asp:ListItem Text="45" Value="45"></asp:ListItem>
     </asp:DropDownList>
     </td>
     
     </tr>
    <tr><td>&nbsp;</td></tr>
     <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5" >
            &nbsp;Working Days  - &nbsp;<font style=" font-size:smaller;">(To specify your working days)</font></td>
            <td class="tdheader"  > </td>
        </tr>
       <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblErrorMsgWorkingDays" runat="server" ForeColor="Red"></asp:Label></td></tr>
        <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkMonday" runat="server" Text="&nbsp;&nbsp;Monday" /></td></tr>
        <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkTuesday" runat="server" Text="&nbsp;&nbsp;Tuesday" /></td></tr>
        <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkWednesday" runat="server" Text="&nbsp;&nbsp;Wednesday" /></td></tr>
        <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkThursday" runat="server" Text="&nbsp;&nbsp;Thursday" /></td></tr>
        <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkFriday" runat="server" Text="&nbsp;&nbsp;Friday" /></td></tr>
        <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkSaturday" runat="server" Text="&nbsp;&nbsp;Saturday" /></td></tr>
        <tr><td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkSunday" runat="server" Text="&nbsp;&nbsp;Sunday" /></td></tr>
     <tr><td>&nbsp;</td></tr>
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;</td>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"><asp:Button ID="btnSave" runat="server" Text=" Save " 
                    onclick="btnSave_Click" />&nbsp;<asp:Button ID="btnReset" 
                    CausesValidation="false" runat="server" Text="Reset" onclick="btnReset_Click" /> </td>
            
    </tr>
         </table> 
    
</ContentTemplate> 
</asp:UpdatePanel> </td> </tr> 
    </table> 

</asp:Content>

