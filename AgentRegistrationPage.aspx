<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="AgentRegistrationPage.aspx.cs" Inherits="AgentRegistrationPage" %>

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
        <li><a href="AddLocation.aspx">Location</a></li>
        <li><a href="AdminLOCATIONGROUPDisplay.aspx">All Location Groups</a></li>
        <li><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li id="selected"><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%><li><a href="AdminFOODITEM_MASTERDisplay.aspx">
            Food Rate</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div style="width: 98%; margin: 0px auto; margin-bottom: 20px;">
        <h3 style="text-indent: 20px; color: #000000; margin-bottom: 10px;">
            Agent Registration</h3>
        <hr />
        <br />
        <div style="width: 100%;">
            <table style="width: 100%; table-layout: fixed;">
                <colgroup>
                    <col width="50%" />
                    <col width="50%" />
                </colgroup>
                <tr>
                    <td valign="top">
                        <table style="width: 100%; table-layout: fixed;">
                            <colgroup>
                                <col width="35%" />
                                <col width="64%" />
                                <col width="1%" />
                            </colgroup>
                            <tbody>
                                
                                <asp:Panel ID="panAspUserName" runat="server" Visible="false">
                                    <tr>
                                        <td>
                                            Username:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="textBOXcss2" />
                                            <asp:Label ID="lblUserInfoID" runat="server" CssClass="textBOXcss2" />

                                            <asp:RequiredFieldValidator ID="userNameRequiredValidator" runat="server" ControlToValidate="txtUserName"
                                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter username."
                                                Text="*" ValidationGroup="registrationWizard" ForeColor="Red"
                                                Font-Size="9px" />
                                            <asp:RegularExpressionValidator ID="userNameExpressionValidator" runat="server" ControlToValidate="txtUserName"
                                                SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w{2,12}" ErrorMessage="Username must be between 2 to 12 characters."
                                                Text="*" ValidationGroup="registrationWizard"
                                                ForeColor="Red" Font-Size="9px" />
                                        </td>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            Password:
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textBOXcss2" />

                                             <asp:RequiredFieldValidator ID="passwordRequiredValidator" runat="server" ControlToValidate="txtPassword"
                                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter password"
                                                Text="*" ValidationGroup="registrationWizard" ForeColor="Red"
                                                Font-Size="9px" />
                                            <asp:RegularExpressionValidator ID="passwordExpressionValidator" runat="server" ControlToValidate="txtPassword"
                                                SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w{5,}" ErrorMessage="Password must be minimum 5 characters."
                                                Text="*" ValidationGroup="registrationWizard"
                                                ForeColor="Red" Font-Size="9px" />
                                        </td>
                                        <td style="text-align: left">
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Confirm password:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="textBOXcss2" />

                                            <asp:RequiredFieldValidator ID="confirmPasswordRequiredValidator" runat="server"
                                                ControlToValidate="txtConfirmPassword" SetFocusOnError="true" Display="Dynamic"
                                                ForeColor="Red" Font-Size="9px" ErrorMessage="Please confirm password." Text="*"
                                                ValidationGroup="registrationWizard" />
                                            <asp:CompareValidator ID="confirmPasswordCompareValidator" runat="server" ControlToValidate="txtConfirmPassword"
                                                ForeColor="Red" Font-Size="9px" ControlToCompare="txtPassword" SetFocusOnError="true"
                                                Display="Dynamic" ErrorMessage="Password and confirm password do not match."
                                                Text="*" ValidationGroup="registrationWizard" />
                                        </td>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            E-mail:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textBOXcss2" />

                                            <asp:RequiredFieldValidator ID="emailRequiredValidator" runat="server" ControlToValidate="txtEmail"
                                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter e-mail."
                                                ForeColor="Red" Font-Size="9px" Text="*" ValidationGroup="registrationWizard" />
                                            <asp:RegularExpressionValidator runat="server" ID="emailExpressionValidator" ControlToValidate="txtEmail"
                                                ForeColor="Red" Font-Size="9px" Display="Dynamic" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ErrorMessage="E-mail is not valid." Text="*" ValidationGroup="registrationWizard" />
                                        </td>
                                        <td>
                                            
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td>
                                        Agent Name:
                                    </td>
                                    <td>
                                        
                                        <asp:TextBox ID="txtAGENTNAME" runat="server" Text="" CssClass="textBOXcss2">
                                        </asp:TextBox>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                            Text="*" ControlToValidate="txtAGENTNAME" ErrorMessage="Fisrt Name Required"
                                            SetFocusOnError="true" ValidationGroup="registrationWizard" Font-Size="9px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Location Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAGENTLOCATION" runat="server" Text="" CssClass="textBOXcss2">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Address:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAGENTADDRESS" runat="server" Text="" CssClass="textBOXcss2" TextMode="MultiLine"
                                            Height="100px">
                                        </asp:TextBox>

                                        
                                    </td>
                                    <td>
                                        
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                    <td valign="top">
                        <asp:UpdatePanel ID="upPanel" runat="server">
                            <ContentTemplate>
                                <table width="100%" style="table-layout: fixed;">
                                    <colgroup>
                                        <col width="35%" />
                                        <col width="64%" />
                                        <col width="1%" />
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                            <td>
                                                State:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAGENTSTATE" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>

                                            </td>
                                            <td>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                City:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAGENTCITY" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Zip:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAGENTZIP" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>

                                              
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Phone #:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAGENTPHONE" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Account #:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAGENTACC" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="panAspSecurity" runat="server">
                                            <tr>
                                                <td>
                                                    Security Question:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSecurityQuestion" runat="server" CssClass="textBOXcss2">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Security Answer:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSecurityAnswer" runat="server" CssClass="textBOXcss2">
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                        </table>
        </div>
    </div>

    
   <div style="width: 80%; text-align: left; margin-bottom: 20px;">
        <asp:Label runat="server" ForeColor="Red" Font-Bold="true" ID="lblError" Text=""></asp:Label>
    </div>


    <div style="width: 98%; text-align: left; margin-bottom: 50px; float: left; overflow: scroll;
        height: 300px;">
        <asp:GridView ID="gvAGENT" runat="server" AutoGenerateColumns="false" CssClass="gridCss"
            GridLines="Both" BorderColor="#CDCDCD" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbtSelect" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                        <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTNAME">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTNAME" runat="server" Text='<%#Eval("AGENTNAME") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="USERNAME" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUSERNAME" runat="server" Text='<%#Eval("USERNAME") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTLOCATION">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTLOCATION" runat="server" Text='<%#Eval("AGENTLOCATION") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTADDRESS">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTADDRESS" runat="server" Text='<%#Eval("AGENTADDRESS") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTCITY">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTCITY" runat="server" Text='<%#Eval("AGENTCITY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTSTATE">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTSTATE" runat="server" Text='<%#Eval("AGENTSTATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTZIP">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTZIP" runat="server" Text='<%#Eval("AGENTZIP") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTPHONE">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTPHONE" runat="server" Text='<%#Eval("AGENTPHONE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTACC">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTACC" runat="server" Text='<%#Eval("AGENTACC") %>'>
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


    <div style="width: 98%; text-align: left; padding-left: 0px; margin-bottom: 20px;
        float: left;">
        <center>
            <table align="center" width="300px">
                <tr>
                    <td>
                        <asp:Button ID="btnNew" runat="server" Text="New" CssClass="btnregtop" OnClick="btnNew_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Edit" CssClass="btnregtop" OnClick="btnUpdate_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save"  ValidationGroup="registrationWizard" CssClass="btnregtop" OnClick="btnSave_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnregtop" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Label ID="lblregistrationError" runat="server" ForeColor="Red" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </center>
    </div>

             
    <div style="visibility: hidden;">
        <asp:Button ID="Button1" runat="server" Text="" />
    </div>
    <br />
    <br />
    <asp:Panel ID="panAll" runat="server" CssClass="modalPopup">
        <center>
            <div style="height: 300px; width: 98%; overflow: scroll;">
                <h2>
                    Select the Agent to which you want to switch the info..</h2>
                <asp:GridView ID="gvwSearch" runat="server" AutoGenerateColumns="false" CssClass="gridCss"
                    GridLines="Both" BorderColor="#CDCDCD" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Select" ControlStyle-Width="60px">
                            <ItemTemplate>
                                <asp:RadioButton ID="rbtSelect" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                                <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AGENTNAME">
                            <ItemTemplate>
                                <asp:Label ID="lblAGENTNAME" runat="server" Text='<%#Eval("AGENTNAME") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AGENTLOCATION">
                            <ItemTemplate>
                                <asp:Label ID="lblAGENTLOCATION" runat="server" Text='<%#Eval("AGENTLOCATION") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AGENTADDRESS">
                            <ItemTemplate>
                                <asp:Label ID="lblAGENTADDRESS" runat="server" Text='<%#Eval("AGENTADDRESS") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AGENTCITY">
                            <ItemTemplate>
                                <asp:Label ID="lblAGENTCITY" runat="server" Text='<%#Eval("AGENTCITY") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AGENTPHONE">
                            <ItemTemplate>
                                <asp:Label ID="lblAGENTPHONE" runat="server" Text='<%#Eval("AGENTPHONE") %>'>
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
                        <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btnregbot" OnClick="btnOk_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnregbot" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
            <br />
        </center>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBackground" DropShadow="false"
        runat="server" PopupControlID="panAll" ID="ModalPopupExtender1" TargetControlID="Button1" />
</asp:Content>
