<%@ Page Language="C#" MasterPageFile="~/Master/MasterAdmin.master" AutoEventWireup="true" CodeFile="EditColorScheme.aspx.cs" Inherits="admin_EditColorScheme" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table width="100%" align="left" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblErrorMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        
                            <tr>
                                <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;">&nbsp;&nbsp;Update Color Scheme</td>            
                            </tr>
                            <tr><td>&nbsp;</td></tr> 
                            <tr>
                                <td align="left"><font class="mandatory">*</font>Color 
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtcolorname" Width="138px"  runat="server"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="reqValcolor" 
                                        runat="server" 
                                        ControlToValidate="txtcolorname" 
                                        EnableClientScript="true"  
                                        SetFocusOnError="true"  
                                        ForeColor="Red" 
                                        ErrorMessage="Enter Color Name">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left"><font class="mandatory">*</font>Percent 
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtPercent" Width="138px"  runat="server"></asp:TextBox>
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="reqValPercent" 
                                        runat="server" 
                                        ControlToValidate="txtPercent" 
                                        EnableClientScript="true"  
                                        SetFocusOnError="true"  
                                        ForeColor="Red" 
                                        ErrorMessage="Enter value of Paercent">
                                    </asp:RequiredFieldValidator>
                                    &nbsp;
                                    <asp:RegularExpressionValidator ID="regexvalPaercent"  
                                        ControlToValidate="txtPercent"  
                                        ValidationExpression="\d+"  
                                        Display="Static"  
                                        EnableClientScript="true"  
                                        ErrorMessage="Please enter numbers only"  
                                        runat="server">
                                    </asp:RegularExpressionValidator> 
                                </td>
                                </tr>
                                    <tr>
                                    <td align="left"><font class="mandatory">*</font>Percent To &nbsp;
                                        <asp:TextBox ID="txtPercentTo" Width="138px"  runat="server"></asp:TextBox>
                                        &nbsp;
                                        <asp:RequiredFieldValidator ID="reqValPercentTo" 
                                            runat="server" 
                                            ControlToValidate="txtPercentTo" 
                                            EnableClientScript="true"  
                                            SetFocusOnError="true"  
                                            ForeColor="Red" 
                                            ErrorMessage="Enter value of ParcentTo">
                                        </asp:RequiredFieldValidator>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="regexvalPaercentTo"  
                                            ControlToValidate="txtPercentTo"  
                                            ValidationExpression="\d+"  
                                            Display="Static"  
                                            EnableClientScript="true"  
                                            ErrorMessage="Please enter numbers only"  
                                            runat="server">
                                        </asp:RegularExpressionValidator> 
                                    </td>
                                    </tr>
                                    <tr>
                                        <td align="left"><font class="mandatory">*</font>Call Status &nbsp;
                                            <asp:TextBox ID="txtcallstatus" Width="138px"  runat="server"></asp:TextBox>
                                            &nbsp;
                                            <asp:RequiredFieldValidator ID="reqValcallstatus" 
                                                runat="server" 
                                                ControlToValidate="txtcallstatus" 
                                                EnableClientScript="true"  
                                                SetFocusOnError="true"  
                                                ForeColor="Red" 
                                                ErrorMessage="Enter call status">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr>
                                        <td background="../images/tdimg.bmp" style="color:White;font-weight:bold;" align="left">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnColorupdate" runat="server" onclick="btnColorupdate_Click" Text="Update"  /> &nbsp;&nbsp;&nbsp;  
                                            <asp:Button ID="lnkback"  CausesValidation="false"  runat="server" Text="Back" onclick="lnkback_Click" /> 
                                        </td>
                                    </tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                            </table> 
                        </ContentTemplate> 
                    </asp:UpdatePanel> 
                </td> 
            </tr> 
           <%-- <tr>
                <td align="right">
                    <asp:LinkButton ID="lnkback" runat="server" Text="Back" Font-Underline="false" onclick="lnkback_Click" ></asp:LinkButton>
                </td>
            </tr>--%>
        </table> 
</asp:Content>

