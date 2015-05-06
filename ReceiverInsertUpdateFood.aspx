<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="ReceiverInsertUpdateFood.aspx.cs" Inherits="ReceiverInsertUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtRECEIVERFNAME.ClientID%>").value == "") {
                alert("First Name can not be blank");
                document.getElementById("<%=txtRECEIVERFNAME.ClientID%>").focus();
                return false;
            }

//            if (document.getElementById("<%=txtRECEIVERMNAME.ClientID%>").value == "") {
//                alert("Middle Name can not be blank");
//                document.getElementById("<%=txtRECEIVERMNAME.ClientID%>").focus();
//                return false;
//            }

            if (document.getElementById("<%=txtRECEIVERLNAME.ClientID%>").value == "") {
                alert("Last Name can not be blank");
                document.getElementById("<%=txtRECEIVERLNAME.ClientID%>").focus();
                return false;
            }

//            if (document.getElementById("<%=txtRECEIVERADDRESS1.ClientID%>").value == "") {
//                alert("Address1 can not be blank");
//                document.getElementById("<%=txtRECEIVERADDRESS1.ClientID%>").focus();
//                return false;
//            }

//            if (document.getElementById("<%=txtRECEIVERSTATE.ClientID%>").value == "") {
//                alert("State can not be blank");
//                document.getElementById("<%=txtRECEIVERSTATE.ClientID%>").focus();
//                return false;
//            }


//            if (document.getElementById("<%=txtRECEIVERCITY.ClientID%>").value == "") {
//                alert("City can not be blank");
//                document.getElementById("<%=txtRECEIVERCITY.ClientID%>").focus();
//                return false;
//            }


//            if (document.getElementById("<%=txtRECEIVERZIP.ClientID%>").value == "") {
//                alert("Zip is not valid");
//                document.getElementById("<%=txtRECEIVERZIP.ClientID%>").focus();
//                return false;
//            }

//            if (document.getElementById("<%=txtRECEIVERPHONE.ClientID%>").value == "") {
//                alert("Phone can not be blank");
//                document.getElementById("<%=txtRECEIVERPHONE.ClientID%>").focus();
//                return false;
//            }



            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpMenu" runat="Server">
<ul>
    <li><a href="SearchFoodSenderPage.aspx">Search Food Sender</a></li>
    <li><a href="CUSTOMERInsertUpdateFood.aspx?cUSTOMERID=0">Sender</a></li>
    <li><a href="SearchFoodReceiverPage.aspx">Search Food Receiver</a></li>
    <li id="selected"><a href="ReceiverInsertUpdateFood.aspx?rECEIVERID=0">Receiver</a></li>
    <li><a href="SearchFoodLocation.aspx">Search Food Location</a></li>
            <li><a href="FoodTransactionPage.aspx">Food Transaction</a></li><li><a href="Default.aspx">Back</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div>
        <table style="width: 100%; table-layout: fixed;">
            <colgroup>
                <col width="15%" style="font-weight: bold;" />
                <col width="85%" align="left" />
            </colgroup>
            <tr>
                <td>
                    Receiver ID :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtMemberID" runat="server" Text="" CssClass="txtRegbig" ReadOnly="true">
                        </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    Receiver Name :
                </td>
                <td align="left">
                    <table>
                        <tr>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtRECEIVERFNAME" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtRECEIVERMNAME" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                            <td>
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
                    Address1 :
                </td>
                <td>
                    <span class="regBoxbig1">
                        <asp:TextBox ID="txtRECEIVERADDRESS1" runat="server" Text="" CssClass="txtRegbig1">
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
                        <asp:TextBox ID="txtRECEIVERADDRESS2" runat="server" Text="" CssClass="txtRegbig1">
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
                                    <asp:TextBox ID="txtRECEIVERSTATE" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                            <td style="width: 10px;">
                                City:
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtRECEIVERCITY" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                            <td style="width: 10px;">
                                Zip:
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtRECEIVERZIP" runat="server" Text="" CssClass="txtRegsmall">
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
                                    <asp:TextBox ID="txtRECEIVERPHONE" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Scan :
                </td>
                <td>
                    <asp:FileUpload ID="uplFile" runat="server" CssClass="txtRegbig" />
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
    <div class="memberBotBtnlist">
        <!-- Begin: memberBotBtnlist -->
        <%--                    	<input type="submit" value="SAR" class="btnregbot" />
                        <input type="submit" value="History" class="btnregbot" />
                        <input type="submit" value="Delete" class="btnregbot" />
                        <input type="submit" value="Edit Sender" class="btnregbot" />
                        <input type="submit" value="New Sender" class="btnregbot nomargin" />--%>
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregbot" OnClick="btnBack_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnregbot" OnClick="btnSave_Click"
            OnClientClick=" return validate()" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnregbot" OnClick="btnUpdate_Click"
            OnClientClick=" return validate()" />
        <asp:Button ID="btnScanID" runat="server" Text="Scan ID" CssClass="btnregbot" OnClick="btnScanID_Click" />
        <%--  <asp:Button ID="btnScanPasswort" runat="server" Text="Scan Passwort" 
                            CssClass="btnregbot nomargin" 
             onclick="btnScanPasswort_Click"  />--%>
    </div>
</asp:Content>
