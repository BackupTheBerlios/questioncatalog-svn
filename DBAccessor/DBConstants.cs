using System;

namespace DBAccessor
{
	/// <summary>
	/// Zusammenfassung für DBConstants.
	/// </summary>
	public class DBConstants
	{
		public DBConstants()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}

		#region Konstanten für Benutzer

		public static int Admin
		{
			get { return 1; }
		}

		public static int User
		{
			get { return 0; }
		}
		
		#endregion

		#region Kostanten für Umfragen

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
