/// By Ali Abdulhussein
/// On 28 Dec. 2014
/// Ingredient Class.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Ingredient
    {
        #region Fileds
        private string m_item;
        private MessaringType m_unit;
        private double m_quantity;
        private string m_description;
        #endregion

        #region Poperties

        public string Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        public MessaringType Unit
        {
            get { return m_unit; }
            set { m_unit = value; }
        }
        public double Quantity
        {
            get { return m_quantity; }
            set { m_quantity = value; }
        }
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
        #endregion

        #region Constractor
        /// <summary>
        /// Defalut Constractor
        /// </summary>
        public Ingredient()
        { }
        /// <summary>
        /// Copy Constractor
        /// </summary>
        /// <param name="other"></param>
        public Ingredient(Ingredient other)
        {
            m_item = other.m_item;
            m_unit = other.m_unit;
            m_description = other.m_description;
            m_quantity = other.m_quantity;
        }
        #endregion

        #region Method
        public void SetNrOfPortion(int nrOfPortion)
        {
            if (nrOfPortion >= 0)
                m_quantity = m_quantity * nrOfPortion;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", m_item,m_quantity, m_unit.ToString(), m_description);
        }
        #endregion


    }
}
