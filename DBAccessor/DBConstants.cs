using System;

namespace DBAccessor
{
	/// <summary>
	/// Sammlung Von Datenbankkonstanten
	/// </summary>
	public class DBConstants
	{
		/// <summary>
		/// repr�sentiert einen ung�ltigen Wert (zB. f�r IDs)
		/// </summary>
		public const int NotValid = -1;

		#region Konstanten f�r Benutzer

		public const int Admin = 1;

		public const int User = 0;
		
		#endregion

		#region Konstanten f�r Umfragen

		public const int Online = 1;

		public const int NotOnline = 0;

		#endregion

		#region Konstanten f�r Fragen

		public const int TextFrage = 0;

		public const int UndFrage = 1;

		public const int OderFrage = 2;

		#endregion

		#region Debug Infos ein-/ausschalten

		/// <summary>
		/// Debugoptionen ein=true / aus=false schalten
		/// </summary> 
		public static bool Debugmodus = true;
			
		#endregion

	}
}
