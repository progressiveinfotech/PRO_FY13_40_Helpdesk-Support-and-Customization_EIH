<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true"
    CodeFile="IncidentRequest.aspx.cs" Inherits="Incident_IncidentRequest" Title="Untitled Page" %>

<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <input type="hidden" id="refreshed" value="no">

    <script type="text/javascript">
        onload = function() {
            var e = document.getElementById("refreshed");
            if (e.value == "no") e.value = "yes";
            else { e.value = "no"; location.reload(); }
        }
    </script>

    <script type="text/javascript" language="javascript">

        function CheckForPastDate(sender, args) {

            var selectedDate = new Date();
            selectedDate = sender._selectedDate;
            var todayDate = new Date();
            if (selectedDate.getDateOnly() > todayDate.getDateOnly()) {

                sender._selectedDate = todayDate;
                sender._textbox.set_Value(sender._selectedDate.format(sender._format));
                alert("Please select past date");
                //            document.getElementById("<%= txtReportedDate.ClientID %>").value = '';
            }
        }
        function refreshParent() {
            window.opener.location.href = window.opener.location.href;
            if (window.opener.progressWindow) {
                window.opener.progressWindow.close()
            }
            window.close();
        }

        // alert('hello lalit');
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

      
    
    </script>

    <style type="text/css">
          #loading
        {
            position: absolute;
            left: 45%;
            top: 50%;
            border: 3px solid #B2D0F7;
           
            padding: 10px;
            font: bold 14px verdana,tahoma,helvetica;
            color: #003366;
            width: 180px;
            text-align: center;
        }
        .loading-indicator
        {
            
            font-size: 8pt;
           
            background-repeat: no-repeat;
            background-position: top left;
            padding-left: 20px;
            height: 73px;
            text-align: left;
        }
     
        .style1
        {
            width: 18%;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="CategoryPanal1" runat="server">
                    <ContentTemplate>
                        <asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                            &nbsp;New Ticket
                        </td>
                    </tr>
                    <tr style="padding-top: 17px;">
                        <td>
                            <asp:UpdatePanel ID="CategoryPanal2" runat="server">
                                <ContentTemplate>
                                    <div style="text-align: center;">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="CategoryPanal2"
                                            DynamicLayout="true">
                                            <ProgressTemplate>
                                                <div id="loading" class="loading-indicator">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <%--   <img src="../images/loader_icon.gif">--%>
                                                            </td>
                                                            <td>
                                                                <img src="../images/loader_icon.gif">
                                                                <br />
                                                                <b>Page loading please wait...</b>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                    <br />
                                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;&nbsp;Call type
                                            </td>
                                            <td width="18%" align="left">
                                                <asp:DropDownList Width="170px" ID="drpRequestType" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10%">
                                               Mode 
                                            </td>
                                            <td width="25%" align="left">
                                             <asp:DropDownList ID="drpMode" Width="170px" runat="server">
                                                </asp:DropDownList>
                                                 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                &nbsp;&nbsp; Status
                                            </td>
                                            <td width="18%" align="left">
                                                <asp:DropDownList Width="170px" ID="drpStatus" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="10%">
                                              Priority  <font class="mandatory">*</font>
                                            </td>
                                            <td width="25%" align="left">
                                            <asp:DropDownList ID="drpPriority" Width="170px" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="true"
                                                    ControlToValidate="drpPriority" ErrorMessage="Select Priority" InitialValue="0"></asp:RequiredFieldValidator>
                                           
                                            
                                                
                                            </td>
                                        </tr>
                                        </td> </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                            &nbsp;Requester Details
                        </td>
                    </tr>
                    <tr style="padding-top: 17px;">
                        <td>
                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td width="10%" valign="top">
                                        <font class="mandatory">*</font>User Name
                                    </td>
                                    <td width="18%" align="left" valign="top">
                                        <asp:TextBox ID="txtUsername" Width="165px" runat="server" AutoPostBack="true" OnTextChanged="txtUsername_TextChanged"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServicePath="~/WebService.asmx"
                                            ServiceMethod="GetCompletionList" CompletionSetCount="10" MinimumPrefixLength="1"
                                            TargetControlID="txtUsername" UseContextKey="true">
                                        </asp:AutoCompleteExtender><br />
                                        <asp:RequiredFieldValidator ID="reqValUserName" runat="server" ControlToValidate="txtUsername"
                                            ForeColor="Red" ErrorMessage="Enter User Name"></asp:RequiredFieldValidator>
                                    </td>
                                    <td width="10%" align="left" valign="top">
                                       Assigned Asset 
                                    </td>
                                    <td width="25%" align="left" valign="top">
                                     <asp:TextBox ID="txtassignasset" Width="165px" runat="server" ReadOnly="true"></asp:TextBox>&nbsp;
                                        <asp:ImageButton ID="imgselectasset" CausesValidation="false" runat="server" ImageUrl="~/images/Searchlogo.jpg"
                                            OnClientClick="javascript:window.open('SelectAsset.aspx','popupwindow','width=770,height=590,left=380,top=230,Scrollbars=yes');" />
                                    
                                    
                                      
                                    </td>
                                </tr>
                                <tr>
                                    <td width="10%" valign="top">
                                        <font class="mandatory">*</font>Email
                                    </td>
                                    <td width="18%" align="left">
                                        <asp:TextBox ID="txtEmail" Width="165px" runat="server"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                            ForeColor="Red" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator
                                                ID="regExtxtEmailId" runat="server" EnableClientScript="true" ControlToValidate="txtEmail"
                                                ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                ErrorMessage="Enter Valid Email-Id"></asp:RegularExpressionValidator>&nbsp;&nbsp;
                                    </td>
                                    <td valign="top">
                                        AMC Call&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td valign="top">
                                        <asp:DropDownList ID="drpAMCcall" Width="170px" runat="server">
                                            <asp:ListItem>NO</asp:ListItem>
                                            <asp:ListItem>YES</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trreporteddate" runat="server">
                                    <td width="10%" valign="top">
                                        &nbsp;</td>
                                    <td width="18%" align="left">
                                        &nbsp;</td>
                                    <td valign="top">
                                        Reported Date</td>
                                    <td valign="top">
                                    <asp:TextBox ID="txtReportedDate" runat="server" MaxLength="10" Width="170px" 
                                        Enabled="false" Font-Names="verdana,arial,helvetica,sans-serif"></asp:TextBox>
                                  <asp:Image ID="imgCal" runat="server" ImageUrl="../images/cal.gif" />
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" Animated="true" PopupButtonID="imgCal" 
        TargetControlID="txtReportedDate" Enabled="True" OnClientDateSelectionChanged="CheckForPastDate" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtReportedDate"
        ErrorMessage="(dd/mm/yyyy)" ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$"
        Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Date Required"
           ControlToValidate="txtReportedDate"  Style="text-align: justify"
         Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                
                                <tr id="trreportedtime" runat="server">
                                    <td width="10%" valign="top">
                                        &nbsp;</td>
                                    <td width="18%" align="left">
                                        &nbsp;</td>
                                    <td valign="top">
                                        Reported Time</td>
                                    <td valign="top">
                                        <asp:DropDownList ID="drpTimeHours" runat="server" Height="16px" Width="38px">
                                        </asp:DropDownList>
                                        :
                                        <asp:DropDownList ID="drpTimeMin" runat="server" Height="16px" Width="39px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td background="../images/tdimg.bmp" style="color: White; font-weight: bold;">
                            &nbsp;Other Details
                        </td>
                    </tr>
                    <tr style="padding-top: 17px;">
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <font class="mandatory">*</font>Customer
                                            </td>
                                            <td align="left" class="style1">
                                                <asp:DropDownList ID="drpCustomer" Width="170px" AutoPostBack="true" runat="server"
                                                    OnSelectedIndexChanged="drpCustomer_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <br /><asp:RequiredFieldValidator ID="reqValdrpCustomer" runat="server" EnableClientScript="true"
                                                    ControlToValidate="drpCustomer" ErrorMessage="Select Customer" 
                                                    InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <font class="mandatory">*</font>Site
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="drpSite" Width="170px" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpSite_SelectedIndexChanged">
                                                </asp:DropDownList><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    EnableClientScript="true" ControlToValidate="drpSite" ErrorMessage="Select Site"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="10%">
                                                &nbsp;&nbsp;Category
                                            </td>
                                            <td align="left" class="style1">
                                                <asp:DropDownList ID="drpCategory" Width="170px" AutoPostBack="true" runat="server"
                                                    OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                                                </asp:DropDownList><br />
                                                <asp:RequiredFieldValidator ID="reqValdrpCategory" runat="server" 
                                                    ControlToValidate="drpCategory" EnableClientScript="true" Display="Dynamic" 
                                                    ErrorMessage="Select Category" InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="10%">
                                                SubCategory
                                            </td>
                                            <td width="25%" align="left">
                                                <asp:DropDownList ID="drpSubcategory" Width="170px" runat="server"  AutoPostBack="true"
                                                    OnSelectedIndexChanged="drpSubcategory_SelectedIndexChanged">
                                                </asp:DropDownList><br />
                                                <asp:RequiredFieldValidator ID="reqsubcategory" runat="server" 
                                                    ControlToValidate="drpSubcategory" Display="Dynamic" EnableClientScript="true" 
                                                    ErrorMessage="Select Sub-Category" InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <%--<tr>
    <td >&nbsp;&nbsp;Technician</td>
    <td align="left">
    </td>
    <td >&nbsp;</td>
    <td  align="left">
    &nbsp;
    </td>
    </tr>--%>
                                        <tr>
                                            <td width="10%"><font class="mandatory">*</font>
                                                Technician</td>
                                            <td align="left" class="style1">
                                                <asp:DropDownList ID="drpTechnician" runat="server" Width="170px">
                                                </asp:DropDownList>&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                    EnableClientScript="true" ControlToValidate="drpTechnician" ErrorMessage="Select Technician"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="10%">
                                                Department</td>
                                            <td align="left" width="25%">
                                                <asp:DropDownList ID="drpDepartment" runat="server" Width="170px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <font class="mandatory">*</font>Title
                                            </td>
                                            <td class="style1">
                                                <asp:TextBox ID="txtTitle" runat="server" Width="171px"></asp:TextBox>
                                                <%--<asp:DropDownList ID="drpTitle" runat="server" Width="390px"></asp:DropDownList>--%>
                                               <br /> <asp:RequiredFieldValidator Display="Dynamic" ID="reqValSubject" runat="server" ControlToValidate="txtTitle"
                                                    ForeColor="Red" ErrorMessage="Enter Title"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                Extension
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Txtextension" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                                    Width="171px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="padding-bottom: 12px;">
                                            <td>
                                                &nbsp;&nbsp;Description
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Height="50px" runat="server"
                                                    Width="620px"></asp:TextBox>
                                                    <asp:HiddenField ID="HidUserName" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td background="../images/tdimg.bmp" align="center">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add Request" OnClick="btnAdd_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnReset" CausesValidation="false" runat="server" Text="Reset" OnClick="btnReset_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
