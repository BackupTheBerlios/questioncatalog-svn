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
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_debug;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_default;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			#region Navigationsmenü 
			
			// Alle Menüs Bis auf Widerruf deaktivieren
			m_menu_default.Visible = false;
			m_menu_registrieren.Visible = false;
			m_menu_user.Visible = false;
			m_menu_admin.Visible = false;
			m_menu_debug.Visible = false;

			
			// Einblenden des generellen Navigationsblocks
			m_menu_default.Visible = true;

			// Einblendung im Navigationmenü prüfen
			/* Im Debugmodus Direktnavigation zu den Seiten einblenden 
				 * und alle Menüs einblenden */
			if (DBConstants.Debugmodus)
			{
				m_menu_default.Visible = true;
				m_menu_registrieren.Visible = true;
				m_menu_user.Visible = true;
				m_menu_admin.Visible = true;
				m_menu_debug.Visible = true;
			}
				// Usermenü bei angemeldetem Benutzer 
			else if (SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				m_menu_user.Visible = true;
				
				// wenn der Benutzer AdminStatus besitzt
				if (SessionContainer.ReadFromSession(this).User.IsAdmin)
				{
					m_menu_admin.Visible = true;
				}

			}
			else
			{
				m_menu_registrieren.Visible = false;
			}
			#endregion

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void m_menu_logout_Click(object sender, System.EventArgs e)
		{
			SessionContainer.ReadFromSession(this).User.Logout();
			// Server.Transfer("default.aspx");
		

		}

	}
}
