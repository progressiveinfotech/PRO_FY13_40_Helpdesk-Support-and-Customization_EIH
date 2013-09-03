<%@ Page Language="C#" MasterPageFile="~/Master/MasterKedb.master" AutoEventWireup="true" CodeFile="AddSolution.aspx.cs" Inherits="admin_AddSolution" Title="Untitled Page" %>
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
        <td  colspan="5" background="../images/tdimg.bmp" style="color:White;font-weight:bold;" width=20%">
            &nbsp;Add Solution</td>
            
    </tr>
    <tr><td>&nbsp;</td></tr>
    
    <tr>
        <td align="left" class="tdsubheading" valign="top">
        <font class="mandatory">*</font>Title
        </td>
        <td >
         
         <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" TextMode="MultiLine" Width="594" Height="30px"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="reqValTitle" runat="server" ControlToValidate="txtTitle" EnableClientScript="true"  SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator> 
         
            
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
         <asp:DropDownList ID="drpTopic" runat="server"></asp:DropDownList>
        
        </td>
        
    </tr>
     <tr>
        <td align="left" class="tdsubheading" valign="top">
          &nbsp;&nbsp; Solution Type  
        </td>
        <td  >
         <asp:DropDownList ID="drpSolutionType" Width="127px" runat="server">
         <asp:ListItem Text="Solution" Value="Solution"></asp:ListItem>
         <asp:ListItem Text="WorkAround" Value="WorkAround"></asp:ListItem>
         </asp:DropDownList>
        
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
       
          
        <td colspan="5"  background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left" style="Padding-left:100px;" >

             <asp:Button ID="btnSolutionAdd" runat="server"  
                Text="Save" onclick="btnSolutionAdd_Click"  />      
           <asp:Button ID="btnReset"  CausesValidation="false"   
                Text="Reset"  runat="server" />  
               
               
         
           
    
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

