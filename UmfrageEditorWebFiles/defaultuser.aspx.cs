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
		protected System.Web.UI.WebControls.Label m_lbLoginInfo;
		protected System.Web.UI.WebControls.Label m_lbUserName;
		protected System.Web.UI.WebControls.Button m_btnLoeschen;
		protected System.Web.UI.WebControls.Button m_btnBearbeiten;
		protected System.Web.UI.WebControls.CheckBoxList m_chblUmfragenListe;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblUmfragenListe;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.LinkButton m_lnkbUmfrageNeu;
		
		/// <summary>
		/// Kommunikation mit der DB
		/// </summary>
		protected DataAccessUmfragen m_daUmfragen = new DataAccessUmfragen();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			UserInfo user = SessionContainer.ReadFromSession(this).User;

			// TEST: zum Testen einen Benutzer einloggen
			user.Login("kathrin", "kathrin");

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
	}
}
