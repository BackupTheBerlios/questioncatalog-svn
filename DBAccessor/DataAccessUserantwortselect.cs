using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace DBAccessor
{
	/// <summary>
	/// Datenzugriffsklasse für die Tabelle userantwortselect
	/// </summary>
	public class DataAccessUserantwortselect : System.ComponentModel.Component
	{
		private SqlCommand m_cmSelect;
		private SqlConnection m_sqlConn;
		private SqlCommand m_cmInsert;
		private SqlCommand m_cmUpdate;
		private SqlCommand m_cmDelete;
		private SqlDataAdapter m_adpUserantwortselect;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DataAccessUserantwortselect(System.ComponentModel.IContainer container)
		{
			///
			/// Erforderlich für Windows.Forms Klassenkompositions-Designerunterstützung
			///
			container.Add(this);
			InitializeComponent();
		}

		public DataAccessUserantwortselect()
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
		/// Stellt ein DataSet aus der Tabelle userantwortselect zusammen, das den mit selectParams festgelegten
		/// Suchkriterien entspricht
		/// </summary>
		/// <param name="selectParams">Suchkriterien</param>
		/// <returns>ein DataSet vom Typ DSBenutzer das die gesuchten Datensätze enthält</returns>
		public DSUserantwortselect Select(DataParameters selectParams)
		{
			m_adpUserantwortselect.SelectCommand.CommandText = SQLCommandBuilder.MakeSelectString(selectParams, "userantwortselect");

			if (selectParams != null)
			{
				for(int i = 0; i < selectParams.Count; i++)
				{
					m_adpUserantwortselect.SelectCommand.Parameters.Add(selectParams[i]);
				}
			}

			DSUserantwortselect dsResult = new DSUserantwortselect();				
			m_adpUserantwortselect.Fill(dsResult, dsResult.userantwortselect.TableName);
			m_cmSelect.Parameters.Clear();
			return dsResult;
		}

		/// <summary>
		/// Stellt ein DataSet zusammen, das alle Datensätze der Tabelle userantwortselect enthält
		/// </summary>
		/// <returns>ein DataSet vom Typ DSUserantwortselect, das alle Datensätze der Tabelle userantwortselect enthält</returns>
		public DSUserantwortselect Select()
		{
			return Select(null);
		}

		/// <summary>
		/// Trägt die Änderungen, die an dem DataSet vorgenommen wurden, in die Datenbank ein
		/// </summary>
		/// <param name="dsUpdate">ein (verändertes) DataSet vom Typ DSUserantwortselect</param>
		public void CommitChanges(DSUserantwortselect dsUpdate)
		{
			m_adpUserantwortselect.Update(dsUpdate, dsUpdate.userantwortselect.TableName);
		}

		public DSUserantwortselect GetAntwortByID(int id)
		{
			SqlParameter pID = ParamUawsID;
			pID.Value = id;
			DataParameters parameter = new DataParameters();
			parameter.Add(pID);
			return Select(parameter);
		}

		public void DeleteAntwort(int id)
		{
			DSUserantwortselect dsDelete = GetAntwortByID(id);
			if (dsDelete.userantwortselect.Count == 1)
			{
				dsDelete.userantwortselect[0].Delete();
				CommitChanges(dsDelete);
			}
		}

		#region Klassenmethoden zur Vorinitialisierung zu verwendender SQLParameter
		/// <summary>
		/// gibt einen für die Spalte "UawsID" der Tabelle userantwortselect initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter ParamUawsID
		{
			get {return new SqlParameter("@UawsID", SqlDbType.Int, 4, "UawsID");}
		}

		/// <summary>
		/// gibt einen für die Spalte "r_AntwortID" der Tabelle userantwortselect initialisierten SQLParameter zurück
		/// </summary>
		public static SqlParameter Paramr_AntwortID
		{
			get {return new SqlParameter("@r_AntwortID", SqlDbType.Int, 4, "r_AntwortID");}
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
			this.m_adpUserantwortselect = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// m_cmSelect
			// 
			this.m_cmSelect.CommandText = "SELECT UawsID, r_AntwortID FROM userantwortselect";
			this.m_cmSelect.Connection = this.m_sqlConn;
			// 
			// m_sqlConn
			// 
			this.m_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// m_cmInsert
			// 
			this.m_cmInsert.CommandText = "INSERT INTO userantwortselect(r_AntwortID) VALUES (@r_AntwortID); SELECT UawsID, " +
				"r_AntwortID FROM userantwortselect WHERE (UawsID = @@IDENTITY)";
			this.m_cmInsert.Connection = this.m_sqlConn;
			this.m_cmInsert.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_AntwortID", System.Data.SqlDbType.Int, 4, "r_AntwortID"));
			// 
			// m_cmUpdate
			// 
			this.m_cmUpdate.CommandText = "UPDATE userantwortselect SET r_AntwortID = @r_AntwortID WHERE (UawsID = @Original" +
				"_UawsID) AND (r_AntwortID = @Original_r_AntwortID); SELECT UawsID, r_AntwortID F" +
				"ROM userantwortselect WHERE (UawsID = @UawsID)";
			this.m_cmUpdate.Connection = this.m_sqlConn;
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@r_AntwortID", System.Data.SqlDbType.Int, 4, "r_AntwortID"));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UawsID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UawsID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_AntwortID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_AntwortID", System.Data.DataRowVersion.Original, null));
			this.m_cmUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UawsID", System.Data.SqlDbType.Int, 4, "UawsID"));
			// 
			// m_cmDelete
			// 
			this.m_cmDelete.CommandText = "DELETE FROM userantwortselect WHERE (UawsID = @Original_UawsID) AND (r_AntwortID " +
				"= @Original_r_AntwortID)";
			this.m_cmDelete.Connection = this.m_sqlConn;
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UawsID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UawsID", System.Data.DataRowVersion.Original, null));
			this.m_cmDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_r_AntwortID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "r_AntwortID", System.Data.DataRowVersion.Original, null));
			// 
			// m_adpUserantwortselect
			// 
			this.m_adpUserantwortselect.DeleteCommand = this.m_cmDelete;
			this.m_adpUserantwortselect.InsertCommand = this.m_cmInsert;
			this.m_adpUserantwortselect.SelectCommand = this.m_cmSelect;
			this.m_adpUserantwortselect.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											 new System.Data.Common.DataTableMapping("Table", "userantwortselect", new System.Data.Common.DataColumnMapping[] {
																																																								  new System.Data.Common.DataColumnMapping("UawsID", "UawsID"),
																																																								  new System.Data.Common.DataColumnMapping("r_AntwortID", "r_AntwortID")})});
			this.m_adpUserantwortselect.UpdateCommand = this.m_cmUpdate;

		}
		#endregion
	}
}
