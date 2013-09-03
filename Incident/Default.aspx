<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="helpdesk_Default" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<meta http-equiv="refresh" content="30"/>

    <script language="javascript" type="text/javascript" src="../JScript/scw.js"></script>
     
    <style type="text/css">
        .divModalBackground
        {
            filter: alpha(opacity=50);
            -moz-opacity: 0.5;
            opacity: 0.5;
            width: 100%;
            height: 100%;
            background-color: #999988;
            position: absolute;
            z-index: 800;
        }
    </style>

    <script language="JavaScript" type="text/javascript">
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
        .loading-indicator
        {
            font-size: 8pt;
            background-image: url(../images/loading.gif);
            background-repeat: no-repeat;
            background-position: top left;
            padding-left: 20px;
            height: 73px;
            text-align: left;
        }
        #loading
        {
            position: absolute;
            left: 45%;
            top: 50%;
            border: 3px solid #B2D0F7;
            background: white url(../images/loading.gif) repeat-x;
            padding: 10px;
            font: bold 14px verdana,tahoma,helvetica;
            color: #003366;
            width: 180px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Add Loader by vishal 23-05-2012--%>
    <%-- <asp:UpdatePanel ID="ResultsUpdatePanel" runat="server">
            <ContentTemplate>
                 <div id="loading" style="text-align: center;" class="loading-indicator">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="ResultsUpdatePanel"
                        DynamicLayout="true">
                        <ProgressTemplate>
                         
                           Please wait...
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>--%>
    <asp:UpdatePanel ID="updatepanel3" runat="server">
        <ContentTemplate>
            <div style="text-align: center;">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepanel3"
                    DynamicLayout="true">
                    <ProgressTemplate>
                        <div id="loading" class="loading-indicator">
                            <table>
                                <tr>
                                    <td>
                                     <%--   <img src="../images/loader_icon.gif">--%>
                                    </td>
                                    <td>
                                     <img src="../images/loader_icon.gif"> <br /> <b>Page loading please wait...</b> 
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            `
            <br />
            <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                        &nbsp;&nbsp;&nbsp;&nbsp;Select Filter
                    </td>
                    <%-- <td class="tdheader" align="right" >&nbsp;&nbsp;&nbsp;</td>--%>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="7">
                                    &nbsp;&nbsp;&nbsp;Status
                                </td>
                                <td width="26%">
                                    <asp:DropDownList ID="drpFilter" runat="server" Width="150px">
                                        <asp:ListItem Text="-------------Select-------------" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Open" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="On Hold" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Closed" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Resolved" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Unassigned" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Assigned" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td width="33%">
                                    &nbsp;&nbsp;&nbsp;Site&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList
                                        ID="drpSite" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="drpSite_SelectedIndexChanged"
                                        runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td width="34%">
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTechnician" runat="server" Text="Technician"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList
                                        ID="drpTechnician" Width="150px" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;Sort by
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpSort" Width="150px" runat="server">
                                        <asp:ListItem Text="-------------Select-------------" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Priority" Value="priorityid"></asp:ListItem>
                                        <asp:ListItem Text="CreateDatetime" Value="createdatetime"></asp:ListItem>
                                        <asp:ListItem Text="IncidentId" Value="incidentid"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox1" Height="17px" runat="server" ToolTip="DD/MM/YYYY" Width="145px"
                                        MaxLength="10"></asp:TextBox>
                                    <img id="img1" style="vertical-align: top;" onclick="scwShow(document.getElementById('<%=TextBox1.ClientID%>'),this);"
                                        src="../images/cal.gif" alt="date" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;To &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox2" Height="17px" Width="145px" runat="server" ToolTip="DD/MM/YYYY"
                                        MaxLength="10"></asp:TextBox>
                                    <img id="img2" style="vertical-align: top;" onclick="scwShow(document.getElementById('<%=TextBox2.ClientID%>'),this);"
                                        src="../images/cal.gif" alt="date" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" valign="top">
                    </td>
                </tr>
                <%-- <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Incident Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox Height="17px" ID="txtId" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFind" runat="server" Text="Find" onclick="btnFind_Click" />
    &nbsp;&nbsp;<asp:RequiredFieldValidator ID="reqValtxtId" runat="server" ControlToValidate="txtId" ForeColor="Red"  ErrorMessage="Enter Request Id"></asp:RequiredFieldValidator></td></tr>--%>
                <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers" TargetControlID="txtId" runat="server">
        </cc1:FilteredTextBoxExtender>--%>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5" background="../images/tdimg.bmp" align="right">
                        <asp:Button ID="btnShow" runat="server" Text="&nbsp;&nbsp;Show&nbsp;&nbsp;" OnClientClick="return dateValidation();"
                            OnClick="btnShow_Click" CausesValidation="false" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="Cancel Call" CausesValidation="false"
                            OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <%--    <tr style="padding-top:5px;">
        
        <td colspan="5"  align="right" ><asp:Label ID="lblSite1" runat="server" Text="Select Site" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList 
                ID="drpSite1" AutoPostBack="true"    runat="server" 
                onselectedindexchanged="drpSite1_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTechnician1" runat="server" Text="Select Technician" Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="drpTechnician1" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                ID="btnAssigned" runat="server" Text="Assigned" onclick="btnAssigned_Click" />&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            
    </tr>--%>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:GridView ID="grdvwRequest" runat="server" CssClass="grid-view" AutoGenerateColumns="False"
                            CellPadding="0" ForeColor="Black" CellSpacing="1" GridLines="Vertical" BackColor="White"
                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0px" OnRowDataBound="grdvwRequest_RowDataBound"
                            OnRowEditing="grdvwRequest_RowEditing" OnPageIndexChanging="grdvwRequest_PageIndexChanging"
                            PageSize="50" AllowPaging="true" Width="984px">
                            <FooterStyle BackColor="#CCCC99" />
                            <RowStyle BackColor="white" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:HyperLinkField HeaderText="Ticket id" DataTextField="incidentid" DataNavigateUrlFields="incidentid"
                                    DataNavigateUrlFormatString="~/Incident/IncidentRequestUpdate.aspx?incidentid={0}" />
                                <%--<asp:BoundField HeaderText="Complaint id"  DataField="incidentid" ReadOnly="true" />--%>
                                <asp:BoundField HeaderText="Title" DataField="title" ReadOnly="true" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Requester Name" DataField="requesterid" ReadOnly="true"
                                    ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Created By" DataField="createdbyid" ReadOnly="true" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Assigned to" DataField="technicianid" ReadOnly="true"
                                    ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Status" DataField="statusid" ReadOnly="true" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Priority" DataField="priorityid" ReadOnly="true" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Customer/Site" DataField="siteid" ReadOnly="true" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="createdatetime" DataField="createdatetime" ReadOnly="true"
                                    ItemStyle-HorizontalAlign="Left" />
                                <%--<asp:CommandField ShowEditButton="True" HeaderText="View Details" EditText="View Details" CausesValidation="false"   />--%>
                                <%--<asp:CommandField NewText="" ShowDeleteButton="True" HeaderText="Delete" CausesValidation="false" />--%>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckAll" onclick="return check_uncheck (this );" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="incidentid" Visible="false" Text='<%# DataBinder.Eval (Container.DataItem, "incidentid") %>'
                                            runat="server" />
                                        <asp:CheckBox ID="deleteRec" onclick="return check_uncheck (this );" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td class="tdheader">
                                            SNo.
                                        </td>
                                        <td class="tdheader">
                                            Ticket id
                                        </td>
                                        <td class="tdheader">
                                            title
                                        </td>
                                        <td class="tdheader">
                                            Requested Name
                                        </td>
                                        <td class="tdheader">
                                            Created By
                                        </td>
                                        <td class="tdheader">
                                            Assigned to
                                        </td>
                                        <td class="tdheader">
                                            Status
                                        </td>
                                        <td class="tdheader">
                                            Priority
                                        </td>
                                        <td class="tdheader">
                                            Customer/Site
                                        </td>
                                        <td class="tdheader">
                                            createdatetime
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            No record Found
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#E1E1E1E1" Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--Add Loader by vishal 23-05-2012--%>
    <%--    <asp:UpdatePanel ID="Upd2" runat="server">
            <ContentTemplate>
                 <div style="text-align: center;" >
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="Upd2"
                        DynamicLayout="true">
                        <ProgressTemplate>
                            <img src="../images/loading.gif">
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>--%>
</asp:Content>
