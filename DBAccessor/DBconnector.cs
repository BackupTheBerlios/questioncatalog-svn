using System;
using System.Data.SqlClient;

// für Einstellungen aus Web.Config
using System.Configuration;

namespace DBAccessor
{
	/// <summary>
	/// Zusammenfassung für DBconnector.
	/// 
	/// TODO: Sicherheitsabfragen von Eingabestrings
	/// </summary>
	public class DBconnector
	{
		protected SqlConnection m_conn;
		protected SqlCommand m_sqlCmd;

		public DBconnector()
		{
			// Verbindung zur Datenbank herstellen
			m_conn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
			

			m_sqlCmd = new SqlCommand();
			m_sqlCmd.Connection = m_conn;

			m_conn.Open();

		}

		public SqlDataReader getData (string command)
		{
			m_sqlCmd.CommandText = command;
			return m_sqlCmd.ExecuteReader();
		}

		public bool setData(string command)
		{
			m_sqlCmd.CommandText = command;
			m_sqlCmd.ExecuteReader();
			return true;
		}
	}
}
