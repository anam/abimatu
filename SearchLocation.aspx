<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="SearchLocation.aspx.cs" Inherits="SearchLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        <li ><a href="SearchSenderPage.aspx">Search Sender</a></li>
        <li><a href="CUSTOMERInsertUpdate.aspx?cUSTOMERID=0">Sender</a></li>
        <li><a href="SearchReceiverPage.aspx">Search Receiver</a></li>
        <li><a href="ReceiverInsertUpdate.aspx?rECEIVERID=0">Receiver</a></li>
        <li id="selected"><a href="SearchLocation.aspx">Search Location</a></li>
        <li ><a href="Payment.aspx">Payment</a></li>
                <li><a href="Transmit.aspx">Transmit</a></li><li><a href="Default.aspx">Back</a></li>
                        </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div>
<%--    <asp:UpdatePanel ID="upnSearch" runat="server">
    <ContentTemplate>--%>
    
        <asp:HiddenField ID="hfAgentID" runat="server" />
        <table style="width: 100%; table-layout: fixed;">
            <colgroup>
                <col width="15%" style="font-weight: bold;" />
                <col width="85%" align="left" />
            </colgroup>
            <tr>
                <td>
                    Country :
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" CssClass="ddlcss"
                                    OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Branch Location :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" CssClass="ddlcss"
                                    Width="200px" onselectedindexchanged="ddlBranch_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    City :
                </td>
                <td>
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="ddlcss" Width="200px" AutoPostBack="false">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="regRow">
            <div class="regbtnrow">
                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnregtop" OnClick="btnBack_Click" />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnregtop" OnClick="btnSearch_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btnregtop" OnClick="btnClear_Click" />
            </div>

            <asp:Button ID="btnSelect" runat="server" Text="Select" CssClass="btnselect" OnClick="btnSelect_Click" />
        </div>
    
    <div class="memberlist" style="overflow: scroll; height: 500px;">
        <asp:GridView ID="gvLocationInfo" runat="server" AutoGenerateColumns="false" CssClass="gridCss"
            GridLines="Both" BorderColor="#CDCDCD" 
            Width="580px">
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
            <span style=" color:Red; font-size:15px; text-align:center;">
            No Location Found
            </span>
            </EmptyDataTemplate>
            <HeaderStyle CssClass="gvHeadercss" />
            <RowStyle CssClass="gvRowCss" />
            <AlternatingRowStyle CssClass="gvRowAltCss" />
        </asp:GridView>
    </div>
        

            <div class="memberBotBtnlist" >
        <asp:Button ID="btnSAR" runat="server" Text="SAR" CssClass="btnregbot" OnClick="btnSAR_Click" />
        <asp:Button ID="btnHistory" runat="server" Text="History" CssClass="btnregbot" OnClick="btnHistory_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnregbot" OnClick="btnDelete_Click" />
        <asp:Button ID="btnEditLocation" runat="server" Text="Edit Location" 
                    CssClass="btnregbot" onclick="btnEditLocation_Click"
             />
        <asp:Button ID="btnNewLocation" runat="server" Text="New Location" 
                    CssClass="btnregbot nomargin" onclick="btnNewLocation_Click"
            />
    </div>
    <br />
    <br />

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
    <div style="width: 100%; float: left;">
        <center>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </center>
    </div>

<%--        </ContentTemplate>
    
    </asp:UpdatePanel>--%>
    <%--</div>--%>

</asp:Content>
