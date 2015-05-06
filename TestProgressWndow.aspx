<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestProgressWndow.aspx.cs" Inherits="TestProgressWndow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    	<link href="App_Themes/Default/cssUpdateProgress.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" language="javascript">
	    var ModalProgress = '<%= ModalProgress.ClientID %>';         
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
<script type="text/javascript" src="App_Themes/Default/js/jsUpdateProgress.js"></script>		
		<asp:ScriptManager ID="ScriptManager1" runat="server" />
		<asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
			<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
				<ProgressTemplate>
					<div style="position: relative; top: 30%; text-align: center;">
						<img src="App_Themes/Default/images/ajax-loader.gif" style="vertical-align: middle" alt="Processing" />
						Processing ...
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</asp:Panel>
		<ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
			BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
	
		<asp:UpdatePanel ID="updatePanel" runat="server">
			<ContentTemplate>
				<asp:Button runat=	"server" Text="Click Me" ID="btnSubmit" 
					onclick="btnSubmit_Click" />
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
    </div>
    </form>
</body>
</html>
