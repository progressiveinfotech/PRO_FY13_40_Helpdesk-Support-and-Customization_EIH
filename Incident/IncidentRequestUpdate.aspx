<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="IncidentRequestUpdate.aspx.cs" Inherits="Incident_IncidentRequestUpdate" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../Include/section.css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript">

    function check_uncheck(Val) {
        var ValChecked = Val.checked;
        var ValId = Val.id;
        var frm = document.forms[0];
        // Loop through all elements
        for (i = 0; i < frm.length; i++) {
            // Look for Header Template's Checkbox
            //As we have not other control other than checkbox we just check following statement
            if (this != null) {
                if (ValId.indexOf('CheckAll') != -1) {
                    // Check if main checkbox is checked,
                    // then select or deselect datagrid checkboxes
                    if (ValChecked)
                        frm.elements[i].checked = true;
                    else
                        frm.elements[i].checked = false;
                }
                else if (ValId.indexOf('deleteRec') != -1) {
                    // Check if any of the checkboxes are not checked, and then uncheck top select all checkbox
                    if (frm.elements[i].checked == false)
                        frm.elements[1].checked = false;
                }
            } // if
        } // for
    } // function

</script>
<script type="text/javascript" language="javascript">
var timeout	= 500;
var closetimer	= 0;
var ddmenuitem	= 0;
function mclosetime()
{
	closetimer = window.setTimeout(mclose, timeout);
}


function mcancelclosetime()
{
	if(closetimer)
	{
		window.clearTimeout(closetimer);
		closetimer = null;
	}
}
function mopen(id)
{	
	// cancel close timer
	mcancelclosetime();

	// close old layer
	if(ddmenuitem) ddmenuitem.style.visibility = 'hidden';

	// get new layer and show it
	ddmenuitem = document.getElementById(id);
	ddmenuitem.style.visibility = 'visible';

}
function mclose()
{
	if(ddmenuitem) ddmenuitem.style.visibility = 'hidden';
	document.onclick = mclose;
}

