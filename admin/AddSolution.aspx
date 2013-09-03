<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="AddSolution.aspx.cs" Inherits="admin_AddSolution" Title="Untitled Page" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
 <tr><td><asp:UpdatePanel ID="AddSolution1" runat="server"><ContentTemplate><asp:Label runat="server" ID="lblerrmsg" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel></td></tr>
 <tr><td>
<asp:UpdatePanel ID="AddSolutionPanal2" runat="server">
<ContentTemplate>
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width=20%">
            &nbsp;Add Solution</td>
            <td width="80%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading" valign="top">
        <font class="mandatory">*</font>Title
        </td>
        <td >
         
         <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" TextMode="MultiLine" Width="594" Height="30px"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValCategory" runat="server" ControlToValidate="txtTitle" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> 
         
            
        </td>
       
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp;Content  
        </td>
        <td >
          <div id="EditorPanel">
          
            <cc:HtmlEditor ID="Editor" runat="server" Height="300px" Width="600px" />
            </div>
        </td>
        
    </tr>
     <tr><td>&nbsp;</td></tr>
    <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp; Topic  
        </td>
        <td  >
         <asp:TextBox ID="txtTopic" runat="server" MaxLength="50" TextMode="MultiLine"></asp:TextBox>
        
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
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"></td> 
          
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">

             <asp:Button ID="btnCategoryadd" runat="server"  
                Text="Save"  />      
           <asp:Button ID="btnReset"  CausesValidation="false"   
                Text="Reset" onclick="" />  
               
               
         
           
    
        </td>
    </tr>
  
    <tr><td>&nbsp;</td></td>
    
   
   <tr><td>&nbsp;</td></tr>
    <tr><td>&nbsp;</td></tr>
     <tr><td>&nbsp;</td></tr>
      <tr><td>&nbsp;</td></tr>
       <tr><td>&nbsp;</td></tr>
        
   
   

</table>
</ContentTemplate>
</asp:UpdatePanel>
 </td></tr>
 </table>



</asp:Content>

