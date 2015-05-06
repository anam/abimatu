<%@ Page Title="" Language="C#" MasterPageFile="~/LogInMaster.master" AutoEventWireup="true" CodeFile="LogInPage.aspx.cs" Inherits="LogInPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="loginbg">
        <!-- Begin: loginbg -->
        <div class="login">
            <!-- Begin: login -->
            <h3>
                Agent / Location Login</h3>
            <div class="loginRow" style="display:none;">
                <label>
                    agent :</label>
                <asp:DropDownList ID="ddlAgent" runat="server">
                </asp:DropDownList>
            </div>
            <asp:LoginView ID="masterview" runat="server">
                <AnonymousTemplate>
                    <asp:Login ID="masterLogin" runat="server" Width="100%" DestinationPageUrl="~/Default.aspx"
                        OnAuthenticate="OnAuthenticate" meta:resourcekey="masterLoginResource1">
                        <LayoutTemplate>
                            <div class="loginRow">
                                <label>
                                    Login ID :</label>
                                <span class="txtinput">
                                    <asp:TextBox ID="UserName" runat="server" CssClass="txtlogin"></asp:TextBox>
                                </span>
                            </div>
                            <div class="loginRow">
                                <label>
                                    Password :</label>
                                <span class="txtinput">
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="txtlogin"></asp:TextBox>
                                </span>
                            </div>
                            <div class="loginRow">
                                <asp:Button ID="btnLogin" runat="server" CommandName="Login" ValidationGroup="Login"
                                    CssClass="btnlogin" />
                                <%--<input type="submit" class="btnexit" value="" />--%>
                            </div>

                            <%--<div class="loginRow">
                            If you are not registered ? Please &nbsp
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AgentRegistrationPage.aspx">Click</asp:HyperLink>&nbsp here.
                                
                                
                            </div>--%>
                            <div class="loginRow">
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ForgetPassword.aspx">Forget Password</asp:HyperLink>
                            <br />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ResetPasswordPage.aspx">Change Password</asp:HyperLink>
                            </div>

                        </LayoutTemplate>
                    </asp:Login>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <div style="text-align: center; padding-top: 10px;">
                        <asp:LoginName ID="memberLoginName" runat="server" ForeColor="#7E8D16" Font-Bold="true"
                            FormatString="Hey {0}!" Font-Size="20px" meta:resourcekey="memberLoginNameResource1" />
                        <br />
                        
                        <asp:LoginStatus ID="memberLoginStatus" runat="server" ForeColor="#000000" Font-Size="18px"
                            Font-Underline="true" Font-Bold="true" LogoutText="Log out" LogoutPageUrl="~/Default.aspx"
                            meta:resourcekey="memberLoginStatusResource1" />
                    </div>
                </LoggedInTemplate>
            </asp:LoginView>
            <br />
            
            <asp:Label ID="lblMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
        </div>
        <!-- End: login -->
    </div>
</asp:Content>

