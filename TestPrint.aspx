<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestPrint.aspx.cs" Inherits="TestPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>

                <asp:TemplateField HeaderText="COUNTRY">
                    <ItemTemplate>
                        <asp:Label ID="lblCOUNTRY" runat="server" Text='<%#Eval("COUNTRY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CITY">
                    <ItemTemplate>
                        <asp:Label ID="lblCITY" runat="server" Text='<%#Eval("CITY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BRANCH">
                    <ItemTemplate>
                        <asp:Label ID="lblBRANCH" runat="server" Text='<%#Eval("BRANCH") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="BRANCH_CODE">
                    <ItemTemplate>
                        <asp:Label ID="lblBRANCH_CODE" runat="server" Text='<%#Eval("BRANCH_CODE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SEQUENCE">
                    <ItemTemplate>
                        <asp:Label ID="lblSEQUENCE" runat="server" Text='<%#Eval("SEQUENCE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTID">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTRATE">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTRATE" runat="server" Text='<%#Eval("AGENTRATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:Button ID="btnPrint" runat="server" Text="Print" onclick="btnPrint_Click" />
    </div>
    </form>
</body>
</html>
