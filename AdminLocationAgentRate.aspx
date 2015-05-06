<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true" CodeFile="AdminLocationAgentRate.aspx.cs" Inherits="AdminLocationAgentRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" Runat="Server">
<ul>
        <li><a href="Default.aspx">Back</a></li>
        <li><a href="AddLocation.aspx">Location</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li ><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li  id="selected"><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%><li><a href="AdminFOODITEM_MASTERDisplay.aspx">Food Rate</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" Runat="Server">
    <h3 style="text-indent: 20px; color: #000000; margin-bottom: 10px;">
            Location and Agent wise Rate</h3>
        <hr />
        <br />
    Location: <asp:DropDownList ID="ddlLOCATION" runat="server" AutoPostBack="true"
        onselectedindexchanged="ddlLOCATION_SelectedIndexChanged">
    </asp:DropDownList>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" 
    onclick="btnUpdate_Click" />

    <asp:GridView ID="gvAgentRate" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Agent" HeaderStyle-Width="200px">
                <ItemTemplate>
                    <asp:Label ID="lblAGENTID" runat="server" Visible="false" Text='<%#Eval("AGENTID") %>'>'></asp:Label>
                    <asp:Label ID="lblAGENTNAME" runat="server" Text='<%#Eval("AGENTNAME") %>'>'></asp:Label>
                    <asp:Label ID="lblLOCATION_AGENT_RATEID" runat="server" Visible="false" Text='<%#Eval("LOCATION_AGENT_RATEID") %>'>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate">
                <ItemTemplate>
                    <asp:TextBox ID="txtRATE" runat="server" Text='<%#Eval("RATE") %>'></asp:TextBox>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Content>

