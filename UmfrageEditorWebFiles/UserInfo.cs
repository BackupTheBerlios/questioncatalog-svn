using System;

namespace UmfrageEditor
{
	/// <summary>
	/// Fasst Informationen über den aktuellen User zusammen
	/// </summary>
	public class UserInfo
	{
		public UserInfo()
		{
			IsLoggedIn = false;
			m_username = "";
		}

		public bool IsLoggedIn
		{
			get { return m_isLoggedIn; }
			set { m_isLoggedIn = value; }
		}
		protected bool m_isLoggedIn;

		public string Username
		{
			get { return m_username; }
			set { m_username = value; }
		}
		protected string m_username;
	}
}
