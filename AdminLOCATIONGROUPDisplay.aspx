<%@ Page Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="AdminLOCATIONGROUPDisplay.aspx.cs" Inherits="AdminLOCATIONGROUPDisplay"
    Title="Display LOCATIONGROUP By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: left;
        }
        
        .addNew
        {
            background: url("App_Themes/Default/images/interface/bg_memberlist.gif") no-repeat scroll left top transparent;
            color: #FFF;
            float: left;
            font-family: Arial,Helvetica,sans-serif;
            font-weight: bold;
            line-height: 31px;
            text-align: center;
            text-transform: capitalize;
            width: 234px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="Default.aspx">Back</a></li>
        <li><a href="AddLocation.aspx">Location</a></li>
        <li   id="selected"><a href="AdminLOCATIONGROUPDisplay.aspx">All Location Groups</a></li>
        <li><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li ><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%>
        <li ><a href="AdminFOODITEM_MASTERDisplay.aspx">Food Rate</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div class="tableCss">
        <table style="width: 70%; margin: 10px auto;">
            <tr>
                <td>
                    GROUP NAME:
                    <asp:RequiredFieldValidator ID="rq01" runat="server" ControlToValidate="txtGROUPNAME"
                        Text=">>" ValidationGroup="group" />
                </td>
                <td>
                    <asp:TextBox ID="txtGROUPNAME" runat="server" Width="250" Height="20">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblErr" runat="server" ForeColor="Maroon" />
                    <asp:HiddenField ID="hdnGroupID" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="group" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                        ValidationGroup="group" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="gvLOCATIONGROUP" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("LOCATIONGROUPID") %>'
                            OnClick="lbSelect_Click">
                            Update
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GROUPNAME">
                    <ItemTemplate>
                        <asp:Label ID="lblGROUPNAME" runat="server" Text='<%#Eval("GROUPNAME") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("LOCATIONGROUPID") %>'
                            OnClick="lbDelete_Click" OnClientClick="return confirm('are you sure?');">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
