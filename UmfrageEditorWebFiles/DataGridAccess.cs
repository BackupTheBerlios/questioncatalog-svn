using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UmfrageEditor
{
	/// <summary>
	/// Zusammenfassung für DataGridAccess.
	/// </summary>
	public class DataGridAccess
	{
		public DataGridAccess()
		{
			//
			// TODO: Fügen Sie hier die Konstruktorlogik hinzu
			//
		}

		public static Control GetControlFromDataGrid(DataGridItem row, Type type, int cellindex, int controlindex)
		{
			if (row.ItemType == ListItemType.Item || row.ItemType == ListItemType.AlternatingItem)
			{
				for (int i = 0; i < row.Cells[cellindex].Controls.Count; i++)
				{
					if(type.Equals(row.Cells[cellindex].Controls[i].GetType()))
					{
						if (0 == controlindex)
						{
							return row.Cells[cellindex].Controls[i];
						}
						else
						{
							controlindex--;
						}
					}
				}
			}
			return null;
		}
	}
}
