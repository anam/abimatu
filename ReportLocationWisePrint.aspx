<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportLocationWisePrint.aspx.cs" Inherits="LocationWiseReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abimatu</title>
    <style type="text/css">
        body{font-family:Arial;}
        .style1 {
            width: 100%;
        }
        .colorbackground
        {
            background-color:#3399FF;
            /*background-image:url(App_Themes/Default/images/coloredbackground.png);*/
            background-repeat:repeat;
            font-weight:bold;
            font-size:15px;
            text-align:center;
            }
            .ar{text-align:right;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="font-size:12px;">
    <center >
                <img src="images/bg_logo.png" />
            </center>
            <center><a href="//pdfcrowd.com/url_to_pdf/?width=210mm&height=297mm">Downlaod PDF</a></center>
        <asp:Label ID="lblPrint" runat="server" Text=""></asp:Label>
        
    </div>
    </form>
</body>
</html>
