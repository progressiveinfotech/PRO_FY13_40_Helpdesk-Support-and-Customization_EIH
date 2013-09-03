<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="center" cellpadding="0"  border="0" cellspacing="0">
        <tr>
            <td align="center" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                <asp:Label ID="lblrep" runat="server" Font-Underline="true" Font-Names="Arial" Text="Administrator Task" Font-Bold="true" Font-Size="19px" ForeColor="White"></asp:Label>
            </td>
        </tr>
         <tr><td>&nbsp;</td></tr>
    </table>
  
        
        <table align="center" width="90%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="50%">
                <table align="left" width="66%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="20px" width="2%" background="../images/leftadmin.bmp"> </td>
                        <td  height="20px" width="94%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                        &nbsp;&nbsp;
                        <asp:Label ID="lbl1" runat="server" ForeColor="white" Font-Bold="true" Text="User Task" Font-Size="12px"></asp:Label> </td>
                        <td height="20px" width="4%" background="../images/rightadmin.bmp"> </td>
                    </tr>
                </table>
            </td>
            <td width="50%" valign="top">
                <table align="right" width="66%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="20px" width="2%" background="../images/leftadmin.bmp"> </td>
                        <td  height="20px" width="94%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="white" Font-Bold="true" Text="Organization Task" Font-Size="12px"></asp:Label></td>
                        <td height="20px" width="4%" background="../images/rightadmin.bmp"> </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
        <table align="center" width="90%" cellpadding="0" cellspacing="0" border="0">
          
            <tr>
                <td width="50%">
                    <table align="left" width="66%" cellpadding="0" cellspacing="0">
                       
                        <tr>
                            <td width="4%" align="center">
                            <asp:Image ID="img1" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                            <td width="96%">&nbsp;
                            <asp:LinkButton ID="lnkCreateUser" 
                                OnClientClick="lnkCreateUser_Click"
                                runat="server"  Font-Bold="true"
                                ForeColor="#0066cc" onclick="lnkCreateUser_Click">Create User
                            </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkViewUser" 
                                OnClientClick="lnkViewUser_Click"
                                runat="server" Font-Bold="true"
                                ForeColor="#0066cc" onclick="lnkViewUser_Click">View User
                            </asp:LinkButton>
                            </td>
                        </tr>
                         <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image31" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="LnkBtnmultipleusersitemapping" 
                                OnClientClick="LnkBtnmultipleusersitemapping_Click"
                                runat="server" Font-Bold="true"
                                ForeColor="#0066cc" onclick="LnkBtnmultipleusersitemapping_Click">Map Multiple Users to sites
                            </asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image21" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkUserToSiteMapping" 
                        runat="server" 
                        ForeColor="#0066cc"  Font-Bold="true"
                        OnClick="lnkUserToSiteMapping_Click">Mapped Users to Sites
                        </asp:LinkButton>
                        </td>
                         </tr>
                        <tr>
             <td width="4%" align="center">
                        <asp:Image ID="Image33" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="LnkMapHubToSite" 
                        runat="server" 
                        ForeColor="#0066cc"  Font-Bold="true"
                        OnClick="LnkMapHubToSite_Click">Mapped Sites to Hub
                        </asp:LinkButton>
                        </td>
             
                    </tr>
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image11" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkAddCabMember" 
                                OnClientClick="lnkAddCabMember_Click"
                                runat="server"  Font-Bold="true"
                                ForeColor="#0066cc" onclick="lnkAddCabMember_Click">Define CAB Member
                            </asp:LinkButton>
                            </td>
                        </tr>
                        
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image28" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkAddEmail" 
                                OnClientClick="lnkAddEmail_Click"
                                runat="server"  Font-Bold="true"
                                ForeColor="#0066cc" onclick="lnkAddEmail_Click">Define Authority for Escalation
                            </asp:LinkButton>
                            </td>
                        </tr>
                        <tr id="trtechmapping" runat="server">
                        <td width="4%" align="center">
                        <asp:Image ID="Image34" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="LnkMapCatSubCatToTechnician" 
                        runat="server" 
                        ForeColor="#0066cc" Font-Bold="true" onclick="LnkMapCatSubCatToTechnician_Click"
                        >Map Technician to Cat-Subcategory 
                        </asp:LinkButton>
                        </td>
                    </tr>
                    </table>
                </td>
                <td width="50%" valign="top">
            
                <table align="right" width="66%" cellpadding="0" cellspacing="0">
                    
                        <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkAddOrganization" 
                            runat="server"  Font-Bold="true"
                            ForeColor="#0066cc" 
                            OnClick="lnkAddOrganization_Click">Define Organization
                        </asp:LinkButton>
                        </td>
                    </tr>
                     <tr>
                            <td width="4%" align="center">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                            <td width="96%">&nbsp;
                            <asp:LinkButton ID="lnkcustomer" 
                                OnClientClick="lnkCreateCustomer_Click"
                                runat="server"  Font-Bold="true"
                                ForeColor="#0066cc" onclick="lnkCreateCustomer_Click">Create Customer
                            </asp:LinkButton>
                            </td>
                        </tr>
                    <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkAddRegion" 
                            runat="server" Font-Bold="true"
                            ForeColor="#0066cc" 
                            OnClick="lnkAddRegion_Click">Define Region
                        </asp:LinkButton>
                        </td>
                    </tr>
                    
                   
                 <%--   <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image10" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkAddSite" 
                            runat="server" 
                            ForeColor="#0066cc" 
                            OnClick="lnkAddSite_Click">Add Site
                        </asp:LinkButton>
                        </td>
                    </tr>--%>
                    <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkViewSite" 
                        runat="server"  Font-Bold="true"
                        ForeColor="#0066cc" 
                        OnClick="lnkViewSite_Click">Define Site
                        </asp:LinkButton>
                        </td>             
                    </tr>
                    <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkAddDepartment" 
                        runat="server"  Font-Bold="true"
                        ForeColor="#0066cc" 
                        OnClick="lnkAddDepartment_Click">Define  Department
                        </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image22" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkImportUserAd" 
                        runat="server"  Font-Bold="true"
                        ForeColor="#0066cc" 
                        OnClick="lnkImportUserAd_Click">Import User from Active Directory
                        </asp:LinkButton>
                        </td>
             
                    </tr>
                   
                        
                  <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image30" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="Lnkchangesetting" 
                        runat="server"  Font-Bold="true"
                        ForeColor="#0066cc" 
                        OnClick="Lnkchangesetting_Click">Change application setting
                        </asp:LinkButton>
                        </td>
             
                    </tr>
                        
                        
                </table>
                </td>
            </tr>
           </table>
           <table align="center" width="100%" cellpadding="0" cellspacing="0">
                <tr><td>&nbsp;</td></tr>
           </table>
           <table align="center" width="90%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="50%">
          
                        <table align="left" width="66%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="20px" width="2%" background="../images/leftadmin.bmp"> </td>
                                <td  height="20px" width="94%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                                &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" ForeColor="white" Font-Bold="true" Text="Define Services" Font-Size="12px"></asp:Label></td>
                                <td height="20px" width="4%" background="../images/rightadmin.bmp"> </td>
                            </tr>
                        </table>
                    </td>
                    <td width="50%" valign="top">
                    <table align="right" width="66%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="20px" width="2%" background="../images/leftadmin.bmp"> </td>
                            <td  height="20px" width="94%" background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
                           &nbsp;&nbsp; <asp:Label ID="Label3" runat="server" ForeColor="white" Font-Bold="true" Text="Other Task" Font-Size="12px"></asp:Label>  </td>
                            <td height="20px" width="4%" background="../images/rightadmin.bmp"> </td>
                        </tr>
                    </table>
                </td>
            </tr>
        
        </table>
        
        
        <table align="center" width="90%" cellpadding="0" cellspacing="0" border="0">
        
           <tr>
           <td width="50%" valign="top">
             <table align="left" width="66%" cellpadding="0" cellspacing="0">
               <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image25" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkViewServiceWindow"  Font-Bold="true"
                                OnClientClick="lnkViewServiceWindow_Click"
                                runat="server" 
                                ForeColor="#0066cc" onclick="lnkViewServiceWindow_Click">Define Service Window 
                            </asp:LinkButton>
                            </td>
                        </tr>
                  <%--  <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image27" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkaddsla" 
                              
                                runat="server" 
                                ForeColor="#0066cc" onclick="lnkaddsla_Click">Add SLA
                            </asp:LinkButton>
                            </td>
                        </tr>--%>
                        <tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image26" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkViewsla"  Font-Bold="true"
                                OnClientClick="lnkViewsla_Click"
                                runat="server" 
                                ForeColor="#0066cc" onclick="lnkViewsla_Click">Define SLA
                            </asp:LinkButton>
                            </td>
                        </tr>
                   
                      
                    <%--<tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image8" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkAddServiceWindow" 
                        runat="server" 
                        ForeColor="#0066cc" 
                        OnClick="lnkAddServiceWindow_Click">Add Service Window
                        </asp:LinkButton>
                        </td>
             
                    </tr>--%>
                    
                    <tr>
                            <td width="4%" align="center">
                            <asp:Image ID="Image23" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                            <td width="96%">&nbsp;
                            <asp:LinkButton ID="lnkAddHoliday" 
                                OnClientClick="lnkAddHoliday_Click"
                                runat="server"  Font-Bold="true"
                                ForeColor="#0066cc" onclick="lnkAddHoliday_Click">Define Holiday
                            </asp:LinkButton>
                            </td>
                        </tr>
                        <%--<tr>
                             <td width="4%" align="center">
                             <asp:Image ID="Image24" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                             <td width="96%">&nbsp;
                             <asp:LinkButton ID="lnkEditHoliday" 
                                OnClientClick="lnkEditHoliday_Click"
                                runat="server" 
                                ForeColor="#0066cc" onclick="lnkEditHoliday_Click">Edit Holiday
                            </asp:LinkButton>
                            </td>
                        </tr>--%>
                     
                    <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image20" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddColorScheme" 
                             runat="server" 
                             ForeColor="#0066cc"  Font-Bold="true"
                             OnClick="lnkAddColorScheme_Click">Define Color Scheme for Calls
                         </asp:LinkButton>
                     </td>
             </tr>
               <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image8" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkcmdb" 
                             runat="server" 
                             ForeColor="#0066cc"  Font-Bold="true" onclick="lnkcmdb_Click"
                            >Define CI
                         </asp:LinkButton>
                     </td>
             </tr>
              
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image10" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkserviceproduct" 
                             runat="server" 
                             ForeColor="#0066cc"  Font-Bold="true" onclick="lnkserviceproduct_Click" 
                            >Define Service Product
                         </asp:LinkButton>
                     </td>
             </tr>
                    
             </table>
           </td>
            <td width="50%">
            
            <table align="right" width="66%" cellpadding="0" cellspacing="0">
             <%--<tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image5" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddRole" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddRole_Click">Add Role
                         </asp:LinkButton>
                     </td>
             </tr>--%>
            <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image12" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddCategory" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddCategory_Click">Add Category
                         </asp:LinkButton>
                     </td>
             </tr>
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image13" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddSubcategory" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddSubcategory_Click">Add Subcategory
                         </asp:LinkButton>
                     </td>
             </tr>
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image14" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddMode" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddMode_Click">Add Mode
                         </asp:LinkButton>
                     </td>
             </tr>
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image15" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddPriority" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddPriority_Click">Add Priority
                         </asp:LinkButton>
                     </td>
             </tr>
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image16" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddStatus" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddStatus_Click">Add Status
                         </asp:LinkButton>
                     </td>
             </tr>
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image17" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddChangeStatus" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddChangeStatus_Click">Add Change Status
                         </asp:LinkButton>
                     </td>
             </tr>
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image18" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddChangeType" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddChangeType_Click">Add Change Type
                         </asp:LinkButton>
                     </td>
             </tr>
             <tr>
                 <td width="4%" align="center">
                     <asp:Image ID="Image19" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                     <td width="96%">&nbsp;
                         <asp:LinkButton ID="lnkAddVendor" 
                             runat="server" 
                             ForeColor="#0066cc" Font-Bold="true"
                             OnClick="lnkAddVendor_Click">Add Vendor
                         </asp:LinkButton>
                     </td>
             </tr>
             
               <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image9" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkAddCountry" 
                            runat="server" 
                            ForeColor="#0066cc" Font-Bold="true"
                            OnClick="lnkAddCountry_Click">Add Country
                        </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image7" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkAddServiceEffected" 
                        runat="server" 
                        ForeColor="#0066cc" Font-Bold="true"
                        OnClick="lnkAddServiceEffected_Click">Add Service Effected
                        </asp:LinkButton>
                        </td>
                    </tr>
                     <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image24" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkaddtitle" 
                        runat="server" 
                        ForeColor="#0066cc" Font-Bold="true" onclick="lnkaddtitle_Click"
                        >Add Title
                        </asp:LinkButton>
                        </td>
                    </tr>
                     <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image27" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkuseremail" 
                        runat="server" 
                        ForeColor="#0066cc" Font-Bold="true" onclick="lnkuseremail_Click"
                        >User To Email Mapping
                        </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td width="4%" align="center">
                        <asp:Image ID="Image29" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="lnkusersurvey" 
                        runat="server" 
                        ForeColor="#0066cc" Font-Bold="true" onclick="lnkusersurvey_Click"
                        >User Survey
                        </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                      <td width="4%" align="center">
                        <asp:Image ID="Image32" runat="server" ImageUrl="~/images/arrow.jpg" /></td>
                        <td width="96%">&nbsp;
                        <asp:LinkButton ID="LnkAddHub" 
                        runat="server" 
                        ForeColor="#0066cc" Font-Bold="true" onclick="LnkAddHub_Click"
                        >Add HUB
                        </asp:LinkButton>
                        </td>
                    </tr>
             </table>
            
            
            </td>
           
           </tr>
           </table>

</asp:Content>

