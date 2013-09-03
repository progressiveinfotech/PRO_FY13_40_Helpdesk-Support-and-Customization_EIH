<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchSolution.aspx.cs" Inherits="Incident_SearchSolution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
     <table width="100%" align="left" cellpadding="0" cellspacing="0" border="1">
      <tr><td>&nbsp;</td></tr>
    <tr>
        <td colspan="5"  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
            &nbsp;Solution</td>
     </tr> 
           
   
     <tr><td>&nbsp;</td></tr>
    
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
     <tr><td>&nbsp;</td></tr>
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
  <asp:Label ID="Label2" runat="server"   Text='<%# Eval("solutionid")%>'></asp:Label>
 <%-- <a href="EditSolution.aspx?<%# Eval("solutionid")%>"><%# Eval("solutionid")%></a>--%></font><br>
    
    </td>
    <td width="800px%" align="left"><font style="color:#003366; font-family:Verdana; font-size:Small; font-style:normal; font-weight:bold;"> <asp:Label ID="Label3" runat="server"   Text='<%# Eval("title")%>'></asp:Label><%--<a href="EditSolution.aspx?<%# Eval("solutionid")%>"><%# Eval("title")%></a>--%></font><br>
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
 <tr><td>&nbsp;</td></tr>
      <tr>
        <td colspan="5" align="center"  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
            <asp:Button ID="btnClose" runat="server" Text="close" 
                 onclick="btnClose_Click" /></td>
     </tr> 
    </table> 
    
   
    </div>
    </form>
</body>
</html>
