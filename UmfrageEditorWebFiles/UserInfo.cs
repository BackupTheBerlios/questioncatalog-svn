using System;
using DBAccessor;
using System.Data.SqlClient;

namespace UmfrageEditor
{
	/// <summary>
	/// Fasst Informationen über den aktuellen User zusammen
	/// </summary>
	public class UserInfo
	{
		public UserInfo()
		{
			m_isLoggedIn = false;
			m_username = "";
		}

		public bool IsLoggedIn
		{
			get { return m_isLoggedIn; }
//			set { m_isLoggedIn = value; }
		}
		protected bool m_isLoggedIn;

		public string Username
		{
			get { return m_username; }
//			set { m_username = value; }
		}
		protected string m_username;

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
			if (dsUser.benutzer.Rows.Count == 1)
			{
				m_isLoggedIn = true;
				m_username = username;
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
		}
	}
}
