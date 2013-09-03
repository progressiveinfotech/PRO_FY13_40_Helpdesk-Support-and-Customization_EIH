<%@ Page Language="C#" MasterPageFile="~/Master/MasterProblem.master" AutoEventWireup="true" CodeFile="EditProblem.aspx.cs" Inherits="Problem_EditProblem" Title="Untitled Page" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link type="text/css" href="../Include/section.css" rel="Stylesheet" />
<script language="javascript">
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
function Opencommentwindow()
{
//var Solutionid=document.getElementById("lblsolid");
 var label = document.getElementById("<%=lblProblemId.ClientID%>"); 


var url='ProblemNotes.aspx?problemid='+label.innerHTML;
 var width = 400;
    var height =240;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
function OpenNewWorkAroundwindow()
{

var label = document.getElementById("<%=lblProblemId.ClientID%>"); 
 
var url='../KEDB/SolutionandWorkaroundWindow.aspx?Solutionstatus=+1&problemid='+label.innerHTML;
 var width = 800;
    var height =550;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
function OpenNewSolutionwindow()
{

var label = document.getElementById("<%=lblProblemId.ClientID%>"); 
 
var url='../KEDB/SolutionandWorkaroundWindow.aspx?Solutionstatus=+2&problemid='+label.innerHTML;
 var width = 800;
    var height =550;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
function OpenEditSolutionwindow()
{

var label = document.getElementById("<%=lblProblemId.ClientID%>"); 
 
var url='../KEDB/SolutionandWorkaroundWindow.aspx?Solutionstatus=+3&problemid='+label.innerHTML;
 var width = 800;
    var height =550;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
function OpenEditWorkAroundwindow()
{

var label = document.getElementById("<%=lblProblemId.ClientID%>"); 
 
var url='../KEDB/SolutionandWorkaroundWindow.aspx?Solutionstatus=+4&problemid='+label.innerHTML;
 var width = 800;
    var height =550;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td colspan="5" align="right"><ul id="sddm">

<li style="padding-left:880px;"><asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ForeColor="Blue" ID="lnkProblem" Text="[Link To Change]" runat="server" Font-Underline="true"></asp:LinkButton> <div id="m1" onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
    
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkNewProblem" Text="[Create New Change]" runat="server"     Font-Underline="true" OnClick="lnkNewProblem_Click"></asp:LinkButton> 
        
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkExistProblem" Text="[Existing Change]" runat="server"   Font-Underline="true" OnClick="lnkExistProblem_Click"></asp:LinkButton> 
       
        </div></li>


 </ul></td>
</tr>

<tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;<b>Problem Id :</b>&nbsp;<asp:Label ID="lblProblemId" runat="server" Font-Bold="true" ForeColor="white"></asp:Label>
</td>
</tr>

<tr style="padding-bottom:6px;">
<td >
<asp:UpdatePanel ID="updatepanel3" runat="server">
<ContentTemplate>
<asp:ImageButton ID="imgproblem" CausesValidation="false" runat="server" 
ImageUrl="~/images/btnproblem2.bmp" Width="105px" Height="25px" onclick="imgproblem_Click" />
<asp:ImageButton ID="imganalysis" CausesValidation="false"  runat="server"  
ImageUrl="~/images/btnanalysis2.bmp" Width="105px" Height="25px" onclick="imganalysis_Click" />
<asp:ImageButton ID="imgSolution" CausesValidation="false" runat="server" 
ImageUrl="~/images/btnsolution2.bmp" Width="105px" Height="25px" onclick="imgSolution_Click" />
<asp:ImageButton ID="imgincident" CausesValidation="false" runat="server" 
ImageUrl="~/images/btnincident2.bmp" Width="105px" Height="25px" onclick="imgincident_Click" />
<asp:ImageButton ID="imghistory" CausesValidation="false" runat="server" 
ImageUrl="~/images/btnhistory2.bmp" Width="105px" Height="25px" onclick="imghistory_Click" />
</ContentTemplate> 
</asp:UpdatePanel> 
</td>
</tr>
<tr>
<td>
<table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">

<tr>
<td>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
            <ContentTemplate>
             <asp:Panel ID="panelProblem" runat="server" BorderWidth="0">
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
               
<tr>
<td>&nbsp;&nbsp;<b>Title :</b> <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Description :</b> <asp:Label ID="lblDescription" runat="server"></asp:Label> </td>
</tr>
 <tr>
<td >&nbsp;&nbsp;<b>Requested by :</b> <asp:Label ID="lblRequesterDisp" runat="server"> </asp:Label>&nbsp;<b> on  </b>&nbsp;<asp:Label ID="lblDateDisp" runat="server"></asp:Label>
 


</td>
</tr>

<tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;&nbsp; Problem Details
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
       <asp:LinkButton ID="lnkEdit" ForeColor="white"  runat="server" Text="[Edit]"  OnClick="lnkEdit_Click" ></asp:LinkButton> 
        </td>
</tr>

<tr style="padding-top:8px;"><td>


<asp:Panel ID="pan1" Visible="false" runat="server" BorderWidth="0">
<table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

   
 <tr>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Current Status</b></td>
    <td class="tdheaderI" align="left"><asp:Label ID="lblStatus" runat="server" ></asp:Label></td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Priority</b></td>
    <td class="tdheaderI"  align="left">
   <asp:Label ID="lblpriority" runat="server" ></asp:Label>
    </td>
 </tr>
<tr>
    <td>&nbsp;&nbsp;<b>Category</b></td>
    <td align="left"><asp:Label ID="lblcategory" runat="server" ></asp:Label></td>
    <td  >&nbsp;&nbsp;<b>Subcategory</b></td>
    <td  align="left"><asp:Label ID="lblsubcategory" runat="server" ></asp:Label>
  
    </td>
 </tr>
  <tr>
    
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Technician</b></td>
    <td class="tdheaderI" width="25%" align="left"> <asp:Label ID="lbltechid" runat="server" ></asp:Label>  </td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Created By</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblCreatedby" runat="server" ></asp:Label></td>
    

  
    </tr>

 <tr>
    
    <td >&nbsp;&nbsp;<b>Created date</b></td>
    <td   align="left"><asp:Label ID="lblCreatedDate" runat="server" ></asp:Label>
   
    </td>
    <td>&nbsp;&nbsp;<b>Completed Date</b></td>
    <td  align="left" ><asp:Label ID="lblCompletedDate" runat="server" ></asp:Label></td>
    </tr> 
 

    
</table>
</asp:Panel> 
<asp:Panel ID="panaleditproblem" runat="server">
<table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

   
    <tr>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Current Status</b></td>
    <td class="tdheaderI" align="left"><asp:DropDownList ID="drpStatus" Width="170px" runat="server"  AutoPostBack="true"   >
     
    </asp:DropDownList></td>
   
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Priority</b></td>
    <td class="tdheaderI"  align="left"><asp:DropDownList ID="drpPriority" Width="170px" runat="server">
     
    </asp:DropDownList></td>
 </tr>
    <tr>
    <td  >&nbsp;&nbsp;<b>Category</b></td>
    <td  align="left"> <asp:DropDownList ID="drpCategory" AutoPostBack="true" Width="170px" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged"  runat="server">
     
    </asp:DropDownList></td>
    <td  >&nbsp;&nbsp;<b>Sub Category</b></td>
    <td  align="left">
  <asp:DropDownList ID="drpSubcategory" Width="170px" runat="server">
    
    </asp:DropDownList>
    </td>
 </tr>
    <tr>
    
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Technician</b></td>
    <td class="tdheaderI" width="25%" align="left">
    <asp:DropDownList ID="drpTechnician" Width="170px" runat="server">
    
    </asp:DropDownList>

    </td>
    <td class="tdheaderI">&nbsp;&nbsp;<b>Created By</b></td>
    <td class="tdheaderI" align="left">
     <asp:Label ID="lblcreatedbyditproblem" runat="server" ></asp:Label>
    </td>
    </tr>
 
    <tr>
    
    <td >&nbsp;&nbsp;<b>Created date</b></td>
    <td  align="left"><asp:Label ID="lblCreateddateeditproblem" runat="server" ></asp:Label>
  
    </td>
    <td >&nbsp;&nbsp;<b>Completed Date</b></td>
    <td  align="left"><asp:Label ID="lblCompletedDateeditproblem" runat="server" ></asp:Label></td>
    </tr> 
   
 
 
 
</table>
</asp:Panel> 







</td></tr>
<tr style="padding-bottom:4px;padding-top:4px;">
<td align="center">
 <asp:Button ID="btnUpdate" runat="server" Visible="false" Text="Update" 
    OnClick="btnUpdate_Click"     />&nbsp;&nbsp;
 <asp:Button ID="btnCancel" runat="server" Visible="false"  Text=" Cancel " OnClick="lnkcancel_Click"  />
</td>
</tr>
<tr ><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;<strong><font color="white"><asp:LinkButton ID="lnknewwindow" runat="server" Text="Add Note" OnClick="lnknewwindow_Click" ForeColor="white"></asp:LinkButton></font> </strong></td></tr>
<tr><td> <cc1:Accordion ID="Accordion1" runat="server" SelectedIndex="0"
        HeaderCssClass="accordionHeader" 
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
        AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
        HeaderSelectedCssClass="accordionHeaderSelected">
        <Panes>
        <cc1:AccordionPane ID="AccordionPane2" runat="server">
       <Header>
      <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
     <tr><td>&nbsp;</td></tr>
    <tr>
    <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" height="25px"  >&nbsp;&nbsp;<a href="#" ><strong><font color="white">Show Log Note </font> </strong></a></td>
   
    </tr>

   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center">
             <tr><td>
  <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
              
                <tr><td><asp:Panel ID="Panel1" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
               
                
                </table>

</td></tr>
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
               
              <asp:Panel ID="panalanalysis" runat="server" BorderWidth="1">
              <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                
                <tr ><td  width="100%" >
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">Impact </td>
                <td background="../images/tdimg.bmp">&nbsp;</td>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"><asp:LinkButton ID="lnkimpadd" ForeColor="White" runat="server" text="ADD" OnClick="lnkimpadd_Click" ></asp:LinkButton>
                <asp:LinkButton ID="lnimpedit" runat="server" text="EDIT" OnClick="lnimpedit_Click"></asp:LinkButton>
                 </td>
                
                </tr></table>
                 
                
               
                </td>
                </tr>
                <tr><td ><asp:PlaceHolder ID="Placeholderimpact" runat="server" Visible="false"></asp:PlaceHolder> <cc:HtmlEditor ID="Editorimpact" runat="server" Height="300px" Width="900px" Visible= "false"  />  </td></tr>
                <tr><td > <asp:Button ID="btnsaveimpact"  runat="server" Text="Save" Visible="false" OnClick="btnsaveImpact_Click"/><asp:Button ID="btnupdateImpact"  runat="server" Text="Update" Visible="false" OnClick="btnupdateImpact_Click"/> <asp:Button ID="btncancellImpact"  runat="server" Text="Cancell" Visible="false" OnClick="btncancellimpact_Click"/>  </td></tr>
                <tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                 <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%"> RootCause </td>
                 <td>&nbsp;</td>
                
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"> <asp:LinkButton ID="lnkRootcauseadd" runat="server" ForeColor="White" text="ADD" OnClick="lnkRootcauseadd_Click"></asp:LinkButton>
                <asp:LinkButton ID="lnkRootcauseedit" runat="server" text="EDIT" OnClick="lnkRootcauseedit_Click"></asp:LinkButton>
                 </td>
                
                </tr></table>
                 </td></tr>
                
                <tr><td><asp:PlaceHolder ID="PlaceholderRootcause" runat="server" Visible="false"></asp:PlaceHolder><cc:HtmlEditor ID="EditorRootcause" runat="server" Height="300px" Width="900px" Visible="false" /> </td></tr>
                <tr><td ><asp:Button ID="btnsaveRootcause"  runat="server" Text="Save" Visible="false" OnClick="btnsaveRootcause_Click"/><asp:Button ID="btnupdateRootcause"  runat="server" Text="Update" Visible="false" OnClick="btnupdateRootcause_Click"/> <asp:Button ID="btncancellRootcause"  runat="server" Text="Cancell" Visible="false" OnClick="btncancellRootcause_Click"/>  </td></tr>
                
                <tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"> 
                
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%"> Symptom  </td>
                 <td>&nbsp;</td>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"><asp:LinkButton ID="lnksymptomadd" runat="server" ForeColor="White" text="ADD" OnClick="lnksymptomadd_Click"></asp:LinkButton>
                <asp:LinkButton ID="lnksymptomedit" runat="server" text="EDIT" OnClick="lnksymptomedit_Click"></asp:LinkButton>
                 </td>
               
                </tr></table>
                
                </td></tr>
                <tr><td><asp:PlaceHolder ID="PlaceholderSymtom" runat="server" Visible="false"></asp:PlaceHolder> <cc:HtmlEditor ID="Editorsymptom" runat="server" Height="300px" Width="900px" Visible= "false"  /> </td></tr>
                <tr><td > <asp:Button ID="btnsaveSymtom"  runat="server" Text="Save" Visible="false" OnClick="btnsaveSymtom_Click"/><asp:Button ID="btnupdatesymptom"  runat="server" Text="Update" Visible="false" OnClick="btnupdatesymptom_Click"/> <asp:Button ID="btncancellSymptom"  runat="server" Text="Cancell" Visible="false" OnClick="btncancellSymptom_Click"/>  </td></tr>
                
                
                </table>
             
             </asp:Panel>
             <asp:Panel ID="panalsolution" runat="server" BorderWidth="1">
              <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                
                <tr><td class="tdheader" width="100%" >
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"  width="20%">&nbsp;WorkAround </td>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;</td>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" ><asp:LinkButton ID="lnkwrkaround" runat="server" ForeColor="White" text="ADD" OnClick="lnkwrkaround_Click" ></asp:LinkButton>
                <asp:LinkButton ID="lnkwrkedit" runat="server" text="EDIT" ForeColor="White" OnClick="lnkwrkedit_Click" ></asp:LinkButton>
                 </td>
                
                </tr></table>
                 
                
               
                </td>
                </tr>
                <tr><td ><asp:PlaceHolder ID="PlaceHolderWrkaround" runat="server" Visible="false"></asp:PlaceHolder>   </td></tr>
                <tr><td > </td></tr>
                <tr><td class="tdheader">
                 <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">&nbsp;Solution </td>
                 <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;</td>
                
                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"> <asp:LinkButton ID="lnkSolutionadd" runat="server" ForeColor="White" text="ADD" OnClick="lnkSolutionadd_Click" ></asp:LinkButton>
                <asp:LinkButton ID="lnkSolutionedit" runat="server" text="EDIT" ForeColor="White" OnClick="lnkSolutionedit_Click" ></asp:LinkButton>
                 </td>
                
                </tr></table>
                 </td></tr>
                
                <tr><td><asp:PlaceHolder ID="PlaceHolderSolution" runat="server" Visible="false"></asp:PlaceHolder> </td></tr>
                <tr><td ></td></tr>
                
               
                
                </table>
             
             </asp:Panel>
             <asp:Panel ID="panelincidentproblem" Visible="false" runat="server" BorderWidth="1">
               <table align="center" border="0" cellpadding="0" width="100%" cellspacing="0">
              <tr>
                 <td align="center">
                   <asp:GridView ID="grdvwincidentproblem" runat="server"  CssClass="grid-view"  OnRowDataBound="grdvwincidentproblem_RowDataBound" OnRowEditing="grdvwincidentproblem_RowEditing"   OnPageIndexChanging="grdvwincidentproblem_PageIndexChanging"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="1"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="0" 
          
           PageSize="10" AllowPaging="true" Width="100%">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
            
           <asp:BoundField HeaderText="IncidentID" DataField="ID" ReadOnly="true" />  
         <asp:BoundField HeaderText="title" DataField="title" ReadOnly="true" />
         <asp:BoundField HeaderText="Requested By" DataField="requesterid" ReadOnly="true"  />
          <asp:BoundField HeaderText="Assigned to" DataField="requesterid" ReadOnly="true"  />
            
           
            <asp:BoundField HeaderText="Status" DataField="requesterid" ReadOnly="true"  />
          
            <asp:BoundField HeaderText="CreatedDate" DataField="createdatetime" ReadOnly="true"  />
            <asp:CommandField ShowEditButton="True" HeaderText="View Details" EditText="View Details" CausesValidation="false"   />
        
    </Columns>
 <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
 <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
<HeaderStyle  BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
<AlternatingRowStyle  BackColor="Silver" />
 </asp:GridView>
        </td>
</tr>
<tr><td>

 


</td></tr>

               
               </table>
               <asp:Panel ID="panelRequest" runat="server">
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;




<asp:LinkButton ID="lnkclose" runat="server"  ForeColor="White" Text="Close" OnClick="lnkclose_Click"></asp:LinkButton>

 


</td>

</tr>
<tr>
<td>&nbsp;&nbsp;<b>Title :</b> <asp:Label ID="lblrequesttitle" runat="server"></asp:Label></td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Description :</b> <asp:Label ID="lblrequestdescription" runat="server"></asp:Label> </td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Requested by :</b> <asp:Label ID="lblproblemtorequest" runat="server"> </asp:Label>&nbsp; on : &nbsp;<asp:Label ID="lblrequestdatedisp" runat="server"></asp:Label></td>
</tr>
<tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;Call Details
   <font style="padding-left:890px; " >
       </font>
        </td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr><td>


<asp:Panel ID="panalrequestinfo" Visible="false" runat="server">
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
    <td  align="left"><asp:Label ID="lblrequeststatus" runat="server" ></asp:Label></td>
    <td >&nbsp;&nbsp;<b>Mode</b></td>
    <td  align="left">
   <asp:Label ID="lblMode" runat="server" ></asp:Label>
    </td>
 </tr>
<tr>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Priority</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblincidentPriority" runat="server" ></asp:Label></td>
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
    <td class="tdheaderI" align="left"><asp:Label ID="lblincidentCategory" runat="server" ></asp:Label></td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Sub Category</b></td>
    <td class="tdheaderI"  align="left">
   <asp:Label ID="lblincidentSubCategory" runat="server" ></asp:Label>
    </td>
 </tr>
  <tr>
  <td >&nbsp;<b>Part Required from Vendor</b></td>
    <td  align="left">
 <asp:Label ID="lblVendor" runat="server"></asp:Label>
    </td>
    <td >&nbsp;&nbsp;<b>External Ticket No</b></td>
    <td  align="left"><asp:Label ID="lblExternalTicket" runat="server"></asp:Label></td>
   
    </tr> 
 <tr>
    <td  class="tdheaderI">&nbsp;&nbsp;<b>Created By</b></td>
    <td  class="tdheaderI"  align="left"><asp:Label ID="lblrequestby" runat="server" ></asp:Label></td>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Created date</b></td>
    <td  class="tdheaderI" align="left"><asp:Label ID="lblrequestdate" runat="server" ></asp:Label>
   
    </td>
    </tr> 
    <tr>
    <td  >&nbsp;&nbsp;<b>Completed Date</b></td>
    <td  align="left"><asp:Label ID="lblrequestcompleteddate" runat="server" ></asp:Label></td>
    <td  >&nbsp;&nbsp;<asp:Label ID="lblrequesttimespentonDisp" runat="server" Visible="false" Font-Bold="true" Text="Time Spent on Req"></asp:Label></td>
    <td  align="left">
   <asp:Label ID="lblspenttimeonreq" runat="server"></asp:Label>
    </td>
 </tr>

   
   <%--  <tr>
    <td >&nbsp;&nbsp;</td>
    <td  align="left">&nbsp;</td>
    <td>&nbsp;</td>
    <td align="left">
  &nbsp;
    </td>
    </tr> --%>
</table>
</asp:Panel> 



</td></tr>

<%--<tr height="15px">
<td align="center">
 <asp:Button ID="Button1" runat="server" Visible="false" Text="Update" 
        onclick="btnUpdate_Click" />&nbsp;&nbsp;
 <asp:Button ID="Button2" runat="server" Visible="false"  Text=" Cancel " onclick="btnCancel_Click" />
</td>
</tr>--%>


                </table>
                
                
                    </asp:Panel>
            
                    </asp:Panel>
                    <asp:Panel ID="panelHistory" Visible="false" runat="server">
                <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp; History of Problem</td> </tr>
                <tr><td><asp:Panel ID="panDynamic" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolderHistory" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
               
                </table>
                
                    </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel></td>
</tr>

</table>
</td>
</tr>





</table>
</asp:Content>

