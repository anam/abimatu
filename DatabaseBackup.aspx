<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true"
    CodeFile="DatabaseBackup.aspx.cs" Inherits="UserRegistrationPage" %>

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
        <li><a href="UserRegistrationPage.aspx">User</a></li>
        <%--<li ><a href="AdminLocationAgentRate.aspx">Rate</a></li>--%><li><a href="AdminFOODITEM_MASTERDisplay.aspx">
            Food Rate</a></li>
            <li id="selected"><a href="DatabaseBackup.aspx">Database backup</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" runat="Server">
    <div style="width: 98%; margin: 0px auto; margin-bottom: 20px; float: left;">
        <h3 style="text-indent: 20px; color: #000000; margin-bottom: 10px;">
            Database Backup</h3>
        <hr />
        <br />
        <div style="width: 100%;">
            <asp:Button ID="btnBackup" runat="server" Text="Database Backup" 
                onclick="btnBackup_Click" />
        </div>
    </div>
    
</asp:Content>
