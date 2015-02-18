using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KitchenAid.Utility;

namespace KitchenAid
{
    [Serializable]
    public abstract class Recipe : IRecipe
    {
        #region Fields
        private Id m_id;
        private string m_name;
        private string m_extraInfo;
        private ListManager<Ingredient> m_ingredient;
        private CategoryType m_category;
        private ServingOrderType m_serOrder;
        private string m_image;



        private VegetarianType m_type;
        private OriginType m_origion;
        private string m_cookingTime;
        private int m_NrOfPortion;
        private ListManager<string> m_HowToDo;

        #endregion

        #region Properties
        #region Interface Property
        public Id ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string ExtraInfo
        {
            get
            { return m_extraInfo; }
            set
            { m_extraInfo = value; }
        }

        public int NrOfPortion
        {
            get { return m_NrOfPortion; }
            set { m_NrOfPortion = value; }
        }

        public ListManager<Ingredient> Ingredient
        {
            get
            { return m_ingredient; }
            set
            { m_ingredient = value; }
        }

        public CategoryType Category
        {
            get
            { return m_category; }
            set
            { m_category = value; }
        }

        public ServingOrderType Order
        {
            get
            { return m_serOrder; }
            set
            { m_serOrder = value; }
        }

        public ListManager<string> HowToDo
        {
            get
            { return m_HowToDo; }
            set
            { m_HowToDo = value; }
        }

        public string Image
        {
            get
            { return m_image; }
            set
            { m_image = value; }
        }

        #endregion
        #region Recipe Class Property
        public VegetarianType RecipeType
        {
            get { return m_type; }
            set { m_type = value; }
        }

        public OriginType Origin
        {
            get { return m_origion; }
            set { m_origion = value; }
        }

        public string CookingTime
        {
            get { return m_cookingTime; }
            set { m_cookingTime = value; }
        }

        #endregion
        #endregion

        #region Constractor
        
        /// <summary>
        /// Default Constractor
        /// </summary>
        public Recipe()
        {
            m_ingredient=new ListManager<Ingredient>();
            m_HowToDo=new ListManager<string>();
        }

        #endregion
        #region Methods
        public abstract CategoryType GetCategory();
        public abstract ServingOrderType GetOrder();

        /// <summary>
        /// Organized the way in which the HowToDo list print/show out.
        /// </summary>
        /// <returns></returns>
        public virtual string GetHowToDo()
        {
            string strOut = string.Empty;
            foreach (var item in m_HowToDo)
            {
                strOut = HelpMethod.strCounter(m_HowToDo.Count) + strOut + item + Environment.NewLine;
            }
            return strOut;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", m_id.ToString(),m_name);
        }
        #endregion
    }
}
