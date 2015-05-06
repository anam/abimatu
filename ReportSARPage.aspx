<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true" CodeFile="ReportSARPage.aspx.cs" Inherits="ReportSARPage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainMemberContent" Runat="Server">
    <div>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
    </rsweb:ReportViewer>
    </div>
</asp:Content>


