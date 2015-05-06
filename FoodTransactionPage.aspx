<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="FoodTransactionPage.aspx.cs" Inherits="FoodTransactionPage" %>
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtFoodRate.ClientID%>").value == "") {
                alert("Rate can not be blank");
                document.getElementById("<%=txtFoodRate.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtFoodQuantity.ClientID%>").value == "") {
                alert("Quantity can not be blank");
                document.getElementById("<%=txtFoodQuantity.ClientID%>").focus();
                return false;
            }


            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtFoodRate.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtFoodRate.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Rate");
                    document.getElementById("<%=txtFoodRate.ClientID%>").focus();
                    return false;
                }
            }


            var digits = "0123456789";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtFoodQuantity.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtFoodQuantity.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Qunatity");
                    document.getElementById("<%=txtFoodQuantity.ClientID%>").focus();
                    return false;
                }
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="SearchFoodSenderPage.aspx">Search Food Sender</a></li>
        <li><a href="CUSTOMERInsertUpdateFood.aspx?cUSTOMERID=0">Sender</a></li>
        <li><a href="SearchFoodReceiverPage.aspx">Search Food Receiver</a></li>
        <li><a href="ReceiverInsertUpdateFood.aspx?rECEIVERID=0">Receiver</a></li>
        <li><a href="SearchFoodLocation.aspx">Search Food Location</a></li>
        <li id="selected"><a href="FoodTransactionPage.aspx">Food Transaction</a></li>
        <li><a href="Default.aspx">Back</a></li>

    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div class="memberReg">
        <!-- Begin: memberReg -->
        <div class="nameRow">
            <asp:UpdatePanel ID="uplFoodTrans" runat="server">
                <ContentTemplate>
                    <table style="width: 100%; table-layout: fixed;">
                        <colgroup>
                            <col width="15%" style="font-weight: bold;" />
                            <col width="85%" align="left" />
                        </colgroup>
                        <tr>
                            <td>
                                Location Name :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLoction" runat="server" AutoPostBack="true" CssClass="ddlcss"
                                    Width="200px" OnSelectedIndexChanged="ddlLoction_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Country :
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtCountry" runat="server" Text="" CssClass="txtRegsmall">
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
                                            Branch Location :
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtBranch" runat="server" Text="" CssClass="txtRegsmall">
                            </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>--%>
                        <tr>
                            <td>
                                Customer Name :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCustFirstName" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCustMiddleName" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCustLastName" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
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
                                                <asp:TextBox ID="txtReceiverFirstName" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtReceiverMiddleName" runat="server" Text="" CssClass="txtRegsmall">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtReceiverLastName" runat="server" Text="" CssClass="txtRegsmall">
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
                                Food Item :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFoodItem" runat="server" AutoPostBack="true" CssClass="ddlcss"
                                    Width="200px" OnSelectedIndexChanged="ddlFoodItem_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Food Rate :
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtFoodRate" runat="server" Text="0" CssClass="txtRegsmall">
                            </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quantity :
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtFoodQuantity" runat="server" Text="1" CssClass="txtRegsmall">
                            </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td align="right" style="color: Green; font-size: 20px;">
                                            Reference Code
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtReferenceCode" runat="server" Text="" CssClass="txtRegsmall">
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
                            <td align="left">
                                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="btnregtop" OnClick="btnAddItem_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <div class="memberlist" style="overflow: scroll;">
                                    <!-- Begin: memberlist -->
                                    <%-- <img src="App_Themes/Default/images/bg_memberlist.jpg" width="581" height="265" alt="0" />--%>
                                    <asp:GridView ID="gvFoodTransactionItemRelation" runat="server" AutoGenerateColumns="false"
                                        CssClass="gridCss" GridLines="Both" BorderColor="#CDCDCD" Width="100%" OnRowDataBound="gvFoodTransactionItemRelation_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="FoodItemID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfID" runat="server" Text='<%#Eval("fID") %>' Visible="false">
                        </asp:Label>
                                                    <asp:Label ID="lblFoodItem" runat="server">
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfRATE" runat="server" Text='<%#Eval("fRATE") %>'>
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfQTY" runat="server" Text='<%#Eval("fQTY") %>'>
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubTotal">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubTotal" runat="server">
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CUSTID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCUSTID" runat="server" Text='<%#Eval("CUSTID") %>' Visible="false">
                        </asp:Label>
                                                    <asp:Label ID="lblCUSTFname" runat="server">
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LOCATIONID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLOCATIONID" runat="server" Text='<%#Eval("LOCATIONID") %>' Visible="false">
                        </asp:Label>
                                                    <asp:Label ID="lblLOCATIONName" runat="server">
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RECEIVERID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRECEIVERID" runat="server" Text='<%#Eval("RECEIVERID") %>' Visible="false">
                        </asp:Label>
                                                    <asp:Label ID="lblRECEIVERFname" runat="server">
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TOTALAMT">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTOTALAMT" runat="server">
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="gvHeadercss" />
                                        <RowStyle CssClass="gvRowCss" />
                                        <AlternatingRowStyle CssClass="gvRowAltCss" />
                                    </asp:GridView>
                                    <br />
                                    <br />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding-top: 10px;">
                                Total Transaction Amount :
                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="#7EC87E"
                                    Text="0.00"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding-top: 10px;">
                                <asp:Label ID="lblmessage" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="Green"></asp:Label>
                                <br />
                                <asp:Label ID="lblText" runat="server" Font-Bold="false" Font-Size="14px" ForeColor="Green"></asp:Label>
                                <asp:Label ID="lblReferenceCODE" runat="server" Font-Bold="true" Font-Size="25px"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="padding-left: 3px;">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregtop" OnClick="btnBack_Click" />
                                <asp:Button ID="btnSearch" runat="server" Text="Cancel Transaction" CssClass="btnregtop_payment"
                                    OnClick="btnSearch_Click" />
                                <asp:Button ID="btnSaveTransaction" runat="server" Text="Save Transaction" CssClass="btnregtop_payment"
                                    OnClick="btnSaveTransaction_Click" OnClientClick=" return validate()" />
                                <asp:Button ID="btnAnotherTransaction" runat="server" Text="Another Transaction" Visible="false"
                                    CssClass="btnregtop_payment" OnClientClick=" return validate()" OnClick="btnAnotherTransaction_Click" />

                            </td>
                        </tr>
                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>

             <table style="width: 100%; table-layout: fixed;">
                        <colgroup>
                            <col width="15%" style="font-weight: bold;" />
                            <col width="85%" align="left" />
                        </colgroup>
                        <tr>
                        <td>
                        
                        </td>
                        <td>
                        <asp:Button ID="btnPrint" runat="server" Text="Print" Visible="true"
                                    CssClass="btnregtop_payment" onclick="btnPrint_Click"  />
                      <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px" Height="700px" Visible="false">
        </rsweb:ReportViewer>
                        </td>
                        </tr>
                        </table>
            
        </div>
    </div>
</asp:Content>
