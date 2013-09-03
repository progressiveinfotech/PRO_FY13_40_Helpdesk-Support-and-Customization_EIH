<%@ Page Language="C#" MasterPageFile="~/Master/MasterKedb.master" AutoEventWireup="true" CodeFile="EditSolution.aspx.cs" Inherits="KEDB_EditSolution" Title="it Solution" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link type="text/css" href="../Include/section.css" rel="Stylesheet" />
<script language="javascript">
var timeout	= 500;
var closetimer	= 0;
var ddmenuitem	= 0;

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
}

// go close timer
function mclosetime()
{
	closetimer = window.setTimeout(mclose, timeout);
}

// cancel close timer
function mcancelclosetime()
{
	if(closetimer)
	{
		window.clearTimeout(closetimer);
		closetimer = null;
	}
}

// close layer when click-out
document.onclick = mclose; 
function OpenNewApprovewindow()
{

var Solutionid=document.getElementById("lblsolid");
 var label = document.getElementById("<%=lblsolid.ClientID%>"); 
var url='ApproveActions.aspx?statusaction=+1&solutionid='+label.innerHTML;
 var width = 400;
    var height =240;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
function OpenNewRejectwindow()
{

var Solutionid=document.getElementById("lblsolid");
 var label = document.getElementById("<%=lblsolid.ClientID%>"); 
var url='ApproveActions.aspx?statusaction=+2&solutionid='+label.innerHTML;
 var width = 400;
    var height =240;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">

 <tr><td><asp:UpdatePanel ID="AddSolution1" runat="server">
 <ContentTemplate>
 <asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label>
 </ContentTemplate>
 </asp:UpdatePanel>
 </td></tr>


    
    <tr>
    <td>
    

     <table width="100%" align="left" cellpadding="2" cellspacing="1" border="1">
     <tr>
        <td  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
        <table width="100%"><tr><td width="50%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"> &nbsp;<asp:Label ID="solheader" runat="server" Text="Solution"></asp:Label> <asp:Label ID="editsolheader" runat="server" Text="Edit Solution"></asp:Label></td>
        
        <td width="50%" align="right"  > <asp:UpdatePanel ID="UpdatePanel3" runat="server">
 <ContentTemplate>
 <asp:LinkButton ID="lnkback" runat="server" ForeColor="White" Font-Bold="true" Text="[Back]" Font-Underline="false" 
                onclick="lnkback_Click"></asp:LinkButton>&nbsp;
 </ContentTemplate>
 </asp:UpdatePanel></td></tr></table>
           
                     
  </td>   
            
    </tr>
    <tr><td>
   
<ul id="sddm">
 <li><asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" onclick="lnkEdit_Click" onmouseover="mopen('m1')" onmouseout="mclosetime()" Font-Underline="true" ></asp:LinkButton></li>
 
        <li><asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkApprovesection" Text="Approve Section" runat="server" Font-Underline="true"></asp:LinkButton> <div id="m1"onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
    <%--    <asp:UpdatePanel id="ApproveActions" runat="server">
    <ContentTemplate>--%>
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkapprovesolution" Text="Approve Solution" runat="server" Font-Underline="true" OnClientClick="Javascript:OpenNewApprovewindow();" ></asp:LinkButton> 
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkrejectsolution" Text="Reject Solution" runat="server" Font-Underline="true" OnClientClick="Javascript:OpenNewRejectwindow();"></asp:LinkButton> 
       
        </div></li></ul>

            
        
        </td>    
    </tr>
         
     <tr>
     <td>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
   
     <asp:Panel ID="panShowdata" runat="server" ForeColor="#B5AFF3">
     <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0" >
     <tr>
     <td width="75%" height="20%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" valign="top">
         <asp:Label ID ="lbltitle" runat="server" ForeColor="White" Font-Bold="True" 
             Font-Names="Arial" Font-Size="Small"></asp:Label></td>
       
        <td width="25%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">&nbsp;SolutionId&nbsp;&nbsp;:&nbsp;<asp:Label ID ="lblsolid" runat="server" ForeColor="white" 
             Font-Bold="True" Font-Names="Arial" valign="middle"></asp:Label></td></tr>
       <tr>
       
       <td width="75%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" valign="center">
       Topic:<asp:Label ID ="lbltopic" runat="server" Font-Bold="True" 
             Font-Names="Arial" Font-Size="Small" ForeColor="white"></asp:Label></td>
             
         
         <td width="25%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left" valign="top" >
         <table width="100%" align="left">
         <tr>
         <td valign="top" width="20%"><asp:Label ID="lblstatus" Text="Status&nbsp;:" ForeColor="White" Font-Bold="true" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblapprove" runat="server"  ForeColor="White" Font-Bold="true"></asp:Label>  </td>
         <td valign="top" align="left">
         <asp:Image id ="Imgunapproved" runat="server"  ImageUrl="~/images/red.bmp" BackColor="Silver" />
         <asp:Image ID="imgapprove" runat="server"  ImageUrl="~/images/green.bmp" BackColor="Silver" /> 
         </td>
         </tr>
         </table>
         
            
       
         </td>
         
     </tr>
     <tr><td style=" background-color:Silver"></td></tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
     
     <td width="75%" style="font-family:Arial; font-size:medium">
     <asp:Label ID ="lblcontent" runat="server"></asp:Label></td>
     </tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td></td></tr>
     <tr>
     
     <td width="75%"></td>
     <td width="25%"></td>
     </tr>
    <tr><td style=" background-color:Silver"></td></tr>
     <tr>
    
     <td width="75%"><table border="1" cellspacing="1" cellpadding="1" width="100%"><tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width="20%">Keyword</td><td width="80%"><asp:Label ID ="lblkeyword" runat="server"></asp:Label></td></tr></table></td>
       <td width="25%"></td>
     </tr>
   <tr><td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">Solution Details:</td>
  
   </tr>
   <tr><td>
   <table width="100%">
   <tr>
   <td  width="25%">CreatedBy</td>
   <td  width="25%"><asp:Label ID="lblcreatedby" runat="server"></asp:Label></td>
   <td  width="25%">CreatedOn</td>
   <td  width="25%"><asp:Label ID="lblcreatedon" runat="server"></asp:Label></td>
   </tr>
   <tr><td class="tdheader" width="25%">LastUpdatedBy</td>
   <td class="tdheader" width="25%"><asp:Label ID="lbllastupdate" runat="server"></asp:Label></td>
   <td class="tdheader" width="25%">LastUpdatedOn</td>
   <td class="tdheader" width="25%"><asp:Label ID="lbllastupdateon" runat="server"> </asp:Label></td>
   </tr>
   
   
   </table>
   </td>
  
   </tr>
     </table></asp:Panel>
     
       <asp:Panel ID="panEditData"   runat="server">
      
        <table width="75%" align="left" cellpadding="0" cellspacing="0" border="0">
        
    <tr>
        <td align="left" class="tdsubheading" valign="top">
        <font class="mandatory">*</font>Title
        </td>
        <td >
         
         <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" TextMode="MultiLine" Width="594" Height="30px"></asp:TextBox> &nbsp;
         <asp:RequiredFieldValidator ID="reqValTitle" runat="server" ControlToValidate="txtTitle" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> 
         
            
        </td>
       
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp;Content  
        </td>
        <td >
          <div id="EditorPanel">
          
            <cc:HtmlEditor ID="Editor" runat="server" Height="300px" Width="600px" BackColor="Black" Font-Size="Smaller"/>
            </div>
        </td>
        
    </tr>
     <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp; Topic  
        </td>
        <td  >
         <asp:DropDownList ID="drpTopic" runat="server"></asp:DropDownList>
        
        </td>
        
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp;Keywords
        </td>
        <td  >
         <asp:TextBox ID="txtKeywords" runat="server" MaxLength="50" TextMode="MultiLine" Width="594px" Height="30px"></asp:TextBox>
        
        </td>
        
    </tr>
      
      <tr><td>&nbsp;</td></tr>
  
    <tr>
      
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" colspan="5" align="left" style="padding-left:70px;">

             <asp:Button ID="btnUpdate" runat="server"  Text="Update"  OnClick="btnUpdate_Click"/>      
           <asp:Button ID="btnCancel" Text="Cancel"  runat="server" OnClick="btnCancel_Click" />  
               
               
         
           
    
        </td>
    </tr>
         </table> 
       
       
       </asp:Panel>

</ContentTemplate>
</asp:UpdatePanel> 
     </td>
     </tr>
   
       </table> 
    
    </td>
    </tr>
    

    
   
   <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
        
   
   



 </table>




</asp:Content>

