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

namespace UmfrageEditor
{
	/// <summary>
	/// Zusammenfassung für loginstatus.
	/// </summary>
	public class loginstatus : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnVerwaltung;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.HyperLink lnkStatus;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Hier Benutzercode zur Seiteninitialisierung einfügen
			if (SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				btnVerwaltung.Text = "Logout";
			}
			else
			{
				btnVerwaltung.Text = "Verwaltung";
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
			this.btnVerwaltung.Click += new System.EventHandler(this.btnVerwaltung_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnVerwaltung_Click(object sender, System.EventArgs e)
		{
			if(SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				SessionContainer.ReadFromSession(this).User.Logout();
				Server.Transfer("./default.aspx");
			}
			else
			{
				// SessionContainer.ReadFromSession(this).User.IsLoggedIn = true;
				Server.Transfer("./registrieren.aspx");

			}
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
