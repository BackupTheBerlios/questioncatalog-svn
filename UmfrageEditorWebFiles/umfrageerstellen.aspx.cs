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
		protected System.Web.UI.WebControls.Button m_btnFertig;
		protected System.Web.UI.WebControls.Label m_lbFrage;
		protected System.Web.UI.WebControls.TextBox m_txtComment;
		protected System.Web.UI.WebControls.RadioButton m_rdbTextfrage;
		protected System.Web.UI.WebControls.RadioButton m_rdbUndFrage;
		protected System.Web.UI.WebControls.RadioButton m_rdbOderFrage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageTitel;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnNeueFrage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnFrageErstellen;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblAntwortmoeglErstellen;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblAntwortM;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblAntwErstellen;
		protected System.Web.UI.WebControls.Button m_btnFrageUebernehmen;
		protected System.Web.UI.WebControls.Label m_lbHeadline;
		protected System.Web.UI.WebControls.TextBox m_txtFrageTitel;
		protected System.Web.UI.WebControls.DataGrid m_dgFragen;
		protected System.Web.UI.WebControls.LinkButton m_lnkbNeueFrage;
		protected System.Web.UI.WebControls.LinkButton m_lnkbMehrAntw;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnFrageUebernehmen;
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
			m_pnFrageErstellen.Visible = true;
			m_pnFrageUebernehmen.Visible = true;
		}

		private void m_rdbFrageart_CheckedChanged(object sender, System.EventArgs e)
		{
			// wenn Und- oder Oderfrage ausgewählt ist, sollen Antwortmöglichkeiten erstellt werden können
			m_tblAntwortmoeglErstellen.Visible = (m_rdbOderFrage.Checked || m_rdbUndFrage.Checked);
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
				m_txtTitel.Text = dsUmfr.umfragen[0].Titel;
				m_txtComment.Text = dsUmfr.umfragen[0].Beschreibung;
				m_chbOnline.Checked = (dsUmfr.umfragen[0].Onlinestatus == DBConstants.Online);
				RefreshDGFragen();
				m_pnFrageErstellen.Visible = false;
				m_tblAntwortmoeglErstellen.Visible = false;
			}
		}

		#endregion



	}
}
