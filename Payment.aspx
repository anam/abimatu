<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="Payment.aspx.cs" Inherits="SearchSenderPage" %>

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
        <li><a href="SearchSenderPage.aspx">Search Sender</a></li>
        <li><a href="CUSTOMERInsertUpdate.aspx?cUSTOMERID=0">Sender</a></li>
        <li><a href="SearchReceiverPage.aspx">Search Receiver</a></li>
        <li><a href="ReceiverInsertUpdate.aspx?rECEIVERID=0">Receiver</a></li>
        <li><a href="SearchLocation.aspx">Search Location</a></li>
        <li  id="selected"><a href="Payment.aspx">Payment</a></li>
                <li><a href="Transmit.aspx">Transmit</a></li><li><a href="Default.aspx">Back</a></li>
                        </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div class="memberReg">
        <!-- Begin: memberReg -->
        <div class="nameRow">
           <table style="width: 100%; table-layout: fixed;">
                <colgroup>
                    <col width="15%" style=" font-weight:bold;" />
                    <col width="85%" align="left" />
                </colgroup>
                
               
                <tr>
                    <td>
                        Sender Name :
                    </td>
                    <td>
                        <span class="regBoxbig1">
                            <asp:TextBox ID="txtName" runat="server" Text="" CssClass="txtRegbig1">
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
                            <asp:TextBox ID="txtAddress1" runat="server" Text="" CssClass="txtRegbig1">
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
                            <asp:TextBox ID="txtAddress2" runat="server" Text="" CssClass="txtRegbig1">
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
                    <asp:TextBox ID="txtCity" runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                            </span>
                            </td>
                            <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;State: 
                            </td>
                                <td>
                           
                                <span class="regBoxsmall">
                                        <asp:TextBox ID="txtState" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>
                                
                                <td style="width: 10px;">
                                    Zip:
                                </td>
                                <td style="width: 10px;">
                                    <span class="regBoxsmall">
                                        <asp:TextBox ID="txtZIP" runat="server" Text="" CssClass="txtRegsmall">
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
                    <asp:TextBox ID="txtPhoneNumber" runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                            </span>
                    </td>
                    <td>
                    Branch :
                    </td>
                    <td>
                    <span class="regBoxsmall">
                     <asp:TextBox ID="txtCell" runat="server" Text="" Visible="false" CssClass="txtRegsmall">
                            </asp:TextBox>
                            <asp:TextBox ID="txtBranch" runat="server"  Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                            </span>
                    </td>
                    </tr>
                    </table>
                
               
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
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
                                        <asp:TextBox ID="txtFirstName" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>
                                <td>
                                    <span class="regBoxsmall">
                                        <asp:TextBox ID="txtMiddleName" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>
                                <td>
                                    <span class="regBoxsmall">
                                        <asp:TextBox ID="txtLastName" runat="server" Text="" CssClass="txtRegsmall">
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
                                    <asp:TextBox ID="txtReceiverCity" runat="server" Text="" CssClass="txtRegsmall">
                                            </asp:TextBox>
                                            </span>
                                </td>
                                <td>
                                    Country :
                                </td>
                                <td>
                                    <span class="regBoxsmall">
                                     <asp:TextBox ID="txtReceiverCountry" runat="server" Text="" CssClass="txtRegsmall">
                                            </asp:TextBox>
                                            </span>
                                </td>
                            </tr>
                        </table>
                
               
                    </td>
                </tr>

                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>

                <tr>
                    <td >
                        
                    </td>
                    <td>
                        


                        <table >
                        <tr>
                                <td align="right">
                                    Date (Format : mm/dd/yyyy)
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:TextBox ID="txtDate" runat="server"  CssClass="txtRegbig" Text="0" >
                                        </asp:TextBox>
                                        
                                        </span>
                                </td>                                
                            </tr>
                            <tr>
                                <td align="right">
                                    Sending Amount (USD)$
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:TextBox ID="txtSendingAmount" runat="server"  CssClass="txtRegbig" Text="0" onkeyup="calculation()">
                                        </asp:TextBox>

                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtSendingAmount"
                                            FilterType="Custom, Numbers" ValidChars="."  />
                                        </span>
                                </td>                                
                            </tr>
                            <tr>
                                <td align="right">
                                    Service Charges$
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:TextBox ID="txtServiceCharge" runat="server"  CssClass="txtRegbig" 
                                        Text="0" onkeyup="calculation()">
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
                                    <asp:TextBox ID="txtOtherServiceCharge" runat="server"  CssClass="txtRegbig" 
                                        Text="0" onkeyup="calculation()">
                                        </asp:TextBox>

                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtOtherServiceCharge"
                                            FilterType="Custom, Numbers" ValidChars="."  />
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
                                    Promotional Discount$
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:TextBox ID="txtDiscount" runat="server"  CssClass="txtRegbig" Text="0.00" onkeyup="calculation()">
                                        </asp:TextBox>

                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDiscount"
                                            FilterType="Custom, Numbers" ValidChars="."  />
                                        </span>
                                </td>                                
                            </tr>
                            <tr>
                                <td align="right" style="color:Red">
                                    Total Charges(USD)$
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:TextBox ID="txtTotalCharge" runat="server"  CssClass="txtRegbig" Text="0" >
                                        </asp:TextBox>
                                        </span>
                                </td>                                
                            </tr>
                            <tr style="display:none;">
                                <td align="right" >
                                    Rate
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:Label ID="lblRate" runat="server" Text="0"></asp:Label>
                                        </span>
                                </td>                                
                            </tr>
                            <tr style="display:none;">
                                <td align="right" >
                                    Amount Received
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:Label ID="lblAmountReceived" runat="server" Text="0"></asp:Label>
                                        </span>
                                </td>                                
                            </tr>
                            <tr style="display:none;">
                                <td align="right" style="color:Green; font-size:20px;">
                                    Reference Code
                                </td>
                                <td>
                                   <span class="regBoxbig_small">
                                    <asp:Label ID="lblReferenceCode" runat="server" Text=""></asp:Label>
                                        </span>
                                </td>                                
                            </tr>
                        </table>

                    
                    </td>
                </tr>
                <tr style="display:none;">
                    <td></td>
                    <td >
                        <table>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBox2" runat="server" Text=""/>
                                </td>
                                <td>
                                    Send Message to Receiver
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox1" runat="server"  Text="" />
                                </td>
                                <td>
                                    Call my receiver when funds are available        
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style=" padding-top:10px;">
                            <asp:Label ID="lblmessage" runat="server" Font-Bold="True" Font-Size="14px" 
                                ForeColor="Maroon"></asp:Label>
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
                <tr>
                    <td>
                    </td>
                    
                    <td style="padding-left:3px;">
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregtop" 
                            onclick="btnBack_Click" />
                        <asp:Button ID="btnSearch" runat="server" Text="Cancel Transaction"  onclick="btnBack_Click"  CssClass="btnregtop_payment" />
                        <asp:Button ID="btnProcessTransaction" runat="server" 
                            Text="Process Transaction" CssClass="btnregtop_payment" 
                            onclick="btnProcessTransaction_Click" OnClientClick=" return validate()"  />
                            <br />
                                                    <asp:Button ID="btnAnotherTransaction" runat="server" 
                            Text="Another Transaction" CssClass="btnregtop_payment" 
                             OnClientClick=" return validate()" 
                            onclick="btnAnotherTransaction_Click"  />
                    </td>
                </tr>

