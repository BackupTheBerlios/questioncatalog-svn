using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DBAccessor
{
	/// <summary>
	/// Zusammenfassung für DataAccessBenutzer.
	/// </summary>
	public class DataAccessBenutzer : System.ComponentModel.Component
	{
		private System.Data.SqlClient.SqlCommand m_sqlSelectCommand;
		private System.Data.SqlClient.SqlCommand m_sqlInsertCommand;
		private System.Data.SqlClient.SqlCommand m_sqlUpdateCommand;
		private System.Data.SqlClient.SqlCommand m_sqlDeleteCommand;
		private System.Data.SqlClient.SqlConnection m_sqlConn;
		private System.Data.SqlClient.SqlDataAdapter m_adpBenutzer;
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

		public DSBenutzer Select(DataParameters selectParams)
		{
			StringBuilder sbSelect = new StringBuilder("SELECT * FROM Benutzer");
			if (selectParams != null)
			{
				string sqlClause = " WHERE ";
				for(int i = 0; i < selectParams.Count; i++)
				{
					sbSelect.Append(sqlClause);
					sqlClause = " AND ";

					sbSelect.AppendFormat("{0}={1}", selectParams[i].SourceColumn, selectParams[i].ParameterName);

					m_adpBenutzer.SelectCommand.Parameters.Add(selectParams[i]);
				}
			}
			m_adpBenutzer.SelectCommand.CommandText = sbSelect.ToString();

			DSBenutzer dsResult = new DSBenutzer();				
			m_adpBenutzer.Fill(dsResult, dsResult.benutzer.TableName);
			return dsResult;
		}

		public DSBenutzer Select()
		{
			return Select(null);
		}

		public void CommitChanges(DSBenutzer dsUpdate)
		{
			m_adpBenutzer.Update(dsUpdate, dsUpdate.benutzer.TableName);
		}

		public static SqlParameter ParamUserID
		{
			get {return new SqlParameter("@UserID", SqlDbType.Int, 4, "UserID");}
		}

		public static SqlParameter ParamName
		{
			get {return new SqlParameter("@Name", SqlDbType.VarChar, 50, "Name");}
		}

		public static SqlParameter ParamPasswort
		{
			get {return new SqlParameter("@Passwort", SqlDbType.VarChar, 50, "Passwort");}
		}

		public static SqlParameter ParamGruppenID
		{
			get {return new SqlParameter("@GruppenID", SqlDbType.Int, 4, "GruppenID");}
		}

		#region Vom Komponenten-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.m_sqlSelectCommand = new System.Data.SqlClient.SqlCommand();
			this.m_sqlConn = new System.Data.SqlClient.SqlConnection();
			this.m_sqlInsertCommand = new System.Data.SqlClient.SqlCommand();
			this.m_sqlUpdateCommand = new System.Data.SqlClient.SqlCommand();
			this.m_sqlDeleteCommand = new System.Data.SqlClient.SqlCommand();
			this.m_adpBenutzer = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// m_sqlSelectCommand
			// 
			this.m_sqlSelectCommand.CommandText = "SELECT UserID, Name, Passwort, GruppenID FROM benutzer";
			this.m_sqlSelectCommand.Connection = this.m_sqlConn;
			// 
			// m_sqlConn
			// 
			this.m_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("ConnectionString", typeof(string))));
			// 
			// m_sqlInsertCommand
			// 
			this.m_sqlInsertCommand.CommandText = "INSERT INTO benutzer(Name, Passwort, GruppenID) VALUES (@Name, @Passwort, @Gruppe" +
				"nID); SELECT UserID, Name, Passwort, GruppenID FROM benutzer WHERE (UserID = @@I" +
				"DENTITY)";
			this.m_sqlInsertCommand.Connection = this.m_sqlConn;
			this.m_sqlInsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"));
			this.m_sqlInsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Passwort", System.Data.SqlDbType.VarChar, 50, "Passwort"));
			this.m_sqlInsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GruppenID", System.Data.SqlDbType.Int, 4, "GruppenID"));
			// 
			// m_sqlUpdateCommand
			// 
			this.m_sqlUpdateCommand.CommandText = @"UPDATE benutzer SET Name = @Name, Passwort = @Passwort, GruppenID = @GruppenID WHERE (UserID = @Original_UserID) AND (GruppenID = @Original_GruppenID) AND (Name = @Original_Name) AND (Passwort = @Original_Passwort); SELECT UserID, Name, Passwort, GruppenID FROM benutzer WHERE (UserID = @UserID)";
			this.m_sqlUpdateCommand.Connection = this.m_sqlConn;
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", System.Data.SqlDbType.VarChar, 50, "Name"));
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Passwort", System.Data.SqlDbType.VarChar, 50, "Passwort"));
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GruppenID", System.Data.SqlDbType.Int, 4, "GruppenID"));
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GruppenID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GruppenID", System.Data.DataRowVersion.Original, null));
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Passwort", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Passwort", System.Data.DataRowVersion.Original, null));
			this.m_sqlUpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4, "UserID"));
			// 
			// m_sqlDeleteCommand
			// 
			this.m_sqlDeleteCommand.CommandText = "DELETE FROM benutzer WHERE (UserID = @Original_UserID) AND (GruppenID = @Original" +
				"_GruppenID) AND (Name = @Original_Name) AND (Passwort = @Original_Passwort)";
			this.m_sqlDeleteCommand.Connection = this.m_sqlConn;
			this.m_sqlDeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UserID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UserID", System.Data.DataRowVersion.Original, null));
			this.m_sqlDeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GruppenID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "GruppenID", System.Data.DataRowVersion.Original, null));
			this.m_sqlDeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
			this.m_sqlDeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Passwort", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Passwort", System.Data.DataRowVersion.Original, null));
			// 
			// m_adpBenutzer
			// 
			this.m_adpBenutzer.DeleteCommand = this.m_sqlDeleteCommand;
			this.m_adpBenutzer.InsertCommand = this.m_sqlInsertCommand;
			this.m_adpBenutzer.SelectCommand = this.m_sqlSelectCommand;
			this.m_adpBenutzer.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									new System.Data.Common.DataTableMapping("Table", "benutzer", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("UserID", "UserID"),
																																																				new System.Data.Common.DataColumnMapping("Name", "Name"),
																																																				new System.Data.Common.DataColumnMapping("Passwort", "Passwort"),
																																																				new System.Data.Common.DataColumnMapping("GruppenID", "GruppenID")})});
			this.m_adpBenutzer.UpdateCommand = this.m_sqlUpdateCommand;

		}
		#endregion
	}
}
