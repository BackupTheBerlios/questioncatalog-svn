using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DBAccessor;

namespace UmfrageEditor
{
	/// <summary>
	/// Zusammenfassung für administration.
	/// </summary>
	public class administration : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkLog;
		protected System.Web.UI.WebControls.HyperLink lnkVerwaltung;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblRegisterCards;
		protected System.Web.UI.WebControls.Button m_btnBenutzer;
		protected System.Web.UI.WebControls.Button m_btnUmfragen;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblBenutzer;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblUmfragen;
		protected System.Web.UI.HtmlControls.HtmlGenericControl menu_user;
		protected System.Drawing.Color backColorNotChecked = Color.FromArgb(102, 144, 247);
		protected System.Web.UI.WebControls.DataGrid m_dgUmfragen;
		protected System.Web.UI.WebControls.DataGrid m_dgBenutzer;
		protected System.Web.UI.WebControls.Button m_btnBenutzerLoeschen;
		protected System.Web.UI.WebControls.Button m_btnUmfrageLoeschen;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_default;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_registrieren;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_admin;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_user;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_debug;
		protected System.Web.UI.WebControls.LinkButton LinkLogout;
		protected System.Web.UI.WebControls.Label lbLoginStatus;
		protected System.Web.UI.WebControls.LinkButton LinkLogin;
		protected System.Web.UI.WebControls.TextBox txtPasswort;
		protected System.Web.UI.WebControls.TextBox txtBenutzername;
		protected System.Web.UI.WebControls.Label lbLoginMessage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_login;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_logout;
		protected System.Drawing.Color backColorChecked = Color.FromArgb(66, 99, 198);

		protected DataAccessBenutzer daBenutzer;

	
		private void Page_Load(object sender, System.EventArgs e)
		{

			daBenutzer = new DataAccessBenutzer();
			
			// Einblendungen für Login und Navmenü prüfen
			check_visibility();

			// bei jedem Laden prüfen, ob der Benutzer eingeloggt ist und Adminrechte hat
			// wenn nicht, auf die Startseite zurückschicken
			UserInfo user = SessionContainer.ReadFromSession(this).User;

//			// TEST: zum Testen einen Benutzer einloggen
			// user.Login("kathrin", "kathrin");

			if (!user.IsLoggedIn || !user.IsAdmin)
			{
				Server.Transfer("default.aspx");
			}

			if (!IsPostBack)
			{
				// Sichtbarkeiten festlegen: Benutzer sollen beim Start der Seite angezeigt werden
				ShowBenutzer();
			}
		}

