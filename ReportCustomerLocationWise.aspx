<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true" CodeFile="ReportCustomerLocationWise.aspx.cs" Inherits="AgentWiseReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
  ol li{padding:5px 10px;}
  </style>

<script language="javascript" type="text/javascript">
    function SelectSingleRadiobutton(rdBtnID) {
        //process the radio button Being checked.
        var rduser = $(document.getElementById(rdBtnID));
        rduser.closest('TR').addClass('SelectedRowStyle');
        rduser.checked = true;
        // process all other radio buttons (excluding the the radio button Being checked).
        var list = rduser.closest('table').find("INPUT[type='radio']").not(rduser);
        list.attr('checked', false);
        list.closest('TR').removeClass('SelectedRowStyle');
    }
</script>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="SearchSenderPage.aspx">Search Sender</a></li>
        <li><a href="MemberInsertUpdate.aspx?memberInfoID=0&memberType=1">Sender</a></li>
        <li><a href="SearchReceiverPage.aspx">Search Receiver</a></li>
        <li><a href="MemberReceiverInsertUpdate.aspx?memberInfoID=0&memberType=2">Receiver</a></li>
        <li><a href="SearchLocation.aspx">Search Location</a></li>
        <li id="selected"><a href="Payment.aspx">Payment</a></li>
                <li><a href="Transmit.aspx">Transmit</a></li><li><a href="Default.aspx">Back</a></li>
    </ul>
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    
    <asp:HiddenField ID="hfAgentID" runat="server" />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblmessage" Font-Size="Larger"  runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td>
            
            
            
            
    <div runat="server"  id="divPayment" visible="false">
        <div class="memberReg">

        <!-- Begin: memberReg -->
        <div class="nameRow">
            <table style="width: 100%; table-layout: fixed;">
                <colgroup>
                    <col width="15%" style="font-weight: bold;" />
                    <col width="85%" align="left" />
                </colgroup>
                <tr>
                    <td colspan="2">
                       <h2 style="margin-bottom:20px;">Process payment for <asp:Label ID="lblREFCODE" runat="server" ForeColor="Red" Text=""></asp:Label></h2>
                       <hr />
                    </td>
                </tr>
                 <tr >
                    <td>
                        Transaction Amount($) :
                    </td>
                    <td>
                        <span class="regBoxbig">
                            <asp:Label ID="lblTransavtionAmount" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                </tr>
                 <tr >
                    <td>
                        Fees($) :
                    </td>
                    <td>
                        <span class="regBoxbig">
                            <asp:Label ID="lblFees" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr >
                    <td>
                        Other Fees($) :
                    </td>
                    <td>
                        <span class="regBoxbig">
                            <asp:Label ID="lblOtherFees" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                </tr>
                  <tr >
                    <td>
                        Discount($) :
                    </td>
                    <td>
                        <span class="regBoxbig">
                            <asp:Label ID="lblDiscount" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr >
                    <td>
                        Total Amount($) :
                    </td>
                    <td>
                        <span class="regBoxbig">
                            <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td>
                        Member ID :
                    </td>
                    <td>
                        <span class="regBoxbig">
                            <asp:TextBox ID="txtMemberID" runat="server" Text="" CssClass="txtRegbig" ReadOnly="false">
                            </asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        Test Question :
                    </td>
                    <td>
                        <span class="regBoxbig1">
                            <asp:TextBox ID="txtTestQuestion" runat="server" Text="" ReadOnly="true" CssClass="txtRegbig1">
                            </asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        Test Answer :
                    </td>
                    <td>
                        <span class="regBoxbig1">
                            <asp:TextBox ID="txtTestAnswer" runat="server" Text="" ReadOnly="true" CssClass="txtRegbig1">
                            </asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                       Sender Name :
                    </td>
                    <td>
                        <span class="regBoxbig1">
                            <asp:TextBox ID="txtCUSName" runat="server" Text="" CssClass="txtRegbig1">
                            </asp:TextBox>
                        </span>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        Address 1:
                    </td>
                    <td>
                        <span class="regBoxbig1">
                            <asp:TextBox ID="txtCUSAddress1" runat="server" Text="" CssClass="txtRegbig1">
                            </asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address 2:
                    </td>
                    <td>
                        <span class="regBoxbig1">
                            <asp:TextBox ID="txtCUSAddress2" runat="server" Text="" CssClass="txtRegbig1">
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
                                        <asp:TextBox ID="txtCUSState" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>
                                <td>
                                    City :
                                </td>
                                <td>
                                                                    
                                   <span class="regBoxsmall">
                    <asp:TextBox ID="txtCUSCity" runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                            </span>
                                </td>
                                <td style="width: 10px;">
                                    Zip:
                                </td>
                                <td style="width: 10px;">
                                    <span class="regBoxsmall">
                                        <asp:TextBox ID="txtCUSZIP" runat="server" Text="" CssClass="txtRegsmall">
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
                                        <asp:TextBox ID="txtCUSPhoneNumber" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>
