using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace DBAccessor
{
	/// <summary>
	/// Zusammenfassung für DataAccessUmfragen.
	/// </summary>
	public class DataAccessUmfragen : System.ComponentModel.Component
	{
		private SqlCommand m_cmSelect;
		private SqlCommand m_cmInsert;
		private SqlCommand m_cmUpdate;
		private SqlCommand m_cmDelete;
		private SqlConnection m_sqlConn;
		private SqlDataAdapter m_adpUmfragen;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataAccessUmfragen(System.ComponentModel.IContainer container)
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
		public DataAccessUmfragen()
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
		/// Stellt ein DataSet aus der Tabelle umfragen zusammen, das den mit selectParams festgelegten
		/// Suchkriterien entspricht
		/// </summary>
		/// <param name="selectParams">Suchkriterien</param>
		/// <returns>ein DataSet vom Typ DSUmfragen das die gesuchten Datensätze enthält</returns>
		public DSUmfragen Select(DataParameters selectParams)
		{
			m_adpUmfragen.SelectCommand.CommandText = SQLCommandBuilder.MakeSelectString(selectParams, "umfragen");

			if (selectParams != null)
			{
				for(int i = 0; i < selectParams.Count; i++)
				{
					m_adpUmfragen.SelectCommand.Parameters.Add(selectParams[i]);
				}
			}

			DSUmfragen dsResult = new DSUmfragen();				
			m_adpUmfragen.Fill(dsResult, dsResult.umfragen.TableName);
			return dsResult;
		}

		/// <summary>
		/// Stellt ein DataSet zusammen, das alle Datensätze der Tabelle umfragen enthält
		/// </summary>
		/// <returns>ein DataSet vom Typ DSUmfragen, das alle Datensätze der Tabelle umfragen enthält</returns>
		public DSUmfragen Select()
		{
			return Select(null);
		}

		/// <summary>
		/// Trägt die Änderungen, die an dem DataSet vorgenommen wurden, in die Datenbank ein
		/// </summary>
		/// <param name="dsUpdate">ein (verändertes) DataSet vom Typ DSUmfragen</param>
		public void CommitChanges(DSUmfragen dsUpdate)
		{
			m_adpUmfragen.Update(dsUpdate, dsUpdate.umfragen.TableName);
		}

		#region Klassenmethoden zur Vorinitialisierung zu verwendender SQLParameter
		/// <summary>
		/// gibt einen für die Spalte "UmfrageID" der Tabelle umfragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamUmfrageID
		{
			get {return new SqlParameter("@UmfrageID", SqlDbType.Int, 4, "UmfrageID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Titel" der Tabelle umfragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamTitel
		{
			get {return new SqlParameter("@Titel", SqlDbType.VarChar, 100, "Titel");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Beschreibung" der Tabelle umfragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamBeschreibung
		{
			get {return new SqlParameter("@Beschreibung", SqlDbType.VarChar, 1000, "Beschreibung");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Datum_Beginn" der Tabelle umfragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamDatum_Beginn
		{
			get {return new SqlParameter("@Datum_Beginn", SqlDbType.DateTime, 8, "Datum_Beginn");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Datum_Ende" der Tabelle umfragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamDatum_Ende
		{
			get {return new SqlParameter("@Datum_Ende", SqlDbType.DateTime, 8, "Datum_Ende");}
		}

		/// <summary>
		/// gibt einen für die Spalte "r_userID" der Tabelle umfragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter Paramr_userID
		{
			get {return new SqlParameter("@r_userID", SqlDbType.Int, 4, "r_userID");}
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
			this.m_cmInsert = new System.Data.SqlClient.SqlCommand();
			this.m_cmUpdate = new System.Data.SqlClient.SqlCommand();
			this.m_cmDelete = new System.Data.SqlClient.SqlCommand();
			this.m_sqlConn = new System.Data.SqlClient.SqlConnection();
			this.m_adpUmfragen = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// m_cmSelect
			// 
			this.m_cmSelect.CommandText = "SELECT UmfrageID, Titel, Beschreibung, Datum_Beginn, Datum_Ende, r_userID FROM um" +
				"fragen";
			this.m_cmSelect.Connection = this.m_sqlConn;
			// 
			// m_cmInsert
			// 
			this.m_cmInsert.CommandText = @"INSERT INTO umfragen(Titel, Beschreibung, Datum_Beginn, Datum_Ende, r_userID) VALUES (@Titel, @Beschreibung, @Datum_Beginn, @Datum_Ende, @r_userID); SELECT UmfrageID, Titel, Beschreibung, Datum_Beginn, Datum_Ende, r_userID FROM umfragen WHERE (UmfrageID = @@IDENTITY)";
			this.m_cmInsert.Connection = this.m_sqlConn;
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Titel", System.Data.SqlDbType.VarChar, 100, "Titel"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Beschreibung", System.Data.SqlDbType.VarChar, 1000, "Beschreibung"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Datum_Beginn", System.Data.SqlDbType.DateTime, 8, "Datum_Beginn"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Datum_Ende", System.Data.SqlDbType.DateTime, 8, "Datum_Ende"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_userID", System.Data.SqlDbType.Int, 4, "r_userID"));
			// 
			// m_cmUpdate
			// 
			this.m_cmUpdate.CommandText = @"UPDATE umfragen SET Titel = @Titel, Beschreibung = @Beschreibung, Datum_Beginn = @Datum_Beginn, Datum_Ende = @Datum_Ende, r_userID = @r_userID WHERE (UmfrageID = @Original_UmfrageID) AND (Beschreibung = @Original_Beschreibung OR @Original_Beschreibung IS NULL AND Beschreibung IS NULL) AND (Datum_Beginn = @Original_Datum_Beginn OR @Original_Datum_Beginn IS NULL AND Datum_Beginn IS NULL) AND (Datum_Ende = @Original_Datum_Ende OR @Original_Datum_Ende IS NULL AND Datum_Ende IS NULL) AND (Titel = @Original_Titel) AND (r_userID = @Original_r_userID); SELECT UmfrageID, Titel, Beschreibung, Datum_Beginn, Datum_Ende, r_userID FROM umfragen WHERE (UmfrageID = @UmfrageID)";
			this.m_cmUpdate.Connection = this.m_sqlConn;
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Titel", System.Data.SqlDbType.VarChar, 100, "Titel"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Beschreibung", System.Data.SqlDbType.VarChar, 1000, "Beschreibung"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Datum_Beginn", System.Data.SqlDbType.DateTime, 8, "Datum_Beginn"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Datum_Ende", System.Data.SqlDbType.DateTime, 8, "Datum_Ende"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_userID", System.Data.SqlDbType.Int, 4, "r_userID"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UmfrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UmfrageID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Beschreibung", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Beschreibung", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Datum_Beginn", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Datum_Beginn", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Datum_Ende", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Datum_Ende", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Titel", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Titel", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_userID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_userID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UmfrageID", System.Data.SqlDbType.Int, 4, "UmfrageID"));
			// 
			// m_cmDelete
			// 
			this.m_cmDelete.CommandText = @"DELETE FROM umfragen WHERE (UmfrageID = @Original_UmfrageID) AND (Beschreibung = @Original_Beschreibung OR @Original_Beschreibung IS NULL AND Beschreibung IS NULL) AND (Datum_Beginn = @Original_Datum_Beginn OR @Original_Datum_Beginn IS NULL AND Datum_Beginn IS NULL) AND (Datum_Ende = @Original_Datum_Ende OR @Original_Datum_Ende IS NULL AND Datum_Ende IS NULL) AND (Titel = @Original_Titel) AND (r_userID = @Original_r_userID)";
			this.m_cmDelete.Connection = this.m_sqlConn;
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UmfrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UmfrageID", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Beschreibung", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Beschreibung", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Datum_Beginn", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Datum_Beginn", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Datum_Ende", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Datum_Ende", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Titel", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Titel", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_userID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_userID", System.Data.DataRowVersion.Original, null));
			// 
			// m_sqlConn
			// 
			this.m_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// m_adpUmfragen
			// 
			this.m_adpUmfragen.DeleteCommand = this.m_cmDelete;
			this.m_adpUmfragen.InsertCommand = this.m_cmInsert;
			this.m_adpUmfragen.SelectCommand = this.m_cmSelect;
			this.m_adpUmfragen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "umfragen", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("UmfrageID", "UmfrageID"),
																																																				new System.Data.Common.DataColumnMapping("Titel", "Titel"),
																																																				new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
																																																				new System.Data.Common.DataColumnMapping("Datum_Beginn", "Datum_Beginn"),
																																																				new System.Data.Common.DataColumnMapping("Datum_Ende", "Datum_Ende"),
																																																				new System.Data.Common.DataColumnMapping("r_userID", "r_userID")})});
			this.m_adpUmfragen.UpdateCommand = this.m_cmUpdate;

		}
		#endregion
	}
}
