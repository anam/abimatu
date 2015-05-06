<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true" CodeFile="ReportAgentWise.aspx.cs" Inherits="AgentWiseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
    <div class="memberReg">
       
        <div class="regRow">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnBack" runat="server"    Text="Back" CssClass="btnregtop" OnClick="btnBack_Click" />
                    </td>
                </tr>                
            </table>
            <table>
            <tr>
                <td>
                    Location
                    <br/><asp:CheckBox ID="chkAllLocations" Checked="true" runat="server" />All
                </td>
                <td style="height:200px; overflow:scroll;">
                    <div style="height:200px; overflow:scroll;">
                        <asp:HiddenField ID="hfAgentID" runat="server" />
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
            <h1 style="font-size:15px; margin-bottom:10px">Agent Wise Report</h1>
             <asp:GridView ID="gvAgent" runat="server" CssClass="tutorial" AutoGenerateColumns="false"
                        AllowPaging="false" ShowHeader="false"  OnRowDataBound="gvLocation_RowDataBound">
                        <PagerStyle CssClass="papperStyle"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Location"  HeaderStyle-Width="330px" >
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hfAgnetID" runat="server" Value='<%#Eval("AGENTID") %>'/>
                                                   Agent : <asp:Label ID="lblLocationName"  Font-Bold="true" runat="server" Text='<%#Eval("AGENTNAME") %>'></asp:Label><%--(<%#Eval("FirstName")%>)--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <div style="padding:5px 10px">
                                                <asp:GridView ID="gvTRANS" runat="server" CssClass="innergrid" BorderStyle="None" GridLines="Both" AutoGenerateColumns="false" ShowHeader="true">
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
                                                        
                                                        <asp:TemplateField HeaderText="Location" ItemStyle-Width="120px">
                                                            <ItemTemplate>
                                                                <%#Eval("LOCATIONDETAIL")%>
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
                                                                <asp:Label ID="lblDiscount"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSPROMO","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Total Amount" ControlStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalCharge"  Font-Bold="false" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT","{0 :C}") %>'>
                                                                        </asp:Label>
                                                   
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField>
                                                            <ItemTemplate>
                                                               <a id="hlEdit" visible='<%#Eval("IsEdit") %>' href='<%#Eval("REFCODE","EditPayment.aspx?REFCODE={0}") %>' target="_blank" runat="server">Edit</a>
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
                                                    <tr style=" font-weight:bold;color:Blue;">
                                                    <td style="width:575px; text-align:right;">
                                                        
                                                    </td>
                                                    <td style="width:80px; text-align:right;">
                                                        SubTotal:&nbsp;&nbsp;
                                                    </td>
                                                    <td style="width:78px;">
                                                        <asp:Label ID="lblSubTotalSendingAmount" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td style="width:78px;">
                                                        <asp:Label ID="lblSubTotalFees" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td style="width:80px;">
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
                <td style="width:100px; font-weight:bold; text-align:left;">
                    Total:
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
</asp:Content>

