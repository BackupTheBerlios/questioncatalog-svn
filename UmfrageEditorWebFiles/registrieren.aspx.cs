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
		protected System.Web.UI.WebControls.Button btnLogin;
		protected System.Web.UI.WebControls.Label lbLoginStatus;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;

		protected DataAccessBenutzer daBenutzer;
	
		private void Page_Load(object sender, System.EventArgs e)
		{


			daBenutzer = new DataAccessBenutzer();

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
			this.txtBenutzername.TextChanged += new System.EventHandler(this.txtBenutzername_TextChanged);
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.btnRegistrieren.ServerClick += new System.EventHandler(this.btnRegistrieren_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnRegistrieren_ServerClick(object sender, System.EventArgs e)
		{


			SqlParameter paramName = DataAccessBenutzer.ParamName;
			paramName.Value = txtBenutzername.Text;
			DataParameters dParams = new DataParameters();
			dParams.Add(paramName);
			DSBenutzer dsBen = daBenutzer.Select(dParams);

			if(dsBen.benutzer.Rows.Count > 0)
			{
				lbAusgabe.InnerText = "Benutzername existiert bereits!";
			}
			else
			{
				lbAusgabe.InnerText = "Ok!";
				DSBenutzer.benutzerRow newEntry = dsBen.benutzer.NewbenutzerRow();
				newEntry.Name = txtBenutzername.Text;
				newEntry.Passwort = txtPasswort.Text;
				newEntry.GruppenID = 1;
				dsBen.benutzer.AddbenutzerRow(newEntry);
				try
				{
					daBenutzer.CommitChanges(dsBen);
				}
				catch(Exception ex)
				{
					lbAusgabe.InnerText = ex.Message;
				}
			}
		}

		private void btnLogin_Click(object sender, System.EventArgs e)
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
					string username = (string)dsBen.benutzer.Rows[0]["Name"];
					SessionContainer.ReadFromSession(this).User.Login(username, pw);
//					lbLoginStatus.Text = "Login erfolgreich!";
				}
				else
				{
					SessionContainer.ReadFromSession(this).User.Logout();
//					lbLoginStatus.Text = "Falsches Passwort!";
				}
			}
			else
			{
				SessionContainer.ReadFromSession(this).User.Logout();
//				lbLoginStatus.Text = "Falscher Benutzername!";
			}

			if (SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
//				lbLoginStatus.Text = "Login erfolgreich!";
				Server.Transfer("defaultuser.aspx");
			}
			else
			{
				lbLoginStatus.Text = "Login fehlgeschlagen!";
			}
		}

		private void txtBenutzername_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
