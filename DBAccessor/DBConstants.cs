using System;

namespace DBAccessor
{
	/// <summary>
	/// Zusammenfassung f�r DBConstants.
	/// </summary>
	public class DBConstants
	{
		public DBConstants()
		{
			//
			// TODO: F�gen Sie hier die Konstruktorlogik hinzu
			//
		}

		#region Konstanten f�r Benutzer

		public static int Admin
		{
			get { return 1; }
		}

		public static int User
		{
			get { return 0; }
		}
		
		#endregion

		#region Kostanten f�r Umfragen

		public static int Online
		{
			get { return 1; }
		}

		public static int NotOnline
		{
			get { return 0; }
		}

		#endregion

	}
}
