
<%@  Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
       CodeFile="AdminDisplayUSER_Membership.aspx.cs" Inherits="AdminDisplayUSER_Membership" Title="USER_Membership Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function SelectSingleRadiobutton(rdBtnID) {
            //process the radio button Being checked.
            var rduser = $(document.getElementById(rdBtnID));
            rduser.closest('TR').addClass('SelectedRowStyle');
            rduser.checked = true;
            // process all other radio buttons (excluding the the radio button Being checked).
            var list = rduser.closest('table').find("INPUT[type='radio']").not(rduser);
            list.attr('checked', false);
            list.closest('TR').removeClass('SelectedRowStyle');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="Default.aspx">Back</a></li>
        <li><a href="AddLocation.aspx">Location</a></li>
        <li><a href="AdminLOCATIONGROUPDisplay.aspx">All Location Groups</a></li>
        <li><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%><li><a href="AdminFOODITEM_MASTERDisplay.aspx">
            Food Rate</a></li>
        <li><a href="DatabaseBackup.aspx">Database backup</a></li>
        <li  id="selected"><a href="AdminDisplayUSER_Membership.aspx">Unloack User</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div class="content-box">
        <div class="header">
            <h3>
               List of Locked User</h3>
        </div>
        <div class="inner-content">
            <asp:GridView ID="gvUSER_Membership" runat="server" AutoGenerateColumns="false"
                CssClass="gridCss"
            GridLines="Both" BorderColor="#CDCDCD">
                
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Lock Date">
                        <ItemTemplate>
                            <asp:Label ID="lblLockDate" runat="server" Text='<%#Eval("LastLockoutDate", "{0:dd MMM yyyy}") %>'>
 	                        </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Unlock">
                        <ItemTemplate>
                            
                            <asp:ImageButton runat="server" ID="lbSelect" CommandArgument='<%#Eval("UserId") %>'
                                AlternateText="Approve" OnClick="lbSelect_Click" ImageUrl="~/App_Themes/CoffeyGreen/images/icon-pencil.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="paging">
                <div class="viewpageinfo">
                    <%--View 1 -10 of 13--%>
                    Show
                </div>
                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                    <asp:ListItem Text="100" Value="100" />
                    <asp:ListItem Text="250" Value="250" />
                    <asp:ListItem Text="500" Value="500" />
                </asp:DropDownList>
                <div class="pagelist">
                    <asp:Repeater ID="rptPager" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
