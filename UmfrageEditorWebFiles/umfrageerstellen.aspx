<%@ Page language="c#" Codebehind="umfrageerstellen.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.umfrageerstellen" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>umfrageerstellen</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="umfragetitel" style="Z-INDEX: 101; LEFT: 416px; POSITION: absolute; TOP: 112px"
				runat="server" MaxLength="100"></asp:TextBox>
			<asp:TextBox id="umfrageinfo" style="Z-INDEX: 102; LEFT: 408px; POSITION: absolute; TOP: 256px"
				runat="server" Height="168px" Width="336px" MaxLength="1000"></asp:TextBox>
			<asp:Label id="lbUmfragetitel" style="Z-INDEX: 103; LEFT: 424px; POSITION: absolute; TOP: 64px"
				runat="server">Umfragetitel</asp:Label>
			<asp:Label id="lbKurzbeschreibung" style="Z-INDEX: 104; LEFT: 432px; POSITION: absolute; TOP: 192px"
				runat="server">Kurzbeschreibung</asp:Label>
		</form>
	</body>
</HTML>
