<%@ Page Language="C#" MasterPageFile="~/Master/MasterReports.master" AutoEventWireup="true" CodeFile="csmolddata.aspx.cs" Inherits="admin_csmolddata" Title="Untitled Page" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
<script language="JavaScript"   type="text/javascript">
    function dateValidation() {

        var obj = document.getElementById("<%=TextBox1.ClientID%>");

        var jsDay = obj.value.split("/")[0];
        var jsMonth = obj.value.split("/")[1];
        var jsYear = obj.value.split("/")[2];

        var finaldate = new Date(jsYear, jsMonth - 1, jsDay);
        var today = new Date();

        if (jsDay != "") {

            if (jsDay != finaldate.getDate()) {

                alert('Day is not valid!');
                return false;
            }
        }





        if (jsYear < 1900) {
            alert('Year must be greater than 1900.');
            return false;
        }



        if (finaldate == 'undefined') {
            alert("you have entered invalid date!");
            return false;
        }



        var obj1 = document.getElementById("<%=TextBox2.ClientID%>");

        var jsDay1 = obj1.value.split("/")[0];
        var jsMonth1 = obj1.value.split("/")[1];
        var jsYear1 = obj1.value.split("/")[2];

        var finaldate1 = new Date(jsYear1, jsMonth1 - 1, jsDay1);
        var today1 = new Date();

        if (jsDay1 != "") {
            if (jsDay1 != finaldate1.getDate()) {
                alert('Day is not valid!');
                return false;
            }
        }





        if (jsYear1 < 1900) {
            alert('Year must be greater than 1900.');
            return false;
        }



        if (finaldate1 == 'undefined') {
            alert("you have entered invalid date!");
            return false;
        }


    }

       

   
            
    </script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left"   cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
   
     <tr>
        <td colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" >
           &nbsp;&nbsp;&nbsp;&nbsp;Select Filter
        </td>
       
            
    </tr>
     <tr><td>&nbsp;</td></tr>
     <tr>
     <td>
     <table width="100%" align="center"   cellpadding="0" cellspacing="0" border="0">
     <tr>
     <td width="15%"><asp:Label ID="filter" runat="server" Text="Select Filter"></asp:Label></td>
     <td width="23%"><asp:DropDownList  ID="drpFilter"  runat="server" width="150px" OnSelectedIndexChanged="drpFilter_SelectedIndexChanged" AutoPostBack="true" >
    <asp:ListItem Text="-------------Select-------------" Value="0"></asp:ListItem>
    <asp:ListItem Text="Ticketid" Value="1"></asp:ListItem>
    <asp:ListItem Text="Complaint Date" Value="2"></asp:ListItem>
   
    </asp:DropDownList>
    </td>
      <td width="28%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     
      </td>
       <td width="34%">&nbsp;&nbsp;&nbsp;&nbsp;</td>
     
     </tr>
    <tr>
     <td width="15%"><asp:Label ID="Label1" Enabled="false" runat="server" Text="Enter Ticket"></asp:Label></td>
     <td width="23%"> <asp:TextBox ID="txtticket" Enabled="false" runat="server" ></asp:TextBox>
    
                         
    </td>
      <td width="18%">
      
      </td>
       <td width="24%">&nbsp;</td>
     
     </tr>
     
     <tr>
     <td width="15%"><asp:Label ID="LabelFrom"  Enabled="false" runat="server" Text="From"></asp:Label></td>
     <td width="23%"> 
     <asp:TextBox ID="TextBox1" Height="17px" Enabled="false"  runat="server" ToolTip="DD/MM/YYYY" Width="145px"  MaxLength="10"></asp:TextBox>
      <img id="img1"    style="vertical-align:top;"  onclick="scwShow(document.getElementById('<%=TextBox1.ClientID%>'),this);" src="../images/cal.gif" alt="date"/>
                         
    </td>
      <td width="18%">
      <asp:Label ID="Labelto"  Enabled="false" runat="server" Text="To"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" Height="17px"  Enabled="false" Width="145px" runat="server" ToolTip="DD/MM/YYYY"  MaxLength="10"></asp:TextBox><img id="img2" style="vertical-align:top;"  onclick="scwShow(document.getElementById('<%=TextBox2.ClientID%>'),this);" src="../images/cal.gif" alt="date"/>
      </td>
       <td width="24%"></td>
     
     </tr>
    
     
    &nbsp;
     </td>
     <td>
     <%--&nbsp;&nbsp;&nbsp;From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" Height="17px" runat="server" ToolTip="DD/MM/YYYY" Width="145px"  MaxLength="10"></asp:TextBox>
                         <img id="img1" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox1.ClientID%>'),this);" src="../images/cal.gif" alt="date"/>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   --%>
     
     </td>
     <td>
    <%-- &nbsp;&nbsp;&nbsp;&nbsp;To &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="TextBox2" Height="17px" Width="145px" runat="server" ToolTip="DD/MM/YYYY"  MaxLength="10"></asp:TextBox>
                         <img id="img2" style="vertical-align:top;" onclick="scwShow(document.getElementById('<%=TextBox2.ClientID%>'),this);" src="../images/cal.gif" alt="date"/>--%>
                         
                    
     </td>
     </tr>
     </table>
     
     </td>
     
     </tr>
     
   
    
    <tr><td colspan="5" valign="top">
    
     
                         
    
    
    </td></tr>

   
   
      <tr>
    <td >&nbsp; </td>
    </tr>
     <tr>
       
        <td colspan="5" background="../images/tdimg.bmp" align="left" >
            &nbsp;&nbsp;<asp:Button ID="btnShow" runat="server" Text="&nbsp;&nbsp;Show&nbsp;&nbsp;" 
            OnClientClick="return dateValidation();"  CausesValidation="false" 
                onclick="btnShow_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnExcel" runat="server" Text="Export to Excel" 
                onclick="btnExcel_Click"  />
            
            </td>
            
    </tr>
   
     
   
       <tr><td>&nbsp;</td></tr>
    

    <tr><td align="center"  colspan="5">
    
   <asp:GridView ID="grdvwRequest" runat="server"  CssClass="grid-view"
                          
            AutoGenerateColumns="False" CellPadding="0" ForeColor="Black"  CellSpacing="1"
            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE"  BorderStyle="None" BorderWidth="0px" 
           OnPageIndexChanging="grdvwRequest_PageIndexChanging" 
           PageSize="20" AllowPaging="true" Width="984px">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="white"/>
     <Columns>
    
           
            <asp:BoundField HeaderText="Call No"  DataField="CallNo" ReadOnly="true" />
            
            <asp:BoundField HeaderText="Location"  DataField="Location" ReadOnly="true" />
            <asp:BoundField HeaderText="log Date"  DataField="LogDate" ReadOnly="true" />
             <asp:BoundField HeaderText="log time"  DataField="Logtime" ReadOnly="true" />
            <asp:BoundField HeaderText="User"  DataField="user" ReadOnly="true" />
            <asp:BoundField HeaderText="Problem Description"  DataField="ProblemDesc" ReadOnly="true" />
            <asp:BoundField HeaderText="Call Type"  DataField="CallType" ReadOnly="true" />
            <asp:BoundField HeaderText="Severity Level"  DataField="Severitylevel" ReadOnly="true" />
            <asp:BoundField HeaderText="Engineer"  DataField="Engineer" ReadOnly="true" />
            <asp:BoundField HeaderText="Closed Date"  DataField="Closeddate" ReadOnly="true" />
               <asp:BoundField HeaderText="Closed Time"  DataField="ClosedTime" ReadOnly="true" />
             <asp:BoundField HeaderText="Resolution Time"  DataField="ResolutionTimeinMinutes" ReadOnly="true" />
             <asp:BoundField HeaderText="Call Status"  DataField="CallStatus" ReadOnly="true" />
             <asp:BoundField HeaderText="SLA Met"  DataField="SLAType" ReadOnly="true" />
            
            
            
            
            
         <%--<asp:CommandField ShowEditButton="True" HeaderText="View Details"  EditText="View Details" CausesValidation="false"   />--%>
         

     

    </Columns>
    <EmptyDataTemplate >
 <table  cellpadding="1" cellspacing="1" width="100%" >
<tr>

<td class="tdheader" > Complaint id </td><td class="tdheader"> Customer Name </td><td class="tdheader">Description</td><td class="tdheader">Complaint Date</td>

</tr>
<tr>

<td></td>
<td>No record Found</td>
<td> </td>
<td></td>


</tr>


</table>
</EmptyDataTemplate>
    
    <PagerStyle  BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle   BackColor="#999999" Font-Bold="True" ForeColor="White" />
    <HeaderStyle  BackColor="#E1E1E1E1"  Font-Bold="True" ForeColor="Black" />
    </asp:GridView>
    
    </td></tr>
    <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
    </table>

</asp:Content>

