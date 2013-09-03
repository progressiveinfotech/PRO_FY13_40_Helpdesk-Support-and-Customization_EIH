<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="RemoveAsset.aspx.cs" Inherits="Asset_RemoveAsset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table width="100%"><tr><td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
 &nbsp;&nbsp;Remove Asset
 </td></tr></table>
<table align="center"  style="width:90%;" >
                     <tr>
                         <td colspan="4" style="height: 15px">
                             &nbsp;&nbsp; &nbsp;&nbsp;
                         </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 15px">
                            <asp:Label ID="Label1" runat="server" Text="To remove the old computers those have been moved from the organization, select the computer and Press Delete Button." Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="4" style="height: 15px">
                            &nbsp; &nbsp;&nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                        
                     </td>
                     <td style="width:35%; height: 15px;">
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                         </td>
                        <td colspan="2" style="height: 15px">
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 14px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 14px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 14px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 14px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         
                     </td>
                     <td style="width:35%; height: 15px;">
                         <asp:Label ID="lbl_computer_name" runat="server" Text="Select the Computer: " Font-Bold="True"></asp:Label>
                         &nbsp; &nbsp; &nbsp;
                      <asp:DropDownList ID="drpCmpList" DataTextField="Computer" DataValueField="Computer"  runat="server" Style="z-index: 100; left: 454px; top: 363px" Width="120px">
                      </asp:DropDownList>
                      
                         </td>
                        <td colspan="2" style="height: 15px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                           <asp:Button id="btnDelete" onclick="btnDelete_Click" runat="server" ToolTip="Click to delete the computer." Text="Delete" BackColor="ButtonFace" Width="73px"></asp:Button>
                            </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         </td>
                     <td style="width:35%; height: 15px;">
                     <asp:Label ID = "lbl_status" runat="server" Text="" Font-Bold="True"></asp:Label>  
                                         
                      </td>
                     <td style="width:15%; height: 15px;" align="left">
                    
                      </td>
                     <td style="width:35%; height: 15px;">
                      
                      </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         
                     </td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">&nbsp;
                      </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         </td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2">
                            &nbsp;</td>
                     <td colspan="2" align="left">
                         &nbsp;</td>
                     <td  align="left">  </td>
                         <td></td>
                    </tr>
                     <tr>
                    <td style="height: 15px"></td>
                    <td style="height: 15px"></td>
                        <td align="left" valign="top" colspan="2" style="height: 15px" >
                            &nbsp;</td>
                    </tr>
                    <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    
                    </tr>
                               
                    
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                        &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                     </td>
                     <td style="width:35%; height: 15px;">
                     </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <%--<tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>--%>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                                              
                     </td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    
                     <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                     <tr>
                        <td align="left" valign="top" colspan="2" >
                            &nbsp;</td>
                    </tr>
                     <tr><td>&nbsp;</td></tr>
                  <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         </td>
                     <td style="width:15%; height: 15px;" align="left">
                         
                     </td>
                     <td style="width:35%; height: 15px;">
                     </td>
                    </tr>
                   
                </table>
                
                <script language="javascript" type="text/javascript">
                             
                function confirm_delete()
                {
                  if (confirm("Are you sure you want to delete the computer?")==true)
                    return true;
                  else
                    return false;
                }

                </script>

</asp:Content>