<%--                                <td>
                                    Cell :
                                </td>
                                <td>
                                    <span class="regBoxsmall">
                                        <asp:TextBox ID="txtCell" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
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
                                        <asp:TextBox ID="txtRECEIVERFNAME" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>
                                <td>
                                    
                                </td>
                                <td>
                                                                    
                                   <span class="regBoxsmall">
                    <asp:TextBox ID="txtRECEIVERMNAME" runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                            </span>
                                </td>
                                <td style="width: 10px;">
                                    
                                </td>
                                <td style="width: 10px;">
                                    <span class="regBoxsmall">
                                        <asp:TextBox ID="txtRECEIVERLNAME" runat="server" Text="" CssClass="txtRegsmall">
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
                        <span class="regBoxbig1">
                            <asp:TextBox ID="txtAddress" runat="server" Text="" CssClass="txtRegbig1">
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
                                        <asp:TextBox ID="txtState" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>
                                <td>
                                    City :
                                </td>
                                <td>
                                                                    
                                   <span class="regBoxsmall">
                    <asp:TextBox ID="txtCity" runat="server" Text="" CssClass="txtRegsmall">
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
<%--                                <td>
                                    Cell :
                                </td>
                                <td>
                                    <span class="regBoxsmall">
                                        <asp:TextBox ID="txtCell" runat="server" Text="" CssClass="txtRegsmall">
                                        </asp:TextBox>
                                    </span>
                                </td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <hr />
                    </td>
                </tr>
            </table>
            <table style="display:none;">
                <tr>
                    <td>
                        You need to do :
<ol>
  <li>1.<b>Search Receiver:</b> You can search receiver by clicking the <b>"Search"</b> button after entering the search text in the above fields. After Getting </li>        
  <li>2.<b>New Receiver:</b> You can click the <b>"New Receiver"</b> Button and enter the information above the information and then also if you have the Email of the Receiver then give that and then Click the <b>"Process Payment"</b></li>
  <li>3.<b>Update Receiver:</b> You can select the receiver from the list bellow and Click "Select To Update Info" and Enter the updated info and then also if you have the Email of the Receiver then give that and then Click the <b>"Process Payment"</b></li>

