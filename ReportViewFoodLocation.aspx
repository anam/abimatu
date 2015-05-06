<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true"
    CodeFile="ReportViewFoodLocation.aspx.cs" Inherits="ReportViewFoodLocation" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <table align="center" class="style1">
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblLocation" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblFromDate" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblToDate" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblAmount" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <asp:Label ID="lblagentID" runat="server" Text="" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    Width="900px" ToolPanelView="None" HasCrystalLogo="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregtop" OnClick="btnBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
