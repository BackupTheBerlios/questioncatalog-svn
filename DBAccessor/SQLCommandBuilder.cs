using System;
using System.Text;

namespace DBAccessor
{
	/// <summary>
	/// Helferklasse, die ein SQL-Statement mit verschiedenen Parametern zusammenbaut
	/// </summary>
	internal class SQLCommandBuilder
	{
		public SQLCommandBuilder()
		{
			
		}

		public static string MakeSelectString(DataParameters selectParams, string tableName)
		{
			StringBuilder sbSelect = new StringBuilder("SELECT * FROM ");
			sbSelect.Append(tableName);
			if (selectParams != null)
			{
				string sqlClause = " WHERE ";
				for(int i = 0; i < selectParams.Count; i++)
				{
					sbSelect.Append(sqlClause);
					sqlClause = " AND ";

					sbSelect.AppendFormat("{0}={1}", selectParams[i].SourceColumn, selectParams[i].ParameterName);
				}
			}
			
			return sbSelect.ToString();
		}
	}
}
