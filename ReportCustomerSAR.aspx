<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true"
    CodeFile="ReportCustomerSAR.aspx.cs" Inherits="ReportCustomerSAR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <div class="memberReg">
        <div class="regRow">
            <asp:HiddenField ID="hfAgentID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregtop" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr runat="server" id="trFromDate">
                    <td>
                        From date
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>(select date form the calendar)
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                            CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trToDate">
                    <td>
                        To date
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>(select date form the calendar)
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                            CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnPrint" runat="server" Text="Download pdf" OnClick="btnPrint_Click" />
                    </td>
                </tr>
            </table>
            <h1 style="font-size: 15px; margin-bottom: 10px">
                Customer SAR Report</h1>
            <asp:GridView ID="gvCustomer" runat="server" CssClass="tutorial" AutoGenerateColumns="false"
                AllowPaging="false" ShowHeader="false" OnRowDataBound="gvCustomer_RowDataBound">
                <PagerStyle CssClass="papperStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="Customer" HeaderStyle-Width="330px">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 450px;">
                                                    <span style="font-weight: bold; font-size: 14px;">Customer Name : </span>
                                                    <asp:Label ID="lblCUSTID" runat="server" Text='<%#Eval("CUSTID") %>' Visible="false">
                                                    </asp:Label>
                                                    <asp:Label ID="lblCUSTNAME" runat="server">
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTRANSDT" runat="server" Text='<%#Eval("TRANSDT") %>' Visible="false">
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    <span style="font-weight: bold; font-size: 14px;">Total Amount : </span>
                                                    <asp:Label ID="lblTRANSTOTALAMOUNT" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT","{0 :C}") %>'>
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 20px;">
                                        <div style="padding: 5px 10px">
                                            <asp:GridView ID="gvTRANS" runat="server" CssClass="innergrid" BorderStyle="None"
                                                GridLines="None" AutoGenerateColumns="false" ShowHeader="true" OnRowDataBound="gvTRANS_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Transaction Date" ControlStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTransactionDate" Font-Bold="false" runat="server" Text='<%#Eval("CREATEDON","{0:MM/dd/yyyy}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reference Code" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReferenceCode" Font-Bold="false" runat="server" Text='<%#Eval("REFCODE") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="RECEIVER" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRECEIVERID" Font-Bold="false" runat="server" Text='<%#Eval("RECEIVERID") %>' Visible="false">
                                                            </asp:Label>
                                                            <asp:Label ID="lblReceiver" Font-Bold="false" runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Location" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLOCATIONID" Font-Bold="false" runat="server" Text='<%#Eval("LOCATIONID") %>' Visible="false">
                                                            </asp:Label>
                                                            <asp:Label ID="lblLocation" Font-Bold="false" runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSendingAmount" Font-Bold="false" runat="server" Text='<%#Eval("TRANSAMOUNT","{0:C}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fees" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblServiceCharge" Font-Bold="false" runat="server" Text='<%#Eval("TRANSFEES","{0 :C}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Discount" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDiscount" Font-Bold="false" runat="server" Text='<%#Eval("TRANSPROMO","{0 :C}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalCharge" Font-Bold="false" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT","{0 :C}") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#AFA582" Font-Bold="True" ForeColor="White" CssClass="gridHeaderClass" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="heading" />
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
