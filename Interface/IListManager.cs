/// IList interface
/// Generic IList collection implementation
/// By Ali Abdulhussein
/// On 25 Dec. 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAid
{
    interface IListManager<T>
    {
        #region Properties
        T this[int index]
        { get; set; }
        int Count
        { get; }

        bool IsReadOnly
        { get; }
        bool IsFixedSize
        { get;}
        #endregion

        #region Methods
        int IndexOf(T item);


        bool Insert(int index, T item);

        bool RemoveAt(int index);


        bool Add(T item);

        bool Clear();

        bool Contains(T item);

        bool CopyTo(T[] array, int arrayIndex);


        bool Remove(T item);

        IEnumerator<T> GetEnumerator();

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator();

        #endregion

    }
}
