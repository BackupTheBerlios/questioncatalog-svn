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
	/// Zusammenfassung für login.
	/// </summary>
	public class login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtBenutzername;
		protected System.Web.UI.WebControls.TextBox txtPasswort;
		protected System.Web.UI.WebControls.Label lbLoginStatus;
		protected System.Web.UI.WebControls.LinkButton LinkLogin;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_login;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_logout;
		protected System.Web.UI.WebControls.Label lbLoginMessage;
		protected System.Web.UI.WebControls.LinkButton LinkLogout;
	
		protected DataAccessBenutzer daBenutzer;


		private void Page_Load(object sender, System.EventArgs e)
		{
			daBenutzer = new DataAccessBenutzer();

			/* Sichtbarkeit festlegen */
			
			if (!SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				// Zeige Login wenn User nicht eingeloggt ist
				m_login.Visible = true;
				m_logout.Visible = false;
			}
			else
			{
				// Zeige Logout wenn User eingeloggt ist
				m_login.Visible = false;
				m_logout.Visible = true;
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
			this.LinkLogin.Click += new System.EventHandler(this.LinkLogin_Click);
			this.LinkLogout.Click += new System.EventHandler(this.LinkLogout_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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
				}
				else
				{
					// Falsches Passwort
					SessionContainer.ReadFromSession(this).User.Logout();
					// lbLoginMessage.Text = "Login nicht erfolgreich!";
					lbLoginMessage.Text = "Falsches Passwort!";
				}
			}
			else
			{
				SessionContainer.ReadFromSession(this).User.Logout();
				lbLoginMessage.Text = "Benutzer ist  nicht bekannt!";
			}

			if (SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				// lbLoginStatus.Text = "Login erfolgreich!";
				// Server.Transfer("defaultuser.aspx");
				lbLoginStatus.Text = @"Eingeloggt als """ + SessionContainer.ReadFromSession(this).User.Username + @"""";
				m_login.Visible = false;
				m_logout.Visible = true;
				lbLoginMessage.Text = "";
			}
			else
			{
				// lbLoginMessage.Text = "Login fehlgeschlagen!";
				lbLoginStatus.Text = "";
			}
		}

		private void txtPasswort_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtBenutzername_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void LinkLogout_Click(object sender, System.EventArgs e)
		{
			m_login.Visible = true;
			m_logout.Visible = false;
			SessionContainer.ReadFromSession(this).User.Logout();

		}

	}
}
