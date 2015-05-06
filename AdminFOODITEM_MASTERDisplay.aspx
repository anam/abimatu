<%@ Page Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="AdminFOODITEM_MASTERDisplay.aspx.cs" Inherits="AdminFOODITEM_MASTERDisplay" Title="Display FOODITEM_MASTER By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
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
        <li><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li ><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%>
        <li  id="selected"><a href="AdminFOODITEM_MASTERDisplay.aspx">Food Rate</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">

    <div>
        <a class="addNew" href="AdminFOODITEM_MASTERInsertUpdate.aspx?fOODITEM_MASTERID=0">Add New Food Iteam</a>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Location: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlLocation" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                onclick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvFOODITEM_MASTER" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("FOODITEM_MASTERID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ITEMCODE">
                    <ItemTemplate>
                        <asp:Label ID="lblITEMCODE" runat="server" Text='<%#Eval("ITEMCODE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ITEMNAME">
                    <ItemTemplate>
                        <asp:Label ID="lblITEMNAME" runat="server" Text='<%#Eval("ITEMNAME") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RATE">
                    <ItemTemplate>
                        <asp:Label ID="lblRATE" runat="server" Text='<%#Eval("RATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="AGENTID">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false" HeaderText="SEQ">
                    <ItemTemplate>
                        <asp:Label ID="lblSEQ" runat="server" Text='<%#Eval("SEQ") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("FOODITEM_MASTERID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
