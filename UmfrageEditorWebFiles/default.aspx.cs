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
using System.Configuration;

namespace UmfrageEditor
{
	/// <summary>
	/// Startseite des Umfrage-Editors
	/// </summary>
	public class _default : System.Web.UI.Page
	{
	
//		protected SqlConnection m_conn;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
//		protected SqlCommand m_sqlCmd;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Hier Benutzercode zur Seiteninitialisierung einfügen
			DBconnector db = new DBconnector();
//			DataGrid1.DataSource = db.m_sqlCmd.ExecuteReader();
//			DataGrid1.DataBind();

			// Verbindung zur Datenbank herstellen
			

//			m_conn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
//			
//
//			m_sqlCmd = new SqlCommand();
//			m_sqlCmd.Connection = m_conn;
//
//			m_conn.Open();

			DataGrid1.DataSource = db.getData("SELECT * FROM umfragen");
			DataGrid1.DataBind();
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=TRONIC;packet size=4096;user id=sa;data source=TRONIC;persist secu" +
				"rity info=True;initial catalog=UmfrageEditorDB;password=fhwaspnet";
			this.sqlConnection1.InfoMessage += new System.Data.SqlClient.SqlInfoMessageEventHandler(this.sqlConnection1_InfoMessage);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
		{
		
		}
	}
}
