using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace DBAccessor
{
	/// <summary>
	/// Datenzugriffsklasse für die Tabelle userantworttext
	/// </summary>
	public class DataAccessUserantworttext : System.ComponentModel.Component
	{
		private SqlCommand m_cmSelect;
		private SqlCommand m_cmInsert;
		private SqlCommand m_cmUpdate;
		private SqlCommand m_cmDelete;
		private SqlConnection m_sqlConn;
		private SqlDataAdapter m_adpUserantworttext;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataAccessUserantworttext(System.ComponentModel.IContainer container)
		{
			///
			/// Erforderlich für Windows.Forms Klassenkompositions-Designerunterstützung
			///
			container.Add(this);
			InitializeComponent();
		}

		public DataAccessUserantworttext()
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
		/// Stellt ein DataSet aus der Tabelle userantworttext zusammen, das den mit selectParams festgelegten
		/// Suchkriterien entspricht
		/// </summary>
		/// <param name="selectParams">Suchkriterien</param>
		/// <returns>ein DataSet vom Typ DSUserantworttext das die gesuchten Datensätze enthält</returns>
		public DSUserantworttext Select(DataParameters selectParams)
		{
			m_adpUserantworttext.SelectCommand.CommandText = SQLCommandBuilder.MakeSelectString(selectParams, "userantworttext");

			if (selectParams != null)
			{
				for(int i = 0; i < selectParams.Count; i++)
				{
					m_adpUserantworttext.SelectCommand.Parameters.Add(selectParams[i]);
				}
			}

			DSUserantworttext dsResult = new DSUserantworttext();				
			m_adpUserantworttext.Fill(dsResult, dsResult.userantworttext.TableName);
			m_cmSelect.Parameters.Clear();
			return dsResult;
		}

		/// <summary>
		/// Stellt ein DataSet zusammen, das alle Datensätze der Tabelle userantworttext enthält
		/// </summary>
		/// <returns>ein DataSet vom Typ DSUserantworttext, das alle Datensätze der Tabelle userantworttext enthält</returns>
		public DSUserantworttext Select()
		{
			return Select(null);
		}

		/// <summary>
		/// Trägt die Änderungen, die an dem DataSet vorgenommen wurden, in die Datenbank ein
		/// </summary>
		/// <param name="dsUpdate">ein (verändertes) DataSet vom Typ DSUserantworttext</param>
		public void CommitChanges(DSUserantworttext dsUpdate)
		{
			m_adpUserantworttext.Update(dsUpdate, dsUpdate.userantworttext.TableName);
		}

		public DSUserantworttext getAntwortByID(int id)
		{
			SqlParameter pID = ParamUawtID;
			pID.Value = id;
			DataParameters parameter = new DataParameters();
			parameter.Add(pID);
			return Select(parameter);
		}

		public void DeleteAntwort(int id)
		{
			DSUserantworttext dsDelete = getAntwortByID(id);
			if (dsDelete.userantworttext.Count == 1)
			{
				dsDelete.userantworttext[0].Delete();
				CommitChanges(dsDelete);
			}
		}

		#region Klassenmethoden zur Vorinitialisierung zu verwendender SQLParameter
		/// <summary>
		/// gibt einen für die Spalte "UawtID" der Tabelle userantworttext initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamUawtID
		{
			get {return new SqlParameter("@UawtID", SqlDbType.Int, 4, "UawtID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "r_FrageID" der Tabelle userantworttext initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter Paramr_FrageID
		{
			get {return new SqlParameter("@r_FrageID", SqlDbType.Int, 4, "r_FrageID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Text" der Tabelle userantworttext initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamText
		{
			get {return new SqlParameter("@Text", SqlDbType.VarChar, 1000, "Text");}
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
			this.m_adpUserantworttext = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// m_cmSelect
			// 
			this.m_cmSelect.CommandText = "SELECT UawtID, r_FrageID, Text FROM userantworttext";
			this.m_cmSelect.Connection = this.m_sqlConn;
			// 
			// m_sqlConn
			// 
			this.m_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// m_cmInsert
			// 
			this.m_cmInsert.CommandText = "INSERT INTO userantworttext(r_FrageID, Text) VALUES (@r_FrageID, @Text); SELECT U" +
				"awtID, r_FrageID, Text FROM userantworttext WHERE (UawtID = @@IDENTITY)";
			this.m_cmInsert.Connection = this.m_sqlConn;
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_FrageID", System.Data.SqlDbType.Int, 4, "r_FrageID"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 1000, "Text"));
			// 
			// m_cmUpdate
			// 
			this.m_cmUpdate.CommandText = @"UPDATE userantworttext SET r_FrageID = @r_FrageID, Text = @Text WHERE (UawtID = @Original_UawtID) AND (Text = @Original_Text OR @Original_Text IS NULL AND Text IS NULL) AND (r_FrageID = @Original_r_FrageID); SELECT UawtID, r_FrageID, Text FROM userantworttext WHERE (UawtID = @UawtID)";
			this.m_cmUpdate.Connection = this.m_sqlConn;
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_FrageID", System.Data.SqlDbType.Int, 4, "r_FrageID"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 1000, "Text"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UawtID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UawtID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_FrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_FrageID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UawtID", System.Data.SqlDbType.Int, 4, "UawtID"));
			// 
			// m_cmDelete
			// 
			this.m_cmDelete.CommandText = "DELETE FROM userantworttext WHERE (UawtID = @Original_UawtID) AND (Text = @Origin" +
				"al_Text OR @Original_Text IS NULL AND Text IS NULL) AND (r_FrageID = @Original_r" +
				"_FrageID)";
			this.m_cmDelete.Connection = this.m_sqlConn;
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UawtID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UawtID", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_FrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_FrageID", System.Data.DataRowVersion.Original, null));
			// 
			// m_adpUserantworttext
			// 
			this.m_adpUserantworttext.DeleteCommand = this.m_cmDelete;
			this.m_adpUserantworttext.InsertCommand = this.m_cmInsert;
			this.m_adpUserantworttext.SelectCommand = this.m_cmSelect;
			this.m_adpUserantworttext.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										   new System.Data.Common.DataTableMapping("Table", "userantworttext", new System.Data.Common.DataColumnMapping[] {
																																																							  new System.Data.Common.DataColumnMapping("UawtID", "UawtID"),
																																																							  new System.Data.Common.DataColumnMapping("r_FrageID", "r_FrageID"),
																																																							  new System.Data.Common.DataColumnMapping("Text", "Text")})});
			this.m_adpUserantworttext.UpdateCommand = this.m_cmUpdate;

		}
		#endregion
	}
}
