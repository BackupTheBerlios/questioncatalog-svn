using System;
using DBAccessor;
using System.Data.SqlClient;
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
	/// Fasst Informationen über den aktuellen User zusammen
	/// </summary>
	public class UserInfo
	{
		public UserInfo()
		{
			Logout();
		}

		public string Username
		{
			get { return m_username; }
		}
		protected string m_username;

		public int UserID
		{
			get { return m_userID; }
		}
		protected int m_userID;

		public bool IsLoggedIn
		{
			get { return m_isLoggedIn; }
		}
		protected bool m_isLoggedIn;

		public bool IsAdmin
		{
			get { return m_isAdmin; }
		}
		protected bool m_isAdmin;

		/// <summary>
		/// prüft, ob Benutzername und Passwort gültig sind und loggt den Benutzer ggf. ein
		/// </summary>
		/// <param name="username">zu prüfender Benutzername</param>
		/// <param name="passwd">zu prüfendes Passwort</param>
		/// <returns>true, wenn Login erfolgreich, sonst false</returns>
		public bool Login(string username, string passwd)
		{
			// Daten für die DB-Abfrage vorbereiten
			SqlParameter pUsername = DataAccessBenutzer.ParamName;
			pUsername.Value = username;
			SqlParameter pPasswd = DataAccessBenutzer.ParamPasswort;
			pPasswd.Value = passwd;
			DataParameters loginParams = new DataParameters();
			loginParams.Add(pUsername);
			loginParams.Add(pPasswd);

			// DataSet mit Ergebnissen abholen
			DataAccessBenutzer daUser = new DataAccessBenutzer();
			DSBenutzer dsUser = daUser.Select(loginParams);

			// genau 1 Datensatz?
			if (dsUser.benutzer.Count == 1)
			{
				m_isLoggedIn = true;
				m_username = username;
				m_userID = dsUser.benutzer[0].UserID;
				m_isAdmin = (DBConstants.Admin == dsUser.benutzer[0].GruppenID);
			}
			else
			{
				Logout();
			}

			return m_isLoggedIn;
		}

		/// <summary>
		/// setzt den Status des Benutzers auf "nicht eingeloggt"
		/// </summary>
		public void Logout()
		{
			m_isLoggedIn = false;
			m_username = "";
			m_userID = -1;
			m_isAdmin = false;
		}
	}
}
