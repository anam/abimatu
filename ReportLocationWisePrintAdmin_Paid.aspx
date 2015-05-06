<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportLocationWisePrintAdmin_Paid.aspx.cs"
    Inherits="LocationWiseReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abimatu</title>
    <style type="text/css">
        body
        {
            font-family: Arial;
        }
        .style1
        {
            width: 100%;
        }
        .colorbackground
        {
            background-color: #3399FF; /*background-image:url(App_Themes/Default/images/coloredbackground.png);*/
            background-repeat: repeat;
            font-weight: bold;
            font-size: 15px;
            text-align: center;
        }
        .ar
        {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="font-size: 12px;">
        <center>
            <img src="images/bg_logo.png" />
        </center>
        <center>
            <a href="//pdfcrowd.com/url_to_pdf/?width=210mm&height=297mm">Downlaod PDF</a></center>
        <asp:GridView ID="gvTRANS" runat="server" CssClass="innergrid" BorderStyle="None"
            GridLines="Horizontal" AutoGenerateColumns="false" ShowHeader="true">
            <Columns>
            <asp:TemplateField HeaderText="Select" ControlStyle-Width="100px">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" ToolTip='<%#Eval("TRANSID") %>' Text='<%#Eval("CREATEDON","{0:MM/dd/yyyy}") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="REF Code" ControlStyle-Width="90px">
                    <ItemTemplate>
                        <a href='<%#Eval("REFCODE","EditPayment.aspx?REFCODE={0}") %>' target="_blank">
                            <asp:Label ID="lblReferenceCode" Font-Bold="false" runat="server" Text='<%#Eval("REFCODE") %>'>
                            </asp:Label>
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer Detail" ControlStyle-Width="180px">
                    <ItemTemplate>
                        <asp:Label ID="lblCustomerDetail" Font-Bold="false" runat="server" Text='<%#Eval("CUSTDETAIL")%>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Receiver Detail" ControlStyle-Width="180px">
                    <ItemTemplate>
                        <asp:Label ID="lblReceiverDetail" Font-Bold="false" runat="server" Text='<%#Eval("RECEIVERDETAIL")%>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount" ControlStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Label ID="lblSendingAmount" Font-Bold="false" runat="server" Text='<%#Eval("TRANSAMOUNT","{0:C}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fees" ControlStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Label ID="lblServiceCharge" Font-Bold="false" runat="server" Text='<%#Eval("TRANSFEES","{0 :C}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Total Amount" ControlStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalCharge" Font-Bold="false" runat="server" Text='<%#Eval("TRANSTOTALAMOUNT","{0 :C}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" ControlStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" Font-Bold="false" runat="server" Text='<%#Eval("TRANSSTATUS") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <HeaderStyle BackColor="#AFA582" Font-Bold="True" ForeColor="White" CssClass="gridHeaderClass" />
        </asp:GridView>
        <asp:Button ID="btnPaid" runat="server" Text="Change status to Paid" 
            onclick="btnPaid_Click" />
    </div>
    </form>
</body>
</html>
