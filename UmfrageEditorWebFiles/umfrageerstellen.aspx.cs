using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DBAccessor;

using System.Configuration;


namespace UmfrageEditor
{
	/// <summary>
	/// Zusammenfassung für umfrageerstellen.
	/// </summary>
	public class umfrageerstellen : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_default;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_registrieren;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_admin;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_user;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_menu_debug;
		protected System.Web.UI.WebControls.LinkButton LinkLogout;
		protected System.Web.UI.WebControls.Label lbLoginStatus;
		protected System.Web.UI.WebControls.LinkButton LinkLogin;
		protected System.Web.UI.WebControls.TextBox txtPasswort;
		protected System.Web.UI.WebControls.TextBox txtBenutzername;
		protected System.Web.UI.WebControls.Label lbLoginMessage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_login;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_logout;
		protected System.Web.UI.WebControls.LinkButton m_lnkbNeueFrage;
		protected System.Web.UI.WebControls.Button m_btnFertig;
		protected System.Web.UI.WebControls.Button m_btnFrageUebernehmen;
		protected System.Web.UI.WebControls.LinkButton m_lnkbMehrAntw;
		protected System.Web.UI.WebControls.DataGrid m_dgAntwErstellen;
		protected System.Web.UI.WebControls.Label m_lbWarningAlreadyAnswered;
		protected System.Web.UI.WebControls.Label m_lbValidatorMessageFrage;
		protected System.Web.UI.WebControls.RequiredFieldValidator m_valFrageTitel;
		protected System.Web.UI.WebControls.RadioButton m_rdbOderFrage;
		protected System.Web.UI.WebControls.RadioButton m_rdbUndFrage;
		protected System.Web.UI.WebControls.RadioButton m_rdbTextfrage;
		protected System.Web.UI.WebControls.TextBox m_txtFrageTitel;
		protected System.Web.UI.WebControls.Label m_lbFrage;
		protected System.Web.UI.WebControls.Button m_btnBearbeiten;
		protected System.Web.UI.WebControls.Button m_btnLoeschen;
		protected System.Web.UI.WebControls.DataGrid m_dgFragen;
		protected System.Web.UI.WebControls.Label m_lbValidatorMessageTitel;
		protected System.Web.UI.WebControls.RequiredFieldValidator m_valComment;
		protected System.Web.UI.WebControls.RequiredFieldValidator m_valTitel;
		protected System.Web.UI.WebControls.Label m_lbHeadline;
		protected System.Web.UI.WebControls.TextBox m_txtComment;
		protected System.Web.UI.WebControls.CheckBox m_chbOnline;
		protected System.Web.UI.WebControls.Button m_btnTitelUebernehmen;
		protected System.Web.UI.WebControls.TextBox m_txtTitel;
		protected System.Web.UI.WebControls.Label m_lbComment;
		protected System.Web.UI.WebControls.Label m_lbTitle;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnUmfrageTitel;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblFragen;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnFrageErstellen;
		protected System.Web.UI.HtmlControls.HtmlTable m_tblAntwortmoeglErstellen;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnFrageUebernehmen;
		protected System.Web.UI.HtmlControls.HtmlGenericControl m_pnNeueFrage;
		protected string PageTitle;

		protected DataAccessBenutzer daBenutzer = new DataAccessBenutzer();

