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
	/// Zusammenfassung für umfrageerstellen.
	/// </summary>
	public class umfrageerstellen : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label m_lbTitle;
		protected System.Web.UI.WebControls.Label m_lbComment;
		protected System.Web.UI.WebControls.Button m_btnTitelUebernehmen;
		protected System.Web.UI.WebControls.CheckBox m_chbOnline;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblFragen;
		protected System.Web.UI.WebControls.Button m_btnLoeschen;
		protected System.Web.UI.WebControls.Button m_btnBearbeiten;
		protected System.Web.UI.WebControls.TextBox m_txtTitel;
		protected System.Web.UI.WebControls.Label m_lbFrage;
		protected System.Web.UI.WebControls.TextBox m_txtComment;
		protected System.Web.UI.WebControls.RadioButton m_rdbTextfrage;
		protected System.Web.UI.WebControls.RadioButton m_rdbUndFrage;
		protected System.Web.UI.WebControls.RadioButton m_rdbOderFrage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageTitel;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnFrageErstellen;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblAntwortmoeglErstellen;
//		protected System.Web.UI.HtmlControls.HtmlTable m_tblAntwortM;
		protected System.Web.UI.WebControls.Button m_btnFrageUebernehmen;
		protected System.Web.UI.WebControls.Label m_lbHeadline;
		protected System.Web.UI.WebControls.TextBox m_txtFrageTitel;
		protected System.Web.UI.WebControls.DataGrid m_dgFragen;
		protected System.Web.UI.WebControls.LinkButton m_lnkbMehrAntw;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnFrageUebernehmen;
		protected System.Web.UI.WebControls.DataGrid m_dgAntwErstellen;
		protected System.Web.UI.WebControls.Button m_btnFertig;
		protected System.Web.UI.WebControls.LinkButton m_lnkbNeueFrage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnNeueFrage;
		protected string PageTitle;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//wenn kein Benutzer eingeloggt ist, direkt zur Loginseite schicken
			UserInfo user = SessionContainer.ReadFromSession(this).User;
			if (!user.IsLoggedIn)
			{
				Server.Transfer("default.aspx");
			}

			if (!IsPostBack)
			{
				// Titel des Browserfensters setzen
				PageTitle = "Umfrage Erstellen";
				DataBind();

				// Abschnitte, die immer sichtbar sein sollen
				m_pnUmfrageTitel.Visible = true;

				// soll eine neue Umfrage erstellt werden?
				UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
				if (!umfr.IsLoaded)
				{
					// für neue Umfrage nicht relevante Abschnitte der Seite ausblenden
					m_tblFragen.Visible	= false;
					m_pnNeueFrage.Visible = true;
					m_pnFrageErstellen.Visible = false;
					m_tblAntwortmoeglErstellen.Visible = false;
					m_pnFrageUebernehmen.Visible = false;
				}
				else
				{
					// testen, ob die geladene Umfrage dem eingeloggten Benutzer gehört...
					if (!CheckUmfrageBelongsToUser())
					{
						// ...wenn nicht neue Umfrage erstellen lassen
						umfr.Clear();
						Response.Redirect("umfrageerstellen.aspx");
					}
					else
					{
						// Umfrage zum bearbeiten laden
						LoadUmfrage();
					}
				}
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
			this.m_lnkbNeueFrage.Click += new System.EventHandler(this.m_lnkbNeueFrage_Click);
			this.m_rdbTextfrage.CheckedChanged += new System.EventHandler(this.m_rdbFrageart_CheckedChanged);
			this.m_rdbUndFrage.CheckedChanged += new System.EventHandler(this.m_rdbFrageart_CheckedChanged);
			this.m_rdbOderFrage.CheckedChanged += new System.EventHandler(this.m_rdbFrageart_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void m_btnBearbeiten_Click(object sender, System.EventArgs e)
		{
			// suche die erste selektierte Frage
			for (int i = 0; i < m_dgFragen.Items.Count; i++)
			{
				CheckBox cbx = (CheckBox)DataGridAccess.GetControlFromDataGrid(m_dgFragen.Items[i], typeof(CheckBox), 0, 0);
				if (cbx != null && cbx.Checked)
				{
					// den Fragetitel eintragen
					m_txtFrageTitel.Text = m_dgFragen.Items[i].Cells[1].Text;
					m_pnFrageErstellen.Visible = true;
					m_pnFrageUebernehmen.Visible = true;

					// bei Und- und Oderfragen auch die Antwortmöglichkeiten eintragen
					int frageart = Convert.ToInt32(m_dgFragen.Items[i].Cells[3].Text);
					if (frageart != DBConstants.TextFrage)
					{
						FillDGAntwErstellen(Convert.ToInt32(m_dgFragen.Items[i].Cells[2].Text));
						m_tblAntwortmoeglErstellen.Visible = true;
					}

					// Radiobutton entsprechend der Frageart setzen
					m_rdbTextfrage.Checked = false;
					m_rdbUndFrage.Checked = false;
					m_rdbOderFrage.Checked = false;
					switch(frageart)
					{
						case DBConstants.TextFrage:
							m_rdbTextfrage.Checked = true;
							break;
						case DBConstants.UndFrage:
							m_rdbUndFrage.Checked = true;
							break;
						case DBConstants.OderFrage:
							m_rdbOderFrage.Checked = true;
							break;
					}

					// die erste selektierte Frage wurde gefunden, die weiteren werden nicht behandelt
					break;
				}
			}
		}

		private void m_btnLoeschen_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < m_dgFragen.Items.Count; i++)
			{
				if (m_dgFragen.Items[i].ItemType == ListItemType.Item || m_dgFragen.Items[i].ItemType == ListItemType.AlternatingItem)
				{
					if (((CheckBox)(m_dgFragen.Items[i].Cells[0].Controls[1])).Checked)
					{
						// TODO: Frage löschen
					}
				}
			}
		}

		private void m_lnkbNeueFrage_Click(object sender, System.EventArgs e)
		{
			// alle Editfelder zurücksetzen
			m_txtFrageTitel.Text = "";
			m_rdbTextfrage.Checked = true;
			m_rdbOderFrage.Checked = false;
			m_rdbUndFrage.Checked = false;
			m_tblAntwortmoeglErstellen.Visible = false;
			m_pnFrageErstellen.Visible = true;
			m_pnFrageUebernehmen.Visible = true;
		}

		private void m_rdbFrageart_CheckedChanged(object sender, System.EventArgs e)
		{
			// wenn Und- oder Oderfrage ausgewählt ist, sollen Antwortmöglichkeiten erstellt werden können
			m_tblAntwortmoeglErstellen.Visible = (m_rdbOderFrage.Checked || m_rdbUndFrage.Checked);
			PrepareDGAntwErstellen(6);
		}

		#region Hilfsfunktionen

		private void RefreshDGFragen()
		{
			SqlParameter pRUmfrageID = DataAccessFragen.Paramr_UmfrageID;
			pRUmfrageID.Value = SessionContainer.ReadFromSession(this).Umfrage.UmfrageID;
			DataParameters paramsFragen = new DataParameters();
			paramsFragen.Add(pRUmfrageID);
			DataAccessFragen daFragen = new DataAccessFragen();
			DSFragen dsFragen = daFragen.Select(paramsFragen);
			m_dgFragen.DataSource = dsFragen.fragen;
			m_dgFragen.DataBind();
			m_tblFragen.Visible = (dsFragen.fragen.Rows.Count > 0);
		}

		private void PrepareDGAntwErstellen(int numOfTxt)
		{
			// eine Datenquelle vorbereiten, die so vielen Zeilen hat wie TextBoxes
			// in dem DataGrid erscheinen sollen
			ArrayList rowsCountArray = new ArrayList();
			for (int i = 0; i < numOfTxt; i++)
			{
				rowsCountArray.Add(i);
			}

			m_dgAntwErstellen.DataSource = rowsCountArray;
			m_dgAntwErstellen.DataBind();  
		}

		private void FillDGAntwErstellen(int FrageID)
		{
			// vorhandene Antwortmöglichkeiten zu der Frage mit der Id FrageID aus der DB ziehen
			SqlParameter pR_FrageID = DataAccessAwmoeglichkeiten.Paramr_FrageID;
			pR_FrageID.Value = FrageID;
			DataParameters parameters = new DataParameters();
			parameters.Add(pR_FrageID);
			DataAccessAwmoeglichkeiten daAwMoegl = new DataAccessAwmoeglichkeiten();
			DSAwmoeglichkeiten dsAwMoegl = daAwMoegl.Select(parameters);

			if (dsAwMoegl.awmoeglichkeiten.Count > 0)
			{
				// Entsprechende Anzahl von Editfeldern im DataGrid anlegen
				PrepareDGAntwErstellen(dsAwMoegl.awmoeglichkeiten.Count);

				// Daten in die Editfelder eintragen
				for (int i = 0; i < dsAwMoegl.awmoeglichkeiten.Count; i++)
				{
					TextBox txtbx = (TextBox)DataGridAccess.GetControlFromDataGrid(m_dgAntwErstellen.Items[i], typeof(TextBox), 1, 0);
					if (txtbx != null)
					{
						txtbx.Text = dsAwMoegl.awmoeglichkeiten[i].Text;
					}
				}
			}
			else
			{
				PrepareDGAntwErstellen(6);
			}

		}

		/// <summary>
		/// Überprüft, ob die geladene Umfrage dem eingeloggten Benutzer gehört
		/// </summary>
		/// <returns>true, wenn die geladene Umfrage dem eingeloggten Benutzer gehört
		///	false, wenn kein Benutzer eingeloggt ist, keine Umfrage geladen ist oder 
		///	die geladene Umfrage nicht dem eingeloggten Benutzer gehört</returns>
		protected bool CheckUmfrageBelongsToUser()
		{
			// gar kein Benutzer eingeloggt:
			UserInfo user = SessionContainer.ReadFromSession(this).User;
			if (!user.IsLoggedIn)
			{
				return false;
			}

			DSUmfragen dsUmfr = SessionContainer.ReadFromSession(this).Umfrage.getLoadedUmfrage();
			if (dsUmfr.umfragen.Rows.Count == 1)
			{
				return (user.UserID == Convert.ToInt32(dsUmfr.umfragen.Rows[0]["r_UserID"]));
			}

			return false;
		}


		private void LoadUmfrage()
		{
			DSUmfragen dsUmfr = SessionContainer.ReadFromSession(this).Umfrage.getLoadedUmfrage();
			if (dsUmfr.umfragen.Rows.Count == 1)
			{
				// Editfelder mit Titel und Kurzbeschreibung der Umfrage füllen
				m_txtTitel.Text = dsUmfr.umfragen[0].Titel;
				m_txtComment.Text = dsUmfr.umfragen[0].Beschreibung;
				// Checkbox je nach Onlinestatus der Umfrage setzen
				m_chbOnline.Checked = (dsUmfr.umfragen[0].Onlinestatus == DBConstants.Online);
				// schon vorhandene Fragen aus der Datenbank ziehen
				RefreshDGFragen();	
				m_pnFrageErstellen.Visible = false;
				m_tblAntwortmoeglErstellen.Visible = false;
			}
		}

		#endregion



	}
}
