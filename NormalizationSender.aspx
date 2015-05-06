<%@ Page Title="" Language="C#" MasterPageFile="~/MemberMaster.master" AutoEventWireup="true" CodeFile="NormalizationSender.aspx.cs" Inherits="tmp_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 

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
<table>
    <tr>
        <td>
            <asp:CheckBoxList ID="chklUniversity" runat="server">
            </asp:CheckBoxList>
        </td>
        <td>
            <asp:RadioButtonList ID="rbtnlUniversity" runat="server">
            </asp:RadioButtonList>
        </td>
        <td valign="top">
            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
        </td>
    </tr>
    <tr style="display:none;">
        <td>
            <asp:TextBox ID="txtCountryName" runat="server" Text="FOREIGN"></asp:TextBox>
            <asp:Button ID="btnTransferToForeign" runat="server" Text="Update Country" 
                onclick="btnTransferToForeign_Click" />
        </td>
        <td>
           <asp:Button ID="btnUpdateToBangladesh" runat="server" 
                Text="Update To Bangladesh" onclick="btnUpdateToBangladesh_Click"  />
        </td>
        <td></td>
    </tr>
</table>
</asp:Content>

