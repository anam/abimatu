<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="CUSTOMERInsertUpdateFood.aspx.cs" Inherits="CUSTOMERInsertUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script language="javascript" type="text/javascript">
    function validate() {
//        if (document.getElementById("<%=txtCUSTFNAME.ClientID%>").value == "") {
//            alert("First Name can not be blank");
//            document.getElementById("<%=txtCUSTFNAME.ClientID%>").focus();
//            return false;
//        }

//        if (document.getElementById("<%=txtCUSTMNAME.ClientID%>").value == "") {
//            alert("Middle Name can not be blank");
//            document.getElementById("<%=txtCUSTMNAME.ClientID%>").focus();
//            return false;
//        }

//        if (document.getElementById("<%=txtCUSTLNAME.ClientID%>").value == "") {
//            alert("Last Name can not be blank");
//            document.getElementById("<%=txtCUSTLNAME.ClientID%>").focus();
//            return false;
//        }

//        if (document.getElementById("<%=txtCUSTADDRESS1.ClientID%>").value == "") {
//            alert("Address1 can not be blank");
//            document.getElementById("<%=txtCUSTADDRESS1.ClientID%>").focus();
//            return false;
//        }

//        if (document.getElementById("<%=txtCUSTSTATE.ClientID%>").value == "") {
//            alert("State can not be blank");
//            document.getElementById("<%=txtCUSTSTATE.ClientID%>").focus();
//            return false;
//        }


//        if (document.getElementById("<%=txtCUSTCITY.ClientID%>").value == "") {
//            alert("City can not be blank");
//            document.getElementById("<%=txtCUSTCITY.ClientID%>").focus();
//            return false;
//        }


//        if (document.getElementById("<%=txtCUSTZIP.ClientID%>").value == "") {
//            alert("Zip is not valid");
//            document.getElementById("<%=txtCUSTZIP.ClientID%>").focus();
//            return false;
//        }

//        if (document.getElementById("<%=txtCUSTHPHONE.ClientID%>").value == "") {
//            alert("Home Phone can not be blank");
//            document.getElementById("<%=txtCUSTHPHONE.ClientID%>").focus();
//            return false;
//        }



        return true;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="SearchFoodSenderPage.aspx">Search Food Sender</a></li>
        <li  id="selected"><a href="CUSTOMERInsertUpdateFood.aspx?cUSTOMERID=0">Sender</a></li>
        <li><a href="SearchFoodReceiverPage.aspx">Search Food Receiver</a></li>
        <li><a href="ReceiverInsertUpdateFood.aspx?rECEIVERID=0">Receiver</a></li>
        <li><a href="SearchFoodLocation.aspx">Search Food Location</a></li>
                <li><a href="FoodTransactionPage.aspx">Food Transaction</a></li><li><a href="Default.aspx">Back</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div>
        <table style="width: 100%; table-layout: fixed;">
            <colgroup>
                <col width="15%" style="font-weight: bold;" />
                <col width="85%" align="left" />
            </colgroup>
            <tr>
                <td>
                    Member ID :
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
                    Member Name :
                </td>
                <td align="left">
                    <table>
                        <tr>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtCUSTFNAME" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtCUSTMNAME" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtCUSTLNAME" runat="server" Text="" CssClass="txtRegsmall">
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
                        <asp:TextBox ID="txtCUSTADDRESS1" runat="server" Text="" CssClass="txtRegbig1">
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
                        <asp:TextBox ID="txtCUSTADDRESS2" runat="server" Text="" CssClass="txtRegbig1">
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
                    Home Phone Number :
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtCUSTHPHONE" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                            <td>
                                Cell :
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtCUSTCPHONE" runat="server" Text="" CssClass="txtRegsmall">
                                    </asp:TextBox>
                                </span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Work Number :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtCUSTWPHONE" runat="server" Text="" CssClass="txtRegbig">
                        </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    Driving License :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtDrivingLicense" runat="server" Text="" CssClass="txtRegbig">
                        </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    SSN :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtCUSTSSN" runat="server" Text="" CssClass="txtRegbig">
                        </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    ID Type :
                </td>
                <td>
                    <asp:DropDownList ID="ddlCUST" runat="server" CssClass="txtRegbig">
                    </asp:DropDownList>
                </td>
            </tr>
                        <tr>
                <td>
                    Scan :
                </td>
                <td>
                    <asp:FileUpload ID="uplFile" runat="server"  CssClass="txtRegbig" />
                </td>
            </tr>
            <tr>
                <td>
                    ID Number :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtCUSTIDNUMBER" runat="server" Text="" CssClass="txtRegbig">
                        </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    Issue Date :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtCUSTISSUEDATE" runat="server" Text="" CssClass="txtRegbig">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomRight"
                            PopupButtonID="txtCUSTISSUEDATE" TargetControlID="txtCUSTISSUEDATE">
                        </ajaxToolkit:CalendarExtender>
                    </span>
                    Get Date From Calender
                </td>
            </tr>
            <tr>
                <td>
                    Expires Date :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtCUSTEXPIREDATE" runat="server" Text="" CssClass="txtRegbig">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupPosition="BottomRight"
                            PopupButtonID="txtCUSTEXPIREDATE" TargetControlID="txtCUSTEXPIREDATE">
                        </ajaxToolkit:CalendarExtender>
                         </span>
                         Get Date From Calender
                </td>
            </tr>
            <tr>
                <td>
                    DOB :
                </td>
                <td>
                    <span class="regBoxbig">
                        <asp:TextBox ID="txtCUSTDOB" runat="server" Text="" CssClass="txtRegbig">
                        </asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupPosition="BottomRight"
                            PopupButtonID="txtCUSTDOB" TargetControlID="txtCUSTDOB">
                        </ajaxToolkit:CalendarExtender>
                    </span>
                    Get Date From Calender
                </td>
            </tr>
            <tr>
                <td>
                    Remarks :
                </td>
                <td>
                    <span class="regBoxbig1">
                        <asp:TextBox ID="txtCUSTREMARKS" runat="server" Text="" CssClass="txtRegbig1">
                        </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblOfacMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                 <asp:Panel ID="panlIFrame" runat="server" Visible="false">
<%--            <div id="data" style="width: 660px; height: 220px; overflow-y: hidden; overflow: hidden">
                <iframe height="220" width="660" scrolling="no" src="https://www.patriotagent.com/">
                </iframe>
            </div>--%>
            <center>
            <%--<INPUT type="button" value="Please Click here to contact with Patriot Agent!" onClick="window.open('https://www.patriotagent.com/','mywindow','width=400,height=200')"> --%>
                <%--<asp:Button ID="btnPatriotAgent" runat="server" 
                    Text="Please Click here to contact with Patriot Agent!" 
                    onclick="btnPatriotAgent_Click" />--%>
                    <a href="https://www.patriotagent.com/" target="_blank" style="color:Blue;text-decoration:underline;">Please Click here</a> For PATRIOT AGENT. <br />To Check the ID and DOB to Confirm that this is a Suspecious Customer. 
            <br />

            <%--if found suspicious activity <asp:CheckBox ID="CheckBox1" runat="server" onClick="window.open('https://www.patriotagent.com/','mywindow','width=400,height=200')"/>--%>
            <b style="color:RED;text-decoration:underline;">if found suspicious customer please Click here. And Click save </b><asp:CheckBox ID="chkSuspicious" runat="server" />

            <br />
                <asp:Label ID="lblCheckSus" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Button ID="btnSaveSA" runat="server" Text="Save" 
                    onclick="btnSaveSA_Click" />

            </center>
        </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <div class="memberBotBtnlist">
        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregbot" OnClick="btnBack_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnregbot" OnClick="btnSave_Click" OnClientClick=" return validate()" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnregbot" OnClick="btnUpdate_Click" OnClientClick=" return validate()" />
        <asp:Button ID="btnScanID" runat="server" Text="Scan ID" CssClass="btnregbot" OnClick="btnScanID_Click" />
    </div>
</asp:Content>
