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
	/// Zusammenfassung für registrieren.
	/// </summary>
	public class registrieren : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtBenutzername;
		protected System.Web.UI.WebControls.TextBox txtPasswort;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnRegistrieren;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lbAusgabe;
		protected DBconnector db;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			db = new DBconnector();
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
			this.btnRegistrieren.ServerClick += new System.EventHandler(this.btnRegistrieren_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnRegistrieren_ServerClick(object sender, System.EventArgs e)
		{
			SqlDataReader reader = db.getData("SELECT Name FROM benutzer WHERE Name = '" + txtBenutzername.Text + "'");
			if (reader.HasRows)
			{
				reader.Close();
				lbAusgabe.InnerText = "Benutzername existiert bereits!";
			}
			else
			{
				reader.Close();
				lbAusgabe.InnerText = "Ok!";
				db.setData("INSERT INTO benutzer (Name, Passwort) VALUES ('" + txtBenutzername.Text + "', '" + txtBenutzername.Text + "'");
			}
		}
	}
}
