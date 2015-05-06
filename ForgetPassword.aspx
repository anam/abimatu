<%@ Page Title="" Language="C#" MasterPageFile="~/LogInMaster.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="pagecontentinner">
    <div style="width:95%; margin: 0px auto;">
                  <h1>
                Forget Password</h1>
                
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
                                <asp:Label ID="lblAnswer" runat="server" Text="Answer:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAnswer" runat="server" CssClass="forminput" Width="180px" />
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
            <asp:Panel ID="panPassword" runat="server" Visible="false">
                <span style="padding-left: 20px; color: Green;">Your Password is sent to your Email Address :</span> <b>
                    <asp:Label ID="lblPassword" runat="server" />
                </b>
                <br />
                <br />
<%--                <asp:Button ID="Button1" runat="server" Text="Log In" 
                    PostBackUrl="~/LogInPage.aspx" />--%>
            </asp:Panel>
            <asp:Panel ID="panError" runat="server" Visible="false">
                <p style="padding-bottom: 20px; text-indent: 140px; color: Red; font-size: 13px;">
                    Your User name or Answer is not correct.<br />
                    <br />
                    <asp:Label ID="lblError" runat="server" />
                </p>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

