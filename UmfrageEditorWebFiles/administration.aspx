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
								<td width="120" align="left" valign="top"><DIV id="menu_user" runat="server" ms_positioning="FlowLayout"><IFRAME id="menu" style="WIDTH: 122px; HEIGHT: 450px" tabIndex="1" hspace="5" src="menu.aspx"
											frameBorder="0" width="120" scrolling="no"></IFRAME>
									</DIV>
								</td>
								<TD align="left" valign="top">&nbsp;
									<TABLE id="m_tblRegisterCards" cellSpacing="1" cellPadding="1" width="550" border="0" runat="server">
										<TR>
											<TD style="WIDTH: 120px">
												<asp:Button id="m_btnBenutzer" runat="server" Text="Benutzer" BackColor="#4263C6" Width="100%"
													BorderWidth="1px" ForeColor="White" BorderColor="Silver"></asp:Button></TD>
											<TD style="WIDTH: 120px">
												<asp:Button id="m_btnUmfragen" runat="server" Text="Umfragen" BackColor="#4263C6" Width="100%"
													BorderWidth="1px" ForeColor="White" BorderColor="Silver"></asp:Button></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<TABLE id="m_tblBenutzer" cellSpacing="0" cellPadding="1" width="550" border="1" runat="server">
										<TR>
											<TD borderColor="#c0c0c0" colSpan="2">
												<asp:DataGrid id="m_dgBenutzer" runat="server" BorderWidth="0px" AutoGenerateColumns="False" GridLines="None">
													<Columns>
														<asp:BoundColumn DataField="UserID"></asp:BoundColumn>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:CheckBox id="CheckBox2" runat="server"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Name"></asp:BoundColumn>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:DropDownList id="DropDownList1" runat="server"></asp:DropDownList>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 100px" borderColor="#c0c0c0">
												<asp:Button id="m_btnBenutzerLoeschen" runat="server" Text="Löschen" Width="90px"></asp:Button></TD>
										</TR>
									</TABLE>
									<TABLE id="m_tblUmfragen" borderColor="silver" cellSpacing="1" cellPadding="1" width="550"
										border="1" runat="server">
										<TR>
											<TD>
												<asp:DataGrid id="m_dgUmfragen" runat="server" BorderWidth="0px" AutoGenerateColumns="False" GridLines="None">
													<Columns>
														<asp:BoundColumn DataField="UmfrageID"></asp:BoundColumn>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Titel"></asp:BoundColumn>
													</Columns>
												</asp:DataGrid></TD>
										</TR>
										<TR>
											<TD>
												<asp:Button id="m_btnUmfrageLoeschen" runat="server" Width="90px" Text="Löschen"></asp:Button></TD>
										</TR>
									</TABLE>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
