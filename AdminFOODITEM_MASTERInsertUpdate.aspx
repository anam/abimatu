<%@ Page Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true" 
CodeFile="AdminFOODITEM_MASTERInsertUpdate.aspx.cs" Inherits="AdminFOODITEM_MASTERInsertUpdate" Title="FOODITEM_MASTER Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tableCss
        {
        	text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li id="selected"><a href="AdminFOODITEM_MASTERDisplay.aspx">Back</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div class="tableCss">
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
                    <asp:Label ID="lblITEMCODE" runat="server" Text="ITEM CODE: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtITEMCODE" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblITEMNAME" runat="server" Text="ITEM NAME: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtITEMNAME" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRATE" runat="server" Text="RATE: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRATE" runat="server" Text="">
                    </asp:TextBox>
                </td>
            </tr>
            
            <tr style="display:none;">
                <td>
                    <asp:Label ID="lblSEQ" runat="server" Text="SEQ: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSEQ" runat="server" Text="0">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" ControlToValidate="txtITEMNAME" ValidationGroup="FoodIteam" ErrorMessage="Item Name Required<br/>"></asp:RequiredFieldValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRATE" ValidationGroup="FoodIteam" ErrorMessage="Item Rate Required<br/>"></asp:RequiredFieldValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtITEMCODE" ValidationGroup="FoodIteam" ErrorMessage="Item Code Required<br/>"></asp:RequiredFieldValidator>
                     <%--<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="FoodIteam" runat="server" />--%>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" ValidationGroup="FoodIteam" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
