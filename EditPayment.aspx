<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="EditPayment.aspx.cs" Inherits="EditPayment" %>
        <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtSendingAmount.ClientID%>").value == "") {
                alert("Sending Amount can not be blank");
                document.getElementById("<%=txtSendingAmount.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtServiceCharge.ClientID%>").value == "") {
                alert("Service Charge can not be blank");
                document.getElementById("<%=txtServiceCharge.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtOtherServiceCharge.ClientID%>").value == "") {
                alert("Other Service Charge can not be blank");
                document.getElementById("<%=txtOtherServiceCharge.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtDiscount.ClientID%>").value == "") {
                alert("Discount can not be blank");
                document.getElementById("<%=txtDiscount.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtTotalCharge.ClientID%>").value == "") {
                alert("Total Charge can not be blank");
                document.getElementById("<%=txtTotalCharge.ClientID%>").focus();
                return false;
            }

            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtSendingAmount.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtSendingAmount.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Sending Amount");
                    document.getElementById("<%=txtSendingAmount.ClientID%>").focus();
                    return false;
                }
            }

            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtServiceCharge.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtServiceCharge.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Service Charge");
                    document.getElementById("<%=txtServiceCharge.ClientID%>").focus();
                    return false;
                }
            }


            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtOtherServiceCharge.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtOtherServiceCharge.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Other Service Charge");
                    document.getElementById("<%=txtOtherServiceCharge.ClientID%>").focus();
                    return false;
                }
            }



            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtDiscount.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtDiscount.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Discount");
                    document.getElementById("<%=txtDiscount.ClientID%>").focus();
                    return false;
                }
            }


            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtTotalCharge.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtTotalCharge.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Total Charge");
                    document.getElementById("<%=txtTotalCharge.ClientID%>").focus();
                    return false;
                }
            }

            return true;
        }
    </script>

        <script language="JavaScript" type="text/javascript">
            function calculation() {

                var SendingAmount = document.getElementById("<%=txtSendingAmount.ClientID%>").value;
                //            
                var OtherServiceCharge = document.getElementById("<%=txtOtherServiceCharge.ClientID%>").value;
                var Discount = document.getElementById("<%=txtDiscount.ClientID%>").value;
                var TotalCharge = document.getElementById("<%=txtTotalCharge.ClientID%>").value;

                var ServiceChargePre = SendingAmount * 10 / 100;

                document.getElementById("<%=txtServiceCharge.ClientID%>").value = ServiceChargePre.toFixed(2);
                var ServiceCharge = document.getElementById("<%=txtServiceCharge.ClientID%>").value;
                var totalAmount = parseFloat(SendingAmount) + parseFloat(ServiceCharge) + parseFloat(OtherServiceCharge) - parseFloat(Discount);
                document.getElementById("<%=txtTotalCharge.ClientID%>").value = totalAmount.toFixed(2);
            }
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li id="selected"><a href="Default.aspx">Back to Menu</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div class="memberReg">
        <!-- Begin: memberReg -->
        <asp:Panel ID="panSearch" runat="server" Visible="true">
            <div>
                <table style="width: 100%; table-layout: fixed;">
                    <colgroup>
                        <col width="15%" style="font-weight: bold;" />
                        <col width="85%" align="left" />
                    </colgroup>
                    <tr>
                        <td>
                            Reference Code:
                        </td>
                        <td>
                            <span class="regBoxsmall">
                                <asp:TextBox ID="txtReferenceCode" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                <asp:HiddenField ID="hfReferenceCode" runat="server" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btnregtop" />
                            <asp:Button ID="btnComplianceForm" runat="server" Text="Compliance Form"  
                                CssClass="btnregtop" onclick="btnComplianceForm_Click" />
                            <%--<asp:Button ID="btn_BACK" runat="server" Text="Back" 
        onclick="btnBack_Click" CssClass="btnregtop" />--%>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="panData" runat="server" Visible="false">
            <div class="nameRow">
                <table style="width: 100%; table-layout: fixed;">
                    <colgroup>
                        <col width="15%" style="font-weight: bold;" />
                        <col width="85%" align="left" />
                    </colgroup>
                    <tr>
                        <td>
                        </td>
                        <td style="padding-left: 3px;">
                            <div class="memberBotBtnlist">
                                <!-- Begin: memberBotBtnlist -->
                                <asp:Button ID="btnBack" runat="server" Visible="false" Text="Back" CssClass="btnregbot" OnClick="btnBack_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CssClass="btnregbot" OnClick="btnUpdate_Click"
                                    OnClientClick=" return validate()" />
                                <asp:Button ID="btnDelete" runat="server" Text="Return" Visible="false" CssClass="btnregbot" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnPending" runat="server" Text="PENDING" Visible="false" 
                                    CssClass="btnregbot" onclick="btnPending_Click" />
                                    <asp:Button ID="btnHOLDING" runat="server" Text="HOLDING" Visible="false" 
                                    CssClass="btnregbot" onclick="btnHOLDING_Click" />
                                    <asp:Button ID="btnPaid" runat="server" Text="PAID" Visible="false" 
                                    CssClass="btnregbot" onclick="btnPaid_Click" />
                                <asp:Button ID="btnReturn" runat="server" Text="Delete" Visible="false" CssClass="btnregbot" OnClick="btnCancel_Click" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnregbot" OnClick="btnPrint_Click" />
                                <br /><br /><br />
                                Receiver ID:  <asp:TextBox ID="txtReceiverEmail" runat="server"  CssClass="txtRegbig"></asp:TextBox>(Only For Payment time)
                                <br />
                                <asp:Button ID="btnFullPayment" runat="server" Text="Pay" CssClass="btnregbot" 
                                    onclick="btnFullPayment_Click" />
                                
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Sender Name :
                        </td>
                        <td>
                            <span class="regBoxbig1">
                                <asp:TextBox ID="txtName" Enabled="false" runat="server" Text="" CssClass="txtRegbig1">
                            </asp:TextBox>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address1 :
                        </td>
                        <td>
                            <span class="regBoxbig1">
                                <asp:TextBox ID="txtAddress1" Enabled="false"  runat="server" Text="" CssClass="txtRegbig1">
                            </asp:TextBox>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address2 :
                        </td>
                        <td>
                            <span class="regBoxbig1">
                                <asp:TextBox ID="txtAddress2" Enabled="false"  runat="server" Text="" CssClass="txtRegbig1">
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
                                            <asp:TextBox ID="txtCity" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                                        </span>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;State:
                                    </td>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtState" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                        </span>
                                    </td>
                                    <td style="width: 10px;">
                                        Zip:
                                    </td>
                                    <td style="width: 10px;">
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtZIP" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone Number :
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtPhoneNumber" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                                        </span>
                                    </td>
                                    <td>
                                        Branch :
                                    </td>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtCell" Enabled="false"  runat="server" Text="" Visible="false" CssClass="txtRegsmall">
                            </asp:TextBox>
                                            <asp:TextBox ID="txtBranch" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Receiver Name :
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtFirstName" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                                            </asp:TextBox>
                                        </span>
                                    </td>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtMiddleName" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                                            </asp:TextBox>
                                        </span>
                                    </td>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtLastName" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
                                            </asp:TextBox>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Receiver City :
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtReceiverCity"  Enabled="false" runat="server" Text="" CssClass="txtRegsmall">
                                            </asp:TextBox>
                                        </span>
                                    </td>
                                    <td>
                                        State :
                                    </td>
                                    <td>
                                        <span class="regBoxsmall">
                                            <asp:TextBox ID="txtReceiverCountry" Enabled="false"  runat="server" Text="" CssClass="txtRegsmall">
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
                            <asp:Button ID="btnEditReceiver" runat="server" Text="Edit Receiver" 
                                onclick="btnEditReceiver_Click" CssClass="btnregbot"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                Sending Amount (USD)$
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:TextBox ID="txtSendingAmount" runat="server" CssClass="txtRegbig" Text="0" onkeyup="calculation()">
                                        </asp:TextBox>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Service Charges$
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:TextBox ID="txtServiceCharge" runat="server" CssClass="txtRegbig" Text="0" onkeyup="calculation()" >
                                        </asp:TextBox>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr style="display:none;">
                                            <td align="right">
                                                Why Other Service Charges
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                <asp:TextBox ID="txtCauseOtherServiceCharges_unused" runat="server"  CssClass="txtRegbig" >
                                                    </asp:TextBox>
                                                    </span>
                                            </td>                                
                                        </tr>
                                        <tr>
                                <td align="right">
                                  Other Service Charges$
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:TextBox ID="txtOtherServiceCharge" runat="server"  CssClass="txtRegbig" >
                                        </asp:TextBox>
                                        </span>
                                </td>                                
                            </tr>
                                        <tr>
                                            <td align="right">
                                                Promotional Discount$
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="txtRegbig" Text="0" onkeyup="calculation()">
                                        </asp:TextBox>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="color: Red">
                                                Total Charges(USD)$
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:TextBox ID="txtTotalCharge" runat="server" CssClass="txtRegbig" Text="0">
                                        </asp:TextBox>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td align="right">
                                                Rate
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:Label ID="lblRate" runat="server" Text="0"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td align="right">
                                                Amount Received
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:Label ID="lblAmountReceived" runat="server" Text="0"></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td align="right" style="color: Green; font-size: 20px;">
                                                Reference Code
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:Label ID="lblReferenceCode" runat="server" Text=""></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Status
                                            </td>
                                            <td>
                                                <span class="regBoxbig_small">
                                                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkSMR" runat="server" Text="" />
                                    </td>
                                    <td>
                                        Send Message to Receiver
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkCRF" runat="server" Text="" />
                                    </td>
                                    <td>
                                        Call my receiver when funds are available
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Others:
                        </td>
                        <td>
                            <span class="regBoxbig1_others">
                                <asp:TextBox ID="txtCauseOtherServiceCharges" runat="server" Text="" TextMode="MultiLine" Width="500px" Height="100px" CssClass="txtRegbig1">
                                </asp:TextBox>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Test Question:
                        </td>
                        <td>
                            <span class="regBoxbig1">
                                <asp:TextBox ID="txtTestQuestion" runat="server" Text="" CssClass="txtRegbig1">
                            </asp:TextBox>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Test Answer:
                        </td>
                        <td>
                            <span class="regBoxbig1">
                                <asp:TextBox ID="txtTestAnswer" runat="server" Text="" CssClass="txtRegbig1">
                            </asp:TextBox>
                            </span>
                        </td>
                    </tr>
                    
                </table>
            </div>
        </asp:Panel>


            <div style="width: 100%; float: left;">
        
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        
    </div>

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px" Visible="false">
    </rsweb:ReportViewer>
    </div>
</asp:Content>
