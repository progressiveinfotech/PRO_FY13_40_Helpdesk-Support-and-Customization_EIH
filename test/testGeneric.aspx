<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.master" AutoEventWireup="true" CodeFile="testGeneric.aspx.cs" Inherits="test_testGeneric" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">
function test()
{
var i="hello";
var j=3;
alert(i+j);

}

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



       <asp:Button ID="btnSubmit" runat="server" Text="Calculate Escalate Time" 
           onclick="btnSubmit_Click"  />&nbsp;<asp:Button ID="btnEmail" runat="server" 
           Text="Sent Email" onclick="btnEmail_Click" />
           &nbsp;&nbsp;
           <asp:Button ID="btnNotification" runat="server" 
           Text="Contract Notification"  OnClientClick="javascript:test();" />
         
         
         <br />
         <br />
         <br />
         <br />
          <br />

</asp:Content>

