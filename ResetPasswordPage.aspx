<%@ Page Title="" Language="C#" MasterPageFile="~/LogInMaster.master" AutoEventWireup="true" CodeFile="ResetPasswordPage.aspx.cs" Inherits="ResetPasswordPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="pagecontentinner">
    <div style="width:95%; margin: 0px auto;">
                  <h1>
                      Change Password</h1>
                
                <hr />
                <br />
            <asp:Panel ID="panForgetPassword" runat="server">
                <table class="tblCss">
                    <colgroup>
                        <col width="2%" />
                        <col width="15%" />
                    </colgroup>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="forminput" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAnswer" runat="server" Text="Old Password:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="forminput" Width="180px" TextMode="Password" />
                            </td>
                        </tr>

                                                <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="New Password:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="forminput" Width="180px" TextMode="Password"/>
                            </td>
                        </tr>

                        <tr>
                            <td>
                            </td>
                            <td style="padding: 10px 0px 20px 35px;">
                                <span>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick"
                                        CssClass="btncss" /></span>&nbsp;&nbsp; <span>
                                            <asp:Button ID="btnReset" runat="server" Text="Clear" OnClick="btnReset_OnClick"
                                                CssClass="btncss" />
                                        </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Panel ID="panPassword" runat="server" Visible="false" >
                <span style="padding-left: 20px; color: Green;"></span> <b>
                    <asp:Label ID="lblPassword" runat="server" />
                </b>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Log In" 
                    PostBackUrl="~/LogInPage.aspx" onclick="Button1_Click" />
            </asp:Panel>

                        <asp:Panel ID="panError" runat="server" Visible="false" >
                <span style="padding-left: 20px; color: Green;"></span> <b>
                    <asp:Label ID="lblError" runat="server" />
                </b>

            </asp:Panel>
            
        </div>
    </div>
</asp:Content>

