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
	/// Zusammenfassung f�r fragedarstellung.
	/// </summary>
	public class fragedarstellung : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table m_tblFragenListe;
		protected System.Web.UI.HtmlControls.HtmlGenericControl P1;
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
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageTitel;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_lbUmfrageTitel;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_lbComment;
		protected System.Web.UI.WebControls.DataGrid m_dgFragedarstellung;
	
		protected DataAccessBenutzer daBenutzer = new DataAccessBenutzer();


		private void Page_Load(object sender, System.EventArgs e)
		{

			// Falls keine Umfrage geladen ist, zur�ck zur Startseite
			UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;

			// TEST: Umfrage laden
			umfr.Load(Convert.ToInt32(Request.QueryString["uid"]));

			if (!umfr.IsLoaded)
			{
				Server.Transfer("default.aspx");
			}

			// Einblendungen f�r Login und Navmen� pr�fen
			check_visibility();

			// Initialisierungen
			if (!IsPostBack)
			{
				// Umfrage aus der DB ziehen
				DSUmfragen dsUmfr = new DataAccessUmfragen().GetUmfrageByID(umfr.UmfrageID);

				if (dsUmfr.umfragen.Count == 1)
				{
					// Umfragetitel setzen
					m_lbUmfrageTitel.InnerText = dsUmfr.umfragen[0].Titel;
					m_lbComment.InnerText = dsUmfr.umfragen[0].Beschreibung;
					ShowFragen();
				}
			}

		}

		#region Hilfsfunktionen

		private void ShowFragen()
		{
			UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
			// alle Fragen zu der Umfrage aus der DB ziehen
			SqlParameter pAllFragen = DataAccessFragen.Paramr_UmfrageID;
			pAllFragen.Value = umfr.UmfrageID;
			DataParameters parameters = new	DataParameters();
			parameters.Add(pAllFragen);
			DSFragen dsAllFragen = new DataAccessFragen().Select(parameters);

			// DataGrid vorbereiten
			m_dgFragedarstellung.DataSource = dsAllFragen.fragen;
			m_dgFragedarstellung.DataBind();

			// Fragen in Datagrid eintragen
			for (int i = 0; i < m_dgFragedarstellung.Items.Count; i++)
			{
				// Titel setzen
				Label lb = (Label)DataGridAccess.GetControlFromDataGrid(m_dgFragedarstellung.Items[i], typeof(Label), 1, 0);
				if (lb != null)
				{
					lb.Text = dsAllFragen.fragen[i].Text;
				}

				// Antwortm�glickeiten darstellen
				PutAntworten(m_dgFragedarstellung.Items[i],dsAllFragen.fragen[i].FrageID, dsAllFragen.fragen[i].Frageart);

			}

		}

		private void PutAntworten(DataGridItem item, int frageID, int frageart)
		{
			// Antwortm�glichkeiten aus der DB ziehen
			SqlParameter pFrageID = DataAccessAwmoeglichkeiten.Paramr_FrageID;
			pFrageID.Value = frageID;
			DataParameters parameters = new DataParameters();
			parameters.Add(pFrageID);
			DSAwmoeglichkeiten dsAntw = new DataAccessAwmoeglichkeiten().Select(parameters);

			switch (frageart)
			{
				case DBConstants.TextFrage:
					TextBox txt = (TextBox)DataGridAccess.GetControlFromDataGrid(item, typeof(TextBox), 1, 0);
					if (txt != null)
					{
						txt.Visible = true;
					}
					break;
				case DBConstants.UndFrage:
					CheckBoxList chbl = (CheckBoxList)DataGridAccess.GetControlFromDataGrid(item, typeof(CheckBoxList), 1, 0);
					if (chbl != null)
					{
						chbl.Visible = true;
						chbl.DataTextField = dsAntw.awmoeglichkeiten.Columns["Text"].ToString();
						chbl.DataSource = dsAntw.awmoeglichkeiten;
						chbl.DataBind();
					}
					break;
				case DBConstants.OderFrage:
					DropDownList ddl = (DropDownList)DataGridAccess.GetControlFromDataGrid(item, typeof(DropDownList), 1, 0);
					if (ddl != null)
					{
						ddl.Visible = true;
						ddl.DataSource = dsAntw.awmoeglichkeiten;
						ddl.DataTextField = dsAntw.awmoeglichkeiten.Columns["Text"].ToString();
						ddl.DataBind();
					}
					break;
			}		
				
		}

		#endregion

		#region Vom Web Form-Designer generierter Code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: Dieser Aufruf ist f�r den ASP.NET Web Form-Designer erforderlich.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Erforderliche Methode f�r die Designerunterst�tzung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{    
			this.LinkLogin.Click += new System.EventHandler(this.LinkLogin_Click);
			this.LinkLogout.Click += new System.EventHandler(this.LinkLogout_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Login & Men�
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
					
					// �berpr�fung auf Debugmodus
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

				// �berpr�fung auf Debugmodus
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

			#region Navigationsmen� 
			
			// Alle Men�s bis auf Widerruf deaktivieren
			m_menu_default.Visible = false;
			m_menu_registrieren.Visible = false;
			m_menu_user.Visible = false;
			m_menu_admin.Visible = false;
			m_menu_debug.Visible = false;

			
			// Einblenden des generellen Navigationsblocks
			m_menu_default.Visible = true;

			// Einblendung im Navigationmen� pr�fen
			/* Im Debugmodus Direktnavigation zu den Seiten einblenden 
				 * und alle Men�s einblenden */
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
				// Usermen� anzeigen 
				m_menu_user.Visible = true;
				
				// wenn der Benutzer AdminStatus besitzt
				if (SessionContainer.ReadFromSession(this).User.IsAdmin)
				{
					// Adminmen� anzeigen
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
