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
			this.m_dgBenutzer.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.m_dgBenutzer_ItemCommand);
			this.m_btnBenutzerLoeschen.Click += new System.EventHandler(this.m_btnBenutzerLoeschen_Click);
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
			// IDs aller selektierten Fragen ermitteln
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
					ddl.SelectedIndexChanged +=new EventHandler(ddlUserRights_SelectedIndexChanged);
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

	}
}
