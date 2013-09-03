<%@ Page Language="C#" MasterPageFile="~/Master/MasterKedb.master" AutoEventWireup="true" CodeFile="ViewSolution.aspx.cs" Inherits="KEDB_ViewSolution" Title="View Solution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../Include/section.css" rel="Stylesheet" />
<script language="javascript" type="text/javascript">

function EndRequestHandler()
{
alert("Fire Javascript");
}
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

var Solutionid=document.getElementById("lblsolutionid");
//var url='ApproveActions.aspx?statusaction=+1&solutionid='+Solutionid;
var url='ApproveActions.aspx?statusaction=1&flag=3'
 var width = 400;
    var height =240;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "fullscreen=no,width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
function OpenNewRejectwindow()
{

// Solutionid=document.getElementById("lblsolutionid");
var url='ApproveActions.aspx?statusaction=2&flag=3'

 var width = 400;
    var height =240;
    var left = parseInt((screen.availWidth/2) - (width/2));
    var top = parseInt((screen.availHeight/2) - (height/2));
 var windowFeatures = "width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;    

          
window.open(url, 'popupwindow',windowFeatures );
}
</script>
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

    <style type="text/css">
        .style1
        {
            height: 22px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td><asp:UpdatePanel ID="AddSolution1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel></td></tr>
 <tr><td>

    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td colspan="5"  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
            &nbsp;Solution</td>
            </tr> 
           
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left"  valign="top" valign="middle" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
        
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>
         
           &nbsp;Search &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtsearch"  runat="server" Height="21px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnsearch" OnClick="btnsearch_Click" Text="Search Solution" runat="server" 
                Height="23px" Width="172px"/>   
            &nbsp;&nbsp; 
            </ContentTemplate>
</asp:UpdatePanel>  
        </td>
        
       
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" valign="top" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
<ContentTemplate>
        <font class="mandatory"></font>&nbsp;Filter
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="drpfilter" runat="server" OnSelectedIndexChanged="drpfilter_SelectedIndexChanged" AutoPostBack="true">
          <asp:ListItem Text="All" Value="3"></asp:ListItem>
           <asp:ListItem Text="UnApproved" Value="0"></asp:ListItem>
           <asp:ListItem Text="Approved" Value="1"></asp:ListItem>
           <asp:ListItem Text="Rejected" Value="2"></asp:ListItem>
        </asp:DropDownList>
       </ContentTemplate>
</asp:UpdatePanel> </td></tr>
 <tr>
        <td align="left" valign="top"  >
        <ul id="sddm">
 <li><%--<asp:LinkButton ID="lnkEdit" runat="server" Text="New Solution" onclick="lnkEdit_Click" onmouseover="mopen('m1')" onmouseout="mclosetime()" Font-Underline="true" ></asp:LinkButton>--%></li>
 
        <li><asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkApprovesection" Text="Approve Section" runat="server" Font-Underline="true"></asp:LinkButton> <div id="m1" onmouseover="mcancelclosetime()" onmouseout="mclosetime()">
    
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkapprovesolution" Text="Approve Solution" runat="server" Font-Underline="true"   OnClick="lnkapprovesolution_Click"></asp:LinkButton> 
        
        <asp:LinkButton onmouseover="mopen('m1')" onmouseout="mclosetime()" ID="lnkrejectsolution" Text="Reject Solution" runat="server" Font-Underline="true"  OnClick="lnkrejectsolution_Click"></asp:LinkButton> 
       
        </div></li>
        <li><%--<asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" onclick="lnkdelete_Click" onmouseover="mopen('m1')" onmouseout="mclosetime()" Font-Underline="true" ></asp:LinkButton>--%></li>
        </ul>
        
        
        </td></tr>
    
       
   <tr><td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:Repeater ID="rptPages" Runat="server" >
      <HeaderTemplate>
      <table cellpadding="0" cellspacing="0" border="0">
      <tr class="text">
         <td><b>Page:</b>&nbsp;</td>
         <td>
      </HeaderTemplate>
      <ItemTemplate>
         
           <asp:LinkButton ID="btnpage" CommandName="Page" CommandArgument="<%#Container.DataItem %>" Runat="server" ><%# Container.DataItem %></asp:LinkButton>           
                         &nbsp;
      </ItemTemplate>
      <FooterTemplate>
         </td>
      </tr>
      </table>
      </FooterTemplate>
      </asp:Repeater>
</ContentTemplate>
</asp:UpdatePanel></td></tr> 
      
     
               
         
           
    
       
  
    <tr><td> <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <asp:Repeater ID="Repeter" runat="server"  OnItemDataBound="Repeter_ItemDataBound" >
    
    <HeaderTemplate>
    <table border="1" cellpadding="0" cellspacing="0" width="1000px" >
    <tr  align="center" >
    <td width="100px">
       <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server"  />
    </td>
    <td width="100px"><b>SolutionId</b>
    </td>
    <td width="800px" align="left"><b>Subject</b>
    </td> 
     <td width="100px"><b>Approve Status</b>
    </td> 
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr align="center">
    <td width="100px"  align="center">
    
    
      <asp:Label ID="SiteID" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "solutionid") %>'
    runat="server" />
    <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                           runat="server" />
   
    </td>
    <td width="100px"  align="center">
    
   
   
    <asp:Label ID="lblsolutionid" runat="server" Visible="false"  Text='<%# Eval("solutionid")%>'></asp:Label>
  <font style="color:black; font-family: Verdana; font-size:small; font-style:normal; font-weight: bold";> 
  <a href="EditSolution.aspx?<%# Eval("solutionid")%>"><%# Eval("solutionid")%></a></font><br>
    
    </td>
    <td width="800px%" align="left"><font style="color:#003366; font-family:Verdana; font-size:Small; font-style:normal; font-weight:bold;"><a href="EditSolution.aspx?<%# Eval("solutionid")%>"><%# Eval("title")%></a></font><br>
  <font style="color:Black; font-size:small; font-family:Verdana; font-weight: bold">Topic:</font> 
  <font style="color:Black; font-size:Small; font-weight:bold; font-family:Verdana"> 
  <asp:label ID="lbltopicid" runat="server" Text='<%# Eval("Topicid")%>' visible="false" ></asp:label></font><br>
  <font style="color:Black; font-size:small; font-family:Verdana; font-weight: bold">Type:</font> 
  <font style="color:Black; font-size:Small; font-weight:bold; font-family:Verdana"> 
  <asp:label ID="Label1" runat="server" Text='<%# Eval("Solution")%>'  ></asp:label></font><br>
  <font style="color: Black; font-family:Verdana; font-size:small "></font> <%# Eval("Content")%></td>
    <td width="100px%">
    <table width="100%" align="left" >
        <tr>
         <td valign="top" width="20%" >
         <asp:Label ID="lblapprove" runat="server" Text="Approve" Font-Bold="true"></asp:Label>
         </td>
         <td valign="middle" width="20%" align="left"> 
         <asp:Image id ="Imgunapproved" runat="server"  ImageUrl="~/images/red1.bmp" BackColor="Silver" />
         <asp:Image ID="imgapprove" runat="server"  ImageUrl="~/images/green1.bmp" BackColor="Silver" />
         </td>
         </tr>
      </table>
      </td>
    </tr>	
   
   
    </ItemTemplate> 
   <AlternatingItemTemplate><div style="background-color:silver;">

	 <tr align="center">
	 <td width="100px"  align="center">
    
    <%--<asp:Label ID="lblsolutionid" runat="server" Visible="true" Text='<%# Eval("solutionid")%>'></asp:Label>--%>
     <asp:Label ID="SiteID" Visible="false" 
    Text='<%# DataBinder.Eval (Container.DataItem, "solutionid") %>'
    runat="server" />
    <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );"
                                           runat="server" />
   
    </td><td width="100px" style="background-color:Silver;" align="center">
	 <%--<asp:Label ID="lblsolutionid" runat="server" Visible="true" Text='<%# Eval("solutionid")%>'></asp:Label>--%>
	<asp:Label ID="lblsolutionid" runat="server" Visible="false" Text='<%# Eval("solutionid")%>'></asp:Label>
    <font style="color:black; font-family:Verdana; font-size:small"><a href="EditSolution.aspx?<%# Eval("solutionid")%>"> <%# Eval("solutionid")%></a></font><br>
    
    </td>
    <td width="800px%" align="left" background-color:Silver;">
    <font style="color:#003366; font-family:Verdana; font-size:Small; font-style:normal; font-weight:bold;">
    <a href="EditSolution.aspx?<%# Eval("solutionid")%>"><%# Eval("title")%></a>
    </font>
    <br>
    <font style="color:Black; font-size:small; font-family:Verdana; font-weight: bold">Topic:</font> 
    <font style="color:Black; font-size:Small; font-weight:bold; font-family:Verdana"> 
    <asp:label ID="lbltopicid" runat="server" Text='<%# Eval("Topicid")%>' visible="false" ></asp:label>
    </font>
    <br>
    <font style="color:Black; font-size:small; font-family:Verdana; font-weight: bold">Type:</font> 
  <font style="color:Black; font-size:Small; font-weight:bold; font-family:Verdana"> 
  <asp:label ID="Label1" runat="server" Text='<%# Eval("Solution")%>'  ></asp:label></font><br>
    <font style="color: Black; font-family:Verdana; font-size:small "></font> <%# Eval("Content")%>
    </td>
   <td width="100px%" style="background-color:Silver;">
    <table width="100%" align="left" >
         <tr>
         <td valign="top" width="20%" align="left" >
            <asp:Label ID="lblapprove" runat="server" Text="Approve" Font-Bold="true"></asp:Label>
         </td>
         <td valign="middle" width="20%" align="left" > 
            <asp:Image id ="Imgunapproved" runat="server"  ImageUrl="~/images/red.bmp" BackColor="Silver" />
            <asp:Image ID="imgapprove" runat="server"  ImageUrl="~/images/green.bmp" BackColor="Silver"  />
         </td>
         </tr>
    </table>
    </td>
    </tr>	
	</div>	
</AlternatingItemTemplate>
  <FooterTemplate> 
 </table>            
 </FooterTemplate></asp:Repeater></ContentTemplate>
</asp:UpdatePanel></td></tr>
    
    
      

</table>


 </td></tr></table>



</asp:Content>

