/// IListManager Interface implementation.
/// By Ali Abdulhussein
/// On 25 Dec. 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAid
{
    [Serializable]
    public class ListManager<T> : IListManager<T>,IEnumerable<T>
    {
        #region Fileds
        private List<T> m_List;
        #endregion

        #region Properties
        public T this[int index]
        {
            get { return m_List[index]; }
            set { m_List[index] = value; }
        }

        public List<T> List
        {
            get { return m_List; }
            set { m_List = value; }
        }

        public int Count
        {
            get { return m_List.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        #endregion

        #region Constrain
        public ListManager()
        {
            m_List = new List<T>();
        }
        #endregion

        #region Methods
        public int IndexOf(T item)
        {
            int itmIndex = -1;
            try
            {
                itmIndex = m_List.IndexOf(item);
            }
            catch (Exception)
            {
                itmIndex = -1;
            }
            return itmIndex;
        }

        public bool Insert(int index, T item)
        {
            bool success = false;
            try
            {
                m_List.Insert(index, item);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public bool RemoveAt(int index)
        {
            bool success = false;
            try
            {
                m_List.RemoveAt(index);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public bool Add(T item)
        {
            bool success = false;
            try
            {
                m_List.Add(item);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public bool Clear()
        {
            bool success = false;
            try
            {
                m_List.Clear();
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public bool Contains(T item)
        {
            bool success = false;
            try
            {
                m_List.Contains(item);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public bool CopyTo(T[] array, int arrayIndex)
        {
            bool success = false;
            try
            {
                m_List.CopyTo(array, arrayIndex);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public bool Remove(T item)
        {
            bool success = false;
            try
            {
                m_List.Remove(item);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_List.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
           return this.GetEnumerator();
        }
        #endregion
    }
}