</ol>

                    </td>
                </tr>
            </table>
        </div>        
        <div class="regRow_Payment"  style="display:none;">
            <asp:HiddenField ID="hfTransID" runat="server" />
           <asp:Button ID="btnSearchReceiver" runat="server" Text="Search" CssClass="btnregtop" OnClick="btnSearchReceiver_Click" />
           <asp:Button ID="btnNewReceiver" runat="server" Text="New Receiver" CssClass="processPaymentButton" OnClick="btnNewReceiver_Click" />
           <asp:Button ID="btnSelectReciver" runat="server" Text="Select To update info" CssClass="processPaymentButton" OnClick="btnSelectReciver_Click" />
        </div>
    </div>
    <!-- End: memberReg -->
    <div class="memberlist" style="overflow: scroll; display:none;">
        <!-- Begin: memberlist -->
        <%-- <img src="App_Themes/Default/images/bg_memberlist.jpg" width="581" height="265" alt="0" />--%>
        

        <asp:GridView ID="gvRECEIVER" runat="server" AutoGenerateColumns="false" CssClass="gridCss" GridLines="Both" BorderColor="#CDCDCD" PageSize="15" AllowPaging="True" OnPageIndexChanging="gvRECEIVER_PageIndexChanging" Width="100%">
         <PagerSettings Mode="NumericFirstLast" />
            <Columns>
                            <asp:TemplateField HeaderText="Select" ControlStyle-Width="60px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbtSelect" Checked="true" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                        <asp:Label ID="lblRECEIVERID" runat="server" Text='<%#Eval("RECEIVERID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Member Name">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERFNAME" runat="server" Text='<%#Eval("RECEIVERFNAME") %>'>
                        </asp:Label>
                        &nbsp
                        <asp:Label ID="lblRECEIVERMNAME" runat="server" Text='<%#Eval("RECEIVERMNAME") %>'>
                        </asp:Label>
                        &nbsp
                        <asp:Label ID="lblRECEIVERLNAME" runat="server" Text='<%#Eval("RECEIVERLNAME") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERPHONE" runat="server" Text='<%#Eval("RECEIVERPHONE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERADDRESS1" runat="server" Text='<%#Eval("RECEIVERADDRESS1") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERSTATE" runat="server" Text='<%#Eval("RECEIVERSTATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERCITY" runat="server" Text='<%#Eval("RECEIVERCITY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ZIP">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERZIP" runat="server" Text='<%#Eval("RECEIVERZIP") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="Larger" Text="No data found for the above search criterion"></asp:Label>
                            <asp:Label ID="Label12" runat="server" ForeColor="Green" Font-Size="Larger" Text=" Please change the search criterion.."></asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="gvHeadercss" />
            <RowStyle CssClass="gvRowCss" />
            <AlternatingRowStyle CssClass="gvRowAltCss" />
        </asp:GridView>
    </div>
    <div class="regRow_Payment">
           <div  style="display:none;">Please select a Receiver from the search result <br />AND / OR<br />Enter the Receiver Email: <%--<asp:TextBox ID="txtReceiverEmail" runat="server"  CssClass="txtRegbig"></asp:TextBox>--%>
            And then click "Process full/partial Payment"
            <br/><br/></div>
            <b>Others:</b> (you can described anything here, related to the payment process)<br />
        <asp:HiddenField ID="hfCauseOtherServiceChages" runat="server" />
            <asp:TextBox ID="txtCauseOtherServiceCharges" runat="server" Text="" TextMode="MultiLine" Width="500px" Height="100px" CssClass="txtRegbig1"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCauseOtherServiceCharges" ValidationGroup="partialpayment" runat="server" ErrorMessage="For Partial payment Need some Description"></asp:RequiredFieldValidator>
            <br />
            Receiver ID : <asp:TextBox ID="txtReceiverEmail" runat="server"  CssClass="txtRegbig"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnProcessPayment" runat="server" Text="Process full Payment" CssClass="processPaymentButton" OnClick="btnProcessPayment_Click" />
            <asp:Button ID="btnProcessPaymentPartial" runat="server" Text="Process partial Payment" CssClass="processPaymentButton"  ValidationGroup="partialpayment"  OnClick="btnProcessPaymentPartial_Click" />
        </div>
    </div>
    </td>
        </tr>
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
                </tr>
            </table>
            <table> 
                <tr>
                    <td>
                        Status
                    </td>
                    <td>
                        <asp:CheckBox ID="chkPending" runat="server" Text="PENDING" Checked="true"/><br />
                        <asp:CheckBox ID="chkPaid" runat="server" Text="PAID" Checked="true"/><br />
                        <asp:CheckBox ID="chkPartiallyPaid" runat="server" Text="PAETIALLY-PAID" Checked="true"/><br />
                        <asp:CheckBox ID="chkCanceled" runat="server" Text="RETURNED" /><br />
                    </td>
                </tr>           
                <tr>
                    <td>
                        Agent
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAgent" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlAgent_SelectedIndexChanged">
                        
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="trLocation">
                <td>
                    Location
                    <br/><asp:CheckBox ID="chkAllLocations" Checked="true" runat="server" />All
                    <asp:HiddenField ID="hfLoggedinLocationID" runat="server" Value="0"/>
                </td>
                <td style="height:200px; overflow:scroll;">
                    <div style="height:200px; overflow:scroll;">
                        <asp:GridView ID="dlLocation" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Select" ControlStyle-CssClass="gridIteamCenter">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect"  />
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
           
                <tr runat="server" id="tr1">
                <td>
                    Receiver
                    <br/><asp:CheckBox ID="chkAllReceivers" Checked="true" runat="server" />All
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="0"/>
                </td>
                <td style="height:200px; overflow:scroll;">
                    <div style="height:200px; overflow:scroll;">
                        <asp:GridView ID="gvReciver" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Select" ControlStyle-CssClass="gridIteamCenter">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect"  />
                                        <asp:HiddenField runat="server" ID="hfReceiverID" Value='<%# Eval("RECEIVERID")  %>' />                                               
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <%#String.Format("{0}", Eval("RECEIVERID"))%>                                         
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="First Name" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <%#String.Format("{0}", Eval("RECEIVERFNAME"))%>                                         
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Middle Name" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <%#String.Format("{0}", Eval("RECEIVERMNAME"))%>                                         
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Last Name" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <%#String.Format("{0}", Eval("RECEIVERLNAME"))%>                                         
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
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>(select date form the calendar)
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ErrorMessage="*"></asp:RequiredFieldValidator>


                    </td>
                </tr>
                <tr runat="server" id="trToDate">
                    <td>
                        To date 
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>(select date form the calendar)
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate" CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" 
                            onclick="btnSearch_Click"  />
                              <asp:Button ID="btnPrint" runat="server" Text="Download pdf" 
                            onclick="btnPrint_Click" />  
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
                        <asp:Button ID="btnSearchByRefCode" runat="server" Text="Search" onclick="btnSearchByRefCode_Click"  />
                    </td>
                </tr>
                
            </table>
            <div class="regRow" id="divListOfAllTransaction" runat="server">
            <h1 style="font-size:15px; margin-bottom:10px">Location Wise Report</h1>
             <asp:GridView ID="gvLocation" runat="server" CssClass="tutorial" AutoGenerateColumns="false"
                        ShowHeader="false"  
                OnRowDataBound="gvLocation_RowDataBound">
                        <PagerStyle CssClass="papperStyle"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Location"  HeaderStyle-Width="330px" >
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hfLocationID" runat="server" Value='<%#Eval("LOCATIONID") %>'/>
                                                Country :<asp:Label ID="Label2"  Font-Bold="true" runat="server" Text='<%#Eval("COUNTRY") %>'></asp:Label>
                                                <br/>City :<asp:Label ID="Label1"  Font-Bold="true" runat="server" Text='<%#Eval("CITY") %>'></asp:Label>
                                                <br/>Branch :<asp:Label ID="lblLocationName"  Font-Bold="true" runat="server" Text='<%#Eval("BRANCH") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <div style="padding:5px 10px">
                                               <asp:GridView ID="gvTRANS" runat="server" CssClass="innergrid" BorderStyle="None" GridLines="Horizontal" AutoGenerateColumns="false" ShowHeader="true">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Date" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransactionDate"  Font-Bold="false" runat="server" Text='<%#Eval("CREATEDON","{0:MM/dd/yyyy}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="REF Code" ControlStyle-Width="90px">
                                                            <ItemTemplate>
                                                                <a href='<%#Eval("REFCODE","EditPayment.aspx?REFCODE={0}") %>' target="_blank"><asp:Label ID="lblReferenceCode"  Font-Bold="false" runat="server" Text='<%#Eval("REFCODE") %>'>
                                                                        </asp:Label> </a>                                                  
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Customer Detail" ControlStyle-Width="180px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCustomerDetail"  Font-Bold="false" runat="server" Text='<%#Eval("CUSTDETAIL")%>'>
                                                                        </asp:Label>                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Receiver Detail" ControlStyle-Width="180px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReceiverDetail"  Font-Bold="false" runat="server" Text='<%#Eval("RECEIVERDETAIL")%>'>
                                                                        </asp:Label>                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Amount" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSendingAmount"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSAMOUNT","{0:C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Fees" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblServiceCharge"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSFEES","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Discount" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDiscount"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSPROMOCODE","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Total Amount" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalCharge"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSSTATUS") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                               <a id="hlEdit" visible='<%#Eval("IsEdit") %>' href='<%#Eval("REFCODE","EditPayment.aspx?REFCODE={0}") %>' target="_blank" runat="server">Edit</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnIsPending" runat="server" Text="Pay?" Visible='<%#Eval("IsPending") %>'  CommandArgument='<%#Eval("TRANSID") %>' OnClick="btnIsPending_Click"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#AFA582" Font-Bold="True" ForeColor="White" CssClass="gridHeaderClass" />
                                                </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr style=" font-weight:bold;color:Blue;">
                                                        <td style="width:475px; text-align:right;">
                                                        
                                                        </td>
                                                        <td style="width:80px; text-align:right;">
                                                        
                                                            SubTotal :&nbsp;&nbsp;
                                                        </td>
                                                        <td style="width:78px;">
                                                            <asp:Label ID="lblSubTotalSendingAmount" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td style="width:78px;">
                                                            <asp:Label ID="lblSubTotalFees" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td style="width:78px;">
                                                            <asp:Label ID="lblSubTotalDiscount" runat="server" Text=""></asp:Label>                                                    
                                                        </td>
                                                        <td style="width:80px;">
                                                             <asp:Label ID="lblSubTotalTotalAmount" runat="server" Text=""></asp:Label>                                                    
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
            <tr style=" font-weight:bold;color:Green;">
                <td style="width:155px; text-align:right;">                                                        
                </td>
                <td style="width:100px; text-align:right;">                                                        
                    Total (<asp:Label ID="lblTotalno" runat="server" Text="0" ForeColor="Red"></asp:Label>) :
                </td>
                <td style="width:100px;">
                    <asp:Label ID="lblSubTotalSendingAmountTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="width:97px;">
                    <asp:Label ID="lblSubTotalFeesTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="width:98px;">
                    <asp:Label ID="lblSubTotalDiscountTotal" runat="server" Text="0"></asp:Label>                                                    
                </td>
                <td style="width:100px;">
                        <asp:Label ID="lblSubTotalTotalAmountTotal" runat="server" Text="0"></asp:Label>                                                    
                </td>
            </tr>
        </table>
    </div>
    </td>
        </tr>
    </table>
    
    
            <br />
            <br />
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="85%">
    </rsweb:ReportViewer>
    <br />


</asp:Content>

