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
			<asp:Label id="m_lbLoginInfo" runat="server">Sie sind eingeloggt als </asp:Label>
			<asp:Label id="m_lbUserName" runat="server"></asp:Label>
			<TABLE id="m_tblUmfragenListe" cellSpacing="1" cellPadding="1" width="300" border="0" runat="server">
				<TR>
					<TD colSpan="2">
						<asp:CheckBoxList id="m_chblUmfragenListe" runat="server"></asp:CheckBoxList></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 109px">
						<asp:Button id="m_btnLoeschen" runat="server" Text="Löschen"></asp:Button></TD>
					<TD>
						<asp:Button id="m_btnBearbeiten" runat="server" Text="Bearbeiten"></asp:Button></TD>
				</TR>
			</TABLE>
			<DIV id="m_pnUmfrageNeu" style="WIDTH: 269px; POSITION: relative; HEIGHT: 64px" align="left"
				runat="server" ms_positioning="GridLayout">
				<asp:Button id="m_btnUmfrageNeu" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 16px"
					runat="server" Text="neue Umfrage erstellen" Width="232px"></asp:Button></DIV>
		</form>
	</body>
</HTML>
