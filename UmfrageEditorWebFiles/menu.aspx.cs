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

namespace UmfrageEditor
{
	/// <summary>
	/// Zusammenfassung für menu.
	/// </summary>
	public class menu : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_registrieren;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_admin;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_user;
		protected System.Web.UI.WebControls.LinkButton m_menu_logout;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_debug;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_default;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//wenn kein Benutzer eingeloggt ist
			m_menu_default.Visible = true;
			m_menu_registrieren.Visible = true;
			m_menu_admin.Visible = true;
			m_menu_user.Visible = true;
			if (DBConstants.Debugmodus)
			{
				m_menu_debug.Visible = true;
			}
			else
			{
				m_menu_debug.Visible = false;
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
			this.m_menu_logout.Click += new System.EventHandler(this.m_menu_logout_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void m_menu_logout_Click(object sender, System.EventArgs e)
		{
			SessionContainer.ReadFromSession(this).User.Logout();
			Server.Transfer("default.aspx");
		

		}

	}
}
