<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true" CodeFile="ReportFoodLocationWise.aspx.cs" Inherits="ReportFoodLocationWise" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    var win = null;
    function printIt(printThis) {
        win = window.open();
        self.focus();
        win.document.open();
        win.document.write('<' + 'html' + '><' + 'head' + '><' + 'style' + '>');
        win.document.write('body, td { font-family: Verdana; font-size: 10pt;}');
        win.document.write('<' + '/' + 'style' + '><' + '/' + 'head' + '><' + 'body' + '>');
        win.document.write(printThis);
        win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
        win.document.close();
        win.print();
        win.close();
    }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">


<asp:HiddenField ID="hfIsLocation" runat="server" Value="0"/>
<asp:HiddenField ID="hfAgentID" runat="server" />

    <table>
    <tr>
        
            <td>
                <div class="memberReg">
                    <table>
                        <tr>
                    <td>
                        <asp:Button ID="btnBack" runat="server"  Text="Back" CssClass="btnregtop" OnClick="btnBack_Click" />
                    </td>
                    <td>
                        <a href="ReportLocationWise.aspx" class="btnregtop" >Money Transfer</a>

                    </td>
                    <td>
                        <a href="ReportFoodLocationWise.aspx" class="btnregtop" >Food<br />Transfer</a>
                    </td>
                    <td>
                        <a href="ReportLocationWiseWithSUS.aspx" class="btnregtop" >SUS<br />CUSTOMER</a>
                    </td>
                </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                Status
                            </td>
                            <td>
                                <asp:CheckBox ID="chkPending" runat="server" Text="PENDING" Checked="true" /><br />
                                <asp:CheckBox ID="chkPaid" runat="server" Text="PAID" Checked="true" /><br />
                                <asp:CheckBox ID="chkPartiallyPaid" runat="server" Text="PAETIALLY-PAID" Checked="true" /><br />
                                <asp:CheckBox ID="chkCanceled" runat="server" Text="RETURNED" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Agent
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAgent" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAgent_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr runat="server" id="trLocation">
                            <td>
                                Location
                                <br />
                                <asp:CheckBox ID="chkAllLocations" Checked="true" runat="server" />All
                                <asp:HiddenField ID="hfLoggedinLocationID" runat="server" Value="0" />
                            </td>
                            <td style="height: 200px; overflow: scroll;">
                                <div style="height: 200px; overflow: scroll;">
                                    <asp:GridView ID="dlLocation" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" ControlStyle-CssClass="gridIteamCenter">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chkSelect" />
                                                    <asp:HiddenField runat="server" ID="hfLocationID" Value='<%# Eval("LOCATIONID")  %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Country" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <%#String.Format("{0}",Eval("COUNTRY"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="City" HeaderStyle-Width="100px">
                                                <ItemTemplate>
                                                    <%#String.Format("{0}",Eval("CITY"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch" HeaderStyle-Width="150px">
                                                <ItemTemplate>
                                                    <%#String.Format("{0}",Eval("BRANCH"))%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txtMoney" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr runat="server" id="trFromDate">
                            <td>
                                From date
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>(select date form the
                                calendar)
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
                    <table id="tblSearchByRefCode" runat="server">
                        <tr>
                            <td>
                                Ref. Code
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefCodeForSearch" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSearchByRefCode" runat="server" Text="Search" OnClick="btnSearchByRefCode_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton ID="lnkPrint" Text="Print" runat="server" OnClientClick="javascript:printIt(document.getElementById('printThis').innerHTML);"></asp:LinkButton>
                <br /> 
                <div id='printThis'>

                    <div class="regRow" id="divListOfAllTransaction" runat="server">
                        <h1 style="font-size: 15px; margin-bottom: 10px">
                            Location Wise Report For Food Transfer</h1>
                        <asp:GridView ID="gvLocation" runat="server" CssClass="tutorial" AutoGenerateColumns="false"
                            ShowHeader="false" OnRowDataBound="gvLocation_RowDataBound">
                            <PagerStyle CssClass="papperStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Location" HeaderStyle-Width="330px">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hfLocationID" runat="server" Value='<%#Eval("LID") %>' />
                                                    Country :<asp:Label ID="Label2" Font-Bold="true" runat="server" Text='<%#Eval("COUNTRY") %>'></asp:Label>
                                                    <br />
                                                    City :<asp:Label ID="Label1" Font-Bold="true" runat="server" Text='<%#Eval("CITY") %>'></asp:Label>
                                                    <br />
                                                    Branch :<asp:Label ID="lblLocationName" Font-Bold="true" runat="server" Text='<%#Eval("BRANCH") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="padding: 5px 10px">
                                                        <asp:GridView ID="gvTRANS" runat="server" CssClass="innergrid" BorderStyle="None"
                                                            GridLines="Horizontal" AutoGenerateColumns="false" ShowHeader="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Date" ControlStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTransactionDate" Font-Bold="false" runat="server" Text='<%#Eval("CREATEDON","{0:MM/dd/yyyy}") %>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="REF Code" ControlStyle-Width="90px">
                                                                    <ItemTemplate>
                                                                        <a href='<%#Eval("REFCODE","EditFoodPayment.aspx?REFCODE={0}") %>' target="_blank">
                                                                            <asp:Label ID="lblReferenceCode" Font-Bold="false" runat="server" Text='<%#Eval("REFCODE") %>'>
                                                                            </asp:Label>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Customer Detail" ControlStyle-Width="180px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCustomerDetail" Font-Bold="false" runat="server" Text='<%#Eval("CUSTOMERFULLNAME")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Receiver Detail" ControlStyle-Width="180px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblReceiverDetail" Font-Bold="false" runat="server" Text='<%#Eval("RECEIVERFULLNAME")%>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Total Amount" >
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTotalCharge" Visible='<%#Eval("IsAmountVisible")%>' Font-Bold="false" runat="server" Text='<%#Eval("TOTALAMT","{0 :C}") %>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status" ControlStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblStatus" Font-Bold="false" runat="server" Text='<%#Eval("TRANSSTATUS") %>'>
                                                                        </asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                               <%-- <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <a id="hlEdit" visible='<%#Eval("IsEdit") %>' href='<%#Eval("REFCODE","EditPayment.aspx?REFCODE={0}") %>'
                                                                            target="_blank" runat="server">Edit</a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                              <%--  <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnIsPending" runat="server" Text="Pay?" Visible='<%#Eval("IsPending") %>'
                                                                            CommandArgument='<%#Eval("TRANSID") %>' OnClick="btnIsPending_Click" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                            </Columns>
                                                            <HeaderStyle BackColor="#AFA582" Font-Bold="True" ForeColor="White" CssClass="gridHeaderClass" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr style="font-weight: bold; color: Blue;">
                                                            <td style="width: 475px; text-align: right;">
                                                            </td>
                                                            <td style="width: 80px; text-align: right;">
                                                                SubTotal :&nbsp;&nbsp;
                                                            </td>
                                                            <td style="width: 78px;">
                                                                <asp:Label ID="lblSubTotalSendingAmount" runat="server" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 78px;">
                                                                <%--<asp:Label ID="lblSubTotalFees" runat="server" Text=""></asp:Label>--%>
                                                            </td>
                                                            <td style="width: 78px;">
                                                                <%--<asp:Label ID="lblSubTotalDiscount" runat="server" Text=""></asp:Label>--%>
                                                            </td>
                                                            <td style="width: 80px;">
                                                                <%--<asp:Label ID="lblSubTotalTotalAmount" runat="server" Text=""></asp:Label>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="Larger" Text="No money transfer data for the above search criterion"></asp:Label>
                                <asp:Label ID="Label12" runat="server" ForeColor="Green" Font-Size="Larger" Text="<br/>Please change the search criterion"></asp:Label>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="heading" />
                        </asp:GridView>
                    </div>
                    <table runat="server" id="tblTotal">
                        <tr style="font-weight: bold; color: Green;">
                            <td style="width: 155px; text-align: right;">
                            </td>
                            <td style="width: 100px; text-align: right;">
                                Total <asp:Label ID="lblTotalno" Visible="false" runat="server" Text="0" ForeColor="Red"></asp:Label>
                                :
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="lblSubTotalSendingAmountTotal" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 97px;">
                                <asp:Label ID="lblSubTotalFeesTotal" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 98px;">
                                <asp:Label ID="lblSubTotalDiscountTotal" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 100px;">
                                <asp:Label ID="lblSubTotalTotalAmountTotal" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

