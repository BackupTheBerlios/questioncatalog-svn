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
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV id="m_pnUmfrageTitel" style="WIDTH: 600px; POSITION: relative; HEIGHT: 248px" ms_positioning="GridLayout"
				runat="server">
				<asp:Label id="m_lbTitle" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server">Titel</asp:Label>
				<asp:Label id="m_lbComment" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 128px"
					runat="server">Kurzbeschreibung</asp:Label>
				<asp:TextBox id="m_txtTitel" style="Z-INDEX: 103; LEFT: 168px; POSITION: absolute; TOP: 80px"
					runat="server" Width="393px"></asp:TextBox>
				<asp:Button id="m_btnTitelUebernehmen" style="Z-INDEX: 104; LEFT: 416px; POSITION: absolute; TOP: 192px"
					runat="server" Text="Übernehmen"></asp:Button>
				<asp:CheckBox id="m_chbOnline" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 200px"
					runat="server" Text="Umfrage online stellen"></asp:CheckBox>
				<asp:TextBox id="m_txtComment" style="Z-INDEX: 106; LEFT: 168px; POSITION: absolute; TOP: 120px"
					runat="server" Width="392px"></asp:TextBox>
				<asp:Label id="m_lbHeadline" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 24px"
					runat="server">Neue Umfrage Erstellen</asp:Label></DIV>
			<TABLE id="m_tblFragen" style="WIDTH: 600px; HEIGHT: 57px" cellSpacing="1" cellPadding="1"
				width="600" border="0" runat="server">
				<TR>
					<TD colSpan="2">
						<asp:DataGrid id="m_dgFragen" runat="server" AutoGenerateColumns="False" GridLines="None">
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Text"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 109px">
						<asp:Button id="m_btnLoeschen" runat="server" Text="Löschen"></asp:Button></TD>
					<TD>
						<asp:Button id="m_btnBearbeiten" runat="server" Text="Bearbeiten" Width="96px"></asp:Button></TD>
				</TR>
			</TABLE>
			<DIV style="WIDTH: 600px; POSITION: relative; HEIGHT: 88px" ms_positioning="GridLayout"
				id="m_pnNeueFrage" runat="server">
				<asp:HyperLink id="m_lnkNeueFrage" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 32px"
					runat="server">neue Frage erstellen</asp:HyperLink>
				<asp:Button id="m_btnFertig" style="Z-INDEX: 102; LEFT: 496px; POSITION: absolute; TOP: 32px"
					runat="server" Text="Fertig"></asp:Button></DIV>
			<DIV style="WIDTH: 600px; POSITION: relative; HEIGHT: 186px" ms_positioning="GridLayout"
				id="m_pnFrageErstellen" runat="server">
				<asp:Label id="m_lbFrage" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 32px" runat="server">Frage</asp:Label>
				<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 24px" runat="server"
					Width="472px"></asp:TextBox>
				<asp:RadioButton id="m_rdbTextfrage" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 72px"
					runat="server" Text="Text-Frage"></asp:RadioButton>
				<asp:RadioButton id="m_rdbUndFrage" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 104px"
					runat="server" Text="Und-Frage (mehrfachauswahl möglich)"></asp:RadioButton>
				<asp:RadioButton id="m_rdbOderFrage" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 136px"
					runat="server" Text="Oder-Frage (keine Mehrfachauswahl)"></asp:RadioButton></DIV>
			<TABLE id="m_tblAntwortmoeglErstellen" style="WIDTH: 600px; HEIGHT: 84px" cellSpacing="1"
				cellPadding="1" width="600" border="0" runat="server">
				<TR>
					<TD colSpan="2">Antwortmöglickeiten vorgeben:</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE id="m_tblAntwErstellen" style="WIDTH: 592px; HEIGHT: 30px" cellSpacing="1" cellPadding="1"
							width="592" border="0" runat="server">
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 447px">
						<asp:HyperLink id="m_lnkMehrAntw" runat="server">mehr Antwortmöglichkeiten</asp:HyperLink></TD>
					<TD>
						<asp:Button id="m_btnFrageUebernehmen" runat="server" Text="Übernehmen"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
