<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="Transmit.aspx.cs" Inherits="SearchLocation" %>
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="SearchSenderPage.aspx">Search Sender</a></li>
        <li><a href="CUSTOMERInsertUpdate.aspx?cUSTOMERID=0">Sender</a></li>
        <li><a href="SearchReceiverPage.aspx">Search Receiver</a></li>
        <li><a href="ReceiverInsertUpdate.aspx?rECEIVERID=0">Receiver</a></li>
        <li><a href="SearchLocation.aspx">Search Location</a></li>
        <li><a href="Payment.aspx">Payment</a></li>
        <li id="selected"><a href="Transmit.aspx">Transmit</a></li>
        <li><a href="Default.aspx">Back</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div>       
        <table style="width: 100%; table-layout: fixed; padding: 110px 0;">
            <tr>
                <td style="font-weight: bold; padding-left: 150px;">
                    <b style="font-size: 40px; color: Red;">Payment
                        Due</b>
                    <span  style="font-weight: normal; "><br/>Reference CODE: <asp:Label ID="lblReferenceCODE" Font-Bold="true" Font-Size="25px" ForeColor="Green" runat="server" ></asp:Label></span>
                        
                </td>
            </tr>

        </table>
    </div>
    <div class="regRow">
        <div class="regbtnrow" style=" width:600px;">
            <asp:Button ID="btnReceipt" runat="server" Text="Receipt" CssClass="btnregtop" 
                onclick="btnReceipt_Click"  />
            <asp:Button ID="btnSearch" runat="server" Text="Close" CssClass="btnregtop" OnClick="btnSearch_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Print" CssClass="btnregtop" OnClick="btnClear_Click" />
            <asp:Button ID="btnAnotherTransaction" runat="server" 
                            Text="Another Transaction" CssClass="btnregtop_payment" 
                            onclick="btnAnotherTransaction_Click"  />
        </div>
    </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px" Visible="false">
    </rsweb:ReportViewer>


</asp:Content>
