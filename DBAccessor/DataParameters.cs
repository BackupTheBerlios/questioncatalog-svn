using System;
using System.Data.SqlClient;
using System.Collections;

namespace DBAccessor
{
	/// <summary>
	/// Datenparameterliste
	/// </summary>
	public class DataParameters : IList
	{
		/// <summary>
		/// Standardkonstruktor
		/// </summary>
		public DataParameters()
		{
			// Membervariablen initialisieren...
			m_InternalDataParameters = new ArrayList();
		}

		/// <summary>
		/// Interne Collection zur Aufnahme der Prameter
		/// </summary>
		protected ArrayList m_InternalDataParameters;

		#region IList Member

		public bool IsReadOnly
		{
			get
			{				
				return m_InternalDataParameters.IsReadOnly;
			}
		}

		object IList.this[int index]
		{
			get
			{				
				return m_InternalDataParameters[index];
			}
			set
			{
				m_InternalDataParameters[index] = value;
			}
		}

		public SqlParameter this[int index]
		{
			get
			{				
				return (SqlParameter)m_InternalDataParameters[index];
			}
			set
			{
				m_InternalDataParameters[index] = value;
			}
		}

		public void RemoveAt(int index)
		{
			m_InternalDataParameters.RemoveAt(index);
		}

		void IList.Insert(int index, object value)
		{
			m_InternalDataParameters.Insert(index, value);
		}

		public void Insert(int index, SqlParameter value)
		{
			m_InternalDataParameters.Insert(index, value);
		}

		public void Remove(object value)
		{
			m_InternalDataParameters.Remove(value);
		}

		public bool Contains(object value)
		{			
			return m_InternalDataParameters.Contains(value);
		}

		public void Clear()
		{
			m_InternalDataParameters.Clear();
		}

		public int IndexOf(object value)
		{			
			return m_InternalDataParameters.IndexOf(value);
		}

		int IList.Add(object value)
		{
			return m_InternalDataParameters.Add(value);
		}

		public int Add(SqlParameter value)
		{
			return m_InternalDataParameters.Add(value);
		}

		public int Add(SqlParameter parameter, object value)
		{
			parameter.Value = value;
			return m_InternalDataParameters.Add(parameter);
		}

		public bool IsFixedSize
		{
			get
			{						
				return m_InternalDataParameters.IsFixedSize;
			}
		}

		#endregion

		#region ICollection Member

		public bool IsSynchronized
		{
			get
			{
				return m_InternalDataParameters.IsSynchronized;
			}
		}

		public int Count
		{
			get
			{
				return m_InternalDataParameters.Count;
			}
		}

		public void CopyTo(Array array, int index)
		{
			m_InternalDataParameters.CopyTo(array, index);
		}

		public object SyncRoot
		{
			get
			{
				return m_InternalDataParameters.SyncRoot;
			}
		}

		#endregion

		#region IEnumerable Member

		public IEnumerator GetEnumerator()
		{
			return m_InternalDataParameters.GetEnumerator();
		}

		#endregion
	}
}
