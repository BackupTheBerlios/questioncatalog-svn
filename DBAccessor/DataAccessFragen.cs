using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace DBAccessor
{
	/// <summary>
	/// Zusammenfassung für DataAccessFragen.
	/// </summary>
	public class DataAccessFragen : System.ComponentModel.Component
	{
		private SqlCommand m_cmSelect;
		private SqlCommand m_cmInsert;
		private SqlCommand m_cmUpdate;
		private SqlCommand m_cmDelete;
		private SqlConnection m_sqlConn;
		private SqlDataAdapter m_adpFragen;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataAccessFragen(System.ComponentModel.IContainer container)
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
		public DataAccessFragen()
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
		/// Stellt ein DataSet aus der Tabelle fragen zusammen, das den mit selectParams festgelegten
		/// Suchkriterien entspricht
		/// </summary>
		/// <param name="selectParams">Suchkriterien</param>
		/// <returns>ein DataSet vom Typ DSFragen das die gesuchten Datensätze enthält</returns>
		public DSFragen Select(DataParameters selectParams)
		{
			m_adpFragen.SelectCommand.CommandText = SQLCommandBuilder.MakeSelectString(selectParams, "fragen");

			if (selectParams != null)
			{
				for(int i = 0; i < selectParams.Count; i++)
				{
					m_adpFragen.SelectCommand.Parameters.Add(selectParams[i]);
				}
			}

			DSFragen dsResult = new DSFragen();				
			m_adpFragen.Fill(dsResult, dsResult.fragen.TableName);
			m_cmSelect.Parameters.Clear();
			return dsResult;
		}

		/// <summary>
		/// Stellt ein DataSet zusammen, das alle Datensätze der Tabelle fragen enthält
		/// </summary>
		/// <returns>ein DataSet vom Typ DSFragen, das alle Datensätze der Tabelle fragen enthält</returns>
		public DSFragen Select()
		{
			return Select(null);
		}

		/// <summary>
		/// Trägt die Änderungen, die an dem DataSet vorgenommen wurden, in die Datenbank ein
		/// </summary>
		/// <param name="dsUpdate">ein (verändertes) DataSet vom Typ DSFragen</param>
		public void CommitChanges(DSFragen dsUpdate)
		{
			m_adpFragen.Update(dsUpdate, dsUpdate.fragen.TableName);
		}

		public DSFragen getFrageByID(int id)
		{
			SqlParameter pID = ParamFrageID;
			pID.Value = id;
			DataParameters parameter = new DataParameters();
			parameter.Add(pID);
			return Select(parameter);
		}

		public void DeleteFrage(int id)
		{
			DSFragen dsDelete = getFrageByID(id);
			if (dsDelete.fragen.Count == 1)
			{
				dsDelete.fragen[0].Delete();
				CommitChanges(dsDelete);
			}
		}

		#region Klassenmethoden zur Vorinitialisierung zu verwendender SQLParameter
		/// <summary>
		/// gibt einen für die Spalte "FrageID" der Tabelle fragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamFrageID
		{
			get {return new SqlParameter("@FrageID", SqlDbType.Int, 4, "FrageID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "r_UmfrageID" der Tabelle fragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter Paramr_UmfrageID
		{
			get {return new SqlParameter("@r_UmfrageID", SqlDbType.Int, 4, "r_UmfrageID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Text" der Tabelle fragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamText
		{
			get {return new SqlParameter("@Text", SqlDbType.VarChar, 500, "Text");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Frageart" der Tabelle fragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamFrageart
		{
			get {return new SqlParameter("@Frageart", SqlDbType.Int, 4, "Frageart");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Reihenfolge" der Tabelle fragen initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamReihenfolge
		{
			get {return new SqlParameter("@Reihenfolge", SqlDbType.Int, 4, "Reihenfolge");}
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
			this.m_adpFragen = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// m_cmSelect
			// 
			this.m_cmSelect.CommandText = "SELECT FrageID, r_UmfrageID, Text, Frageart, Reihenfolge FROM fragen";
			this.m_cmSelect.Connection = this.m_sqlConn;
			// 
			// m_cmInsert
			// 
			this.m_cmInsert.CommandText = "INSERT INTO fragen(r_UmfrageID, Text, Frageart, Reihenfolge) VALUES (@r_UmfrageID" +
				", @Text, @Frageart, @Reihenfolge); SELECT FrageID, r_UmfrageID, Text, Frageart, " +
				"Reihenfolge FROM fragen WHERE (FrageID = @@IDENTITY)";
			this.m_cmInsert.Connection = this.m_sqlConn;
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_UmfrageID", System.Data.SqlDbType.Int, 4, "r_UmfrageID"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 500, "Text"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Frageart", System.Data.SqlDbType.Int, 4, "Frageart"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reihenfolge", System.Data.SqlDbType.Int, 4, "Reihenfolge"));
			// 
			// m_cmUpdate
			// 
			this.m_cmUpdate.CommandText = @"UPDATE fragen SET r_UmfrageID = @r_UmfrageID, Text = @Text, Frageart = @Frageart, Reihenfolge = @Reihenfolge WHERE (FrageID = @Original_FrageID) AND (Frageart = @Original_Frageart) AND (Reihenfolge = @Original_Reihenfolge OR @Original_Reihenfolge IS NULL AND Reihenfolge IS NULL) AND (Text = @Original_Text) AND (r_UmfrageID = @Original_r_UmfrageID); SELECT FrageID, r_UmfrageID, Text, Frageart, Reihenfolge FROM fragen WHERE (FrageID = @FrageID)";
			this.m_cmUpdate.Connection = this.m_sqlConn;
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_UmfrageID", System.Data.SqlDbType.Int, 4, "r_UmfrageID"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 500, "Text"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Frageart", System.Data.SqlDbType.Int, 4, "Frageart"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reihenfolge", System.Data.SqlDbType.Int, 4, "Reihenfolge"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FrageID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Frageart", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Frageart", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reihenfolge", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 500, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_UmfrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_UmfrageID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FrageID", System.Data.SqlDbType.Int, 4, "FrageID"));
			// 
			// m_cmDelete
			// 
			this.m_cmDelete.CommandText = @"DELETE FROM fragen WHERE (FrageID = @Original_FrageID) AND (Frageart = @Original_Frageart) AND (Reihenfolge = @Original_Reihenfolge OR @Original_Reihenfolge IS NULL AND Reihenfolge IS NULL) AND (Text = @Original_Text) AND (r_UmfrageID = @Original_r_UmfrageID)";
			this.m_cmDelete.Connection = this.m_sqlConn;
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_FrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "FrageID", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Frageart", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Frageart", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reihenfolge", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 500, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_UmfrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_UmfrageID", System.Data.DataRowVersion.Original, null));
			// 
			// m_sqlConn
			// 
			this.m_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// m_adpFragen
			// 
			this.m_adpFragen.DeleteCommand = this.m_cmDelete;
			this.m_adpFragen.InsertCommand = this.m_cmInsert;
			this.m_adpFragen.SelectCommand = this.m_cmSelect;
			this.m_adpFragen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "fragen", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("FrageID", "FrageID"),
																																																			new System.Data.Common.DataColumnMapping("r_UmfrageID", "r_UmfrageID"),
																																																			new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																			new System.Data.Common.DataColumnMapping("Frageart", "Frageart"),
																																																			new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})});
			this.m_adpFragen.UpdateCommand = this.m_cmUpdate;

		}
		#endregion
	}
}