<%--                <tr>
                <td>
                </td>
                <td>
                
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </td>
                </tr>--%>
            </table>
            

            <br />
            <br />
            <div style=" width:650px ; overflow:scroll;">
        
                <asp:GridView ID="gvTRANS" runat="server" AutoGenerateColumns="false" CssClass="gridCss">
            <Columns>

                <asp:TemplateField HeaderText="CUSTID">
                    <ItemTemplate>
                        <asp:Label ID="lblCUSTID" runat="server" Text='<%#Eval("CUSTID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RECEIVERID">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERID" runat="server" Text='<%#Eval("RECEIVERID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LOCATIONID">
                    <ItemTemplate>
                        <asp:Label ID="lblLOCATIONID" runat="server" Text='<%#Eval("LOCATIONID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSDT">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSDT" runat="server" Text='<%#Eval("TRANSDT") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSAMOUNT">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSAMOUNT" runat="server" Text='<%#Eval("TRANSAMOUNT") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSFEES">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSFEES" runat="server" Text='<%#Eval("TRANSFEES") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSOTHERFEES">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSOTHERFEES" runat="server" Text='<%#Eval("TRANSOTHERFEES") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSPROMOCODE">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSPROMOCODE" runat="server" Text='<%#Eval("TRANSPROMOCODE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSPROMO">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSPROMO" runat="server" Text='<%#Eval("TRANSPROMO") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSTOTALAMOUNT">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSTOTALAMOUNT" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_SM_RECEIVER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_SM_RECEIVER" runat="server" Text='<%#Eval("FLAG_SM_RECEIVER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SM_RECEIVER">
                    <ItemTemplate>
                        <asp:Label ID="lblSM_RECEIVER" runat="server" Text='<%#Eval("SM_RECEIVER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_CALL_RECEIVER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_CALL_RECEIVER" runat="server" Text='<%#Eval("FLAG_CALL_RECEIVER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RECEIVERPHONENO">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERPHONENO" runat="server" Text='<%#Eval("RECEIVERPHONENO") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_DD">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_DD" runat="server" Text='<%#Eval("FLAG_DD") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_TESTQUESTION">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_TESTQUESTION" runat="server" Text='<%#Eval("FLAG_TESTQUESTION") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TESTQUESTION">
                    <ItemTemplate>
                        <asp:Label ID="lblTESTQUESTION" runat="server" Text='<%#Eval("TESTQUESTION") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TESTANSWER">
                    <ItemTemplate>
                        <asp:Label ID="lblTESTANSWER" runat="server" Text='<%#Eval("TESTANSWER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_CALLSENDER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_CALLSENDER" runat="server" Text='<%#Eval("FLAG_CALLSENDER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_SMSSENDER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_SMSSENDER" runat="server" Text='<%#Eval("FLAG_SMSSENDER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_EMAILSENDER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_EMAILSENDER" runat="server" Text='<%#Eval("FLAG_EMAILSENDER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SENDEREMAILADDRESS">
                    <ItemTemplate>
                        <asp:Label ID="lblSENDEREMAILADDRESS" runat="server" Text='<%#Eval("SENDEREMAILADDRESS") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSSTATUS">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSSTATUS" runat="server" Text='<%#Eval("TRANSSTATUS") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSRECEIVEDID">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSRECEIVEDID" runat="server" Text='<%#Eval("TRANSRECEIVEDID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSRECEIVEDATE">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSRECEIVEDATE" runat="server" Text='<%#Eval("TRANSRECEIVEDATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CREATEDBY">
                    <ItemTemplate>
                        <asp:Label ID="lblCREATEDBY" runat="server" Text='<%#Eval("CREATEDBY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CREATEDON">
                    <ItemTemplate>
                        <asp:Label ID="lblCREATEDON" runat="server" Text='<%#Eval("CREATEDON") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UPDATEDBY">
                    <ItemTemplate>
                        <asp:Label ID="lblUPDATEDBY" runat="server" Text='<%#Eval("UPDATEDBY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UPDATEDON">
                    <ItemTemplate>
                        <asp:Label ID="lblUPDATEDON" runat="server" Text='<%#Eval("UPDATEDON") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTID">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="REFCODE">
                    <ItemTemplate>
                        <asp:Label ID="lblREFCODE" runat="server" Text='<%#Eval("REFCODE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
        </div>
    </div>
    
</asp:Content>
