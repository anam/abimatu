<%@ Page Language="C#" MasterPageFile="~/MemberMasterWithLoader.master" AutoEventWireup="true"
    CodeFile="AdminLOCATIONMAPPINGInsertUpdate.aspx.cs" Inherits="AdminLOCATIONMAPPINGInsertUpdate"
    Title="LOCATIONMAPPING Insert/Update By Admin" %>

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
        <li id="selected"><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li ><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%>
        <li><a href="AdminFOODITEM_MASTERDisplay.aspx">Food Rate</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
   
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
   
    <div class="tableCss">
        <table style="width: 70%; margin: 10px auto;">
            <tr>
                <td>
                    LOCATION GROUP:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLOCATIONGROUP" runat="server" Height="20" AutoPostBack="true"
                        onselectedindexchanged="ddlLOCATIONGROUP_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    LOCATION:
                </td>
                <td>
                    <asp:DropDownList ID="ddlLOCATION" runat="server" Height="20">
                    </asp:DropDownList>
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
        <%--<asp:Button ID="Button1" runat="server" Text="Add( Not Grouped Location)" OnClick="btnAdd_Click" />--%>
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
    
   </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
