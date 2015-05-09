<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSign.aspx.cs" Inherits="CustomerSign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #0033CC;
            font-size: xx-large;
        }
        .style2
        {
            text-align: justify;
        }
        .style4
        {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
        .underlineBorder{border-bottom:1px solid black;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:800px;text-align:center;" >
        <span class="style1"><strong>ABIMATU ENTERPRISE, INC.
    </strong></span>
    <br />
   5010 SUNNYSIDE AVE * SUITE 104 * BELTSVILLE * MARYLAND * 20 705
    <br />
    <p class="style2">
Our compliance with U.S. Federal laws relating to Money Transfer, such as the Bank Secrecy Act/USA Patriot Act/ OFAC, require us to collect the information below, including photocopies of a valid state or federal-issued personal identification card, such as a driver’s license or a passport.  We will also, as required by federal law, protect your information and will not share it with any other persons or entities or use it for any other purpose.
Social Security and photo ID are required only for transactions of $3,000.00 or more.</p>

All first time customers are required to present a photo I.D.
  <table border='1' width="100%">
        <tr>
            <td>
                Please complete the required information below
                
                </td>
        </tr>
        <tr>
            <td>
                <b>Sender’s information</b>
                <table cellpadding="1" cellspacing="5" width="100%" style="text-align:left;">
                    <tr>
                        <td>
                            First Name</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblFName" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            Middle Name</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblMName" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            Last Name</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblLName" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            SSN</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblSSN" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            ID No.</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblIDNo" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            State</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblStateID" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            Expire Date</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblExpireDate" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            Date of Birth</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblDOB" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            Place of Birth</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblPlaceOfBirth" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            Street Address</td>
                        <td colspan="5" class="underlineBorder">
                            <asp:Label ID="lblStreetAddress" runat="server" Text=""></asp:Label>
                            </td>
                        
                    </tr>
                    <tr>
                        <td>
                            City</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblCity" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            State</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblStateAddress" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            Zip Code</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblZip" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            Home Phone</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblHomePhone" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            Work Phone</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblWorkPhone" runat="server" Text=""></asp:Label>
                            </td>
                        <td>
                            Cell</td>
                        <td class="underlineBorder">
                            <asp:Label ID="lblCellPhone" runat="server" Text=""></asp:Label>
                            </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td>
                <b>RECIPIENT’S INFORMATION</b>
                <asp:Label ID="lblReceiver" runat="server" Text=""></asp:Label>
                </td>
        </tr>
        <tr>
            <td align="left">
            <table width="100%">
        <tr>
            <td width='50px'>Description</td>
            <td class="underlineBorder"></td>
            
        </tr>
        </table>
            <br />
            <br />
                <table width="100%">
        <tr>
            <td width='50px'>Signature</td>
            <td class="underlineBorder"></td>
            <td width='50px'>Date</td>
            <td class="underlineBorder"></td>
        </tr>
    </table>
                </td>
        </tr>
    </table>
    
    <table width="100%">
        <tr>
            <td>Tel: 301-474-7188/0180</td>
            <td>Fax: 301-474-7165      </td>
            <td>Email: abimatu@abimatu.com</td>
        </tr>
    </table>
    </div>
    </form>
  
</body>
</html>
