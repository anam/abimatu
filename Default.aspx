<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
<div class="content"><!-- Begin: content -->
        	
            <a href="UserRegistrationPage.aspx" class="administrator" id="a_administrator" runat="server"></a>
 			<a href="ReportLocationWise.aspx" class="locationReport" id="a_locationReport" runat="server"></a>
             <a href="SearchFoodSenderPage.aspx" class="foodItems" id="a_foodItems" runat="server"></a>
            <a href="ReportAgentWiseCommission.aspx" class="agentCommReport" id="a_agentCommReport" runat="server"></a>
            <a href="ReportLocationWise.aspx?Daily=1" class="dailyReport" id="a_dailyReport" runat="server"></a>
            <a href="EditPayment.aspx" class="editTransfer" id="a_editTransfer" runat="server"></a>
             <a href="ReportCustomerSAR.aspx" class="compliance" id="a_compliance" runat="server"></a>
            <a href="ReportAgentWise.aspx" class="agentWiseReport" id="a_agentWiseReport" runat="server"></a>
            <a href="SearchSenderPage.aspx" class="transferMoney" id="a_transferMoney" runat="server"></a>
            <asp:Button ID="btnExit" class="btnexit" runat="server" Visible="false" Text="" onclick="btnExit_Click" />
            		
        </div><!-- End: content -->
</asp:Content>
