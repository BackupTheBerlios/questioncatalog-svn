using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace DBAccessor
{
	/// <summary>
	/// Datenzugriffsklasse für die Tabelle awmoeglichkeiten.
	/// </summary>
	public class DataAccessAwmoeglichkeiten : System.ComponentModel.Component
	{
		private SqlConnection m_sqlConn;
		private SqlDataAdapter m_adpAwmoegl;
		private SqlCommand m_cmInsert;
		private SqlCommand m_cmDelete;
		private SqlCommand m_cmUpdate;
		private SqlCommand m_cmSelect;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataAccessAwmoeglichkeiten(System.ComponentModel.IContainer container)
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
		public DataAccessAwmoeglichkeiten()
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
		/// Stellt ein DataSet aus der Tabelle awmoeglichkeiten zusammen, das den mit selectParams festgelegten
		/// Suchkriterien entspricht
		/// </summary>
		/// <param name="selectParams">Suchkriterien</param>
		/// <returns>ein DataSet vom Typ DSAwmoeglichkeiten das die gesuchten Datensätze enthält</returns>
		public DSAwmoeglichkeiten Select(DataParameters selectParams)
		{
			m_adpAwmoegl.SelectCommand.CommandText = SQLCommandBuilder.MakeSelectString(selectParams, "awmoeglichkeiten");

			if (selectParams != null)
			{
				for(int i = 0; i < selectParams.Count; i++)
				{
					m_adpAwmoegl.SelectCommand.Parameters.Add(selectParams[i]);
				}
			}

			DSAwmoeglichkeiten dsResult = new DSAwmoeglichkeiten();				
			m_adpAwmoegl.Fill(dsResult, dsResult.awmoeglichkeiten.TableName);
			return dsResult;
		}

		/// <summary>
		/// Stellt ein DataSet zusammen, das alle Datensätze der Tabelle awmoeglichkeiten enthält
		/// </summary>
		/// <returns>ein DataSet vom Typ DSAwmoeglichkeiten, das alle Datensätze der Tabelle awmoeglichkeiten enthält</returns>
		public DSAwmoeglichkeiten Select()
		{
			return Select(null);
		}

		/// <summary>
		/// Trägt die Änderungen, die an dem DataSet vorgenommen wurden, in die Datenbank ein
		/// </summary>
		/// <param name="dsUpdate">ein (verändertes) DataSet vom Typ DSAwmoeglichkeiten</param>
		public void CommitChanges(DSAwmoeglichkeiten dsUpdate)
		{
			m_adpAwmoegl.Update(dsUpdate, dsUpdate.awmoeglichkeiten.TableName);
		}

		#region Klassenmethoden zur Vorinitialisierung zu verwendender SQLParameter
		/// <summary>
		/// gibt einen für die Spalte "AwmID" der Tabelle awmoeglichkeiten initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamAwmID
		{
			get {return new SqlParameter("@AwmID", SqlDbType.Int, 4, "AwmID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "r_FrageID" der Tabelle awmoeglichkeiten initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter Paramr_FrageID
		{
			get {return new SqlParameter("@r_FrageID", SqlDbType.Int, 4, "r_FrageID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "Text" der Tabelle awmoeglichkeiten initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamText
		{
			get {return new SqlParameter("@Text", SqlDbType.VarChar, 150, "Text");}
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
			this.m_adpAwmoegl = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// m_cmSelect
			// 
			this.m_cmSelect.CommandText = "SELECT AwmID, r_FrageID, Text FROM awmoeglichkeiten";
			this.m_cmSelect.Connection = this.m_sqlConn;
			// 
			// m_cmInsert
			// 
			this.m_cmInsert.CommandText = "INSERT INTO awmoeglichkeiten(r_FrageID, Text) VALUES (@r_FrageID, @Text); SELECT " +
				"AwmID, r_FrageID, Text FROM awmoeglichkeiten WHERE (AwmID = @@IDENTITY)";
			this.m_cmInsert.Connection = this.m_sqlConn;
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_FrageID", System.Data.SqlDbType.Int, 4, "r_FrageID"));
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 150, "Text"));
			// 
			// m_cmUpdate
			// 
			this.m_cmUpdate.CommandText = @"UPDATE awmoeglichkeiten SET r_FrageID = @r_FrageID, Text = @Text WHERE (AwmID = @Original_AwmID) AND (Text = @Original_Text OR @Original_Text IS NULL AND Text IS NULL) AND (r_FrageID = @Original_r_FrageID); SELECT AwmID, r_FrageID, Text FROM awmoeglichkeiten WHERE (AwmID = @AwmID)";
			this.m_cmUpdate.Connection = this.m_sqlConn;
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_FrageID", System.Data.SqlDbType.Int, 4, "r_FrageID"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 150, "Text"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AwmID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AwmID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_FrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_FrageID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AwmID", System.Data.SqlDbType.Int, 4, "AwmID"));
			// 
			// m_cmDelete
			// 
			this.m_cmDelete.CommandText = "DELETE FROM awmoeglichkeiten WHERE (AwmID = @Original_AwmID) AND (Text = @Origina" +
				"l_Text OR @Original_Text IS NULL AND Text IS NULL) AND (r_FrageID = @Original_r_" +
				"FrageID)";
			this.m_cmDelete.Connection = this.m_sqlConn;
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AwmID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AwmID", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Text", System.Data.SqlDbType.VarChar, 150, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Text", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_FrageID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_FrageID", System.Data.DataRowVersion.Original, null));
			// 
			// m_sqlConn
			// 
			this.m_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// m_adpAwmoegl
			// 
			this.m_adpAwmoegl.DeleteCommand = this.m_cmDelete;
			this.m_adpAwmoegl.InsertCommand = this.m_cmInsert;
			this.m_adpAwmoegl.SelectCommand = this.m_cmSelect;
			this.m_adpAwmoegl.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "awmoeglichkeiten", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("AwmID", "AwmID"),
																																																					   new System.Data.Common.DataColumnMapping("r_FrageID", "r_FrageID"),
																																																					   new System.Data.Common.DataColumnMapping("Text", "Text")})});
			this.m_adpAwmoegl.UpdateCommand = this.m_cmUpdate;

		}
		#endregion
	}
}
