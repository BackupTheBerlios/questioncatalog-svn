using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DBAccessor;
using System.Data.SqlClient;

namespace UmfrageEditor
{
	/// <summary>
	/// Persönliche Startseite eines eingeloggten Benutzers
	/// Stellt Möglichkeiten zum Löschen und Editieren eigener Umfragen zur Verfügung
	/// </summary>
	public class defaultuser : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageNeu;
		protected System.Web.UI.WebControls.Button m_btnLoeschen;
		protected System.Web.UI.WebControls.Button m_btnBearbeiten;
		protected System.Web.UI.WebControls.CheckBoxList m_chblUmfragenListe;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblUmfragenListe;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.LinkButton m_lnkbUmfrageNeu;
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

		protected DataAccessBenutzer daBenutzer = new DataAccessBenutzer();
		
		/// <summary>
		/// Kommunikation mit der DB
		/// </summary>
		protected DataAccessUmfragen m_daUmfragen = new DataAccessUmfragen();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Einblendungen für Login und Navmenü prüfen
			check_visibility();

			
			UserInfo user = SessionContainer.ReadFromSession(this).User;

			// TEST: zum Testen einen Benutzer einloggen
			// user.Login("kathrin", "kathrin");

			// prüfen, ob der Benutzer eingeloggt ist, 
			// wenn nicht, auf die Login-Seite zurückschicken
			if (!user.IsLoggedIn)
			{
				Server.Transfer("default.aspx");
			}

			if (!IsPostBack)
			{
				m_lbUserName.Text = user.Username;
				m_tblUmfragenListe.Visible = true;
				m_pnUmfrageNeu.Visible = true;

				RefreshUmfragenListe();
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
			this.m_btnLoeschen.Click += new System.EventHandler(this.m_btnLoeschen_Click);
			this.m_btnBearbeiten.Click += new System.EventHandler(this.m_btnBearbeiten_Click);
			this.m_lnkbUmfrageNeu.Click += new System.EventHandler(this.m_lnkbUmfrageNeu_Click);
			this.LinkLogout.Click += new System.EventHandler(this.LinkLogout_Click);
			this.LinkLogin.Click += new System.EventHandler(this.LinkLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void m_btnLoeschen_Click(object sender, System.EventArgs e)
		{
			for(int i = 0; i < m_chblUmfragenListe.Items.Count; i++)
			{
				if (m_chblUmfragenListe.Items[i].Selected)
				{
					UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
					umfr.DeleteFromDB(Convert.ToInt32(m_chblUmfragenListe.Items[i].Value),
										SessionContainer.ReadFromSession(this).User);
				}
			}
			RefreshUmfragenListe();
		}

		private void m_btnBearbeiten_Click(object sender, System.EventArgs e)
		{
			if (m_chblUmfragenListe.SelectedValue != "")
			{
				SessionContainer.ReadFromSession(this).Umfrage.Load(Convert.ToInt32(m_chblUmfragenListe.SelectedValue));
			}
			else
			{
				SessionContainer.ReadFromSession(this).Umfrage.Clear();
			}

//			// TEST: Falsche UmfrageID laden
//			SessionContainer.ReadFromSession(this).Umfrage.Load(5);

			Server.Transfer("umfrageerstellen.aspx");
		}

		private void RefreshUmfragenListe()
		{
			// Umfragen des eingeloggten Benutzers abrufen:
			// Daten vorbereiten
			SqlParameter pUserID = DataAccessUmfragen.Paramr_userID;
			pUserID.Value = SessionContainer.ReadFromSession(this).User.UserID;
			DataParameters parameters = new DataParameters();
			parameters.Add(pUserID);
			DSUmfragen ds = m_daUmfragen.Select(parameters);
			// in der Checkboxliste darstellen
			m_chblUmfragenListe.DataSource = ds.umfragen;
			// den Titel der Umfrage neben der Checkbox anzeigen
			m_chblUmfragenListe.DataTextField = ds.umfragen.Columns["Titel"].ToString();
			// die UmfrageID als Value mitgeben, um zum Löschen oder Bearbeiten wieder an den Datensatz zu kommen
			m_chblUmfragenListe.DataValueField = ds.umfragen.Columns["UmfrageID"].ToString();
			m_chblUmfragenListe.DataBind();
			// wenn keine Datensätze gefunden wurden, sollen die Umfragenliste und die
			// dazugehörigen Buttons nicht sichtbar sein
			m_tblUmfragenListe.Visible = (ds.umfragen.Rows.Count > 0);
		}

		private void m_lnkbUmfrageNeu_Click(object sender, System.EventArgs e)
		{
			SessionContainer.ReadFromSession(this).Umfrage.Clear();
			Server.Transfer("umfrageerstellen.aspx");
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
