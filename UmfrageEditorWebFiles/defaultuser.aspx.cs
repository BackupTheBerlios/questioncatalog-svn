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
	/// Pers�nliche Startseite eines eingeloggten Benutzers
	/// Stellt M�glichkeiten zum L�schen und Editieren eigener Umfragen zur Verf�gung
	/// </summary>
	public class defaultuser : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button m_btnLoeschen;
		protected System.Web.UI.WebControls.Button m_btnBearbeiten;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageNeu;
		protected System.Web.UI.WebControls.Button m_btnUmfrageNeu;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageListe;
		protected System.Web.UI.WebControls.CheckBoxList m_chblUmfragenListe;
		/// <summary>
		/// Kommunikation mit der DB
		/// </summary>
		protected DataAccessUmfragen m_daUmfragen;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// pr�fen, ob der Benutzer eingeloggt ist, 
			// wenn nicht, auf die Login-Seite zur�ckschicken
			if (!SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				Server.Transfer("registrieren.aspx");
			}

			m_pnUmfrageListe.Visible = true;
			m_pnUmfrageNeu.Visible = true;

//			SqlParameter 	
//			m_chblUmfragenListe.DataSource = m_daUmfragen.Select(
		}

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
