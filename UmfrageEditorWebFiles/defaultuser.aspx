<%@ Page language="c#" Codebehind="defaultuser.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.defaultuser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>defaultuser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV id="m_pnUmfrageListe" style="WIDTH: 263px; POSITION: relative; HEIGHT: 120px" align="left"
				runat="server" ms_positioning="GridLayout">
				<asp:Button id="m_btnLoeschen" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 80px"
					runat="server" Text="Löschen"></asp:Button>
				<asp:Button id="m_btnBearbeiten" style="Z-INDEX: 102; LEFT: 144px; POSITION: absolute; TOP: 80px"
					runat="server" Text="Bearbeiten"></asp:Button>
				<asp:CheckBoxList id="m_chblUmfragenListe" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 24px"
					runat="server"></asp:CheckBoxList></DIV>
			<DIV id="m_pnUmfrageNeu" style="WIDTH: 269px; POSITION: relative; HEIGHT: 72px" align="left"
				runat="server" ms_positioning="GridLayout">
				<asp:Button id="m_btnUmfrageNeu" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 32px"
					runat="server" Text="neue Umfrage erstellen"></asp:Button></DIV>
		</form>
	</body>
</HTML>
