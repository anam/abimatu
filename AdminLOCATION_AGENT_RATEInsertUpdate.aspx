<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" 
CodeFile="AdminLOCATION_AGENT_RATEInsertUpdate.aspx.cs" Inherits="AdminLOCATION_AGENT_RATEInsertUpdate" Title="LOCATION_AGENT_RATE Insert/Update By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .tableCss
        {
        	text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="tableCss">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblLOCATIONID" runat="server" Text="LOCATIONID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlLOCATION" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAGENTID" runat="server" Text="AGENTID: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAGENT" runat="server">
                    </asp:DropDownList>
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
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                        OnClick="btnUpdate_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
