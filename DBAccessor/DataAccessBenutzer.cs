using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace DBAccessor
{
	/// <summary>
	/// Datenzugriffsklasse für die Tabelle benutzer
	/// </summary>
	public class DataAccessBenutzer : System.ComponentModel.Component
	{
		private SqlConnection m_sqlConn;
		private SqlDataAdapter m_adpBenutzer;
		private SqlCommand m_cmSelect;
		private SqlCommand m_cmInsert;
		private SqlCommand m_cmUpdate;
		private SqlCommand m_cmDelete;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataAccessBenutzer(System.ComponentModel.IContainer container)
		{
			///
			/// Erforderlich für Windows.Forms Klassenkompositions-Designerunterstützung
			///
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// Standardkonstruktor
		/// </summary>
		public DataAccessBenutzer()
		{
			///
			/// Erforderlich für Windows.Forms Klassenkompositions-Designerunterstützung
			///
			InitializeComponent();
		}

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Stellt ein DataSet aus der Tabelle benutzer zusammen, das den mit selectParams festgelegten
		/// Suchkriterien entspricht
		/// </summary>
		/// <param name="selectParams">Suchkriterien</param>
		/// <returns>ein DataSet vom Typ DSBenutzer das die gesuchten Datensätze enthält</returns>
		public DSBenutzer Select(DataParameters selectParams)
		{
			m_adpBenutzer.SelectCommand.CommandText = SQLCommandBuilder.MakeSelectString(selectParams, "benutzer");

			if (selectParams != null)
			{
				for(int i = 0; i < selectParams.Count; i++)
				{
					m_adpBenutzer.SelectCommand.Parameters.Add(selectParams[i]);
				}
			}

			DSBenutzer dsResult = new DSBenutzer();				
			m_adpBenutzer.Fill(dsResult, dsResult.benutzer.TableName);
			return dsResult;
		}

		/// <summary>
		/// Stellt ein DataSet zusammen, das alle Datensätze der Tabelle benutzer enthält
		/// </summary>
		/// <returns>ein DataSet vom Typ DSBenutzer, das alle Datensätze der Tabelle benutzer enthält</returns>
		public DSBenutzer Select()
		{
			return Select(null);
		}

		/// <summary>
		/// Trägt die Änderungen, die an dem DataSet vorgenommen wurden, in die Datenbank ein
		/// </summary>
		/// <param name="dsUpdate">ein (verändertes) DataSet vom Typ DSBenutzer</param>
		public void CommitChanges(DSBenutzer dsUpdate)
		{
			m_adpBenutzer.Update(dsUpdate, dsUpdate.benutzer.TableName);
		}

		#region Klassenmethoden zur Vorinitialisierung zu verwendender SQLParameter
		/// <summary>
		/// gibt einen für die Spalte "UserID" der Tabelle benutzer initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamUserID
		{
			get {return new SqlParameter("@UserID", SqlDbType.Int, 4, "UserID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Name" der Tabelle benutzer initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamName
		{
			get {return new SqlParameter("@Name", SqlDbType.VarChar, 50, "Name");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Passwort" der Tabelle benutzer initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamPasswort
		{
			get {return new SqlParameter("@Passwort", SqlDbType.VarChar, 50, "Passwort");}
		}

		/// <summary>
		/// gibt einen für die Spalte "GruppenID" der Tabelle benutzer initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamGruppenID
		{
			get {return new SqlParameter("@GruppenID", SqlDbType.Int, 4, "GruppenID");}
		}
		#endregion

		#region Vom Komponenten-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.m_cmSelect = new System.Data.SqlClient.SqlCommand();
			this.m_sqlConn = new System.Data.SqlClient.SqlConnection();
			this.m_cmInsert = new System.Data.SqlClient.SqlCommand();
			this.m_cmUpdate = new System.Data.SqlClient.SqlCommand();
			this.m_cmDelete = new System.Data.SqlClient.SqlCommand();
			this.m_adpBenutzer = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// m_cmSelect
			// 
			this.m_cmSelect.CommandText = "SELECT UserID, Name, Passwort, GruppenID FROM benutzer";
			this.m_cmSelect.Connection = this.m_sqlConn;
			// 
			// m_sqlConn
			// 
			this.m_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// m_cmInsert
			// 
			this.m_cmInsert.CommandText = "INSERT INTO benutzer(Name, Passwort, GruppenID) VALUES (@Name, @Passwort, @Gruppe" +
				"nID); SELECT UserID, Name, Passwort, GruppenID FROM benutzer WHERE (UserID = @@I" +
				"DENTITY)";
			this.m_cmInsert.Connection = this.m_sqlConn;
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Passwort", System.Data.SqlDbType.VarChar, 50, "Passwort"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GruppenID", System.Data.SqlDbType.Int, 4, "GruppenID"));
			// 
			// m_cmUpdate
			// 
			this.m_cmUpdate.CommandText = @"UPDATE benutzer SET Name = @Name, Passwort = @Passwort, GruppenID = @GruppenID WHERE (UserID = @Original_UserID) AND (GruppenID = @Original_GruppenID) AND (Name = @Original_Name) AND (Passwort = @Original_Passwort); SELECT UserID, Name, Passwort, GruppenID FROM benutzer WHERE (UserID = @UserID)";
			this.m_cmUpdate.Connection = this.m_sqlConn;
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Passwort", System.Data.SqlDbType.VarChar, 50, "Passwort"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GruppenID", System.Data.SqlDbType.Int, 4, "GruppenID"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GruppenID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GruppenID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Passwort", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Passwort", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"));
			// 
			// m_cmDelete
			// 
			this.m_cmDelete.CommandText = "DELETE FROM benutzer WHERE (UserID = @Original_UserID) AND (GruppenID = @Original" +
				"_GruppenID) AND (Name = @Original_Name) AND (Passwort = @Original_Passwort)";
			this.m_cmDelete.Connection = this.m_sqlConn;
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GruppenID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GruppenID", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Passwort", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Passwort", System.Data.DataRowVersion.Original, null));
			// 
			// m_adpBenutzer
			// 
			this.m_adpBenutzer.DeleteCommand = this.m_cmDelete;
			this.m_adpBenutzer.InsertCommand = this.m_cmInsert;
			this.m_adpBenutzer.MissingSchemaAction = System.Data.MissingSchemaAction.AddWithKey;
			this.m_adpBenutzer.SelectCommand = this.m_cmSelect;
			this.m_adpBenutzer.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "benutzer", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																				new System.Data.Common.DataColumnMapping("Name", "Name"),
																																																				new System.Data.Common.DataColumnMapping("Passwort", "Passwort"),
																																																				new System.Data.Common.DataColumnMapping("GruppenID", "GruppenID")})});
			this.m_adpBenutzer.UpdateCommand = this.m_cmUpdate;
			this.m_adpBenutzer.RowUpdated += new System.Data.SqlClient.SqlRowUpdatedEventHandler(this.m_adpBenutzer_RowUpdated);

		}
		#endregion

		private void m_adpBenutzer_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
		{
		
		}
	}
}
