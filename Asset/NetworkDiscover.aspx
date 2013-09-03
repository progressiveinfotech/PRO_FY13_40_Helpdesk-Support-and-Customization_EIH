<%@ Page Language="C#" MasterPageFile="~/Master/MasterNetwork.master" AutoEventWireup="true" CodeFile="NetworkDiscover.aspx.cs" Inherits="Tracker_NetworkDiscover" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table align="center"  style="width:90%;" >
                     
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         </td>
                     <td style="width:35%; height: 15px;" align="left">
                         &nbsp;</td>
                    </tr>              
                    
                    <tr>
                        <td colspan="4" style="height: 15px" align="center">
                            <asp:Label ID="lbl_device" runat="server" Text="Device" Font-Bold="True" Font-Size="Large" Font-Overline="False" 

Font-Strikeout="False" Font-Underline="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    
                    </table>
                    
                    
                      <table align="center"  style="width:90%;" >
                     <tr>
                         <td colspan="2" style="height: 15px">
                             &nbsp;&nbsp;
                         </td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">&nbsp;
                      </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 15px">
                            <asp:Label ID="lbl_os" runat="server" Text="General Information:" Font-Bold="True" Font-Size="Larger" Font-Underline="False"></asp:Label></td>
                     <td style="width:15%; height: 15px;" align="left">&nbsp;
                      </td>
                     <td style="width:35%; height: 15px;">&nbsp;
                      </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:282px; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                        <asp:Label ID="lbl_device_name" runat="server" Text="Device:" Font-Bold="True"></asp:Label>
                     </td>
                     <td style="width:282px; height: 15px;">
                         <asp:Label ID="lbl_device_value" runat="server"></asp:Label>
                         </td>
                        <td colspan="2" style="height: 15px">
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 14px;" align="left">
                         <asp:Label ID="lbl_description" runat="server" Text="Description:" Font-Bold="True"></asp:Label>
                     </td>
                     <td style="width:282px; height: 14px;">
                         <asp:Label ID="lbl_description_value" runat="server"></asp:Label>
                         </td>
                     <td style="width:15%; height: 14px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 14px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                      <asp:Label ID="lbl_inventory_date" runat="server" Text="Inventory date:" Font-Bold="True"></asp:Label>   
                     </td>
                     <td style="width:282px; height: 15px;">
                         <asp:Label ID="lbl_inventory_value" runat="server"></asp:Label>
                         </td>
                        <td colspan="2" style="height: 15px">
                            </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:282px; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         </td>
                     <td style="width:282px; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">&nbsp;
                      </td>
                     <td style="width:35%; height: 15px;">&nbsp;
                      </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:282px; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">&nbsp;
                      </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 15px">
                        <asp:Label ID="Label1" runat="server" Text="Additional Information:" Font-Bold="True" Font-Size="Larger" Font-Underline="False"></asp:Label>    
                        </td>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:35%; height: 15px;">&nbsp;
                      </td>
                    </tr>
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:282px; height: 15px;">
                         &nbsp;</td>
                     <td style="width:15%; height: 15px;" align="left">
                         </td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:15%; height: 15px;" align="left">
                         <asp:Label ID="lbl_contact" runat="server" Text="Contact:" Font-Bold="True"></asp:Label>   </td>
                     <td style="width:282px; height: 15px;">
                         <asp:Label ID="lbl_contact_value" runat="server"></asp:Label></td>
                     <td style="width:15%; height: 15px;" align="left">
                         </td>
                     <td style="width:35%; height: 15px;">
                         &nbsp;</td>
                    </tr>
                     <tr>
                    <td style="height: 15px"><asp:Label ID="lbl_location" runat="server" Text="Location:" Font-Bold="True"></asp:Label>   </td>
                    <td style="height: 15px; width: 282px;">
                    <asp:Label ID="lbl_location_value" runat="server"></asp:Label>
                    </td>
                        <td align="left" valign="top" colspan="2" style="height: 15px" >
                            &nbsp;</td>
                    </tr>
                    <tr>
                    <td><asp:Label ID="lbl_platform_id" runat="server" Text="Platform ID:" Font-Bold="True"></asp:Label>   </td>
                    <td style="width: 282px">
                    <asp:Label ID="lbl_platform_value" runat="server"></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                    
                    </tr>
                               
                    
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                       <asp:Label ID="lbl_up_time" runat="server" Text="Up time:" Font-Bold="True"></asp:Label>   </td>
                     <td style="width:282px; height: 15px;">
                         <asp:Label ID="lbl_up_time_value" runat="server"></asp:Label>
                         </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:282px; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                     </td>
                     <td style="width:282px; height: 15px;">
                     </td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:282px; height: 15px;">
                         &nbsp;</td>
                    </tr>
                    
                    <tr>
                     <td style="width:15%; height: 15px;" align="left">
                         &nbsp;</td>
                     <td style="width:282px; height: 15px;">
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
                     <td style="width:282px; height: 15px;">
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
                     <td style="width:282px; height: 15px;">
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
                     <td style="width:282px; height: 15px;">
                         </td>
                     <td style="width:15%; height: 15px;" align="left">
                         
                     </td>
                     <td style="width:35%; height: 15px;">
                     </td>
                    </tr>
                    
                </table>
</asp:Content>

