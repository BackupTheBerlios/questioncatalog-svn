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
		protected System.Drawing.Color backColorChecked = Color.FromArgb(66, 99, 198);
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// bei jedem Laden prüfen, ob der Benutzer eingeloggt ist und Adminrechte hat
			// wenn nicht, auf die Startseite zurückschicken
			UserInfo user = SessionContainer.ReadFromSession(this).User;

//			// TEST: zum Testen einen Benutzer einloggen
			user.Login("kathrin", "kathrin");

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
			choice.Add("Admin");
			choice.Add("Benutzer");
			for (int i = 0; i < dsAllUsers.benutzer.Count; i++)
			{
				DropDownList ddl = (DropDownList)DataGridAccess.GetControlFromDataGrid(m_dgBenutzer.Items[i], typeof(DropDownList), 3, 0);
				if (ddl != null)
				{
					ddl.DataSource = choice;
					ddl.DataBind();
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


	}
}
