<%@ Page Language="C#" MasterPageFile="~/Master/MasterChange.master" AutoEventWireup="true" CodeFile="EditChange.aspx.cs" Inherits="Change_EditChange" Title="Untitled Page" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" language="javascript">
function Opencommentwindow()
{
//var Solutionid=document.getElementById("lblsolid");
 var label = document.getElementById("<%=lblchangeid.ClientID%>"); 


var url='ChangeNotes.aspx?changeid='+label.innerHTML;
 var width = 400;
    var height =240;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
function OpenNewTaskWindow()
{
var label = document.getElementById("<%=lblchangeid.ClientID%>"); 

var url='InsertChangeTask.aspx?changeid='+label.innerHTML;


 var width = 600;
    var height =340;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
</script>
    <style type="text/css">
        .style1
        {
            width: 426px;
        }
        .style2
        {
            background-color: Silver;
            height: 20px;
            width: 426px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;
</td>
</tr>
<tr><td>

&nbsp;&nbsp;<b>Change Id :</b>&nbsp;<asp:Label ID="lblchangeid" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label></td></tr>
<tr>
<td >
<asp:UpdatePanel ID="updatepanel3" runat="server">
<ContentTemplate>
<asp:ImageButton ID="imgchange" CausesValidation="false" runat="server" ImageUrl="~/images/btnchange2.bmp"  Width="105px" Height="25px" onclick="imgchange_Click" 
        />

<asp:ImageButton ID="imgProblems" CausesValidation="false" runat="server" ImageUrl="~/images/btnproblem2.bmp" Width="105px" Height="25px" onclick="imgProblems_Click" />
       
       <asp:ImageButton ID="imgincident" CausesValidation="false" runat="server" ImageUrl="~/images/btnincident2.bmp" Width="105px" Height="25px" onclick="imgincident_Click" 
       />
       <asp:ImageButton ID="imganalysis" CausesValidation="false"  runat="server"  ImageUrl="~/images/btnanalysis2.bmp" Width="105px" Height="25px" onclick="imganalysis_Click" 
       />
        <asp:ImageButton ID="imgimplementation" CausesValidation="false"  runat="server"  ImageUrl="~/images/btnimplemetation2.bmp" Width="105px" Height="25px"  onclick="imgimplementation_Click" 
       />
       
       <asp:ImageButton ID="imghistory" CausesValidation="false" runat="server" ImageUrl="~/images/btnhistory2.bmp" Width="105px" Height="25px" onclick="imghistory_Click"
       />
</ContentTemplate> 
</asp:UpdatePanel> 
</td>
</tr>
<tr>
<td>
<table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
<%--<tr>
<td colspan="5" align="right"><ul id="sddm">

<li style="padding-left:880px;"><asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ForeColor="Blue" ID="lnkProblem" Text="[Link To Problem]" runat="server" Font-Underline="true"></asp:LinkButton> <div id="m1" onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
    
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkNewProblem" Text="[Create New Problem]" runat="server"     Font-Underline="true"></asp:LinkButton> 
        
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkExistProblem" Text="[Existing Problem]" runat="server"   Font-Underline="true"></asp:LinkButton> 
       
        </div></li>


 </ul></td>
</tr>--%>

<tr>
<td>
   <asp:UpdatePanel ID="updatepanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="panelchange" runat="server" BorderWidth="1">
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;Requested by -  <asp:Label ID="lblRequesterDisp" runat="server"> </asp:Label>&nbsp; on : &nbsp;<asp:Label ID="lblDateDisp" runat="server"></asp:Label>
 


</td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Title :</b> <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Solution Details :</b> <asp:Label ID="lblDescription" runat="server"></asp:Label> </td>
</tr>


      <tr>
<td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >&nbsp;&nbsp;Change Details<font style="padding-left:790px; " >
<asp:LinkButton ID="lnkEdit" ForeColor="white"  runat="server" Text="[Edit]" 
onclick="lnkEdit_Click"></asp:LinkButton></font>
</td>
</tr>




<tr style="padding-top:8px;"><td>

<asp:Panel ID="pan1" Visible="false" runat="server" BorderWidth="0">
        <table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

   <%-- <tr>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Technician</b></td>
    <td class="tdheaderI" width="18%" align="left"><asp:Label ID="lbltechid" runat="server" ></asp:Label></td>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Service Effected</b></td>
    <td class="tdheaderI" width="25%" align="left">
     <asp:Label ID="lblserviceeffected" runat="server" ></asp:Label>

    </td>
    </tr>--%>
 <tr>
 <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Current Status</b></td>
    <td class="tdheaderI" width="18%" align="left"><asp:Label ID="lblStatus" runat="server" ></asp:Label></td>
    <%--<td >&nbsp;&nbsp;<b>Current Status</b></td>
    <td  align="left" class="style1"><asp:Label ID="lblStatus" runat="server" ></asp:Label></td>--%>
    <%--<td >&nbsp;&nbsp;<b>Priority</b></td>
    <td  align="left">
   <asp:Label ID="lblpriority" runat="server" ></asp:Label>
    </td>--%>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Service Effected</b></td>
    <td class="tdheaderI" width="25%" align="left">
     <asp:Label ID="lblserviceeffected" runat="server" ></asp:Label>
 </tr>
<tr>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Category</b></td>
    <td class="style2"  align="left"><asp:Label ID="lblcategory" runat="server" ></asp:Label></td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Subcategory</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblsubcategory" runat="server" ></asp:Label>
  
    </td>
 </tr>
 <tr>
    <td >&nbsp;&nbsp;<b>Change Type</b></td>
    <td   align="left" class="style1"><asp:Label ID="lblchangetype" runat="server" ></asp:Label></td>
    <td>&nbsp;&nbsp;<b>Created By</b></td>
    <td align="left"><asp:Label ID="lblCreatedby" runat="server" ></asp:Label>
   
    </td>
    </tr> 

 <tr>
    <td  class="tdheaderI">&nbsp;&nbsp;<b>Created date</b></td>
    <td class="style2"  align="left"><asp:Label ID="lblCreatedDate" runat="server" ></asp:Label></td>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Completed Date</b></td>
    <td  class="tdheaderI" align="left"><asp:Label ID="lblCompletedDate" runat="server" ></asp:Label>
   
    </td>
    </tr> 
    
    <tr>
    <td  >&nbsp;&nbsp;<b>Asset Involved</b></td>
    <td  align="left" class="style1" ><asp:ListBox ID="lstAsset" runat="server" Width="200px" Height="50px"></asp:ListBox></td>
    <td  >&nbsp;&nbsp;<asp:Label ID="lbltimespentonDisp" runat="server" Visible="false" Font-Bold="true" Text="Time Spent on Req"></asp:Label></td>
    <td  align="left">
   <asp:Label ID="lbltimespentonreq" runat="server"></asp:Label>
    </td>
 </tr>

    
</table>
</asp:Panel> 


<asp:Panel ID="panaleditchange" runat="server">
<table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

    <%--<tr>--%>
    <%--<td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Technician</b></td>
    <td class="tdheaderI" width="18%" align="left"><asp:DropDownList ID="drpTechnician" Width="170px" runat="server">
    
    </asp:DropDownList></td>--%>
   <%-- <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Service Effected</b></td>
    <td class="tdheaderI" width="25%" align="left">
    <asp:Label ID="lblchangeserviceeffected" runat="server" ></asp:Label>

    </td>--%>
    <%--</tr>--%>
    <tr>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Current Status</b></td>
    <td class="tdheaderI" width="18%" align="left"><asp:DropDownList ID="drpStatus" Width="170px" runat="server"  AutoPostBack="true" >
    
    <%--<td >&nbsp;&nbsp;<b>Current Status</b></td>
    <td  align="left"><asp:DropDownList ID="drpStatus" Width="170px" runat="server"  AutoPostBack="true"   >--%>
     
    </asp:DropDownList></td>
     <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Service Effected</b></td>
    <td class="tdheaderI" width="25%" align="left">
     <asp:DropDownList ID="drpserviceeffect"  Width="170px"  runat="server" >
     </asp:DropDownList>
    <%--<asp:Label ID="lblchangeserviceeffected" runat="server" ></asp:Label>--%>

    </td>
   
    <%--<td  >&nbsp;&nbsp;<b>Priority</b></td>
    <td   align="left"><asp:DropDownList ID="drpPriority" Width="170px" runat="server">
     
    </asp:DropDownList></td>--%>
 </tr>


 <tr>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Category</b></td>
    <td class="tdheaderI" align="left"> <asp:DropDownList ID="drpCategory" AutoPostBack="true" Width="170px"  runat="server" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
     
    </asp:DropDownList></td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Sub Category</b></td>
    <td class="tdheaderI"  align="left">
  <asp:DropDownList ID="drpSubcategory" Width="170px" runat="server"  >
    
    </asp:DropDownList>
    </td>
 </tr>
 <tr>
    <td >&nbsp;&nbsp;<b>Change Type</b></td>
    <td   align="left"><asp:DropDownList ID="drpchangetype" runat="server"></asp:DropDownList></td>
    <td>&nbsp;&nbsp;<b>Created By</b></td>
    <td align="left"><asp:Label ID="lblcreatedbyuser" runat="server" ></asp:Label>
   
    </td>
    </tr> 
 <tr>
    <td class="tdheaderI">&nbsp;&nbsp;<b>Created date</b></td>
    <td  align="left" class="tdheaderI">
     <asp:Label ID="lblcreatedchangedate" runat="server" ></asp:Label>
    </td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b></b>CompletedDate</td>
    <td  align="left" class="tdheaderI"><asp:Label ID="lblchangecompleteddate" runat="server" ></asp:Label>
  
    </td>
    </tr> 
    <tr>
    <td >&nbsp;&nbsp;<b>Asset Involved</b></td>
    <td   align="left"><asp:ListBox ID="lstassetupdate" runat="server" Width="200px" Height="50px" ></asp:ListBox><asp:LinkButton ID="lnkopennewwindow" Text="[Select Asset]" runat="server" OnClick="lnkopennewwindow_Click"></asp:LinkButton></td>
    <td  >&nbsp;&nbsp;<b>&nbsp;</b></td>
    <td   align="left">
   &nbsp;
    </td>
 </tr>
 
 
 <%--  <tr>
    <td >&nbsp;&nbsp;</td>
    <td  align="left">&nbsp;</td>
    <td>&nbsp;</td>
    <td align="left">
  &nbsp;
    </td>
    </tr>--%>
</table>
</asp:Panel> 




</td></tr>
<tr>
<td align="center">
 <asp:Button ID="btnUpdate" runat="server" Visible="false" Text="Update" onclick="btnUpdate_Click"
        />&nbsp;&nbsp;
 <asp:Button ID="btnCancel" runat="server" Visible="false"  Text=" Cancel " OnClick="btnCancel_Click"  />
</td>
</tr>
<tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;<strong><font color="#0066cc"><asp:LinkButton ID="lnknewwindow" runat="server" Text="Add Note" OnClick="lnknewwindow_Click" ForeColor="White"></asp:LinkButton></font> </strong></td></tr>
<tr><td> <cc1:Accordion ID="Accordion1" runat="server" SelectedIndex="0"
        HeaderCssClass="accordionHeader" 
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
        AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
        HeaderSelectedCssClass="accordionHeaderSelected">
        <Panes>
        <cc1:AccordionPane ID="AccordionPane2" runat="server">
       <Header>
      <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
     
    <tr>
    <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" height="25px"  >&nbsp;&nbsp;<a href="#" ><strong><font color="White">Show Log Note </font> </strong></a></td>
   
    </tr>

   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center">
             <tr><td>
  <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
              
                <tr><td><asp:Panel ID="Panel1" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
               
                 <tr>
    <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" height="25px" >&nbsp;</td>
   
    </tr>
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
<tr><td>
  <%-- <cc1:Accordion ID="Accordion2" runat="server" SelectedIndex="0"
        HeaderCssClass="accordionHeader" 
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
        AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
        HeaderSelectedCssClass="accordionHeaderSelected">
        <Panes>
        <cc1:AccordionPane ID="AccordionPane1" runat="server">
       <Header>
      <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
     
    <tr>
    <td  class="tdheader" height="25px"  >&nbsp;&nbsp;<a href="#" ><strong><font color="#0066cc">Show History of a Call </font> </strong></a></td>
   
    </tr>

   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center">
             <tr><td>
  <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
              
                <tr><td><asp:Panel ID="panDynamic" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolderHistory" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
               
                 <tr>
    <td  class="tdheader" height="25px" ></td>
   
    </tr>
                </table>

</td></tr>
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
       </cc1:Accordion>--%>

</td></tr>
                </table>
                
                
                    </asp:Panel>
                <asp:Panel ID="panelincidentchange" Visible="false" runat="server" BorderWidth="1">
               <table align="center" border="0" cellpadding="0" width="100%" cellspacing="0">
              <tr>
<td align="center">
<asp:GridView ID="grdvwincidentchange" runat="server"  CssClass="grid-view"  OnRowDataBound="grdvwincidentchange_RowDataBound" OnRowEditing="grdvwincidentchange_RowEditing"   OnPageIndexChanging="grdvwincidentchange_PageIndexChanging"
                          
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
    <EmptyDataTemplate >
 <table  cellpadding="1" cellspacing="1" width="100%" >
<tr>
<td class="tdheader" > IncidentID </td><td class="tdheader"> title </td><td class="tdheader">Requested By</td><td class="tdheader">Assigned to</td><td class="tdheader">Status</td><td class="tdheader">CreatedDate</td>

</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td> No record Found</td>
<td></td>
<td></td>



</tr>


</table>
</EmptyDataTemplate>
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
<td class="tdheader">&nbsp;&nbsp;Requested by -  <asp:Label ID="lblproblemtorequest" runat="server"> </asp:Label>&nbsp; on : &nbsp;<asp:Label ID="lblrequestdatedisp" runat="server"></asp:Label>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;



<asp:LinkButton ID="lnkclose" runat="server"  Text="Close" OnClick="lnkclose_Click"></asp:LinkButton>

 


</td>

</tr>
<tr>
<td>&nbsp;&nbsp;<b>Title :</b> <asp:Label ID="lblrequesttitle" runat="server"></asp:Label></td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Description :</b> <asp:Label ID="lblrequestdescription" runat="server"></asp:Label> </td>
</tr>

<tr>
<td class="tdheader" >&nbsp;&nbsp;Call Details
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
                <asp:Panel ID="panalproblemchange" Visible="false" runat="server" BorderWidth="1">
               <table align="center" border="0" cellpadding="0" width="100%" cellspacing="0">
              <tr>
<td align="center">
<asp:GridView ID="grdvwproblemchange" runat="server"  CssClass="grid-view"  OnRowDataBound="grdvwproblemchange_RowDataBound" OnRowEditing="grdvwproblemchange_RowEditing"   OnPageIndexChanging="grdvwproblemchange_PageIndexChanging"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="1"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="0" 
          
           PageSize="10" AllowPaging="true" Width="100%">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
            
           <asp:BoundField HeaderText="ProblemID" DataField="ID" ReadOnly="true" />  
         <asp:BoundField HeaderText="title" DataField="title" ReadOnly="true" />
         <asp:BoundField HeaderText="Requested By" DataField="Requesterid" ReadOnly="true"  />
          <asp:BoundField HeaderText="Assigned to" DataField="Technicianid" ReadOnly="true"  />
            
           
            <asp:BoundField HeaderText="Status" DataField="Statusid" ReadOnly="true"  />
          
            <asp:BoundField HeaderText="CreatedDate" DataField="CreateDatetime" ReadOnly="true"  />
            <asp:CommandField ShowEditButton="True" HeaderText="View Details" EditText="View Details" CausesValidation="false"   />
        
    </Columns>
      <EmptyDataTemplate >
 <table  cellpadding="1" cellspacing="1" width="100%" >
<tr>
<td class="tdheader" > ProblemID </td><td class="tdheader"> title </td><td class="tdheader">Requested By</td><td class="tdheader">Assigned to</td><td class="tdheader">Status</td><td class="tdheader">CreatedDate</td>

</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td> No record Found</td>
<td></td>
<td></td>



</tr>


</table>
</EmptyDataTemplate>
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
               <asp:Panel ID="panelshowproblemchange" runat="server" BorderWidth="1">
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
<td class="tdheader">&nbsp;&nbsp;Requested by -  <asp:Label ID="lblproblemrequestedby" runat="server"> </asp:Label>&nbsp; on : &nbsp;<asp:Label ID="lblproblemcreateddate" runat="server"></asp:Label>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkproblemclose" runat="server"  Text="Close" OnClick="lnkproblemclose_Click"></asp:LinkButton>


</td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Title :</b> <asp:Label ID="lblproblemtitle" runat="server"></asp:Label></td>
</tr>
<tr>
<td>&nbsp;&nbsp;<b>Description :</b> <asp:Label ID="lblproblemdescription" runat="server"></asp:Label> </td>
</tr>

<tr>
<td class="tdheader" >&nbsp;&nbsp;Problem Details
   <font style="padding-left:890px; " >

        </td>
</tr>
<tr><td>&nbsp;</td></tr>
<tr><td>


<asp:Panel ID="panalprobleminfo" Visible="false" runat="server" BorderWidth="0">
<table align="center" width="100%" cellpadding="2" cellspacing="1" border="0">

    <tr>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Service Effected</b></td>
    <td class="tdheaderI" width="18%" align="left"><asp:Label ID="lblproblemserviceeffected" runat="server" ></asp:Label></td>
    <td class="tdheaderI" width="10%">&nbsp;&nbsp;<b>Technician</b></td>
    <td class="tdheaderI" width="25%" align="left">
     <asp:Label ID="lblproblemtechnician" runat="server" ></asp:Label>

    </td>
    </tr>
 <tr>
    <td >&nbsp;&nbsp;<b>Current Status</b></td>
    <td  align="left"><asp:Label ID="lblproblemstatus" runat="server" ></asp:Label></td>
    <td >&nbsp;&nbsp;<b>Priority</b></td>
    <td  align="left">
   <asp:Label ID="lblproblempriority" runat="server" ></asp:Label>
    </td>
 </tr>
<tr>
    <td  class="tdheaderI" >&nbsp;&nbsp;<b>Category</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblproblemcategory" runat="server" ></asp:Label></td>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Subcategory</b></td>
    <td class="tdheaderI"  align="left"><asp:Label ID="lblproblemsubcategory" runat="server" ></asp:Label>
  
    </td>
 </tr>

 <tr>
    <td  >&nbsp;&nbsp;<b>Created By</b></td>
    <td   align="left"><asp:Label ID="lblproblemcreatedby" runat="server" ></asp:Label></td>
    <td   >&nbsp;&nbsp;<b>Created date</b></td>
    <td   align="left"><asp:Label ID="lblproblemcreateddate1" runat="server" ></asp:Label>
   
    </td>
    </tr> 
    <tr>
    <td class="tdheaderI" >&nbsp;&nbsp;<b>Completed Date</b></td>
    <td  align="left" class="tdheaderI"><asp:Label ID="lblproblemcompletedate" runat="server" ></asp:Label></td>
    <td  class="tdheaderI">&nbsp;&nbsp;<asp:Label ID="lblproblemtimespent" runat="server" Visible="false" Font-Bold="true" Text="Time Spent on Req"></asp:Label></td>
    <td  align="left"class="tdheaderI" >
   <asp:Label ID="Label15" runat="server"></asp:Label>
    </td>
 </tr>

    
</table>
</asp:Panel> 








</td></tr>
<tr>
<td align="center">
 <asp:Button ID="Button1" runat="server" Visible="false" Text="Update" 
    OnClick="btnUpdate_Click"     />&nbsp;&nbsp;
 <asp:Button ID="Button2" runat="server" Visible="false"  Text=" Cancel "  />
</td>
</tr>
<tr><td class="tdheader">&nbsp;&nbsp;<strong><font color="#0066cc"></font> </strong></td></tr>

<tr><td>
  <%-- <cc1:Accordion ID="Accordion2" runat="server" SelectedIndex="0"
        HeaderCssClass="accordionHeader" 
        FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250"
        AutoSize="none" Height="425px"  RequireOpenedPane="false" SuppressHeaderPostbacks="true" 
        HeaderSelectedCssClass="accordionHeaderSelected">
        <Panes>
        <cc1:AccordionPane ID="AccordionPane1" runat="server">
       <Header>
      <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
     
    <tr>
    <td  class="tdheader" height="25px"  >&nbsp;&nbsp;<a href="#" ><strong><font color="#0066cc">Show History of a Call </font> </strong></a></td>
   
    </tr>

   
    </table>
       
        </Header>
       <Content>
       <table width="100%" align="center">
             <tr><td>
  <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
              
                <tr><td><asp:Panel ID="panDynamic" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolderHistory" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
               
                 <tr>
    <td  class="tdheader" height="25px" ></td>
   
    </tr>
                </table>

</td></tr>
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
       </cc1:Accordion>--%>

</td></tr>
                </table>
                
                
                    </asp:Panel> 
            
                    </asp:Panel>
                <asp:Panel ID="panalanalysis" runat="server" BorderWidth="1">
              <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                
                <tr><td class="tdheader" width="100%" >
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td class="tdheader" width="20%">Impact </td>
                <td>&nbsp;</td>
                <td class="tdheader"><asp:LinkButton ID="lnkimpadd" runat="server" text="ADD" OnClick="lnkimpadd_Click" ></asp:LinkButton>
                <asp:LinkButton ID="lnimpedit" runat="server" text="EDIT" OnClick="lnimpedit_Click"></asp:LinkButton>
                 </td>
                
                </tr></table>
                 
                
               
                </td>
                </tr>
                <tr><td ><asp:PlaceHolder ID="Placeholderimpact" runat="server" Visible="false"></asp:PlaceHolder> <cc:HtmlEditor ID="Editorimpact" runat="server" Height="300px" Width="900px" Visible= "false"  />  </td></tr>
                <tr><td > <asp:Button ID="btnsaveimpact"  runat="server" Text="Save" Visible="false" OnClick="btnsaveImpact_Click"/><asp:Button ID="btnupdateImpact"  runat="server" Text="Update" Visible="false" OnClick="btnupdateImpact_Click"/> <asp:Button ID="btncancellImpact"  runat="server" Text="Cancell" Visible="false" OnClick="btncancellimpact_Click"/>  </td></tr>
                <tr><td class="tdheader">
                 <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td class="tdheader" width="20%"> RollOutPlan </td>
                 <td>&nbsp;</td>
                
                <td class="tdheader"> <asp:LinkButton ID="lnkRollOutPlanadd" runat="server" text="ADD" OnClick="lnkRollOutPlanadd_Click" ></asp:LinkButton>
                <asp:LinkButton ID="lnkRollOutPlanedit" runat="server" text="EDIT" OnClick="lnkRollOutPlanedit_Click"  ></asp:LinkButton>
                 </td>
                
                </tr></table>
                 </td></tr>
                
                <tr><td><asp:PlaceHolder ID="PlaceholderRollOutPlan" runat="server" Visible="false"></asp:PlaceHolder><cc:HtmlEditor ID="EditorRollOutPlan" runat="server" Height="300px" Width="900px" Visible="false" /> </td></tr>
                <tr><td ><asp:Button ID="btnsaveRollOutPlan"  runat="server" Text="Save" Visible="false" OnClick="btnsaveRollOutPlan_Click"  /><asp:Button ID="btnupdateRollOutPlan"  runat="server" Text="Update" Visible="false" OnClick="btnupdateRollOutPlan_Click"  /> <asp:Button ID="btncancellRollOutPlan"  runat="server" Text="Cancell" Visible="false" OnClick="btncancellRollOutPlan_Click" />  </td></tr>
                
                <tr><td class="tdheader"> 
                
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td class="tdheader" width="20%"> BackOutPlan  </td>
                 <td>&nbsp;</td>
                <td class="tdheader"><asp:LinkButton ID="lnkBackOutPlanadd" runat="server" text="ADD" OnClick="lnkBackOutPlanadd_Click" ></asp:LinkButton>
                <asp:LinkButton ID="lnkBackOutPlanedit" runat="server" text="EDIT" OnClick="lnkBackOutPlanedit_Click" ></asp:LinkButton>
                 </td>
               
                </tr></table>
                
                </td></tr>
                <tr><td><asp:PlaceHolder ID="PlaceholderBackOutPlan" runat="server" Visible="false"></asp:PlaceHolder> <cc:HtmlEditor ID="EditorBackOutPlan" runat="server" Height="300px" Width="900px" Visible= "false"  /> </td></tr>
                <tr><td > <asp:Button ID="btnsaveBackOutPlan"  runat="server" Text="Save" Visible="false" OnClick="btnsaveBackOutPlan_Click"/><asp:Button ID="btnupdateBackOutPlan"  runat="server" Text="Update" Visible="false"  OnClick="btnupdateBackOutPlan_Click"/> <asp:Button ID="btncancellBackOutPlan"  runat="server" Text="Cancell" Visible="false" OnClick="btncancellBackOutPlan_Click" />  </td></tr>
                
                
                </table>
             
             </asp:Panel>  
                <asp:Panel ID="panalimplementation" Visible="false" runat="server" BorderWidth="1">
               <table align="center" border="0" cellpadding="0" width="100%" cellspacing="0">
            <tr><td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" height="25px">&nbsp;&nbsp;Task Details</td></tr>
            <tr><td>&nbsp;&nbsp;<asp:LinkButton ID="lnknewtask" runat="server" Text="New Task" OnClick="lnknewtask_Click"></asp:LinkButton></td></tr>
              <tr>
<td align="center">
<asp:GridView ID="grdvwimplementation" runat="server"  CssClass="grid-view" OnRowDataBound="grdvwimplementation_RowDataBound"   OnRowEditing="grdvwimplementation_RowEdit"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="1"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="0" 
          
           PageSize="10" AllowPaging="true" Width="100%">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
<%--             <asp:HyperLinkField  HeaderText="TaskId" DataTextField="TaskId"  
           DataNavigateUrlFields="TaskId"  datanavigateurlformatstring= />--%>
                     <asp:BoundField HeaderText="TaskId" DataField="Taskid" ReadOnly="true" /> 
         <asp:BoundField HeaderText="Title" DataField="Title" ReadOnly="true" />
         <asp:BoundField HeaderText="Scheduled Start Time" DataField="Scheduledstarttime" ReadOnly="true"  />
          <asp:BoundField HeaderText="Scheduled End Time" DataField="Scheduledendtime" ReadOnly="true"  />
            
           
            <asp:BoundField HeaderText="Status" DataField="Taskstatusid" ReadOnly="true"  />
          
            <asp:BoundField HeaderText="Assigned" DataField="Ownerid" ReadOnly="true"  />
           <asp:CommandField  HeaderText="Click" CausesValidation="false" ShowEditButton="true" EditText="Click"  />
        
    </Columns>
      <EmptyDataTemplate >
 <table  cellpadding="1" cellspacing="1" width="100%" >
<tr>
<td class="tdheader" > TaskId</td><td class="tdheader"> title </td><td class="tdheader">Scheduled Start Time</td><td class="tdheader">Scheduled End Time</td><td class="tdheader">Assigned to</td><td class="tdheader">Status</td>

</tr>
<tr>
<td></td>
<td></td>
<td></td>
<td> No record Found</td>
<td></td>
<td></td>



</tr>


</table>
</EmptyDataTemplate>
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
               
            
                    </asp:Panel>
                <asp:Panel ID="panelHistory" Visible="false" runat="server">
                <table align="center" width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr><td class="tdheader">&nbsp; History of Problem</td> </tr>
                <tr><td><asp:Panel ID="panDynamic" BorderWidth="1" BorderColor="Black"  runat="server"><asp:PlaceHolder ID="PlaceHolderHistory" runat="server"></asp:PlaceHolder></asp:Panel></td></tr>
               
                </table>
                
                    </asp:Panel>
                 </ContentTemplate>
        </asp:UpdatePanel>
             
           </td>
</tr>

</table>
</td>
</tr>





</table>
</asp:Content>

