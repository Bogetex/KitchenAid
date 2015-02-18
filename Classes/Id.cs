/// By Ali Abdulhussein
/// On 22 Dec. 2014
/// This is special class for creating ID, where ever need.
/// Can ID has some text in addtion to the cout "Suffix", therefore this class come with ability to generate normal ID, and ID with suffex.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    public class Id
    {
        private const int Min=100;
        private int m_number;
        private string m_suffix;

        /// <summary>
        /// Default constractor
        /// </summary>
        public Id()
        {
            m_number = 0;
            m_suffix = string.Empty;
        }

        public Id(int number)
        {
            m_number = Number;
        }
        /// <summary>
        /// Constractor with parameter to generate m_Id with suffix
        /// </summary>
        /// <param name="suffis"></param>
        public Id(string suffis):this()
        {
            m_suffix = suffis;
        }
        /// <summary>
        /// Return Number counter
        /// </summary>
        public int Number
        {
            get {
                Random random = new Random();
                return m_number = Min + random.Next(0, 100); 
            }
        }
        /// <summary>
        /// Using this property to Set text to integer m_Id value
        /// Suffix can send by Constractor parameter, Or by setting new value to this property
        /// m_Id(),m_Id("MM"), m_Id.Suffix="LL"
        /// </summary>
        public string Suffix
        {
            get { return m_suffix; }
            set { m_suffix = value; }
        }
        /*
        public string GetNewId()
        {
            return string.Format("{0}{1}",Number.ToString(),m_suffix);
        }
        */
        public override string ToString()
        {
            return string.Format("{0}{1}", Number.ToString(), m_suffix);
        }
    }
}
