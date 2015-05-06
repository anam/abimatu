<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="SuspiciousActivityPage.aspx.cs" Inherits="SuspiciousActivityPage" %>
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="SearchSenderPage.aspx">Back</a></li>
        <%--        <li><a href="CUSTOMERInsertUpdate.aspx?cUSTOMERID=0">Sender</a></li>
        <li><a href="SearchReceiverPage.aspx">Search Receiver</a></li>
        <li><a href="ReceiverInsertUpdate.aspx?rECEIVERID=0">Receiver</a></li>
        <li><a href="SearchLocation.aspx">Search Location</a></li>
        <li><a href="Payment.aspx">Payment</a></li>
                <li><a href="Transmit.aspx">Transmit</a></li><li><a href="Default.aspx">Back</a></li>--%>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div>
        <div class="susDIv">
            <fieldset class="fieldsetcls">
                <legend class="lgdcls">Contact For Assistance</legend>
                <div>
                    <table style="width: 98%; table-layout: fixed;">
                        <colgroup>
                            <col width="40%" style="font-weight: bold;" />
                            <col width="60%" align="left" />
                        </colgroup>
                        <tr>
                            <td>
                                Designated Contact Officer :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="txtDesignatedContactOfficer" runat="server" Text="" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtPHONE" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            Date :
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtdate" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomRight"
                                                PopupButtonID="txtdate" TargetControlID="txtdate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Agency(If not filled by Money Service Business) :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="txtAgency" runat="server" Text="" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div class="susDIv">
            <fieldset class="fieldsetcls">
                <legend class="lgdcls">Subject Information Part 1</legend>
                <div>
                    <table style="width: 98%; table-layout: fixed;">
                        <colgroup>
                            <col width="13%" style="font-weight: bold;" />
                            <col width="87%" align="left" />
                        </colgroup>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkAmending" runat="server" 
                                                Text="Check this box if amending or correcting a prior report" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkRecurring" runat="server" 
                                                Text="Check this box if this is a recurring report" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkMultiple" runat="server" Text="Multiple Subjects" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Subject Type :
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblSubjectType" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Purchaser / Sender" Value="Purchaser / Sender" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Payee / Receiver" Value="Payee / Receiver"></asp:ListItem>
                                    <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                LastName :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTLNAME" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            FirstName:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTFNAME" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            MiddleName:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px;">
                                                <asp:TextBox ID="txtCUSTMNAME" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                    </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="txtCUSTADDRESS1" runat="server" Text="" CssClass="txtRegbig2">
                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                State :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTSTATE" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            City:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTCITY" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            Zip:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTZIP" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Government Issued Identification (If Available)"
                                    CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Driver's License / State ID" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Passport" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Alien Registration" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Others" Value=""></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="TextBox5" runat="server" Text="" CssClass="txtRegsmall"> 
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Number :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTIDNUMBER" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            Issuing State / Country :
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuingState_Country" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                SSN / EIN :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTSSN" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            DOB:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTDOB" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupPosition="BottomRight"
                                                PopupButtonID="txtCUSTDOB" TargetControlID="txtCUSTDOB">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td style="width: 10px;">
                                            Phone#:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCUSTHPHONE" runat="server" Text="" CssClass="txtRegsmall"> 
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div class="susDIv">
            <fieldset class="fieldsetcls">
                <legend class="lgdcls">Suspicious Activity Information</legend>
                <div>
                    <table style="width: 98%; table-layout: fixed;">
                        <colgroup>
                            <col width="5%" style="font-weight: bold;" />
                            <col width="95%" align="left" />
                        </colgroup>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Date or date range of suspicious activity"
                                    CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            From Date :
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtFromDate" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" PopupPosition="BottomRight"
                                                PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            To Date :
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtToDate" runat="server" Text="" CssClass="txtRegsmall"> 
                                                </asp:TextBox>
                                            </span>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupPosition="BottomRight"
                                                PopupButtonID="txtToDate" TargetControlID="txtToDate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            Amount $ :
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtTotalAmount" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="chkUnAmount" runat="server" Text="Amount Unknown" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Category of suspicious activity (Check all that apply)"
                                    CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="cblSusCategory" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Money laundering" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Structuring" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Terrorist financing" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Other(specify)" Value=""></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtSusActivityOther" runat="server" Text="" CssClass="txtRegsmall"> 
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Financial services involved in the suspicious avtivity and character of the suspicious activity including ubusual use (check all that apply)"
                                    CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="cblFinancialService" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Money Order" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Traveler's Check" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Money Transfer" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Others" Value=""></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtOtherFinancialService" runat="server" Text="" CssClass="txtRegsmall"> 
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Check all of the following that apply"
                                    CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="cblSuspiciousActivity" runat="server" RepeatDirection="Horizontal"
                                    RepeatColumns="2">
                                    <asp:ListItem Text="Alter transaction to avoid completion of funds transfer record or money order or traveler's check record ($3000 or more)"
                                        Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Comes in frequently and purchases lessthan $3000" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Alter transaction to avoid filling a CTR forn ($10,000 or more)"
                                        Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Changes spelling or arrangement of name" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="Individual(S using multiple or false identification documents)"
                                        Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Two or more individuals using the similar / same identification"
                                        Value="8"></asp:ListItem>
                                    <asp:ListItem Text="Two or more individuals working together" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Same individual(s) using multiple locations over a short time period"
                                        Value="9"></asp:ListItem>
                                    <asp:ListItem Text="offers a bribe in the form of a tip / gratuity" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Exchange small bills for large bills or vice versa" Value="10"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div class="susDIv">
            <fieldset class="fieldsetcls">
                <legend class="lgdcls">Suspicious Activity Information Continued</legend>
                <div>
                    <table style="width: 98%; table-layout: fixed;">
                        <colgroup>
                            <col width="5%" style="font-weight: bold;" />
                            <col width="95%" align="left" />
                        </colgroup>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Purchase and redemptions (check box 'p' for purchase or box 'R' for redemption)"
                                    CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <colgroup>
                                        <col width="10%" />
                                        <col width="5%" />
                                        <col width="5%" />
                                        <col width="30%" />
                                        <col width="20%" />
                                        <col width="30%" />
                                    </colgroup>
                                    <tr>
                                        <td>
                                            Instrument
                                        </td>
                                        <td>
                                            P
                                        </td>
                                        <td>
                                            R
                                        </td>
                                        <td>
                                            Issuers
                                        </td>
                                        <td>
                                            Total Instruments
                                        </td>
                                        <td>
                                            Total Amount (US Dollars)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP1" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR1" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer1" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments1" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount1" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Money Orders
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP2" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR2" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer2" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments2" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount2" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP3" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR3" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer3" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments3" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount3" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP4" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR4" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer4" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments4" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount4" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Travelr&#39;s Check
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP5" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR5" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer5" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments5" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount5" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP6" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR6" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer6" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments6" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount6" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP7" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR7" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer7" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments7" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount7" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Money Transfers
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP8" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR8" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer8" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments8" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount8" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkP9" runat="server" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ChkR9" runat="server" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtIssuer9" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtInstruments9" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtAmount9" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <colgroup>
                                        <col width="10%" />
                                        <col width="5%" />
                                        <col width="5%" />
                                        <col width="30%" />
                                        <col width="20%" />
                                        <col width="30%" />
                                    </colgroup>
                                    <tr>
                                        <td>
                                            Currency Exchenges
                                        </td>
                                        <td>
                                            Tendered Currency / Instrument
                                        </td>
                                        <td>
                                            Country
                                        </td>
                                        <td>
                                            Received Currency
                                        </td>
                                        <td>
                                            Country
                                        </td>
                                        <td>
                                            Amount (US Dollars)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="Chkbulk1" runat="server" Text="If bulk small currency" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtCurrency1" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtCountry1" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtReceivedCurrency1" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtReceivedCountry1" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtReceivedAmount1" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="Chkbulk2" runat="server" Text="If bulk small currency" />
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtCurrency2" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtCountry2" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtReceivedCurrency2" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtReceivedCountry2" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px">
                                                <asp:TextBox ID="txtReceivedAmount2" runat="server" Text="" CssClass="txtRegsmall" Width="100px">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div class="susDIv">
            <fieldset class="fieldsetcls">
                <legend class="lgdcls">Transaction Location</legend>
                <div>
                    <table style="width: 98%; table-layout: fixed;">
                        <colgroup>
                            <col width="25%" style="font-weight: bold;" />
                            <col width="75%" align="left" />
                        </colgroup>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="Multiple transaction location" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Type of business location" CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblTypeBusiness" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Selling business location" Value="Selling business location" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Paying business location" Value="Paying business location"></asp:ListItem>
                                    <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Legal name of business :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox26" runat="server" Text="ABIMATU ENTERPRISE" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Doing Business as :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox27" runat="server" Text="" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox28" runat="server" Text="5010 SUNNYSIDE AVE" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                City :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="TextBox29" runat="server" Text="BELTSVILLE" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            State:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="TextBox32" runat="server" Text="MD" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            Zip#:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px;">
                                                <asp:TextBox ID="TextBox33" runat="server" Text="20705" CssClass="txtRegsmall" Width="100px"> 
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                SSN/EIN :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox30" runat="server" Text="" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox31" runat="server" Text="3014747188" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
        <div class="susDIv">
            <fieldset class="fieldsetcls">
                <legend class="lgdcls">Reporting Business</legend>
                <div>
                    <table style="width: 98%; table-layout: fixed;">
                        <colgroup>
                            <col width="25%" style="font-weight: bold;" />
                            <col width="75%" align="left" />
                        </colgroup>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="The Reporting Business is the same as the Transaction Location (go to part V)" />
                            </td>
                        </tr>
                        <%--                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Type of business location" CssClass="suslabel"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                Legal name of business :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox34" runat="server" Text="ABIMATU ENTERPRISE" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Doing Business as :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox35" runat="server" Text="" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox36" runat="server" Text="5010 SUNNYSIDE AVE" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                City :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="TextBox37" runat="server" Text="BELTSVILLE" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            State:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="TextBox38" runat="server" Text="MD" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td style="width: 10px;">
                                            Zip#:
                                        </td>
                                        <td>
                                            <span class="regBoxsmall" style="width: 100px;">
                                                <asp:TextBox ID="TextBox39" runat="server" Text="20705" CssClass="txtRegsmall" Width="100px"> 
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                SSN/EIN :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox40" runat="server" Text="" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone :
                            </td>
                            <td>
                                <span class="regBoxbig2">
                                    <asp:TextBox ID="TextBox41" runat="server" Text="3014747188" CssClass="txtRegbig2">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>


        <div style=" width:100%; float:left;">
        
        <br />
        <br />
        <center>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnregbot" OnClick="btnPrint_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnregbot" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </center>

            <br />
    <br />

    <rsweb:reportviewer ID="ReportViewer1" runat="server" Width="100%" Visible="true">
    </rsweb:reportviewer>
    </div>
    </div>



</asp:Content>
