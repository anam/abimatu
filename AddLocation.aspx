<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="AddLocation.aspx.cs" Inherits="AddLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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


    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtCOUNTRY.ClientID%>").value == "") {
                alert("Country can not be blank");
                document.getElementById("<%=txtCOUNTRY.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtCITY.ClientID%>").value == "") {
                alert("CITY can not be blank");
                document.getElementById("<%=txtCITY.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtBRANCH.ClientID%>").value == "") {
                alert("Branch can not be blank");
                document.getElementById("<%=txtBRANCH.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtAGENTRATE.ClientID%>").value == "") {
                alert("RATE can not be blank");
                document.getElementById("<%=txtAGENTRATE.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=txtBRANCH_CODE.ClientID%>").value == "") {
                alert("BRANCH CODE can not be blank");
                document.getElementById("<%=txtBRANCH_CODE.ClientID%>").focus();
                return false;
            }


            if (document.getElementById("<%=txtSEQUENCE.ClientID%>").value == "") {
                alert("SEQUENCE can not be blank");
                document.getElementById("<%=txtSEQUENCE.ClientID%>").focus();
                return false;
            }


            if (document.getElementById("<%=txtAGENTRATE.ClientID%>").value == "") {
                alert("Rate is not valid");
                document.getElementById("<%=txtAGENTRATE.ClientID%>").focus();
                return false;
            }
            var digits = "0123456789.";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtAGENTRATE.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtAGENTRATE.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Rate");
                    document.getElementById("<%=txtAGENTRATE.ClientID%>").focus();
                    return false;
                }
            }

            //            if (document.getElementById("<%=txtSEQUENCE.ClientID%>").value == "") {
            //                alert("Sequence is not valid");
            //                document.getElementById("<%=txtSEQUENCE.ClientID%>").focus();
            //                return false;
            //            }
            var digits = "0123456789";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtSEQUENCE.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtSEQUENCE.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Please enter correct Sequence");
                    document.getElementById("<%=txtSEQUENCE.ClientID%>").focus();
                    return false;
                }
            }

            return true;
        }
