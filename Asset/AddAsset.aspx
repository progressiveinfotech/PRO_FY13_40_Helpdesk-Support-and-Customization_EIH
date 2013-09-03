<%@ Page Language="C#" MasterPageFile="~/Master/MasterAsset.master" AutoEventWireup="true" CodeFile="AddAsset.aspx.cs"
 Inherits="Asset_AddAsset" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript" type="text/javascript"  src="../JScript/scw.js"></script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
    <tr>
    <td>
        <asp:UpdatePanel ID="CategoryPanal1" runat="server">
        <ContentTemplate>
            <asp:Label runat="server" ID="lblerrmsg" 
                Font-Bold="true" ForeColor="red"></asp:Label></ContentTemplate></asp:UpdatePanel>
    </td>
    </tr>
 
    <tr>
    <td>
        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Computer Details
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
    
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="CategoryPanal2" runat="server">
            <ContentTemplate>
            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td width="10%"><font class="mandatory">*</font>Computer Name
                    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; --%></td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtcomputername" Width="165px"  runat="server" ></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="reqValComputerName" runat="server" ControlToValidate="txtcomputername" 
                    EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td width="10%">Domain</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtdomain" Width="165px"  runat="server" ></asp:TextBox>
                </td>
                </tr>
                <!-- added by Lalit Joshi-->
                <tr>
                    <td width="10%">&nbsp;Tag No.</td>
                    <td align="left" width="18%">
                        <asp:TextBox ID="TxtTagNo" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    <td width="10%">PO NO.</td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="TxtPONo"  Width="165px"  runat="server"></asp:TextBox>
                    </td>
                </tr>
               
                <%--<tr visible="false">
                    <td width="10%">
                        Asset Owner</td>
                    <td align="left" width="18%">
                 
                        &nbsp;<asp:DropDownList ID="DdlOwner" runat="server" AutoPostBack="True" Width="170px"
                            onselectedindexchanged="DdlOwner_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    
                   <%-- <td width="10%">Asset Location
                        &nbsp;</td>
                    <td align="left" width="25%">
                    <asp:DropDownList ID="DdlAssetLocation" runat="server" AutoPostBack="True" Width="170px" />
                        &nbsp;</td>--%>
                </tr>
                <tr>
                    <td width="10%">
                        Asset Owner</td>
                    <td align="left" width="18%">
                        <asp:TextBox ID="TxtOtherOwner" runat="server" Width="165px"></asp:TextBox>
                    </td>
                    <td width="10%">
                        CompanyCode</td>
                    <td align="left" width="18%">
                        <asp:TextBox ID="Txtcompanycode" runat="server" Width="165px"></asp:TextBox>
                    </td>
                </tr>
               
                <tr>
                    <td width="10%">
                        Location</td>
                    <td align="left" width="18%">
                        <asp:TextBox ID="Txtlocation" runat="server" Width="165px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtlocation"
                                            ForeColor="Red" ErrorMessage="Enter less than 50 characters "></asp:RequiredFieldValidator>--%>
                                            </td>
                    <td width="10%">
                        PurchaseDate</td>
                    <td align="left" width="18%">
                        <asp:TextBox ID="Txtpurchasedate" runat="server" Width="165px"></asp:TextBox>
                        <img id="img2" style="vertical-align: middle;" onclick="scwShow(document.getElementById('<%=Txtpurchasedate.ClientID%>'),this);"
                        src="../images/cal.gif" alt="date" />&nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="regDate" 
                                            runat="server" 
                                            ControlToValidate="Txtpurchasedate" 
                                            ErrorMessage="Enter date into right format" 
                                            ValidationExpression="^(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((1[6-9]|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((1[6-9]|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$">
                                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                
                
                <tr><td> is in stock</td><td><asp:DropDownList ID="DdlStock" runat="server" AutoPostBack="True" Width="170px"
                            
                AppendDataBoundItems="True" 
                >
                <asp:ListItem>NO</asp:ListItem>
                <asp:ListItem>YES</asp:ListItem>
                        </asp:DropDownList></td>
                    <%--    <td></td><td></td>--%>
                        <td width="10%">
                        AssetCategory</td>
                    <td align="left" width="18%">
                        <asp:TextBox ID="Txtassetcategory" runat="server" Width="165px"></asp:TextBox>
                    </td>
                        </tr>
                         <tr>
                    <td width="10%">
                        Remarks</td>
                    <td align="left" width="18%" colspan="3">
                        <asp:TextBox ID="Txtremarks" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
         </tr> 
                        
               <tr id="trshowotherowner" runat="server" visible="false">
                    <td width="10%">
                        &nbsp;</td>
                    <td align="left" width="18%">
                        &nbsp;</td>
                    
                    <td align="left" width="25%">
                        &nbsp;</td>
                </tr>
              
        
        
                 <!--end -->
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
                 
        <%--<tr><td>
            <asp:Label ID="lblStock" runat="server" Text="Is in stock" 
                AssociatedControlID="DdlStock"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DdlStock" runat="server" AutoPostBack="True" Width="170px"
                            
                AppendDataBoundItems="True" 
                >
                <asp:ListItem>NO</asp:ListItem>
                <asp:ListItem>YES</asp:ListItem>
                        </asp:DropDownList>
            </td></tr>--%>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Product Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td><font class="mandatory">*</font>Product Name</td>
                <td align="left">
                    <asp:TextBox ID="txtproductname" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProductName" runat="server" ControlToValidate="txtproductname" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td><font class="mandatory">*</font>Product Manufacturer</td>
                <td align="left">
                    <asp:TextBox ID="txtproductmanufacture" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProductManufacturer" runat="server" ControlToValidate="txtproductmanufacture" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                </tr>
                
                <tr>
                <td width="10%"><font class="mandatory">*</font>Serial Number</td>
                <td width="18%" align="left">   
                    <asp:TextBox ID="txtproductsno" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProductSerialno" runat="server" ControlToValidate="txtproductsno" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td width="10%">Uuid</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtuuid" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td >&nbsp;&nbsp;SKU Number</td>
                <td align="left">
                    <asp:TextBox ID="txtskuno" Width="165px"  runat="server"></asp:TextBox>
                </td>
                <td width="10%"></td>
                <td width="25%" align="left">
                    <asp:Label ID="lbldate" Text="null" Visible="false" runat="server"></asp:Label>
                </td>
                </tr>
    
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>  
    
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Processor Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td><font class="mandatory">*</font>Processor Name</td>
                <td align="left">
                    <asp:TextBox ID="txtprocessorname" Width="165px"  runat="server"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="reqValProcessorname" runat="server" ControlToValidate="txtprocessorname" EnableClientScript="true"   SetFocusOnError="true"  ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>Manufacturer</td>
                <td align="left">
                    <asp:TextBox ID="txtprocmanufacturer" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td width="10%">&nbsp;&nbsp;Speed</td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtspeed" Width="165px"  runat="server"></asp:TextBox>
                </td>
                <td width="10%">Family</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtfamily" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                 <tr>
                <td >&nbsp;&nbsp;Model</td>
                <td align="left">
                    <asp:TextBox ID="txtmodel" Width="165px"  runat="server"></asp:TextBox>
                </td>
                <td >Stepping</td>
                <td align="left">
                    <asp:TextBox ID="txtstepping" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td >&nbsp;&nbsp;Max Speed</td>
                <td align="left">
                    <asp:TextBox ID="txtmaxspeed" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
    
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Memory Details
        </td>
        </tr>
        <tr style="padding-top:10px;">
        <td>
            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td width="10%">&nbsp;&nbsp;Physical Memory</td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtphysicalmemory" Width="165px"  runat="server" AutoPostBack="true"></asp:TextBox>
                </td>
                <td width="10%">Virtual Memory</td>
                <td width="25%" align="left">
                    <asp:TextBox ID="txtvirtualmemory" Width="165px"  runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td width="10%">&nbsp;&nbsp;Page File</td>
                <td width="18%" align="left">
                    <asp:TextBox ID="txtpagefile" Width="165px"  runat="server" AutoPostBack="true"></asp:TextBox>
                </td>
                </tr>
    
            </table> 
        </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Network Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                    <td>&nbsp;&nbsp;Adapter Name</td>
                    <td align="left">
                        <asp:TextBox ID="txtadaptername" Width="165px"  runat="server"></asp:TextBox></td>
                    <td>MAC Address</td>
                    <td align="left">
                        <asp:TextBox ID="txtmacaddress" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                    <td width="10%">&nbsp;&nbsp;Link Speed</td>
                    <td width="18%" align="left">
                        <asp:TextBox ID="txtlinkspeed" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    <td width="10%">MTU</td>
                    <td width="25%" align="left">
                        <asp:TextBox ID="txtmtu" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    </tr>
                     <tr>
                    <td >&nbsp;&nbsp;Type</td>
                    <td align="left">
                        <asp:TextBox ID="txttype" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    <td >Protocol Name</td>
                    <td align="left">
                        <asp:TextBox ID="txtprotocol" Width="165px"  runat="server"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                    <td>
                        &nbsp;&nbsp;IP Address
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtipaddress" runat="server" Width="165px"></asp:TextBox>
                    </td>
                    <td> Subnet Mask</td>
                    <td align="left">
                        <asp:TextBox ID="txtsubnet" runat="server" Width="165px"></asp:TextBox>
                    </td>
                    <tr>
                    <td> &nbsp;&nbsp;Gateway</td>
                    <td align="left">
                        <asp:TextBox ID="txtgateway" runat="server" Width="165px"></asp:TextBox>
                    </td>
                    </tr>
                </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
         
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
            &nbsp;Operating System Details
        </td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td>&nbsp;&nbsp;OS Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtosname" Width="165px"  runat="server"></asp:TextBox></td>
                        <td>Major Version</td>
                        <td align="left">
                            <asp:TextBox ID="txtmajorversion" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td width="10%">&nbsp;&nbsp;Minor Version</td>
                        <td width="18%" align="left">
                            <asp:TextBox ID="txtminorversion" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td width="10%">Build Number</td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtbuildno" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td >&nbsp;&nbsp;Add information</td>
                        <td align="left">
                            <asp:TextBox ID="txtaddinfo" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td >User Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtusername1" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td>
                            &nbsp;&nbsp;Reg Code
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtregcode" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        <td> Reg Organisation</td>
                        <td align="left">
                            <asp:TextBox ID="txtregorg" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        <tr>
                        <td> &nbsp;&nbsp;Reg To</td>
                        <td align="left">
                            <asp:TextBox ID="txtregto" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        <td>
                            Localization</td>
                        <td align="left">
                            <asp:TextBox ID="txtlocal" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td> &nbsp;&nbsp;Product Key</td>
                        <td align="left">
                            <asp:TextBox ID="txtprokey" runat="server" Width="165px"></asp:TextBox>
                        </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>

        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">
        &nbsp;Physical Drive Details</td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td>&nbsp;&nbsp;Drive Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtdrivename" Width="165px"  runat="server"></asp:TextBox></td>
                        <td>Manufacturer</td>
                        <td align="left">
                            <asp:TextBox ID="txtmanufacturer" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td width="10%">&nbsp;&nbsp;Product Version</td>
                        <td width="18%" align="left">
                            <asp:TextBox ID="txtproductversion" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td width="10%">Product Id</td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtproductid" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td >&nbsp;&nbsp;Serial Number</td>
                        <td align="left">
                            <asp:TextBox ID="txtserialno" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td >Capacity</td>
                        <td align="left">
                            <asp:TextBox ID="txtcapacity" Width="165px"  runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="reqValtxtcapacity" runat="server" ControlToValidate="txtcapacity"
                                            ForeColor="Red" ErrorMessage="Enter capacity in bytes" Initialvalue="1048576"></asp:RequiredFieldValidator>--%>
                                          <%--<asp:RangeValidator ID="rvcapacity" runat="server"  ControlToValidate="txtcapacity" ErrorMessage="Enter capacity in bytes" Minimum="1048576" Maximum="1000000000" Type="integer">
                                            </asp:RangeValidator>
