<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true"
    CodeFile="ReportAgentWiseCommission.aspx.cs" Inherits="ReportAgentWiseCommission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <div class="memberReg">
        <div class="regRow">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregtop" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
             <table>
            <tr>
                <td>
                    Location
                    <br/><asp:CheckBox ID="chkAllLocations" Checked="true" runat="server"/>All
                </td>
                <td style="height:200px; overflow:scroll;">
                    <div style="height:200px; overflow:scroll;">
                        <asp:GridView ID="dlLocation" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField  HeaderText="Select" ControlStyle-CssClass="gridIteamCenter">
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
                <tr>
                    <td>
                        From date 
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>(select date form the calendar)
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendar" Format="MM/dd/yyyy" PopupButtonID="Image1" />                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ErrorMessage="*"></asp:RequiredFieldValidator>


                    </td>
                </tr>
                <tr>
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
            <h1 style="font-size: 15px; margin-bottom: 10px">
                Agent Wise Commission Report</h1>
            <asp:GridView ID="gvAgent" runat="server" CssClass="tutorial" AutoGenerateColumns="false"
                AllowPaging="false" ShowHeader="false" OnRowDataBound="gvLocation_RowDataBound" Width="700px">
                <PagerStyle CssClass="papperStyle" />
                <Columns>
                    <asp:TemplateField HeaderText="Location" HeaderStyle-Width="330px">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hfAgnetID" runat="server" Value='<%#Eval("AGENTID") %>' />
                                        Agent : <asp:Label ID="lblLocationName" Font-Bold="true" runat="server" Text='<%#Eval("AGENTNAME") %>'></asp:Label><%--(<%#Eval("AGENTNAME")%>)--%>
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td>
                                        <div style="padding: 5px 10px"><%--OnRowDataBound="gvPayment_RowDataBound"--%>
                                            <asp:GridView ID="gvPayment" runat="server" CssClass="innergrid" BorderStyle="None"
                                                GridLines="None" AutoGenerateColumns="false" ShowHeader="true" 
                                                Width="680px" ShowFooter="true">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Location">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLocationID" runat="server" Text='<%#Eval("LOCATIONID") %>' Visible="false">
                                                            </asp:Label>
                                                            <asp:Label ID="lbllocationName" runat="server">
                                                            </asp:Label>
                                                             <asp:Label ID="lblAgentID" runat="server" Visible="false">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trans Count" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTransCount" Font-Bold="false" runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRate" Font-Bold="false" runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fees" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFees" Font-Bold="false" runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                         <FooterTemplate> 
                                                                                                               
                                                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" ForeColor="Black" Text="Total:">
                                                            </asp:Label> 
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Agent Commision" ControlStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAgentCommision" Font-Bold="false" runat="server">
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate> 
                                                                                                                     
                                                            <asp:Label ID="lblTotalAgentCommission"  Font-Bold="true" runat="server" ForeColor="Black">
                                                            </asp:Label>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#AFA582" Font-Bold="True" ForeColor="White" CssClass="gridHeaderClass" />
                                                
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
<%--                                <tr>
                                    <td>
                                        <table>
                                            <tr style="font-weight: bold; color: Blue;">
                                                <td style="width: 155px; text-align: right;">
                                                </td>
                                                <td style="width: 100px; text-align: right;">
                                                    SubTotal1:
                                                </td>
                                                <td style="width: 100px;">
                                                    <asp:Label ID="lblSubTotalSendingAmount" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 97px;">
                                                    <asp:Label ID="lblSubTotalFees" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 50px;">
                                                    <asp:Label ID="lblSubTotalDiscount" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td style="width: 100px;">
                                                    <asp:Label ID="lblSubTotalTotalAmount" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>--%>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="Larger" Text="No Commission for the above search criterion"></asp:Label>
                            <asp:Label ID="Label12" runat="server" ForeColor="Green" Font-Size="Larger" Text="<br/>Please change the search criterion"></asp:Label>
                        </EmptyDataTemplate>
                <HeaderStyle CssClass="heading" />
            </asp:GridView>
        </div>
<%--        <table>
            <tr style="font-weight: bold; color: Green;">
                <td style="width: 155px; text-align: right;">
                </td>
                <td style="width: 100px; font-weight: bold; text-align: left;">
                    Total:
                </td>
                <td style="width: 100px;">
                    <asp:Label ID="lblSubTotalSendingAmountTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="width: 97px;">
                    <asp:Label ID="lblSubTotalFeesTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="width: 98px;">
                    <asp:Label ID="lblSubTotalDiscountTotal" runat="server" Text="0"></asp:Label>
                </td>
                <td style="width: 100px;">
                    <asp:Label ID="lblSubTotalTotalAmountTotal" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>--%>
    </div>
<%--    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br />
    <br />--%>
    <%--<asp:Label ID="lblAgentID" runat="server" Visible="false"></asp:Label>--%>
</asp:Content>