</script>

    <style type="text/css">
        .modalBackground
        {
            background-color: #DCDCDC;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        
        .modalPopup
        {
            background-color: White;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding: 5px;
            width: 600px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="Default.aspx">Back</a></li>
        <li id="selected"><a href="AddLocation.aspx">Location</a></li>
        <li><a href="AdminLOCATIONGROUPDisplay.aspx">All Location Groups</a></li>
        <li><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li ><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%><li><a href="AdminFOODITEM_MASTERDisplay.aspx">Food Rate</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <h3 style="text-indent: 20px; color: #000000; margin-bottom: 10px;">
            Location</h3>
        <hr />
        <br />
    <div>
        <table style="width: 100%; table-layout: fixed;">
            <colgroup>
                <col width="15%" style="font-weight: bold;" />
                <col width="85%" align="left" />
            </colgroup>
                        <tr>
                <td>
                    Agent :
                </td>
                <td>
                    <asp:DropDownList ID="ddlAGENT" runat="server" CssClass="ddlcss" Width="215px" >
                    </asp:DropDownList>
                    
                </td>
            </tr>

            <tr>
                <td>
                    Country :
                </td>
                <td>
                    <span class="regBoxsmall">
                        <asp:TextBox ID="txtCOUNTRY" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    City :
                </td>
                <td>
                    <span class="regBoxsmall">
                        <asp:TextBox ID="txtCITY" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    Branch :
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtBRANCH" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                    <asp:Label ID="lblLocationID" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtNumberOfBranch" runat="server" Text="" CssClass="txtRegsmall"
                                        ReadOnly="true" Visible="false">
                    </asp:TextBox>
                                </span>
                            </td>
                            <%--<td>
                                Number Of Branch :
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    
                                </span>
                            </td>--%>
                            
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                   Default Rate :
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtAGENTRATE" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                </span>
                            </td>
                            <td>
                                Branch Code :
                            </td>
                            <td>
                                <span class="regBoxsmall">
                                    <asp:TextBox ID="txtBRANCH_CODE" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                                </span>(For Food It Must be 0)
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Sequence :
                </td>
                <td>
                    <span class="regBoxsmall">
                        <asp:TextBox ID="txtSEQUENCE" runat="server" Text="" CssClass="txtRegsmall">
                    </asp:TextBox>
                    </span>
                </td>
            </tr>
        </table>
    </div>
    <div class="memberlist" style="overflow: scroll; height:500px;">
        <asp:GridView ID="gvLocationInfo" runat="server" AutoGenerateColumns="false" CssClass="gridCss"
            GridLines="Both" BorderColor="#CDCDCD" Width="580px">
            <Columns>
                <asp:TemplateField HeaderText="Select" ControlStyle-Width="60px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbtSelect" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                        <asp:Label ID="lblLOCATIONID" runat="server" Text='<%#Eval("LOCATIONID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="COUNTRY">
                    <ItemTemplate>
                        <asp:Label ID="lblCOUNTRY" runat="server" Text='<%#Eval("COUNTRY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CITY">
                    <ItemTemplate>
                        <asp:Label ID="lblCITY" runat="server" Text='<%#Eval("CITY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BRANCH">
                    <ItemTemplate>
                        <asp:Label ID="lblBRANCH" runat="server" Text='<%#Eval("BRANCH") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BRANCH_CODE">
                    <ItemTemplate>
                        <asp:Label ID="lblBRANCH_CODE" runat="server" Text='<%#Eval("BRANCH_CODE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SEQUENCE">
                    <ItemTemplate>
                        <asp:Label ID="lblSEQUENCE" runat="server" Text='<%#Eval("SEQUENCE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTID">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTRATE">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTRATE" runat="server" Text='<%#Eval("AGENTRATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="gvHeadercss" />
            <RowStyle CssClass="gvRowCss" />
            <AlternatingRowStyle CssClass="gvRowAltCss" />
        </asp:GridView>
    </div>
    <div class="memberBotBtnlist">
        
        <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btnregtop" OnClick="btnNew_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Edit" CssClass="btnregtop" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnregtop" OnClick="btnSave_Click" OnClientClick=" return validate()" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnregtop" 
            onclick="btnDelete_Click"  />
    </div>
    <br />
    <br />
    <div style="width: 100%; float: left;">
        <center>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </center>
    </div>


            <div style="visibility: hidden;">
        <asp:Button ID="Button1" runat="server" Text="" />
    </div>
    <br />
    <br />
    <asp:Panel ID="panAll" runat="server" CssClass="modalPopup">
        <center>
<div style=" height:300px; width:100%; overflow:scroll;">
                <asp:GridView ID="gvwSearch" runat="server" AutoGenerateColumns="false" CssClass="gridCss"
                    GridLines="Both" BorderColor="#CDCDCD" Width="100%">
                    <Columns>
                <asp:TemplateField HeaderText="Select" ControlStyle-Width="60px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbtSelect" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                        <asp:Label ID="lblLOCATIONID" runat="server" Text='<%#Eval("LOCATIONID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblCOUNTRY" runat="server" Text='<%#Eval("COUNTRY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCITY" runat="server" Text='<%#Eval("CITY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Branch">
                    <ItemTemplate>
                        <asp:Label ID="lblBRANCH" runat="server" Text='<%#Eval("BRANCH") %>'>
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



            

            <br />
            <br />
                    <table>
                    <tr>
                    <td>
                            <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btnregbot" 
                    onclick="btnOk_Click"  />
                    </td>
                    <td>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnregbot" 
                    onclick="btnCancel_Click"  />
                    </td>
                    </tr>
                    </table>
                    <br />
                    

    
            </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBackground" DropShadow="false"
        runat="server" PopupControlID="panAll" ID="ModalPopupExtender1" TargetControlID="Button1" />
</asp:Content>
