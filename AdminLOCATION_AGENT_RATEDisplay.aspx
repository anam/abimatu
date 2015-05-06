<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    CodeFile="AdminLOCATION_AGENT_RATEDisplay.aspx.cs" Inherits="AdminLOCATION_AGENT_RATEDisplay" Title="Display LOCATION_AGENT_RATE By Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .gridCss
        {
            width: 100%;
            padding: 20px 10px 10px 10px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
        <asp:GridView ID="gvLOCATION_AGENT_RATE" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("LOCATION_AGENT_RATEID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LOCATIONID">
                    <ItemTemplate>
                        <asp:Label ID="lblLOCATIONID" runat="server" Text='<%#Eval("LOCATIONID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTID">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RATE">
                    <ItemTemplate>
                        <asp:Label ID="lblRATE" runat="server" Text='<%#Eval("RATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("LOCATION_AGENT_RATEID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
