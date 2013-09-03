<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="EditSLADefinition.aspx.cs" Inherits="admin_EditSLADefinition" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td><asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label></td>
    </tr>
    <tr>
        <td   width="32%">
           &nbsp;</td>
            <td   width="67%"> &nbsp;</td>
            
    </tr>
   
 
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5" >
            &nbsp;SLA Details</td>
            <td class="tdheader"  > </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;&nbsp;&nbsp;<font class="mandatory">*</font>Site Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblSite"  Font-Bold="true" runat="server"></asp:Label></td></tr>
        <tr>
        <td>&nbsp;&nbsp;&nbsp;<font class="mandatory">*</font>SLA Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSlaName" runat="server" MaxLength="50"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="reqValtxtSla" runat="server" ControlToValidate="txtSlaName" ForeColor="Red" ></asp:RequiredFieldValidator></td>
        <td></td>
        </tr>
        <tr>
        <td colspan="5" valign="top">&nbsp;&nbsp;&nbsp;&nbsp;Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDescription" runat="server" MaxLength="500"  Height="30px" Columns="55" TextMode="MultiLine"></asp:TextBox></td>
        <td></td>
        </tr>

   
     
     <tr>
     <td colspan="5">
     
     </td>
     
     </tr>
    <tr><td>&nbsp;</td></tr>
     <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5" >
            &nbsp;SLA Rules  - &nbsp;<font style=" font-size:smaller;">(Define resolution time)</font></td>
            <td class="tdheader"  > </td>
        </tr>
       
        <tr><td colspan="5">&nbsp;&nbsp;  <asp:Label ID="lblErrorTimeSelect" runat="server" ForeColor="Red"></asp:Label> <asp:RequiredFieldValidator ID="reqValtxtDays" runat="server" ControlToValidate="txtDays" ForeColor="Red"></asp:RequiredFieldValidator>
            
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers" TargetControlID="txtDays" runat="server">
            </cc1:FilteredTextBoxExtender>
            
            
            
            
            </td></tr>
         <tr>
        <td colspan="5" valign="top">&nbsp;&nbsp;&nbsp;<font class="mandatory">*</font> Priority &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:label ID="lblPriority" Font-Bold="true" runat="server"></asp:label><%--<asp:DropDownList ID="drpPriority" runat="server"  ></asp:DropDownList>--%>
        &nbsp;&nbsp;<%--<asp:RequiredFieldValidator ID="reqValDrpPriority" runat="server" ControlToValidate="drpPriority" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>--%></td>
        <td></td>
        </tr>
         <tr>
        <td colspan="5" valign="top">&nbsp;&nbsp;&nbsp;<font class="mandatory">*</font>Resolution time : &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDays" runat="server" Height="12px" MaxLength="3" Width="25px"></asp:TextBox>&nbsp;&nbsp;Days&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Time &nbsp;<asp:DropDownList ID="drphr" runat="server" Width="4%">
        <asp:ListItem text="00" Value="0"></asp:ListItem>
      <asp:ListItem text="01" Value="1"></asp:ListItem>
      <asp:ListItem text="02" Value="2"></asp:ListItem>
      <asp:ListItem text="03" Value="3"></asp:ListItem>
      <asp:ListItem text="04" Value="4"></asp:ListItem>
      <asp:ListItem text="05" Value="5"></asp:ListItem>
       <asp:ListItem text="06" Value="6"></asp:ListItem>
       <asp:ListItem text="07" Value="7"></asp:ListItem>
       <asp:ListItem text="08" Value="8"></asp:ListItem>
       <asp:ListItem text="09" Value="9" ></asp:ListItem>
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
        
        
        
        
        &nbsp;&nbsp;Hours&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="drpMin" runat="server" Width="4%">
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
       <asp:ListItem text="18" Value="18"></asp:ListItem>
       <asp:ListItem text="19" Value="19"></asp:ListItem>
       <asp:ListItem text="20" Value="20"></asp:ListItem>
       <asp:ListItem text="21" Value="21"></asp:ListItem>
       <asp:ListItem text="22" Value="22"></asp:ListItem>
       <asp:ListItem text="23" Value="23"></asp:ListItem>
       <asp:ListItem text="24" Value="24"></asp:ListItem>
       <asp:ListItem text="25" Value="25"></asp:ListItem>
       <asp:ListItem text="26" Value="26"></asp:ListItem>
       <asp:ListItem text="27" Value="27"></asp:ListItem>
       <asp:ListItem text="28" Value="28"></asp:ListItem>
       <asp:ListItem text="29" Value="29"></asp:ListItem>
       <asp:ListItem text="30" Value="30"></asp:ListItem>
        <asp:ListItem text="31" Value="31"></asp:ListItem>
       <asp:ListItem text="32" Value="32"></asp:ListItem>
       <asp:ListItem text="33" Value="33"></asp:ListItem>
       <asp:ListItem text="34" Value="34"></asp:ListItem>
       <asp:ListItem text="35" Value="35"></asp:ListItem>
       <asp:ListItem text="36" Value="36"></asp:ListItem>
       <asp:ListItem text="37" Value="37"></asp:ListItem>
       <asp:ListItem text="38" Value="38"></asp:ListItem>
       <asp:ListItem text="39" Value="39"></asp:ListItem>
       <asp:ListItem text="40" Value="40"></asp:ListItem>
       <asp:ListItem text="41" Value="41"></asp:ListItem>
       <asp:ListItem text="42" Value="42"></asp:ListItem>
       <asp:ListItem text="43" Value="43"></asp:ListItem>
       <asp:ListItem text="44" Value="44"></asp:ListItem>
       <asp:ListItem text="45" Value="45"></asp:ListItem>
       <asp:ListItem text="46" Value="46"></asp:ListItem>
       <asp:ListItem text="47" Value="47"></asp:ListItem>
       <asp:ListItem text="48" Value="48"></asp:ListItem>
       <asp:ListItem text="49" Value="49"></asp:ListItem>
       <asp:ListItem text="50" Value="50"></asp:ListItem>
       <asp:ListItem text="51" Value="51"></asp:ListItem>
       <asp:ListItem text="52" Value="52"></asp:ListItem>
       <asp:ListItem text="53" Value="53"></asp:ListItem>
       <asp:ListItem text="54" Value="54"></asp:ListItem>
       <asp:ListItem text="55" Value="55"></asp:ListItem>
       <asp:ListItem text="56" Value="56"></asp:ListItem>
       <asp:ListItem text="57" Value="57"></asp:ListItem>
       <asp:ListItem text="58" Value="58"></asp:ListItem>
       <asp:ListItem text="59" Value="59"></asp:ListItem>
        
        </asp:DropDownList>&nbsp;&nbsp;Minutes
         </td>
        <td></td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;Escalate to <font style=" font-size:smaller;">(if resolution time is elapsed)</font> : </td></tr>
   <tr><td>&nbsp;</td></tr>
   <tr>
   <td  colspan="5">
    <cc1:Accordion ID="Accordion2" runat="server" SelectedIndex="0"
        HeaderCssClass="accordionHeader" 
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
        AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
        HeaderSelectedCssClass="accordionHeaderSelected">
        <Panes>
        <cc1:AccordionPane ID="AccordionPane1" runat="server">
       <Header>
      <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
     
    <tr>
    <td  height="25px"  >&nbsp;&nbsp;&nbsp;<a href="#" ><strong><font color="#0066cc">Enable Level 1 Escalation </font> </strong></a></td>
   
    </tr>

   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center" border="0">
            <tr><td valign="top" width="15%">&nbsp;&nbsp;<asp:CheckBox ID="chkLevel1" runat="server" Text="" />
            &nbsp;&nbsp;<b>Escalate to </b></td>
            <td width="85%" valign="top">
            <asp:ListBox ID="listLevel1"  SelectionMode="Multiple" Visible="false" height="50px" Width="470px" runat="server"></asp:ListBox>
            <asp:Label ID="selectLevale1" Font-Bold="true" runat="server"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkLevel1" OnClick="lnkLevel1_Click" Font-Bold="true" ForeColor="Blue" Text="[Edit]" runat="server"></asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton ID="lnkCancelLevel1" OnClick="lnkCancelLevel1_Click" Font-Bold="true" ForeColor="Blue" Text="[Cancel]" Visible="false" runat="server"></asp:LinkButton>
          </td></tr>
           <tr>
           <td>&nbsp;</td>
           <td align="left">
           <asp:RadioButton ID="radio1Level1" runat="server" Text="&nbsp;&nbsp;Escalate before" Font-Bold="true" GroupName="Level1" />&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="radio2Level1" runat="server" Text="&nbsp;&nbsp;Escalate After" Font-Bold="true" GroupName="Level1" />&nbsp;&nbsp;&nbsp;
            
            
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterType="Numbers" TargetControlID="txtDaysLevel1" runat="server">
            </cc1:FilteredTextBoxExtender><asp:TextBox ID="txtDaysLevel1" runat="server" Height="12px" MaxLength="3" Width="25px"></asp:TextBox>&nbsp;&nbsp;Days&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Time &nbsp;<asp:DropDownList ID="drpHoursLevel1" runat="server" Width="5%">
        <asp:ListItem text="00" Value="0"></asp:ListItem>
      <asp:ListItem text="01" Value="1"></asp:ListItem>
      <asp:ListItem text="02" Value="2"></asp:ListItem>
      <asp:ListItem text="03" Value="3"></asp:ListItem>
      <asp:ListItem text="04" Value="4"></asp:ListItem>
      <asp:ListItem text="05" Value="5"></asp:ListItem>
       <asp:ListItem text="06" Value="6"></asp:ListItem>
       <asp:ListItem text="07" Value="7"></asp:ListItem>
       <asp:ListItem text="08" Value="8"></asp:ListItem>
       <asp:ListItem text="09" Value="9" ></asp:ListItem>
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
        
        
        
        
        &nbsp;&nbsp;Hours&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="drpMinlevel1" runat="server" Width="5%">
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
       <asp:ListItem text="18" Value="18"></asp:ListItem>
       <asp:ListItem text="19" Value="19"></asp:ListItem>
       <asp:ListItem text="20" Value="20"></asp:ListItem>
       <asp:ListItem text="21" Value="21"></asp:ListItem>
       <asp:ListItem text="22" Value="22"></asp:ListItem>
       <asp:ListItem text="23" Value="23"></asp:ListItem>
       <asp:ListItem text="24" Value="24"></asp:ListItem>
       <asp:ListItem text="25" Value="25"></asp:ListItem>
       <asp:ListItem text="26" Value="26"></asp:ListItem>
       <asp:ListItem text="27" Value="27"></asp:ListItem>
       <asp:ListItem text="28" Value="28"></asp:ListItem>
       <asp:ListItem text="29" Value="29"></asp:ListItem>
       <asp:ListItem text="30" Value="30"></asp:ListItem>
        <asp:ListItem text="31" Value="31"></asp:ListItem>
       <asp:ListItem text="32" Value="32"></asp:ListItem>
       <asp:ListItem text="33" Value="33"></asp:ListItem>
       <asp:ListItem text="34" Value="34"></asp:ListItem>
       <asp:ListItem text="35" Value="35"></asp:ListItem>
       <asp:ListItem text="36" Value="36"></asp:ListItem>
       <asp:ListItem text="37" Value="37"></asp:ListItem>
       <asp:ListItem text="38" Value="38"></asp:ListItem>
       <asp:ListItem text="39" Value="39"></asp:ListItem>
       <asp:ListItem text="40" Value="40"></asp:ListItem>
       <asp:ListItem text="41" Value="41"></asp:ListItem>
       <asp:ListItem text="42" Value="42"></asp:ListItem>
       <asp:ListItem text="43" Value="43"></asp:ListItem>
       <asp:ListItem text="44" Value="44"></asp:ListItem>
       <asp:ListItem text="45" Value="45"></asp:ListItem>
       <asp:ListItem text="46" Value="46"></asp:ListItem>
       <asp:ListItem text="47" Value="47"></asp:ListItem>
       <asp:ListItem text="48" Value="48"></asp:ListItem>
       <asp:ListItem text="49" Value="49"></asp:ListItem>
       <asp:ListItem text="50" Value="50"></asp:ListItem>
       <asp:ListItem text="51" Value="51"></asp:ListItem>
       <asp:ListItem text="52" Value="52"></asp:ListItem>
       <asp:ListItem text="53" Value="53"></asp:ListItem>
       <asp:ListItem text="54" Value="54"></asp:ListItem>
       <asp:ListItem text="55" Value="55"></asp:ListItem>
       <asp:ListItem text="56" Value="56"></asp:ListItem>
       <asp:ListItem text="57" Value="57"></asp:ListItem>
       <asp:ListItem text="58" Value="58"></asp:ListItem>
       <asp:ListItem text="59" Value="59"></asp:ListItem>
        
        </asp:DropDownList>&nbsp;&nbsp;Minutes
            
            
           </td>
           </tr>
                </table>
       
       </Content>
       
       </cc1:AccordionPane>
        <cc1:AccordionPane ID="AccordionPane2" runat="server">
       <Header>
      <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
     
    <tr>
    <td  height="25px"  >&nbsp;&nbsp;&nbsp;<a href="#" ><strong><font color="#0066cc">Enable Level 2 Escalation </font> </strong></a></td>
   
    </tr>

   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center">
           <tr><td width="15%" valign="top">&nbsp;&nbsp;<asp:CheckBox ID="chkLevel2" runat="server" Text="" />
            &nbsp;&nbsp;<b>Escalate to</b> &nbsp;
            </td>
            <td width="85%">
            <asp:ListBox ID="listLevel2"  SelectionMode="Multiple" height="50px" Width="470px" Visible="false" runat="server"></asp:ListBox>
           <asp:Label ID="selectLevale2" Font-Bold="true" runat="server"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkLevel2" OnClick="lnkLevel2_Click" Font-Bold="true" ForeColor="Blue" Text="[Edit]" runat="server"></asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton ID="lnkCancelLevel2" OnClick="lnkCancelLevel2_Click" Font-Bold="true" ForeColor="Blue" Text="[Cancel]" Visible="false" runat="server"></asp:LinkButton>
          
            </td></tr>
           <tr>
           <td></td>
           <td>
           <asp:RadioButton ID="radio1Level2" runat="server" Text="&nbsp;&nbsp;Escalate before" Font-Bold="true" GroupName="Level2" />&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="radio2Level2" runat="server" Text="&nbsp;&nbsp;Escalate After" Font-Bold="true" GroupName="Level2" />&nbsp;&nbsp;&nbsp;
            
            
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" FilterType="Numbers" TargetControlID="txtDaysLevel2" runat="server">
            </cc1:FilteredTextBoxExtender><asp:TextBox ID="txtDaysLevel2" runat="server" Height="12px" MaxLength="3" Width="25px"></asp:TextBox>&nbsp;&nbsp;Days&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Time &nbsp;<asp:DropDownList ID="drpHoursLevel2" runat="server" Width="5%">
        <asp:ListItem text="00" Value="0"></asp:ListItem>
      <asp:ListItem text="01" Value="1"></asp:ListItem>
      <asp:ListItem text="02" Value="2"></asp:ListItem>
      <asp:ListItem text="03" Value="3"></asp:ListItem>
      <asp:ListItem text="04" Value="4"></asp:ListItem>
      <asp:ListItem text="05" Value="5"></asp:ListItem>
       <asp:ListItem text="06" Value="6"></asp:ListItem>
       <asp:ListItem text="07" Value="7"></asp:ListItem>
       <asp:ListItem text="08" Value="8"></asp:ListItem>
       <asp:ListItem text="09" Value="9" ></asp:ListItem>
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
        
        
        
        
        &nbsp;&nbsp;Hours&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="drpMinLevel2" runat="server" Width="5%">
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
       <asp:ListItem text="18" Value="18"></asp:ListItem>
       <asp:ListItem text="19" Value="19"></asp:ListItem>
       <asp:ListItem text="20" Value="20"></asp:ListItem>
       <asp:ListItem text="21" Value="21"></asp:ListItem>
       <asp:ListItem text="22" Value="22"></asp:ListItem>
       <asp:ListItem text="23" Value="23"></asp:ListItem>
       <asp:ListItem text="24" Value="24"></asp:ListItem>
       <asp:ListItem text="25" Value="25"></asp:ListItem>
       <asp:ListItem text="26" Value="26"></asp:ListItem>
       <asp:ListItem text="27" Value="27"></asp:ListItem>
       <asp:ListItem text="28" Value="28"></asp:ListItem>
       <asp:ListItem text="29" Value="29"></asp:ListItem>
       <asp:ListItem text="30" Value="30"></asp:ListItem>
        <asp:ListItem text="31" Value="31"></asp:ListItem>
       <asp:ListItem text="32" Value="32"></asp:ListItem>
       <asp:ListItem text="33" Value="33"></asp:ListItem>
       <asp:ListItem text="34" Value="34"></asp:ListItem>
       <asp:ListItem text="35" Value="35"></asp:ListItem>
       <asp:ListItem text="36" Value="36"></asp:ListItem>
       <asp:ListItem text="37" Value="37"></asp:ListItem>
       <asp:ListItem text="38" Value="38"></asp:ListItem>
       <asp:ListItem text="39" Value="39"></asp:ListItem>
       <asp:ListItem text="40" Value="40"></asp:ListItem>
       <asp:ListItem text="41" Value="41"></asp:ListItem>
       <asp:ListItem text="42" Value="42"></asp:ListItem>
       <asp:ListItem text="43" Value="43"></asp:ListItem>
       <asp:ListItem text="44" Value="44"></asp:ListItem>
       <asp:ListItem text="45" Value="45"></asp:ListItem>
       <asp:ListItem text="46" Value="46"></asp:ListItem>
       <asp:ListItem text="47" Value="47"></asp:ListItem>
       <asp:ListItem text="48" Value="48"></asp:ListItem>
       <asp:ListItem text="49" Value="49"></asp:ListItem>
       <asp:ListItem text="50" Value="50"></asp:ListItem>
       <asp:ListItem text="51" Value="51"></asp:ListItem>
       <asp:ListItem text="52" Value="52"></asp:ListItem>
       <asp:ListItem text="53" Value="53"></asp:ListItem>
       <asp:ListItem text="54" Value="54"></asp:ListItem>
       <asp:ListItem text="55" Value="55"></asp:ListItem>
       <asp:ListItem text="56" Value="56"></asp:ListItem>
       <asp:ListItem text="57" Value="57"></asp:ListItem>
       <asp:ListItem text="58" Value="58"></asp:ListItem>
       <asp:ListItem text="59" Value="59"></asp:ListItem>
        
        </asp:DropDownList>&nbsp;&nbsp;Minutes
            
            
           </td>
           </tr>
                </table>
       
       </Content>
       
       </cc1:AccordionPane>
        <cc1:AccordionPane ID="AccordionPane3" runat="server">
       <Header>
      <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
     
    <tr>
    <td  height="25px"  >&nbsp;&nbsp;&nbsp;<a href="#" ><strong><font color="#0066cc">Enable Level 3 Escalation </font> </strong></a></td>
   
    </tr>

   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center">
            <tr><td width="15%">&nbsp;&nbsp;<asp:CheckBox ID="chkLevel3" runat="server" Text="" />
            &nbsp;&nbsp;<b>Escalate to </b>&nbsp;
            </td> 
            <td width="85%">
            <asp:ListBox ID="listLevel3"  Visible="false" SelectionMode="Multiple" height="50px" Width="470px" runat="server"></asp:ListBox>
           <asp:Label ID="selectLevale3" Font-Bold="true" runat="server"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkLevel3" OnClick="lnkLevel3_Click" Font-Bold="true" ForeColor="Blue" Text="[Edit]" runat="server"></asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton ID="lnkCancelLevel3" OnClick="lnkCancelLevel3_Click" Font-Bold="true" ForeColor="Blue" Text="[Cancel]" Visible="false" runat="server"></asp:LinkButton>
          
            </td></tr>
           <tr>
           <td></td>
           <td>
           <asp:RadioButton ID="radio1Level3" runat="server" Text="&nbsp;&nbsp;Escalate before" Font-Bold="true" GroupName="Level3" />&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="radio2Level3" runat="server" Text="&nbsp;&nbsp;Escalate After" Font-Bold="true" GroupName="Level3" />&nbsp;&nbsp;&nbsp;
            
            
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" FilterType="Numbers" TargetControlID="txtDaysLevel3" runat="server">
            </cc1:FilteredTextBoxExtender><asp:TextBox ID="txtDaysLevel3" runat="server" Height="12px" MaxLength="3" Width="25px"></asp:TextBox>&nbsp;&nbsp;Days&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Time &nbsp;<asp:DropDownList ID="drpHoursLevel3" runat="server" Width="5%">
        <asp:ListItem text="00" Value="0"></asp:ListItem>
      <asp:ListItem text="01" Value="1"></asp:ListItem>
      <asp:ListItem text="02" Value="2"></asp:ListItem>
      <asp:ListItem text="03" Value="3"></asp:ListItem>
      <asp:ListItem text="04" Value="4"></asp:ListItem>
      <asp:ListItem text="05" Value="5"></asp:ListItem>
       <asp:ListItem text="06" Value="6"></asp:ListItem>
       <asp:ListItem text="07" Value="7"></asp:ListItem>
       <asp:ListItem text="08" Value="8"></asp:ListItem>
       <asp:ListItem text="09" Value="9" ></asp:ListItem>
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
        
        
        
        
        &nbsp;&nbsp;Hours&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="drpMinLevel3" runat="server" Width="5%">
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
       <asp:ListItem text="18" Value="18"></asp:ListItem>
       <asp:ListItem text="19" Value="19"></asp:ListItem>
       <asp:ListItem text="20" Value="20"></asp:ListItem>
       <asp:ListItem text="21" Value="21"></asp:ListItem>
       <asp:ListItem text="22" Value="22"></asp:ListItem>
       <asp:ListItem text="23" Value="23"></asp:ListItem>
       <asp:ListItem text="24" Value="24"></asp:ListItem>
       <asp:ListItem text="25" Value="25"></asp:ListItem>
       <asp:ListItem text="26" Value="26"></asp:ListItem>
       <asp:ListItem text="27" Value="27"></asp:ListItem>
       <asp:ListItem text="28" Value="28"></asp:ListItem>
       <asp:ListItem text="29" Value="29"></asp:ListItem>
       <asp:ListItem text="30" Value="30"></asp:ListItem>
        <asp:ListItem text="31" Value="31"></asp:ListItem>
       <asp:ListItem text="32" Value="32"></asp:ListItem>
       <asp:ListItem text="33" Value="33"></asp:ListItem>
       <asp:ListItem text="34" Value="34"></asp:ListItem>
       <asp:ListItem text="35" Value="35"></asp:ListItem>
       <asp:ListItem text="36" Value="36"></asp:ListItem>
       <asp:ListItem text="37" Value="37"></asp:ListItem>
       <asp:ListItem text="38" Value="38"></asp:ListItem>
       <asp:ListItem text="39" Value="39"></asp:ListItem>
       <asp:ListItem text="40" Value="40"></asp:ListItem>
       <asp:ListItem text="41" Value="41"></asp:ListItem>
       <asp:ListItem text="42" Value="42"></asp:ListItem>
       <asp:ListItem text="43" Value="43"></asp:ListItem>
       <asp:ListItem text="44" Value="44"></asp:ListItem>
       <asp:ListItem text="45" Value="45"></asp:ListItem>
       <asp:ListItem text="46" Value="46"></asp:ListItem>
       <asp:ListItem text="47" Value="47"></asp:ListItem>
       <asp:ListItem text="48" Value="48"></asp:ListItem>
       <asp:ListItem text="49" Value="49"></asp:ListItem>
       <asp:ListItem text="50" Value="50"></asp:ListItem>
       <asp:ListItem text="51" Value="51"></asp:ListItem>
       <asp:ListItem text="52" Value="52"></asp:ListItem>
       <asp:ListItem text="53" Value="53"></asp:ListItem>
       <asp:ListItem text="54" Value="54"></asp:ListItem>
       <asp:ListItem text="55" Value="55"></asp:ListItem>
       <asp:ListItem text="56" Value="56"></asp:ListItem>
       <asp:ListItem text="57" Value="57"></asp:ListItem>
       <asp:ListItem text="58" Value="58"></asp:ListItem>
       <asp:ListItem text="59" Value="59"></asp:ListItem>
        
        </asp:DropDownList>&nbsp;&nbsp;Minutes
            
            
           </td>
           </tr>
                </table>
       
       </Content>
       
       </cc1:AccordionPane>
         </Panes>
        </cc1:Accordion>
     <cc1:Accordion ID="cs" runat="server" SelectedIndex="0"
        HeaderCssClass="accordionHeader" 
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
        AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
        HeaderSelectedCssClass="accordionHeaderSelected" >
       <Panes>
       <cc1:AccordionPane ID="a" runat="server">
       <Header></Header>
       <Content></Content>
       </cc1:AccordionPane>
       </Panes>
       </cc1:Accordion>
   </td>
   </tr>
      
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;</td>
            <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
                <asp:Button ID="btnUpdate" runat="server" Text=" Update " onclick="btnUpdate_Click"  
                     />&nbsp;<asp:Button ID="btnCancel" 
                    CausesValidation="false" runat="server" Text=" Cancel " onclick="btnCancel_Click" 
                     /> </td>
            
    </tr>
         </table>

</asp:Content>