--%>
                                            
                        </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
    
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;"> &nbsp;Logical Drive Details</td>
        </tr>
       
        <tr style="padding-top:10px;">
        <td>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td>&nbsp;&nbsp;Drive Letter</td>
                        <td align="left">
                            <asp:TextBox ID="txtdriveletter" Width="165px"  runat="server"></asp:TextBox></td>
                        <td>Drive Type</td>
                        <td align="left">
                            <asp:TextBox ID="txtdrivetype" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                        <td width="10%">&nbsp;&nbsp;Total Bytes</td>
                        <td width="18%" align="left">
                            <asp:TextBox ID="txttotalbytes" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        <td width="10%">Free Bytes</td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtfreebytes" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
                         <tr>
                        <td >&nbsp;&nbsp;File System Name</td>
                        <td align="left">
                            <asp:TextBox ID="txtfilesysname" Width="165px"  runat="server"></asp:TextBox>
                        </td>
                        </tr>
    
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>  
         
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="center">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Details" OnClick="btnAdd_click"/>&nbsp;&nbsp;
                    <asp:Button ID="btnReset"  CausesValidation="false" runat="server" Text="Reset" OnClick="btnReset_Click" />
                </ContentTemplate>
                <%--  <Triggers> 
                    <asp:PostBackTrigger ControlID="Ddlassetowner" />
                </Triggers>--%>

            </asp:UpdatePanel>
        </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>&nbsp;</td></tr> 
        <tr><td align="center"></td></tr>

    </table>
    </td>
    </tr>
</table>
</asp:Content>

