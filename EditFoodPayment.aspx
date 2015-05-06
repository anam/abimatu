<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true" CodeFile="EditFoodPayment.aspx.cs" Inherits="EditFoodPayment" %>

        <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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

                                <asp:HiddenField ID="hfCUSTID" runat="server" Visible="true" />
                                <asp:HiddenField ID="hfRECID" runat="server" Visible="true"/>
                                <asp:HiddenField ID="hfIsLocation" runat="server" Visible="true"/>
                                <asp:HiddenField ID="hfFOODTRANSID" runat="server" Visible="true"/>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btnregtop" />

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
                                    />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" 
                                    CssClass="btnregbot" onclick="btnDelete_Click" OnClientClick="return confirm('Are You Sure ? You want to Delete');"  />
                                <asp:Button ID="btnReturn" runat="server" Text="RETURN" Visible="false" 
                                    CssClass="btnregbot" onclick="btnReturn_Click" />
                                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnregbot" 
                                    onclick="btnPrint_Click"  />
                            </div>
                        </td>
                    </tr>


                                            <tr>
                            <td>
                                Location Name :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlLoction" runat="server" AutoPostBack="true" CssClass="ddlcss"
                                    Width="200px" OnSelectedIndexChanged="ddlLoction_SelectedIndexChanged" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Country :
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtCountry" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
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
                                                <asp:TextBox ID="txtCity" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
                            </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            Branch Location :
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtBranch" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
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
                                                <asp:TextBox ID="txtCustFirstName" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCustMiddleName" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtCustLastName" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
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
                                                <asp:TextBox ID="txtReceiverFirstName" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtReceiverMiddleName" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
                                                </asp:TextBox>
                                            </span>
                                        </td>
                                        <td>
                                            <span class="regBoxsmall">
                                                <asp:TextBox ID="txtReceiverLastName" runat="server" Text="" CssClass="txtRegsmall" ReadOnly="true">
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
                                                <asp:TextBox ID="TextBox1" runat="server" Text="" CssClass="txtRegsmall" 
                                                >
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
                                                   <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDelete" Visible='<%#Eval("IsAgent") %>' runat="server" CommandArgument='<%#Eval("FID") %>' OnClick="lbDelete_Click">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                                            <asp:TemplateField HeaderText="FoodItemID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfID" runat="server" Text='<%#Eval("FID") %>' Visible="false">
                        </asp:Label>
                                                    <asp:Label ID="lblFoodItem" runat="server">
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfRATE" runat="server" Visible='<%#Eval("IsAgent") %>' Text='<%#Eval("FRATE") %>'>
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfQTY" runat="server" Text='<%#Eval("FQTY") %>'>
                        </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubTotal">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubTotal" Visible='<%#Eval("IsAgent") %>'  runat="server" Text='<%#Eval("SUBTOTAL") %>'>
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
                                            <asp:TemplateField HeaderText="TOTALAMT" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTOTALAMT" Visible='<%#Eval("IsAgent") %>' runat="server" Text='<%#Eval("TOTALAMT") %>' >
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
                        <tr id="trTotalAmount" runat="server">
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
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14px" ForeColor="Green"></asp:Label>
                                <br />
                                <asp:Label ID="lblText" runat="server" Font-Bold="false" Font-Size="14px" ForeColor="Green"></asp:Label>
                                <asp:Label ID="lblReferenceCODE" runat="server" Font-Bold="true" Font-Size="25px"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        
                    
                </table>
            </div>
        </asp:Panel>


            <div style="width: 100%; float: left;">
        
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        
    </div>

    <br />
    <br />
                 <table style="width: 100%; table-layout: fixed;">
                        <colgroup>
                            <col width="15%" style="font-weight: bold;" />
                            <col width="85%" align="left" />
                        </colgroup>
                        <tr>
                        <td>
                        
                        </td>
                        <td>
                      <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px" Height="700px" Visible="false">
        </rsweb:ReportViewer>
                        </td>
                        </tr>
                        </table>
    </div>
</asp:Content>
