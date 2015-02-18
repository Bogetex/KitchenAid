using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class ShoppingMenuItem
    {
        #region Fields
        private string m_item;
        private int m_Number=0;
        #endregion

        #region Properties
        public string Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        public int Number
        {
            get { return m_Number; }
            set { m_Number = value; }
        }
        #endregion

        #region Constractors
        public ShoppingMenuItem()
        {
        }

        public ShoppingMenuItem(ShoppingMenuItem other)
        {
            m_item = other.m_item;
            m_Number = other.m_Number;
        }

        #endregion

        #region Methods
        #endregion
    }
}
