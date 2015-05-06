<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userguide.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
a:link
	{color:blue;
	text-decoration:underline;
	text-underline:single;
        }
p.MsoListParagraphCxSpFirst
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpMiddle
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpLast
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:.5in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
        .style1
        {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:700px;">
    
        <p class="MsoNormal">
            Site address: <a href="http://www.abimatu.net/">http://www.abimatu.net/</a></p>
        <p class="MsoNormal">
            <strong>Initial admin <span class="style1">login</span>: </strong>
        </p>
        <p class="MsoNormal" style="margin-left:.5in">
            login ID: <span style="mso-spacerun:yes">&nbsp;</span>admin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password: admin123</p>
        <p class="MsoNormal">
            After login Admin can create users for <span style="mso-spacerun:yes">&nbsp;</span><strong>Agents/Locations</strong></p>
        <p class="MsoNormal">
            <strong>For the<span class="style1"> Head office</span></strong>(<span style="font-size:9.5pt;line-height:
115%"><strong>ABIMATU</strong></span><strong> agent) [All the users under this agent] will have the following 
            features:</strong></p>
        <p class="MsoListParagraphCxSpFirst" 
            style="text-indent:-.25in;mso-list:l0 level1 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">1.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Administrator
        </p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">a.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Agent Create/Update</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">b.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Location Create/Update</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">c.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>User(employee under agent/location) Create [after 
            creation admin should send mail to that employee]</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">d.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Rate [which depends on agent and location] – 
            select location form the selection list.</p>
        <p class="MsoListParagraphCxSpMiddle" 
            style="text-indent:-.25in;mso-list:l0 level1 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">2.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Reports [In the search form “Total Amount” is to 
            search the transaction which has amount more that his value ]</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">a.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Agent wise Report</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">b.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Location wise Report</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">c.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Agent commission report(here the rate depends on 
            both the agent and location)</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l0 level2 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">d.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Daily Report</p>
        <p class="MsoListParagraphCxSpMiddle" 
            style="text-indent:-.25in;mso-list:l0 level1 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">3.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Food transfer</p>
        <p class="MsoListParagraphCxSpMiddle" 
            style="text-indent:-.25in;mso-list:l0 level1 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">4.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Money transfer
            <![if !supportLists]>
            <![endif]>
        </p>
        <p class="MsoListParagraphCxSpLast" 
            style="text-indent:-.25in;mso-list:l0 level1 lfo1">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">5.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Edit Money transfer
        </p>
        <p class="MsoNormal">
            <strong>For other <span class="style1">agents</span> </strong>
        </p>
        <p class="MsoListParagraphCxSpFirst" 
            style="text-indent:-.25in;mso-list:l1 level1 lfo2">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">1.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Food transfer</p>
        <p class="MsoListParagraphCxSpMiddle" 
            style="text-indent:-.25in;mso-list:l1 level1 lfo2">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">2.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Money transfer
        </p>
        <p class="MsoListParagraphCxSpMiddle" 
            style="text-indent:-.25in;mso-list:l1 level1 lfo2">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">3.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Reports [only of this agent ]</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l1 level2 lfo2">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">a.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Daily <span style="mso-spacerun:yes">&nbsp;</span>Report</p>
        <p class="MsoListParagraphCxSpLast" style="margin-left:1.0in;mso-add-space:auto;
text-indent:-.25in;mso-list:l1 level2 lfo2">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">b.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Location wise Report</p>
        <p class="MsoNormal">
            <strong>For <span class="style1">Location</span></strong></p>
        <p class="MsoListParagraphCxSpFirst" 
            style="text-indent:-.25in;mso-list:l2 level1 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">1.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Reports [only of this location]</p>
        <p class="MsoListParagraphCxSpMiddle" 
            style="text-indent:-.25in;mso-list:l2 level1 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">2.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>And payment process</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l2 level2 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">a.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>Click the button “Process Payment”</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l2 level2 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">b.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>here you will get the Test Question and Answer we 
            posted when we send the money</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l2 level2 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">c.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>you can edit the receiver info</p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l2 level2 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">d.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>you can search and then edit another receiver
        </p>
        <p class="MsoListParagraphCxSpMiddle" style="margin-left:1.0in;mso-add-space:
auto;text-indent:-.25in;mso-list:l2 level2 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">e.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>you can add new receiver info
        </p>
        <p class="MsoListParagraphCxSpLast" style="margin-left:1.0in;mso-add-space:auto;
text-indent:-.25in;mso-list:l2 level2 lfo3">
            <![if !supportLists]>
            <span style="mso-bidi-font-family:Calibri;mso-bidi-theme-font:minor-latin">
            <span style="mso-list:Ignore">f.<span 
                style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </span></span></span><![endif]>and click the bottom “Process Payment” button</p>
        <p class="MsoNormal">
            <o:p>&nbsp;</o:p></p>
        <p class="MsoNormal">
            <o:p>&nbsp;</o:p></p>
        <p class="MsoNormal">
            <span style="mso-spacerun:yes">&nbsp;</span></p>
        <p class="MsoNormal" style="text-indent:.5in">
            <o:p>&nbsp;</o:p></p>
        <p class="MsoNormal" style="text-indent:.5in">
            <o:p>&nbsp;</o:p></p>
        <p class="MsoNormal" style="text-indent:.5in">
            <o:p>&nbsp;</o:p></p>
    
    </div>
    </form>
</body>
</html>
