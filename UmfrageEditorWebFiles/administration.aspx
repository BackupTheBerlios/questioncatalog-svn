<%@ Page language="c#" Codebehind="administration.aspx.cs" AutoEventWireup="false" Inherits="UmfrageEditor.administration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>administration</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="styles.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
		<table width="712" border="0" cellpadding="0" cellspacing="0">
			<tr align="left" valign="bottom">
				<td height="130" colspan="2"><img src="images/top_bar.gif" width="712" height="130"></td>
			</tr>
			<tr>
				<td width="21" align="left" valign="top"><img src="images/side_bar.gif" width="21" height="296">
				</td>
				<td width="691" align="left" valign="top">
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="120" align="left" valign="top"><p align="center" class="pagename"><strong>Startseite</strong></p>
								<DIV id="menu_user" runat="server" ms_positioning="FlowLayout">
									<P>
										<asp:HyperLink class="menu" id="lnkHome" runat="server" NavigateUrl="default.aspx">Startseite</asp:HyperLink>
										<br>
										<asp:HyperLink class="menu" id="lnkLog" runat="server" NavigateUrl="registrieren.aspx">Login</asp:HyperLink><BR>
										<asp:HyperLink class="menu" id="lnkVerwaltung" runat="server" NavigateUrl="administration.aspx">Verwaltung</asp:HyperLink>
									</P>
								</DIV>
							</td>
							<TD align="left" valign="top">
								<DIV id="gridMain" style="WIDTH: 100%; POSITION: relative; HEIGHT: 256px" ms_positioning="GridLayout"></DIV>
							</TD>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		</form>
	</body>
</HTML>
