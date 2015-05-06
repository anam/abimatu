<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true" CodeFile="SenderHistoryPage.aspx.cs" Inherits="SenderHistoryPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" Runat="Server">
    <ul>
        <li id="selected"><a href="SearchSenderPage.aspx">Back</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" Runat="Server">
<div class="memberlist" style="overflow: scroll; height: 500px; width:100%;">
<asp:GridView ID="gvTRANS" runat="server" AutoGenerateColumns="false" CssClass="gridCss"
            GridLines="Both" BorderColor="#CDCDCD" PageSize="15" AllowPaging="true" OnPageIndexChanging="gvTRANS_PageIndexChanging" OnRowDataBound="gvTRANS_RowDataBound" >
            <PagerSettings Mode="NumericFirstLast" />
            <Columns>
<%--                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("TRANSID") %>' OnClick="lbSelect_Click">
                            Select
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="CUST">
                    <ItemTemplate>
                        <asp:Label ID="lblCUSTID" runat="server" Text='<%#Eval("CUSTID") %>' Visible="false">

                        </asp:Label>
                                                <asp:Label ID="lblCustName" runat="server">

                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RECEIVER">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERID" runat="server" Text='<%#Eval("RECEIVERID") %>' Visible="false">
                        </asp:Label>
                                                <asp:Label ID="lblreceiverName" runat="server">

                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LOCATION">
                    <ItemTemplate>
                        <asp:Label ID="lblLOCATIONID" runat="server" Text='<%#Eval("LOCATIONID") %>' Visible="false">
                        </asp:Label>
                                                <asp:Label ID="lblLocationName" runat="server">

                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSDT">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSDT" runat="server" Text='<%#Eval("TRANSDT") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSAMOUNT">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSAMOUNT" runat="server" Text='<%#Eval("TRANSAMOUNT") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSFEES">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSFEES" runat="server" Text='<%#Eval("TRANSFEES") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSOTHERFEES">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSOTHERFEES" runat="server" Text='<%#Eval("TRANSOTHERFEES") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="TRANSPROMOCODE">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSPROMOCODE" runat="server" Text='<%#Eval("TRANSPROMOCODE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSPROMO">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSPROMO" runat="server" Text='<%#Eval("TRANSPROMO") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="TRANSTOTALAMOUNT">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSTOTALAMOUNT" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="FLAG_SM_RECEIVER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_SM_RECEIVER" runat="server" Text='<%#Eval("FLAG_SM_RECEIVER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SM_RECEIVER">
                    <ItemTemplate>
                        <asp:Label ID="lblSM_RECEIVER" runat="server" Text='<%#Eval("SM_RECEIVER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_CALL_RECEIVER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_CALL_RECEIVER" runat="server" Text='<%#Eval("FLAG_CALL_RECEIVER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RECEIVERPHONENO">
                    <ItemTemplate>
                        <asp:Label ID="lblRECEIVERPHONENO" runat="server" Text='<%#Eval("RECEIVERPHONENO") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_DD">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_DD" runat="server" Text='<%#Eval("FLAG_DD") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_TESTQUESTION">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_TESTQUESTION" runat="server" Text='<%#Eval("FLAG_TESTQUESTION") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TESTQUESTION">
                    <ItemTemplate>
                        <asp:Label ID="lblTESTQUESTION" runat="server" Text='<%#Eval("TESTQUESTION") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TESTANSWER">
                    <ItemTemplate>
                        <asp:Label ID="lblTESTANSWER" runat="server" Text='<%#Eval("TESTANSWER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_CALLSENDER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_CALLSENDER" runat="server" Text='<%#Eval("FLAG_CALLSENDER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_SMSSENDER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_SMSSENDER" runat="server" Text='<%#Eval("FLAG_SMSSENDER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FLAG_EMAILSENDER">
                    <ItemTemplate>
                        <asp:Label ID="lblFLAG_EMAILSENDER" runat="server" Text='<%#Eval("FLAG_EMAILSENDER") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SENDEREMAILADDRESS">
                    <ItemTemplate>
                        <asp:Label ID="lblSENDEREMAILADDRESS" runat="server" Text='<%#Eval("SENDEREMAILADDRESS") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="TRANSSTATUS">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSSTATUS" runat="server" Text='<%#Eval("TRANSSTATUS") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="TRANSRECEIVEDID">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSRECEIVEDID" runat="server" Text='<%#Eval("TRANSRECEIVEDID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TRANSRECEIVEDATE">
                    <ItemTemplate>
                        <asp:Label ID="lblTRANSRECEIVEDATE" runat="server" Text='<%#Eval("TRANSRECEIVEDATE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
<%--                <asp:TemplateField HeaderText="CREATEDBY">
                    <ItemTemplate>
                        <asp:Label ID="lblCREATEDBY" runat="server" Text='<%#Eval("CREATEDBY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CREATEDON">
                    <ItemTemplate>
                        <asp:Label ID="lblCREATEDON" runat="server" Text='<%#Eval("CREATEDON") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UPDATEDBY">
                    <ItemTemplate>
                        <asp:Label ID="lblUPDATEDBY" runat="server" Text='<%#Eval("UPDATEDBY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UPDATEDON">
                    <ItemTemplate>
                        <asp:Label ID="lblUPDATEDON" runat="server" Text='<%#Eval("UPDATEDON") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGENTID">
                    <ItemTemplate>
                        <asp:Label ID="lblAGENTID" runat="server" Text='<%#Eval("AGENTID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="REFCODE">
                    <ItemTemplate>
                        <asp:Label ID="lblREFCODE" runat="server" Text='<%#Eval("REFCODE") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="Larger" Text="No data found"></asp:Label>
                            
                        </EmptyDataTemplate>
            <HeaderStyle CssClass="gvHeadercss" />
            <RowStyle CssClass="gvRowCss" />
            <AlternatingRowStyle CssClass="gvRowAltCss" />
        </asp:GridView>
        </div>


            <div class="memberBotBtnlist" >
        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnregbot" OnClick="btnPrint_Click" />

    </div>
    <br />
    
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server">
    </rsweb:ReportViewer>
</asp:Content>

