using System;
using System.Configuration;

namespace UmfrageEditor
{
	/// <summary>
	/// Containerklasse zur einheitlichen Aufnahme der Sessiondaten
	/// </summary>
	public class SessionContainer
	{
		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="SessionID"></param>
		public SessionContainer(string SessionID)
		{
			// Membervariablen initialisieren...			
			m_SessionID = SessionID;
			m_user = new UserInfo();
		}

		/// <summary>
		/// Auslesen des aktuellen SessionContainers
		/// </summary>
		/// <param name="page">Seite aus deren Session der SessionContainer gelesen
		/// werden soll</param>
		/// <returns>SessionContainer oder null wenn nicht vorhanden</returns>
		public static SessionContainer ReadFromSession(System.Web.UI.Page page)
		{
			// SessionContainer auslesen und prüfen ob gültig!
			Object obj = page.Session["SessionContainer"];
			if((obj != null) && (obj is SessionContainer))
				return (SessionContainer)obj;
			else
				return null;
		}

		/// <summary>
		/// SessionContainer in die übergebene Session schreiben
		/// </summary>
		/// <param name="session">Session in die die Daten geschrieben werden</param>
		public void WriteToSession(System.Web.SessionState.HttpSessionState session)
		{
			session["SessionContainer"] = this;
		}


		/// <summary>
		/// SessionID des Benutzers auslesen
		/// </summary>
		public string SessionID
		{
			get { return m_SessionID; }
		}
		protected string m_SessionID;


		/// <summary>
		/// Temporäre Daten freigeben
		/// </summary>
		public void KillTemporaryData()
		{
			
		}

		public UserInfo User
		{
			get { return m_user; }
		}
		protected UserInfo m_user;

	}

}
