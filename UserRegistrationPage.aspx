<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="UserRegistrationPage.aspx.cs" Inherits="UserRegistrationPage" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" runat="Server">
    <ul>
        <li><a href="Default.aspx">Back</a></li>
        <li><a href="AddLocation.aspx">Location</a></li>
        <li><a href="AdminLOCATIONGROUPDisplay.aspx">All Location Groups</a></li>
        <li><a href="AdminLOCATIONMAPPINGDisplay.aspx">Location ~ Location Group</a></li>
        <li><a href="AgentRegistrationPage.aspx">Agent</a></li>
        <li id="selected"><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%><li><a href="AdminFOODITEM_MASTERDisplay.aspx">
            Food Rate</a></li>
        <li><a href="DatabaseBackup.aspx">Database backup</a></li>
        <li ><a href="AdminDisplayUSER_Membership.aspx">Unloack User</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div style="width: 98%; margin: 0px auto; margin-bottom: 20px; float: left;">
        <h3 style="text-indent: 20px; color: #000000; margin-bottom: 10px;">
            User Registration</h3>
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
                                <tr>
                                    <td>
                                        Type:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="ddlcss" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Text="Agent" Value="Agent"></asp:ListItem>
                                            <asp:ListItem Text="Location" Value="Location"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <asp:Panel ID="panAspUserName" runat="server">
                                    <tr>
                                        <td>
                                            Username:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="textBOXcss2" />
                                            <asp:Label ID="lblUserInfoID" runat="server" Visible="false"></asp:Label>

                                            <asp:RequiredFieldValidator ID="userNameRequiredValidator" runat="server" ControlToValidate="txtUserName"
                                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter username."
                                                Text="*" ValidationGroup="registrationWizard" ForeColor="Red" Font-Size="9px" />
                                            <asp:RegularExpressionValidator ID="userNameExpressionValidator" runat="server" ControlToValidate="txtUserName"
                                                SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w{2,12}" ErrorMessage="Username must be between 2 to 12 characters."
                                                Text="*" ValidationGroup="registrationWizard" ForeColor="Red" Font-Size="9px" />
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
                                            <asp:Label ID="lblPassword" Visible="false" runat="server" Text=""></asp:Label>

                                            <asp:RequiredFieldValidator ID="passwordRequiredValidator" runat="server" ControlToValidate="txtPassword"
                                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter password"
                                                Text="*" ValidationGroup="registrationWizard" ForeColor="Red" Font-Size="9px" />
                                            <asp:RegularExpressionValidator ID="passwordExpressionValidator" runat="server" ControlToValidate="txtPassword"
                                                SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w{5,}" ErrorMessage="Password must be minimum 5 characters."
                                                Text="*" ValidationGroup="registrationWizard" ForeColor="Red" Font-Size="9px" />
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
                                            <asp:RequiredFieldValidator ID="emailRequiredValidator"  runat="server" ControlToValidate="txtEmail"
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
                                        First Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBOXcss2"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                            Text="*" ControlToValidate="txtFirstName" ErrorMessage="Fisrt Name Required"
                                            SetFocusOnError="true" ValidationGroup="registrationWizard" Font-Size="9px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Last Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="textBOXcss2"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                            Text="*" ControlToValidate="txtLastName" ErrorMessage="User Name Required"
                                            SetFocusOnError="true" ValidationGroup="registrationWizard" Font-Size="9px"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                 
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Middle Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMiddleName" runat="server" CssClass="textBOXcss2"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Address:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="textBOXcss2" TextMode="MultiLine"
                                            Height="100px"></asp:TextBox>
                                            
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
                                        <col width="40%" />
                                        <col width="55%" />
                                        <col width="0%" />
                                    </colgroup>
                                    <tbody>
                                        <tr>
                                            <td>
                                                Agent / Location Name:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAgent_Location" runat="server" CssClass="ddlcss">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Country:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCountry" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red"
                                                    InitialValue="0" Text="*" ControlToValidate="txtCountry" ErrorMessage="Country Required"
                                                    SetFocusOnError="true"  Font-Size="9px"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                State:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtState" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                                    InitialValue="0" Text="*" ControlToValidate="txtState" ErrorMessage="State Required"
                                                    SetFocusOnError="true" Font-Size="9px"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                City:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCity" runat="server" Text="" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Postal Code:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="textBOXcss2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red"
                                                    Text="*" ControlToValidate="txtPostalCode" ErrorMessage="Postal Code Required"
                                                    SetFocusOnError="true"  Font-Size="9px"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Home Phone:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHomePhone" runat="server" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Work Phone:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtWorkPhone" runat="server" CssClass="textBOXcss2">
                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                                    Text="*" ControlToValidate="txtPostalCode" ErrorMessage="Postal Code Required"
                                                    SetFocusOnError="true" ValidationGroup="registrationWizard" Font-Size="9px"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Mobile:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMobile" runat="server" CssClass="textBOXcss2">
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
                                            <tr>
                                                <td>
                                                    Status:
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkActive" runat="server" Text="Active?"/>
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
                <tr>
                    <td>
                        <asp:Label ID="lblregistrationError" runat="server" ForeColor="Red" />
                    </td>
                    <td colspan="2" align="center">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="width: 80%; text-align: left; padding-left: 50px; margin-bottom: 20px;">
        <asp:Label runat="server" ForeColor="Red" Font-Bold="true" ID="lblError" Text=""></asp:Label></div>
    <div class="memberlist" style="overflow: scroll;  width: 98%;">
        <asp:GridView ID="gvUSERINFO" runat="server" AutoGenerateColumns="false" CssClass="gridCss"
            GridLines="Both" BorderColor="#CDCDCD" Width="100%" OnRowDataBound="gvUSERINFO_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbtSelect" runat="server" OnClick="javascript:SelectSingleRadiobutton(this.id)" />
                        <asp:Label ID="lblUSERINFOID" runat="server" Text='<%#Eval("USERINFOID") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UserName">
                    <ItemTemplate>
                        <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent_LocationID">
                    <ItemTemplate>
                        <asp:Label ID="lblAgent_LocationID" runat="server" Text='<%#Eval("Agent_LocationID") %>'
                            Visible="false">
                        </asp:Label>
                        <asp:Label ID="lblAgent_LocationName" runat="server">
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("FirstName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName">
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("LastName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MiddleName">
                    <ItemTemplate>
                        <asp:Label ID="lblMiddleName" runat="server" Text='<%#Eval("MiddleName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Country") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PostalCode">
                    <ItemTemplate>
                        <asp:Label ID="lblPostalCode" runat="server" Text='<%#Eval("PostalCode") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HomePhone">
                    <ItemTemplate>
                        <asp:Label ID="lblHomePhone" runat="server" Text='<%#Eval("HomePhone") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="WorkPhone">
                    <ItemTemplate>
                        <asp:Label ID="lblWorkPhone" runat="server" Text='<%#Eval("WorkPhone") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile">
                    <ItemTemplate>
                        <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile") %>'>
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
        <asp:Button ID="btnUpdate" runat="server" Text="Edit" CssClass="btnregtop" OnClick="btnUpdate_Click"
            OnClientClick=" return validate()" />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnregtop" OnClick="btnSubmit_Click"
            OnClientClick=" return validate()" ValidationGroup="registrationWizard" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnregtop" OnClientClick=" return validate()"
            OnClick="btnDelete_Click" />
    </div>
    <br />
    <br />
    <div style="width: 100%; float: left;">
        <center>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </center>
    </div>
</asp:Content>