		#region Vom Web Form-Designer generierter Code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: Dieser Aufruf ist für den ASP.NET Web Form-Designer erforderlich.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{    
			this.m_btnBenutzer.Click += new System.EventHandler(this.m_btnBenutzer_Click);
			this.m_btnUmfragen.Click += new System.EventHandler(this.m_btnUmfragen_Click);
			this.m_dgBenutzer.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.m_dgBenutzer_ItemCommand);
			this.m_btnBenutzerLoeschen.Click += new System.EventHandler(this.m_btnBenutzerLoeschen_Click);
			this.m_btnUmfrageLoeschen.Click += new System.EventHandler(this.m_btnUmfrageLoeschen_Click);
			this.LinkLogout.Click += new System.EventHandler(this.LinkLogout_Click);
			this.LinkLogin.Click += new System.EventHandler(this.LinkLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		#region Benutzerdefinierte Eventhandler

		private void m_btnBenutzer_Click(object sender, System.EventArgs e)
		{
			// Sichtbarkeiten ändern
			ShowBenutzer();
		}

		private void m_btnUmfragen_Click(object sender, System.EventArgs e)
		{
			ShowUmfragen();
		}

		private void m_btnBenutzerLoeschen_Click(object sender, System.EventArgs e)
		{
			// für alle selektierten Zeilen den entsprechenden Datensatz löschen
			DataAccessBenutzer daBenutzer = new DataAccessBenutzer();
			// IDs aller selektierten Benutzer ermitteln
			for (int i = 0; i < m_dgBenutzer.Items.Count; i++)
			{
				CheckBox cbx = (CheckBox)DataGridAccess.GetControlFromDataGrid(m_dgBenutzer.Items[i], typeof(CheckBox), 1, 0);
				if (cbx != null && cbx.Checked)
				{
					// Datensatz löschen
					int id = Convert.ToInt32(m_dgBenutzer.Items[i].Cells[0].Text);
					daBenutzer.DeleteBenutzer(id);
				}
			}

			RefreshDGBenutzer();
		}

		private void m_btnUmfrageLoeschen_Click(object sender, System.EventArgs e)
		{
			// für alle selektierten Zeilen den entsprechenden Datensatz löschen
			DataAccessUmfragen daUmfr = new DataAccessUmfragen();
			// IDs aller selektierten Umfragen ermitteln
			for (int i = 0; i < m_dgUmfragen.Items.Count; i++)
			{
				CheckBox cbx = (CheckBox)DataGridAccess.GetControlFromDataGrid(m_dgUmfragen.Items[i], typeof(CheckBox), 1, 0);
				if (cbx != null && cbx.Checked)
				{
					// Datensatz löschen
					int id = Convert.ToInt32(m_dgUmfragen.Items[i].Cells[0].Text);
					daUmfr.DeleteUmfrage(id);
				}
			}

			RefreshDGUmfragen();
		}

		private void ddlUserRights_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_btnBenutzer.Text = "bla";
		}

		#endregion

		#region Hilfsfunktionen

		private void ShowBenutzer()
		{
			// Sichtbarkeiten neu festlegen
			m_tblBenutzer.Visible = true;
			m_tblUmfragen.Visible = false;

			// dem ausgewähltern Register die dunklere Farbe zuweisen
			m_btnBenutzer.BackColor = backColorChecked;
			// dem nicht ausgewählten Register die hellere Farbe zuweisen
			m_btnUmfragen.BackColor = backColorNotChecked;
			RefreshDGBenutzer();
		}

		private void ShowUmfragen()
		{
			// Sichtbarkeiten neu festlegen
			m_tblUmfragen.Visible = true;
			m_tblBenutzer.Visible = false;
			
			// dem ausgewähltern Register die dunklere Farbe zuweisen
			m_btnUmfragen.BackColor = backColorChecked;
			// dem nicht ausgewählten Register die hellere Farbe zuweisen
			m_btnBenutzer.BackColor = backColorNotChecked;
			RefreshDGUmfragen();
		}

		private void RefreshDGBenutzer()
		{
			// alle Benutzerdatensätze aus der DB ziehen und im Datagrid darstellen 
			DSBenutzer dsAllUsers = new DataAccessBenutzer().Select();
			m_dgBenutzer.DataSource = dsAllUsers.benutzer;
			m_dgBenutzer.DataBind();

			// Benutzerrechte in den DropdownListen darstellen
			// Inhalt der Dropdownlisten vorbereiten
			ArrayList choice = new ArrayList();
			choice.Add("Benutzer");
			choice.Add("Admin");
			for (int i = 0; i < dsAllUsers.benutzer.Count; i++)
			{
				DropDownList ddl = (DropDownList)DataGridAccess.GetControlFromDataGrid(m_dgBenutzer.Items[i], typeof(DropDownList), 3, 0);
				if (ddl != null)
				{
					ddl.DataSource = choice;
					ddl.DataBind();
					ddl.SelectedIndex = dsAllUsers.benutzer[i].GruppenID;
					ddl.SelectedIndexChanged += new EventHandler(ddlUserRights_SelectedIndexChanged);
					ddl.AutoPostBack = true;
				}
			}
		}

		private void RefreshDGUmfragen()
		{
			DSUmfragen dsAllUmfragen = new DataAccessUmfragen().Select();
			m_dgUmfragen.DataSource = dsAllUmfragen.umfragen;
			m_dgUmfragen.DataBind();
		}


		#endregion

		private void m_dgBenutzer_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			m_btnBenutzer.Text = "bla";
		}

		#region Login & Menü
		private void LinkLogin_Click(object sender, System.EventArgs e)
		{
			SqlParameter paramName = DataAccessBenutzer.ParamName;
			paramName.Value = txtBenutzername.Text;
			DataParameters dParams = new DataParameters();
			dParams.Add(paramName);
			DSBenutzer dsBen = daBenutzer.Select(dParams);

			if(dsBen.benutzer.Rows.Count == 1)
			{
				string pw = (string)dsBen.benutzer.Rows[0]["Passwort"];
				if (pw.Equals( txtPasswort.Text))
				{
					// Login erfolgreich
					string username = (string)dsBen.benutzer.Rows[0]["Name"];
					SessionContainer.ReadFromSession(this).User.Login(username, pw);
					check_visibility();

					// Statusmessages setzen
					lbLoginStatus.Text = @"Eingeloggt als """ + SessionContainer.ReadFromSession(this).User.Username + @"""";
					lbLoginMessage.Text = "";

					// Redirect zur persönlichen Startseite
					Server.Transfer("defaultuser.aspx");


				}
				else
				{
					// Falsches Passwort
					
					// Überprüfung auf Debugmodus
					if(!DBConstants.Debugmodus)
					{
						// Standardausgabe
						lbLoginMessage.Text = "Login fehlgeschlagen!";
					}
					else
					{
						// Ausgabe im Debugmodus
						lbLoginMessage.Text = "Falsches Passwort!";
					}

					// Zur Sicherheit abmelden
					SessionContainer.ReadFromSession(this).User.Logout();
					
					// Statusmessages setzen
					lbLoginStatus.Text = "";

					// Sichtbarkeiten neu festlegen
					check_visibility();

				}
			}
			else
			{
				// Falscher Benutzer

				// Überprüfung auf Debugmodus
				if(!DBConstants.Debugmodus)
				{
					// Standardausgabe
					lbLoginMessage.Text = "Login fehlgeschlagen!";
				}
				else
				{
					// Ausgabe im Debugmodus
					lbLoginMessage.Text = "Unbekannter Benutzer!";
				}

				// Zur Sicherheit abmelden
				SessionContainer.ReadFromSession(this).User.Logout();

				// Statusmessages setzen
				lbLoginStatus.Text = "";

				// Sichtbarkeiten neu festlegen
				check_visibility();
			}
		}

		private void LinkLogout_Click(object sender, System.EventArgs e)
		{
			m_login.Visible = true;
			m_logout.Visible = false;
			SessionContainer.ReadFromSession(this).User.Logout();
			Server.Transfer("default.aspx");
		}

		private void txtBenutzername_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtPasswort_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void check_visibility()
		{
			/* Sichtbarkeiten festlegen */
			
			#region Loginblock
			if (!SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				//wenn User nicht eingeloggt ist

				// Zeige Login 
				m_login.Visible = true;

				// verstecke Logout
				m_logout.Visible = false;

				// Messages entsprechend setzen
				lbLoginStatus.Text = "";

			}
			else
			{
				// wenn User eingeloggt ist

				// Verstecke Login
				m_login.Visible = false;

				// Zeige Logout 
				m_logout.Visible = true;

				// Messages entsprechend setzen
				lbLoginMessage.Text = "";
				lbLoginStatus.Text = @"Eingeloggt als """ + SessionContainer.ReadFromSession(this).User.Username + @"""";
			}
			#endregion

			#region Navigationsmenü 
			
			// Alle Menüs bis auf Widerruf deaktivieren
			m_menu_default.Visible = false;
			m_menu_registrieren.Visible = false;
			m_menu_user.Visible = false;
			m_menu_admin.Visible = false;
			m_menu_debug.Visible = false;

			
			// Einblenden des generellen Navigationsblocks
			m_menu_default.Visible = true;

			// Einblendung im Navigationmenü prüfen
			/* Im Debugmodus Direktnavigation zu den Seiten einblenden 
				 * und alle Menüs einblenden */
			if (DBConstants.Debugmodus)
			{
				m_menu_default.Visible = true;
				m_menu_registrieren.Visible = true;
				m_menu_user.Visible = true;
				m_menu_admin.Visible = true;
				m_menu_debug.Visible = true;
			}
				// wenn der Benutzer angemeldet ist 
			else if (SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				// Usermenü anzeigen 
				m_menu_user.Visible = true;
				
				// wenn der Benutzer AdminStatus besitzt
				if (SessionContainer.ReadFromSession(this).User.IsAdmin)
				{
					// Adminmenü anzeigen
					m_menu_admin.Visible = true;
				}

			}
				// Wenn der Benutzer nicht angemeldet ist
			else
			{
				// Registrieren anzeigen
				m_menu_registrieren.Visible = true;
			}
			#endregion


		}

		#endregion

	}
}
