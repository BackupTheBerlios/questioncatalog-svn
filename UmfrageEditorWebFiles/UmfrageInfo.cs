using System;
using System.Data.SqlClient;
using DBAccessor;

namespace UmfrageEditor
{
	/// <summary>
	/// Fasst Informationen �ber die aktuelle Umfrage zusammen
	/// </summary>
	public class UmfrageInfo
	{
		public UmfrageInfo()
		{
			Clear();
		}

		public UmfrageInfo(int umfrageID)
		{
			Load(umfrageID);
		}

		/// <summary>
		/// die ID der zur Zeit zu bearbeitenden Umfrage
		/// </summary>
		public int UmfrageID
		{
			get { return m_umfrageID; }
		}
		protected int m_umfrageID;


		/// <summary>
		/// speichert die ID der aktuellen Umfrage
		/// </summary>
		public void Load(int umfrageID)
		{
			Clear();
			m_umfrageID = umfrageID;
		}

		public void Clear()
		{
			m_umfrageID = -1;
		}

		/// <summary>
		/// L�scht die zur Zeit geladene Umfrage aus der Datenbank
		/// Es werden alle zugeh�rigen Datens�tze (Fragen, Antworten...) rekursiv mit gel�scht.
		/// </summary>
		/// <param name="owner">der Benutzer, der die Umfrage l�schen will</param>
		public void DeleteFromDB(UserInfo owner)
		{
			if (m_umfrageID <= 0)
			{
				return;
			}

			if (!owner.IsLoggedIn)
			{
				return;
			}

			DataAccessUmfragen daUmfr = new DataAccessUmfragen();
			DSUmfragen dsUmfr = getUmfrageByID(m_umfrageID);
			if (dsUmfr.umfragen.Rows.Count != 1)
			{
				// wenn nicht genau 1 Datensatz zur�ckkommt, stimmt was nicht
				// TODO: Exception werfen
			}
			else if (!dsUmfr.umfragen.Rows[0]["r_userID"].Equals(owner.UserID) && !owner.IsAdmin)
			{
				// die Umfrage geh�rt nicht dem eingeloggten Benutzer und dieser ist kein Admin
				// TODO: Exception
			}
			else
			{
				dsUmfr.umfragen[0].Delete();
				daUmfr.CommitChanges(dsUmfr);
			}
		}

		/// <summary>
		/// L�scht die Umfrage mit der ID umfrageID aus der Datenbank
		/// Es werden alle zugeh�rigen Datens�tze (Fragen, Antworten...) rekursiv mit gel�scht.
		/// </summary>
		/// <param name="umfrageID">ID der zu l�schenden Umfrage</param>
		/// <param name="owner">der Benutzer, der die Umfrage l�schen will</param>
		public void DeleteFromDB(int umfrageID, UserInfo owner)
		{
			Load(umfrageID);
			DeleteFromDB(owner);
		}

		/// <summary>
		/// gibt ein DataSet zur�ck, das den Datensatz mit der Umfrage mit der ID umfrageID enth�lt
		/// </summary>
		/// <param name="umfrageID">ID der gesuchten Umfrage</param>
		/// <returns>DataSet vom Typ DSUmfragen mit dem gesuchten Datensatz</returns>
		public DSUmfragen getUmfrageByID(int umfrageID)
		{
			SqlParameter pUmfrageID = DataAccessUmfragen.ParamUmfrageID;
			pUmfrageID.Value = umfrageID;
			DataParameters umfrageparams = new DataParameters();
			umfrageparams.Add(pUmfrageID);
			DataAccessUmfragen daUmfr = new DataAccessUmfragen();
			DSUmfragen dsUmfr = daUmfr.Select(umfrageparams);
			return dsUmfr;
		}
	}
}
