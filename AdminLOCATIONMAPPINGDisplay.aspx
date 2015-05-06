<%@ Page Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="AdminLOCATIONMAPPINGDisplay.aspx.cs" Inherits="AdminLOCATIONMAPPINGDisplay"
    Title="Display LOCATIONMAPPING By Admin" %>

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
         <li><a href="AdminLOCATIONGROUPDisplay.aspx">All Location Groups</a></li>
        <li   id="selected"><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li ><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%>
        <li><a href="AdminFOODITEM_MASTERDisplay.aspx">Food Rate</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add( Not Grouped Location)" OnClick="btnAdd_Click" />
        <asp:GridView ID="gvLOCATIONMAPPING" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("LOCATIONMAPPINGID") %>'
                            OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="GROUP">
                    <ItemTemplate>
                        <asp:Label ID="lblLOCATIONGROUPID" runat="server" Text='<%#Eval("LOCATIONGROUPID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LOCATION">
                    <ItemTemplate>
                        <asp:Label ID="lblLOCATIONID" runat="server" Text='<%#Eval("LOCATIONID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("LOCATIONMAPPINGID") %>'
                            OnClick="lbDelete_Click" OnClientClick="return confirm('are you sure?');">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