</script>
    <style type="text/css">
        .style1
        {
            height: 51px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table width="100%" align="center" cellpadding="0" border="0" cellspacing="0">
<tr>
<td   align="left">
<ul id="sddm">

  <li style="padding-left:750px;"><asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ForeColor="Blue" ID="lnkProblem" Text="[Link To Problem]" runat="server" Font-Underline="true" ></asp:LinkButton> <div id="m1" onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
    
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkNewProblem" Text="[Create New Problem]" runat="server" onclick="lnkNewProblem_Click"    Font-Underline="true"></asp:LinkButton> 
        
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkExistProblem" Text="[Existing Problem]" runat="server" onclick="lnkExistProblem_Click"  Font-Underline="true"></asp:LinkButton> 
       
        </div></li> 
  

<li style="padding-left:5px;"><asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ForeColor="Blue" ID="lnkNewchange" Text="[Link To Change]" runat="server" Font-Underline="true" onclick="lnkNewchange_Click" ></asp:LinkButton> <div id="Div1" onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
    
        <%--<asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkNewchange" Text="[Create New Change]" runat="server" onclick="lnkNewchange_Click"    Font-Underline="true"></asp:LinkButton> 
        
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkExistingChange" Text="[Existing Change]" runat="server" onclick="lnkExistingChange_Click"  Font-Underline="true"></asp:LinkButton> 
       --%>
        </div></li>
 </ul>
</td>

</tr>
</table>
<asp:UpdatePanel ID="updatepanel3" runat="server">
<ContentTemplate>
<table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;<b>Ticket id :</b>&nbsp;<asp:Label ID="lblIncidentId" runat="server" Font-Bold="true" ForeColor="White"></asp:Label>



</td>

</tr>

<tr>
<td>

<asp:ImageButton ID="imgRequest" CausesValidation="false" runat="server" 
ImageUrl="~/images/btnincident2.bmp" Width="105px" Height="25px"  OnClick="imgRequest_Click" />

<asp:ImageButton ID="imgHistory" CausesValidation="false" runat="server" 
ImageUrl="~/images/btnhistory2.bmp" Width="105px" Height="25px" OnClick="imgHistory_Click"   />

<asp:ImageButton ID="imgResolution" CausesValidation="false" runat="server" 
ImageUrl="~/images/btnresolution2.bmp" Width="105px" Height="25px" OnClick="imgResolution_Click"   />

</td>
</tr>

<tr>
<td>
      
 
<table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
<tr>
<td>&nbsp;&nbsp;<b>Title :</b> <asp:Label ID="lblTitle" runat="server"></asp:Label>
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 </td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Description :</b>&nbsp;&nbsp;<asp:Label ID="lblDescription" runat="server"></asp:Label> </td>
</tr>
<tr>
        <td>&nbsp;&nbsp;<b>User Extension :</b>&nbsp;&nbsp;<asp:Label ID="lblextension" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>&nbsp;&nbsp;<b>AMC Call :</b>&nbsp;&nbsp;<asp:Label ID="lblAMCcall" runat="server"></asp:Label></td>
    </tr>
<tr>
<td>&nbsp;&nbsp;<b>Requested by :</b> <asp:Label ID="lblRequesterDisp" runat="server"> </asp:Label>&nbsp; on  &nbsp;<asp:Label ID="lblDateDisp" runat="server"></asp:Label>
    <asp:Label ID="Lblstatusupdatemsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
    &nbsp;</td>
</tr>
  

    <tr>
        <td>
            <b>&nbsp;Reported Date :</b>
            <asp:Label ID="lblReportedDate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
  

<tr>
<td>

   
<asp:Panel ID="panelRequest" runat="server">

<table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">



<tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;&nbsp;Call Details
<font style="padding-left:890px; " >
<asp:LinkButton ID="lnkEdit" ForeColor="white"  runat="server" Text="[Edit]" 
onclick="lnkEdit_Click"></asp:LinkButton></font>
</td>
</tr>

<tr style="padding-top:8px;"><td>


<asp:Panel ID="pan1" Visible="false" runat="server">
<table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

<tr>
<td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Call type</b></td>
<td class="tdheaderI" width="18%" align="left"><asp:Label ID="lblCalltype" runat="server" ></asp:Label></td>
<td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>SLA</b></td>
<td class="tdheaderI" width="25%" align="left">
<asp:Label ID="lblSLA" runat="server" ></asp:Label>

</td>
</tr>
<tr>
<td >&nbsp;&nbsp;<b>Current Status</b></td>
<td  align="left"><asp:Label ID="lblStatus" runat="server" ></asp:Label></td>
<td >&nbsp;&nbsp;<b>Mode</b></td>
<td  align="left">
<asp:Label ID="lblMode" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td class="tdheaderI" >&nbsp;&nbsp;<b>Priority</b></td>
<td class="tdheaderI"  align="left"><asp:Label ID="lblPriority" runat="server" ></asp:Label></td>
<td class="tdheaderI" >&nbsp;&nbsp;<b>Technician</b></td>
<td class="tdheaderI"  align="left"><asp:Label ID="lblTechnician" runat="server" ></asp:Label>

</td>
</tr>
<tr>
<td >&nbsp;&nbsp;<b>Site</b></td>
<td  align="left"><asp:Label ID="lblSite" runat="server" ></asp:Label></td>
<td >&nbsp;&nbsp;<b>Department</b></td>
<td  align="left">
<asp:Label ID="lblDept" runat="server" ></asp:Label>
</td>
</tr> 
<tr>
<td  class="tdheaderI" >&nbsp;&nbsp;<b>Category</b></td>
<td class="tdheaderI" align="left"><asp:Label ID="lblCategory" runat="server" ></asp:Label></td>
<td class="tdheaderI" >&nbsp;&nbsp;<b>Sub Category</b></td>
<td class="tdheaderI"  align="left">
<asp:Label ID="lblSubCategory" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td >&nbsp;<b>Part Required from Vendor</b></td>
<td  align="left">
<asp:Label ID="lblVendor" runat="server"></asp:Label>
</td>
<td >&nbsp;&nbsp;<b>Asset Name</b></td>
<td  align="left"><asp:Label ID="lblExternalTicket" runat="server"></asp:Label></td>

</tr> 
<tr>
<td  class="tdheaderI">&nbsp;&nbsp;<b>Created By</b></td>
<td  class="tdheaderI"  align="left"><asp:Label ID="lblCreatedby" runat="server" ></asp:Label></td>
<td  class="tdheaderI" >&nbsp;&nbsp;<b>Created date</b></td>
<td  class="tdheaderI" align="left"><asp:Label ID="lblCreatedDate" runat="server" ></asp:Label>

</td>
</tr> 
<tr>
<td  >&nbsp;&nbsp;<b>Completed Date</b></td>
<td  align="left"><asp:Label ID="lblCompletedDate" runat="server" ></asp:Label></td>
<td  >&nbsp;&nbsp;<asp:Label ID="lbltimespentonDisp" runat="server" Visible="false" Font-Bold="true" Text="Time Spent on Req"></asp:Label></td>
<td  align="left">
<asp:Label ID="lbltimespentonreq" runat="server"></asp:Label>
</td>
</tr>




</table>
</asp:Panel> 
<asp:Panel ID="pan2" runat="server">
<table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

<tr>
<td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Call type</b></td>
<td class="tdheaderI" width="18%" align="left"><asp:DropDownList Width="170px" ID="drpRequestType" runat="server">
<asp:ListItem Text="--------Select Call Type-------" Value="0"></asp:ListItem>
<asp:ListItem Text="Request for information" Value="1"></asp:ListItem>
<asp:ListItem Text="Incident" Value="2"></asp:ListItem>
</asp:DropDownList></td>
<td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>SLA</b></td>
<td class="tdheaderI" width="25%" align="left">

<asp:Label ID="lblslaPanel2" runat="server" ></asp:Label>
</td>
</tr>
<tr>
<td >&nbsp;&nbsp;<b>Current Status</b></td>
<td  align="left"><asp:DropDownList ID="drpStatus" Width="170px" runat="server"  AutoPostBack="true"
onselectedindexchanged="drpStatus_SelectedIndexChanged">

</asp:DropDownList></td>
<td >&nbsp;&nbsp;<b>Mode</b></td>
<td  align="left">
<asp:DropDownList ID="drpMode" Width="170px" runat="server">
</asp:DropDownList>
</td>
</tr>
<tr>
<td  class="tdheaderI" >&nbsp;&nbsp;<b>Priority</b></td>
<td class="tdheaderI"  align="left"><asp:DropDownList ID="drpPriority" Width="170px" runat="server">

</asp:DropDownList></td>
<td class="tdheaderI" >&nbsp;&nbsp;<b>Technician</b></td>
<td class="tdheaderI"  align="left">
<asp:DropDownList ID="drpTechnician" Width="170px" runat="server">

</asp:DropDownList>
</td>
</tr>
<tr>
<td >&nbsp;&nbsp;<b>Site</b></td>
<td  align="left"><asp:DropDownList ID="drpSite" AutoPostBack="true" Width="170px" OnSelectedIndexChanged="drpSite_SelectedIndexChanged" runat="server" >

</asp:DropDownList></td>
<td >&nbsp;&nbsp;<b>Department</b></td>
<td  align="left">
<asp:DropDownList ID="drpDepartment" Width="170px" runat="server">

</asp:DropDownList>
</td>
</tr> 
<tr>
<td  class="tdheaderI" >&nbsp;&nbsp;<b>Category</b></td>
<td class="tdheaderI" align="left"> <asp:DropDownList ID="drpCategory" AutoPostBack="true" Width="170px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"  runat="server">

</asp:DropDownList></td>
<td class="tdheaderI" >&nbsp;&nbsp;<b>Sub Category</b></td>
<td class="tdheaderI"  align="left">
<asp:DropDownList ID="drpSubcategory" Width="170px" runat="server">

</asp:DropDownList>
</td>
</tr>
<tr>
<td>&nbsp;<b>Part Required from Vendor</b></td>
<td  align="left"><asp:DropDownList ID="drpVendor" AutoPostBack="true" 
Width="170px" runat="server" 
onselectedindexchanged="drpVendor_SelectedIndexChanged">

</asp:DropDownList>
&nbsp;
</td>
<td >&nbsp;&nbsp;<b>Asset Name</b></td>
<td  align="left"><asp:TextBox ID="txtExternalTicket" Width="165px" runat="server"></asp:TextBox>&nbsp; 
<asp:ImageButton ID="imgselectasset" CausesValidation="false" runat="server" ImageUrl="~/images/Searchlogo.jpg"
                                            OnClientClick="javascript:window.open('SelectAsset.aspx','popupwindow','width=770,height=590,left=380,top=230,Scrollbars=yes');" />
</td>
</tr> 
<tr>
<td class="tdheaderI">&nbsp;&nbsp;<b>Created By</b></td>
<td class="tdheaderI" align="left">
<asp:Label ID="lblCreatedbyPanel2" runat="server" ></asp:Label>
</td>
<td class="tdheaderI">&nbsp;&nbsp;<b>Created date</b></td>
<td class="tdheaderI" align="left"><asp:Label ID="lblCreateddatePanel2" runat="server" ></asp:Label>

</td>
</tr> 
    <tr>
        <td class="tdheaderI">
            &nbsp;</td>
        <td align="left" class="tdheaderI">
            &nbsp;</td>
        <td class="tdheaderI">
            &nbsp;</td>
        <td align="left" class="tdheaderI">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;&nbsp;<b>Completed Date</b></td>
        <td align="left" class="style1">
            <asp:Label ID="lblCompletedDatePanel2" runat="server"></asp:Label>
        </td>
        <td class="style1">
            &nbsp;&nbsp;<b>&nbsp;AMC Call</b></td>
        <td align="left" class="style1">
            <asp:DropDownList ID="drpAMCCall" runat="server" AutoPostBack="True" 
                Width="170px">
                <asp:ListItem>NO</asp:ListItem>
                <asp:ListItem>YES</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td align="left">
            &nbsp;</td>
    </tr>

</table>
</asp:Panel> 


</td></tr>

<tr><td>&nbsp;</td></tr>

<tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="10%">&nbsp;&nbsp;<b>Asset Details</b></td>
</tr>
<tr>
<td>
<table width="100%" align="center">
<tr>
<td width="10%">&nbsp;<b>Asset Id</b></td>
<td width="18%" align="left"><asp:Label ID="lblassetid" runat="server" ></asp:Label></td>
<td width="10%">&nbsp;<b>Computer Name</b></td>
<td width="25%" align="left">
<asp:Label ID="lblcompname" runat="server" ></asp:Label>
</td>
</tr>

<tr>
<td  class="tdheaderI" >&nbsp;&nbsp;<b>Domain Name</b></td>
<td class="tdheaderI"  align="left"><asp:Label ID="lbldomainname" runat="server" ></asp:Label></td>
<td class="tdheaderI" >
    <asp:LinkButton ID="LnkAttachment" runat="server" ForeColor="#336699" 
        onclick="LnkAttachment_Click">Show Attachment</asp:LinkButton>
    </td>
<td class="tdheaderI"  align="left">&nbsp;</td>
</tr>
</table>

</td>

</tr>


<%--<tr>
<td width="10%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;&nbsp;&nbsp;</td>
<td width="18%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left"></td>
<td width="10%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;
<asp:LinkButton 
ID="LinkButton2" ForeColor="white" Font-Bold="true" 
OnClientClick="javascript:window.open('incidentresolution.aspx','popupwindow','width=750,height=550,left=380,top=230,Scrollbars=yes');" 
runat="server" Text="Add Resolution" ></asp:LinkButton>


</td>
<td width="25%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"  align="left">
&nbsp;
</td>
</tr>--%>

<tr style="padding-top:4px;padding-bottom:4px;">
<td align="center">


<asp:Button ID="btnUpdate" runat="server" Visible="false" Text="Update" 
onclick="btnUpdate_Click" />&nbsp;&nbsp;
<asp:Button ID="btnCancel" runat="server" Visible="false"  Text=" Cancel " onclick="btnCancel_Click" />
</td>
</tr>

<tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;<asp:LinkButton  ID="lnkAddLog" ForeColor="white" Font-Bold="true" 
OnClientClick="javascript:window.open('incidentlog.aspx','popupwindow','width=500,height=240,left=500,top=300,Scrollbars=yes');" 
runat="server" Text="Add Note"  ></asp:LinkButton> </td>
</tr>  

<tr style="padding-top:6px;"><td>
<cc1:Accordion ID="Accordion2" runat="server" SelectedIndex="0"
HeaderCssClass="accordionHeader" 
FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
HeaderSelectedCssClass="accordionHeaderSelected">
<Panes>
<cc1:AccordionPane ID="AccordionPane1" runat="server">
<Header>
<table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">

<tr >
<td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" height="25px"  >&nbsp;&nbsp;<a href="#" ><strong><font color="white">Show  Notes </font> </strong></a></td>

</tr>


</table>

</Header>
<Content>
<table width="100%" align="center">
<tr><td><asp:Panel ID="panelNotes" BorderWidth="1" BorderColor=Silver   runat="server"><asp:PlaceHolder ID="PlaceHolderNotes" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
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

</td></tr>
</table>


</asp:Panel>

<asp:Panel ID="panelHistory" Visible="false" runat="server">

<table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
<tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;History of a Call</td></tr>
<tr style="padding-top:4px;"><td><asp:Panel ID="panDynamic" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolderHistory" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>


</table>


</asp:Panel>

<asp:Panel ID="pnlResolution" runat="server" Visible="false">
<table align="center" width="100%" cellpadding="0" cellspacing="0">
<tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;Add Resolution</td></tr>
<tr style="padding-top:10px;"><td align="left" style="padding-left:20px;" >
   
           <div  id="EditorPanel">
          
            <cc:HtmlEditor ID="Editor" runat="server" Height="300px" Width="600px" />&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="reqValEditor" runat="server" ControlToValidate="Editor" EnableClientScript="true" ErrorMessage="Enter Resolution"></asp:RequiredFieldValidator>
            </div>
       
    </td></tr>
    <tr><td align="left" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnResolution" OnClick="btnResolution_Click" runat="server" Text="Submit" 
            />  &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" /><asp:Button ID="btnrcaexport" runat="server" Text="Export To RCA" OnClick="btnrcaexport_Click" CausesValidation="false" /></td></tr>
            
   
 <tr style="padding-top:6px;"><td>
<cc1:Accordion ID="Accordion1" runat="server" SelectedIndex="0"
HeaderCssClass="accordionHeader" 
FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
HeaderSelectedCssClass="accordionHeaderSelected">
<Panes>
<cc1:AccordionPane ID="AccordionPane2" runat="server">
<Header>
<table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">

<tr >
<td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" height="25px"  >&nbsp;&nbsp;<a href="#" ><strong><font color="white">Show  Resolutions </font> </strong></a></td>

</tr>


</table>

</Header>
<Content>
<table width="100%" align="center">
<tr><td><asp:Panel ID="panel1" BorderWidth="1" BorderColor=Silver   runat="server"><asp:PlaceHolder ID="PlaceHolderResolution" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
</table>

</Content>

</cc1:AccordionPane>
</Panes>
</cc1:Accordion>

<cc1:Accordion ID="Accordion3" runat="server" SelectedIndex="0"
HeaderCssClass="accordionHeader" 
FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
HeaderSelectedCssClass="accordionHeaderSelected" >
<Panes>
<cc1:AccordionPane ID="AccordionPane3" runat="server">
<Header></Header>
<Content></Content>
</cc1:AccordionPane>
</Panes>
</cc1:Accordion>

</td></tr>

</table>
</asp:Panel>
</td>
</tr>
               
</table>
             
                 
             
</td>
</tr>

</table>
 
</ContentTemplate> 
<Triggers><asp:PostBackTrigger ControlID="LnkAttachment" />
 </Triggers>

</asp:UpdatePanel>

 





</asp:Content>

