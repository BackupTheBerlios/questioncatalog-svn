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
	/// Zusammenfassung f�r registrieren.
	/// </summary>
	public class registrieren : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtBenutzername;
		protected System.Web.UI.WebControls.TextBox txtPasswort;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnRegistrieren;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lbAusgabe;
//		protected DBconnector db;
		protected DataAccessBenutzer daBenutzer;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
//			db = new DBconnector();

			daBenutzer = new DataAccessBenutzer();
//			DSBenutzer dsBen = db.Select();
//			DataGrid1.DataSource = dsBen.benutzer;
//			DataGrid1.DataBind();
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
			this.btnRegistrieren.ServerClick += new System.EventHandler(this.btnRegistrieren_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnRegistrieren_ServerClick(object sender, System.EventArgs e)
		{
//			SqlDataReader reader = db.getData("SELECT Name FROM benutzer WHERE Name = '" + txtBenutzername.Text + "'");
//			if (reader.HasRows)
//			{
//				reader.Close();
//				lbAusgabe.InnerText = "Benutzername existiert bereits!";
//			}
//			else
//			{
//				reader.Close();
//				lbAusgabe.InnerText = "Ok!";
//				db.setData("INSERT INTO benutzer (Name, Passwort) VALUES ('" + txtBenutzername.Text + "', '" + txtBenutzername.Text + "'");
//			}

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
	}
}