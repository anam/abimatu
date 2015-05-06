<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true" CodeFile="SearchFoodLocation.aspx.cs" Inherits="SearchFoodLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" Runat="Server">
    <ul>
        <li><a href="SearchFoodSenderPage.aspx">Search Food Sender</a></li>
        <li><a href="CUSTOMERInsertUpdateFood.aspx?cUSTOMERID=0">Sender</a></li>
        <li><a href="SearchFoodReceiverPage.aspx">Search Food Receiver</a></li>
        <li><a href="ReceiverInsertUpdateFood.aspx?rECEIVERID=0">Receiver</a></li>
        <li   id="selected"><a href="SearchFoodLocation.aspx">Search Food Location</a></li>
                <li><a href="FoodTransactionPage.aspx">Food Transaction</a></li><li><a href="Default.aspx">Back</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" Runat="Server">
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
        
    <br />
    <br />
    <div style="width: 100%; float: left;">
        <center>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </center>
    </div>

<%--        </ContentTemplate>
    
    </asp:UpdatePanel>--%>
    <%--</div>--%>
</asp:Content>

