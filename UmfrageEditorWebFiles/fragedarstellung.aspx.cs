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
using System.Configuration;


namespace UmfrageEditor
{
	/// <summary>
	/// Zusammenfassung für fragedarstellung.
	/// </summary>
	public class fragedarstellung : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table m_tblFragenListe;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageTitel;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_lbUmfrageTitel;
		protected System.Web.UI.HtmlControls.HtmlGenericControl P1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_lbComment;
		protected System.Web.UI.WebControls.LinkButton LinkLogout;
		protected System.Web.UI.WebControls.Label lbLoginStatus;
		protected System.Web.UI.WebControls.LinkButton LinkLogin;
		protected System.Web.UI.WebControls.TextBox txtPasswort;
		protected System.Web.UI.WebControls.TextBox txtBenutzername;
		protected System.Web.UI.WebControls.Label lbLoginMessage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_login;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_default;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_registrieren;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_admin;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_user;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_debug;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_logout;
	
		protected DataAccessBenutzer daBenutzer;


		private void Page_Load(object sender, System.EventArgs e)
		{

			// Falls keine Umfrage geladen ist, zurück zur Startseite
			UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
			if (!umfr.IsLoaded)
			{
				
			}

			daBenutzer = new DataAccessBenutzer();

			// Einblendungen für Login und Navmenü prüfen
			check_visibility();

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
			this.LinkLogin.Click += new System.EventHandler(this.LinkLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