		/// <summary>
		/// speichert die FrageID der in Bearbeitung befindlichen Frage
		/// </summary>
		protected int FrageID
		{
			get
			{
				return ((ViewState["FrageID"] == null) ? DBConstants.NotValid : (int)ViewState["FrageID"]); 
			} 
			set { ViewState["FrageID"] = value; }
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Einblendungen für Login und Navmenü prüfen
			check_visibility();

			//wenn kein Benutzer eingeloggt ist, direkt zur Loginseite schicken
			UserInfo user = SessionContainer.ReadFromSession(this).User;
			if (!user.IsLoggedIn)
			{
				Server.Transfer("default.aspx");
			}

			if (!IsPostBack)
			{
				// Initialisierungen:
				// Titel des Browserfensters setzen
				PageTitle = "Umfrage Erstellen";
				DataBind();

				// Abschnitte, die immer sichtbar sein sollen
				m_pnUmfrageTitel.Visible = true;

				// FrageID in den ViewState schreiben
				FrageID = DBConstants.NotValid;

				// soll eine neue Umfrage erstellt werden?
				UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
				if (!umfr.IsLoaded || !CheckUmfrageBelongsToUser())
				{
					// wenn keine Umfrage in der Session geladen ist oder die geladene
					// Umfrage nicht dem eingeloggten Benutzer gehört...
					NeueUmfrage();
				}
				else
				{
//					// testen, ob die geladene Umfrage dem eingeloggten Benutzer gehört...
//					if (!CheckUmfrageBelongsToUser())
//					{
//						// ...wenn nicht neue Umfrage erstellen lassen
//						umfr.Clear();
//						Response.Redirect("umfrageerstellen.aspx");
//					}
//					else
//					{
						// Umfrage zum bearbeiten laden
						LoadUmfrage();
//					}
				}
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
			this.m_btnTitelUebernehmen.Click += new System.EventHandler(this.m_btnTitelUebernehmen_Click);
			this.m_btnLoeschen.Click += new System.EventHandler(this.m_btnLoeschen_Click);
			this.m_btnBearbeiten.Click += new System.EventHandler(this.m_btnBearbeiten_Click);
			this.m_lnkbMehrAntw.Click += new System.EventHandler(this.m_lnkbMehrAntw_Click);
			this.m_btnFrageUebernehmen.Click += new System.EventHandler(this.m_btnFrageUebernehmen_Click);
			this.m_btnFertig.Click += new System.EventHandler(this.m_btnFertig_Click);
			this.m_lnkbNeueFrage.Click += new System.EventHandler(this.m_lnkbNeueFrage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Benutzerdefinierte Eventhandler

		private void m_btnBearbeiten_Click(object sender, System.EventArgs e)
		{
			// suche die erste selektierte Frage
			for (int i = 0; i < m_dgFragen.Items.Count; i++)
			{
				CheckBox cbx = (CheckBox)DataGridAccess.GetControlFromDataGrid(m_dgFragen.Items[i], typeof(CheckBox), 1, 0);
				if (cbx != null && cbx.Checked)
				{
					// selektierten Frage anhand ihrer ID zum Bearbeiten laden
					LoadFrage(Convert.ToInt32(m_dgFragen.Items[i].Cells[0].Text));

					// die erste selektierte Frage wurde gefunden, die weiteren werden nicht behandelt
					break;
				}
			}
		}

		private void m_btnLoeschen_Click(object sender, System.EventArgs e)
		{
			ArrayList idCache = new ArrayList();

			// IDs aller selektierten Fragen ermitteln
			for (int i = 0; i < m_dgFragen.Items.Count; i++)
			{
				CheckBox cbx = (CheckBox)DataGridAccess.GetControlFromDataGrid(m_dgFragen.Items[i], typeof(CheckBox), 1, 0);
				if (cbx != null && cbx.Checked)
				{
					// ID der selektierten Frage zwischenspeichern
					idCache.Add(Convert.ToInt32(m_dgFragen.Items[i].Cells[0].Text));
				}
			}

			// Für jede ID den entsprechenden Datensatz aus der DB ziehen und löschen
			DataAccessFragen daFragen = new DataAccessFragen();
			foreach (int id in idCache)
			{
				// alle Datensätze aus dem DataSet löschen
				daFragen.DeleteFrage(id);
				// Falls die in Bearbeitung befindliche Frage gelöscht wird
				// die Fragebearbeitungsanzeige zurücksetzen
				if (id == FrageID)
				{
					NeueFrage();
				}
			}

			RefreshDGFragen();
		}

		private void m_lnkbNeueFrage_Click(object sender, System.EventArgs e)
		{
			NeueFrage();
		}

		private void m_rdbFrageart_CheckedChanged(object sender, System.EventArgs e)
		{
			// wenn Und- oder Oderfrage ausgewählt ist, sollen Antwortmöglichkeiten erstellt werden können
			m_tblAntwortmoeglErstellen.Visible = (m_rdbOderFrage.Checked || m_rdbUndFrage.Checked);
			FillDGAntwErstellen(FrageID);
		}

		private void m_lnkbMehrAntw_Click(object sender, System.EventArgs e)
		{
			ArrayList tempData = new ArrayList();

			// den Inhalt aller Textboxen die nicht leer sind zwischenspeichern
			for (int i = 0; i < m_dgAntwErstellen.Items.Count; i++)
			{
				TextBox txtbx = (TextBox)DataGridAccess.GetControlFromDataGrid(m_dgAntwErstellen.Items[i], typeof(TextBox), 1, 0);
				if (txtbx != null)
				{
					if (txtbx.Text.Trim() != "")
					{
						// ein Pair von Text und ID zwischenspeichern
						tempData.Add(new Pair(txtbx.Text, m_dgAntwErstellen.Items[i].Cells[0].Text));
					}
				}
			}

			// mehr Eingabefelder erzeugen
			PrepareDGAntwErstellen(m_dgAntwErstellen.Items.Count + 4);

			// Daten in die Textboxen zurückschreiben 
			for (int i = 0; i < tempData.Count; i++)
			{
				TextBox txtbx = (TextBox)DataGridAccess.GetControlFromDataGrid(m_dgAntwErstellen.Items[i], typeof(TextBox), 1, 0);
				if (txtbx != null)
				{
					txtbx.Text = (string)((Pair)tempData[i]).First;
					m_dgAntwErstellen.Items[i].Cells[0].Text = (string)((Pair)tempData[i]).Second;
				}
			}
		}

		private void m_btnTitelUebernehmen_Click(object sender, System.EventArgs e)
		{
			SaveUmfrage();
			if (IsValid)
			{
				LoadFrage(FrageID);			
			}
		}

		private void m_btnFrageUebernehmen_Click(object sender, System.EventArgs e)
		{
			SaveFrage();
			if (m_tblAntwortmoeglErstellen.Visible)
			{
				SaveAntworten();
			}
		}

		private void m_btnFertig_Click(object sender, System.EventArgs e)
		{
			SaveUmfrage();
			if (m_pnFrageErstellen.Visible)
			{
				SaveFrage();
				if (m_tblAntwortmoeglErstellen.Visible)
				{
					SaveAntworten();
				}
			}
			// Umfrage aus der Session schmeißen
			SessionContainer.ReadFromSession(this).Umfrage.Clear();
			// zur Persönlichen Startseite zurückschicken
			Server.Transfer("defaultuser.aspx");
		}

		#endregion

		#region Hilfsfunktionen

		private void RefreshDGFragen()
		{
			SqlParameter pRUmfrageID = DataAccessFragen.Paramr_UmfrageID;
			pRUmfrageID.Value = SessionContainer.ReadFromSession(this).Umfrage.UmfrageID;
			DataParameters paramsFragen = new DataParameters();
			paramsFragen.Add(pRUmfrageID);
			DataAccessFragen daFragen = new DataAccessFragen();
			DSFragen dsFragen = daFragen.Select(paramsFragen);
			m_dgFragen.DataSource = dsFragen.fragen;
			m_dgFragen.DataBind();
			m_tblFragen.Visible = (dsFragen.fragen.Rows.Count > 0);
		}

		private void PrepareDGAntwErstellen(int numOfTxt)
		{
			// eine Datenquelle vorbereiten, die so vielen Zeilen hat wie TextBoxes
			// in dem DataGrid erscheinen sollen
			ArrayList rowsCountArray = new ArrayList();
			for (int i = 0; i < numOfTxt; i++)
			{
				rowsCountArray.Add(DBConstants.NotValid);
			}

			m_dgAntwErstellen.DataSource = rowsCountArray;
			m_dgAntwErstellen.DataBind();  

			// ID-Felder im Datagrid mit "NotValid" besetzen
			for (int j = 0; j < m_dgAntwErstellen.Items.Count; j++)
			{
				m_dgAntwErstellen.Items[j].Cells[0].Text = DBConstants.NotValid.ToString();
			}
		}

		private void FillDGAntwErstellen(int FrageID)
		{
			// vorhandene Antwortmöglichkeiten zu der Frage mit der Id FrageID aus der DB ziehen
			SqlParameter pR_FrageID = DataAccessAwmoeglichkeiten.Paramr_FrageID;
			pR_FrageID.Value = FrageID;
			DataParameters parameters = new DataParameters();
			parameters.Add(pR_FrageID);
			DataAccessAwmoeglichkeiten daAwMoegl = new DataAccessAwmoeglichkeiten();
			DSAwmoeglichkeiten dsAwMoegl = daAwMoegl.Select(parameters);

			if (dsAwMoegl.awmoeglichkeiten.Count > 0)
			{
				// Entsprechende Anzahl von Editfeldern im DataGrid anlegen (+ 4 neue)
				PrepareDGAntwErstellen(dsAwMoegl.awmoeglichkeiten.Count + 4);

				// Daten in die Editfelder eintragen
				for (int i = 0; i < dsAwMoegl.awmoeglichkeiten.Count; i++)
				{
					TextBox txtbx = (TextBox)DataGridAccess.GetControlFromDataGrid(m_dgAntwErstellen.Items[i], typeof(TextBox), 1, 0);
					if (txtbx != null)
					{
						// Antworttext in das Editfeld dieser Zeile eintragen
						txtbx.Text = dsAwMoegl.awmoeglichkeiten[i].Text;
						// AntwortMögl.-ID in die gleiche Zeile eintragen
						m_dgAntwErstellen.Items[i].Cells[0].Text = dsAwMoegl.awmoeglichkeiten[i].AwmID.ToString();
					}
				}
			}
			else
			{
				PrepareDGAntwErstellen(6);
			}

		}

		/// <summary>
		/// Überprüft, ob die geladene Umfrage dem eingeloggten Benutzer gehört
		/// </summary>
		/// <returns>true, wenn die geladene Umfrage dem eingeloggten Benutzer gehört
		///	false, wenn kein Benutzer eingeloggt ist, keine Umfrage geladen ist oder 
		///	die geladene Umfrage nicht dem eingeloggten Benutzer gehört</returns>
		protected bool CheckUmfrageBelongsToUser()
		{
			// gar kein Benutzer eingeloggt:
			UserInfo user = SessionContainer.ReadFromSession(this).User;
			if (!user.IsLoggedIn)
			{
				return false;
			}

			DSUmfragen dsUmfr = SessionContainer.ReadFromSession(this).Umfrage.getLoadedUmfrage();
			if (dsUmfr.umfragen.Rows.Count == 1)
			{
				return (user.UserID == Convert.ToInt32(dsUmfr.umfragen.Rows[0]["r_UserID"]));
			}

			return false;
		}

//		private void CheckAnswersExist()
//		{
//			UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
//			if (!umfr.IsLoaded)
//			{
//				return;
//			}
//
//			
//
//		}


		private void LoadUmfrage()
		{
			DSUmfragen dsUmfr = SessionContainer.ReadFromSession(this).Umfrage.getLoadedUmfrage();
			if (dsUmfr.umfragen.Rows.Count == 1)
			{
				// Editfelder mit Titel und Kurzbeschreibung der Umfrage füllen
				m_txtTitel.Text = dsUmfr.umfragen[0].Titel;
				m_txtComment.Text = dsUmfr.umfragen[0].Beschreibung;
				// Checkbox je nach Onlinestatus der Umfrage setzen
				m_chbOnline.Checked = (dsUmfr.umfragen[0].Onlinestatus == DBConstants.Online);
				// schon vorhandene Fragen aus der Datenbank ziehen
				RefreshDGFragen();	
				m_pnFrageErstellen.Visible = false;
				m_pnFrageUebernehmen.Visible = false;
				m_tblAntwortmoeglErstellen.Visible = false;
			}
		}

		private void LoadFrage(int id)
		{
			// ID der zu bearbeitenden Frage speichern
			FrageID = id;

			// Frage neu aus der DB ziehen
			DSFragen dsFragen = new DataAccessFragen().GetFrageByID(id);

			if (dsFragen.fragen.Count != 1)
			{
				ClearFrage();
				NeueFrage();
				return;
			}

			// den Fragetitel eintragen
			m_txtFrageTitel.Text = dsFragen.fragen[0].Text;
			m_pnFrageErstellen.Visible = true;
			m_pnFrageUebernehmen.Visible = true;
			// Antwortmöglichkeiten vorsichtshalber ausblenden
			m_tblAntwortmoeglErstellen.Visible = false;

			// bei Und- und Oderfragen auch die Antwortmöglichkeiten eintragen
			int frageart = dsFragen.fragen[0].Frageart;
			if (frageart != DBConstants.TextFrage)
			{
				FillDGAntwErstellen(id);
				m_tblAntwortmoeglErstellen.Visible = true;
			}

			// Radiobutton entsprechend der Frageart setzen
			m_rdbTextfrage.Checked = false;
			m_rdbUndFrage.Checked = false;
			m_rdbOderFrage.Checked = false;
			switch(frageart)
			{
				case DBConstants.TextFrage:
					m_rdbTextfrage.Checked = true;
					break;
				case DBConstants.UndFrage:
					m_rdbUndFrage.Checked = true;
					break;
				case DBConstants.OderFrage:
					m_rdbOderFrage.Checked = true;
					break;
			}

			// neue Frage-Link anzeigen
			m_pnNeueFrage.Visible = true;
		}

		private void ClearFrage()
		{
			FrageID = DBConstants.NotValid;
			// alle Editfelder zurücksetzen
			m_txtFrageTitel.Text = "";
			m_rdbTextfrage.Checked = true;
			m_rdbOderFrage.Checked = false;
			m_rdbUndFrage.Checked = false;
			m_tblAntwortmoeglErstellen.Visible = false;
			m_pnFrageErstellen.Visible = false;
			m_pnFrageUebernehmen.Visible = false;
		}

		private void NeueFrage()
		{
			ClearFrage();
			m_pnFrageErstellen.Visible = true;
			m_pnFrageUebernehmen.Visible = true;
			m_pnNeueFrage.Visible = true;
		}

		private void NeueUmfrage()
		{
			// Umfrage aus der Session löschen
			SessionContainer.ReadFromSession(this).Umfrage.Clear();

			// für neue Umfrage nicht relevante Abschnitte der Seite ausblenden
			m_tblFragen.Visible	= false;
			m_pnNeueFrage.Visible = false;
			m_pnFrageErstellen.Visible = false;
			m_pnFrageUebernehmen.Visible = false;
			m_tblAntwortmoeglErstellen.Visible = false;
			m_pnFrageUebernehmen.Visible = false;
		}

		private void SaveUmfrage()
		{
			if (IsValid)
			{
				// Fehlermessage zurückssetzen
				m_lbValidatorMessageTitel.Visible = false;

				int onlinestatus = (m_chbOnline.Checked ? DBConstants.Online : DBConstants.NotOnline);
				UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
				UserInfo user = SessionContainer.ReadFromSession(this).User;

				// Umfragedatensatz aktualisieren oder neu anlegen
				DataAccessUmfragen daUmfr = new DataAccessUmfragen();
				DSUmfragen dsUmfr= daUmfr.GetUmfrageByID(umfr.UmfrageID);
				if (dsUmfr.umfragen.Count == 0)
				{
					// Umfrage besteht noch nicht in der DB, neuen Datensatz anlegen
					dsUmfr.umfragen.AddumfragenRow(m_txtTitel.Text.Trim(), m_txtComment.Text.Trim(), System.DateTime.Now, System.DateTime.Now, user.UserID, onlinestatus); 
				}
				else if (dsUmfr.umfragen.Count == 1)
				{
					// Umfrage besteht schon, Datensatz aktualisieren
					dsUmfr.umfragen[0].Titel = m_txtTitel.Text.Trim();
					dsUmfr.umfragen[0].Beschreibung = m_txtComment.Text.Trim();
					dsUmfr.umfragen[0].Onlinestatus = onlinestatus;
				}
				daUmfr.CommitChanges(dsUmfr);

				// ID des neuen Datensatzes in die Session schreiben
				if (dsUmfr.umfragen[0].UmfrageID != umfr.UmfrageID)
				{
					umfr.Load(dsUmfr.umfragen[0].UmfrageID);
				}
			}
			else
			{
				m_lbValidatorMessageTitel.Visible = true;
			}
		}

		private void SaveFrage()
		{
			if (IsValid)
			{
				// Fehlermessage zurückssetzen
				m_lbValidatorMessageFrage.Visible = false;

				// Daten vorbereiten
				UmfrageInfo umfr = SessionContainer.ReadFromSession(this).Umfrage;
				int frageart = DBConstants.TextFrage;
				if (m_rdbTextfrage.Checked)
				{
					frageart = DBConstants.TextFrage;
				}
				else if (m_rdbUndFrage.Checked)
				{
					frageart = DBConstants.UndFrage;
				}
				else if (m_rdbOderFrage.Checked)
				{
					frageart = DBConstants.OderFrage;
				}

				// Fragedatensatz aktualisieren oder neu anlegen
				DataAccessFragen daFragen = new DataAccessFragen();
				DSFragen dsFragen = daFragen.GetFrageByID(FrageID);
				if (dsFragen.fragen.Count == 0)
				{
					// Frage besteht noch nicht in der DB, neuen Datensatz anlegen
					dsFragen.fragen.AddfragenRow(umfr.UmfrageID, m_txtFrageTitel.Text.Trim(), frageart, 0);
				}
				else if (dsFragen.fragen.Count == 1)
				{
					// Frage besteht schon, Datensatz aktualisieren
					dsFragen.fragen[0].Text =  m_txtFrageTitel.Text.Trim();
					dsFragen.fragen[0].Frageart = frageart;
				}
				daFragen.CommitChanges(dsFragen);

				// ID des neuen Datensatzes in die FrageID schreiben
				FrageID = dsFragen.fragen[0].FrageID;

				RefreshDGFragen();
			}
			else
			{
				m_lbValidatorMessageFrage.Visible = true;
			}
		}

		private void SaveAntworten()
		{
			TextBox txt = null;
			DataAccessAwmoeglichkeiten daAntw = new DataAccessAwmoeglichkeiten();
			DSAwmoeglichkeiten dsAntw = new DSAwmoeglichkeiten();
			for (int i = 0; i < m_dgAntwErstellen.Items.Count; i++) 
			{
				dsAntw.Clear();
				int id = Convert.ToInt32(m_dgAntwErstellen.Items[i].Cells[0].Text);
				txt = (TextBox)DataGridAccess.GetControlFromDataGrid(m_dgAntwErstellen.Items[i], typeof(TextBox), 1, 0);
				if (txt == null)
				{
					continue;
				}

				if (txt.Text.Trim() == "")
				{
					// wenn ein leeres Textfeld eine gültige ID hat, wird der Datensatz gelöscht
					if (id != DBConstants.NotValid)
					{
						daAntw.DeleteAntwortmoegl(id);
					}
					
					continue;
				}
				else
				{
					dsAntw = daAntw.GetAntwortmoeglByID(id);
					if (dsAntw.awmoeglichkeiten.Count == 0)
					{
						// neuen Datensatz anlegen
						dsAntw.awmoeglichkeiten.AddawmoeglichkeitenRow(FrageID, txt.Text.Trim());
					}
					else if (dsAntw.awmoeglichkeiten.Count == 1)
					{
						// Datensatz aktualisieren
						dsAntw.awmoeglichkeiten[0].Text = txt.Text.Trim();
					}
				}
				daAntw.CommitChanges(dsAntw);

				// ID des Datensatzes in Datagrid eintragen
				m_dgAntwErstellen.Items[i].Cells[0].Text = dsAntw.awmoeglichkeiten[0].AwmID.ToString();
			}

			// Datagrid aktualisieren
			FillDGAntwErstellen(FrageID);
		}

		#endregion

		#region Login & Menü
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
					check_visibility();

					// Statusmessages setzen
					lbLoginStatus.Text = @"Eingeloggt als """ + SessionContainer.ReadFromSession(this).User.Username + @"""";
					lbLoginMessage.Text = "";

					// Redirect zur persönlichen Startseite
					Server.Transfer("defaultuser.aspx");

				}
				else
				{
					// Falsches Passwort
					
					// Überprüfung auf Debugmodus
					if(!DBConstants.Debugmodus)
					{
						// Standardausgabe
						lbLoginMessage.Text = "Login fehlgeschlagen!";
					}
					else
					{
						// Ausgabe im Debugmodus
						lbLoginMessage.Text = "Falsches Passwort!";
					}

					// Zur Sicherheit abmelden
					SessionContainer.ReadFromSession(this).User.Logout();
					
					// Statusmessages setzen
					lbLoginStatus.Text = "";

					// Sichtbarkeiten neu festlegen
					check_visibility();

				}
			}
			else
			{
				// Falscher Benutzer

				// Überprüfung auf Debugmodus
				if(!DBConstants.Debugmodus)
				{
					// Standardausgabe
					lbLoginMessage.Text = "Login fehlgeschlagen!";
				}
				else
				{
					// Ausgabe im Debugmodus
					lbLoginMessage.Text = "Unbekannter Benutzer!";
				}

				// Zur Sicherheit abmelden
				SessionContainer.ReadFromSession(this).User.Logout();

				// Statusmessages setzen
				lbLoginStatus.Text = "";

				// Sichtbarkeiten neu festlegen
				check_visibility();
			}
		}

		private void LinkLogout_Click(object sender, System.EventArgs e)
		{
			m_login.Visible = true;
			m_logout.Visible = false;
			SessionContainer.ReadFromSession(this).User.Logout();
			Server.Transfer("default.aspx");
		}

		private void txtBenutzername_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtPasswort_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void check_visibility()
		{
			/* Sichtbarkeiten festlegen */
			
			#region Loginblock
			if (!SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				//wenn User nicht eingeloggt ist

				// Zeige Login 
				m_login.Visible = true;

				// verstecke Logout
				m_logout.Visible = false;

				// Messages entsprechend setzen
				lbLoginStatus.Text = "";

			}
			else
			{
				// wenn User eingeloggt ist

				// Verstecke Login
				m_login.Visible = false;

				// Zeige Logout 
				m_logout.Visible = true;

				// Messages entsprechend setzen
				lbLoginMessage.Text = "";
				lbLoginStatus.Text = @"Eingeloggt als """ + SessionContainer.ReadFromSession(this).User.Username + @"""";
			}
			#endregion

			#region Navigationsmenü 
			
			// Alle Menüs bis auf Widerruf deaktivieren
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
				// wenn der Benutzer angemeldet ist 
			else if (SessionContainer.ReadFromSession(this).User.IsLoggedIn)
			{
				// Usermenü anzeigen 
				m_menu_user.Visible = true;
				
				// wenn der Benutzer AdminStatus besitzt
				if (SessionContainer.ReadFromSession(this).User.IsAdmin)
				{
					// Adminmenü anzeigen
					m_menu_admin.Visible = true;
				}

			}
				// Wenn der Benutzer nicht angemeldet ist
			else
			{
				// Registrieren anzeigen
				m_menu_registrieren.Visible = true;
			}
			#endregion


		}

		#endregion

	}
}
