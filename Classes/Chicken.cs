using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Chicken:Recipe
    {
        #region Fields
        #endregion

        #region Constractors
        /// <summary>
        /// Default Constractor
        /// </summary>
        public Chicken()
        {
            this.Category = CategoryType.Chiken;
            this.Order = ServingOrderType.Main_Dishes;
        }
        /// <summary>
        /// Copy constractor
        /// </summary>
        /// <param name="other"></param>
        public Chicken(Chicken other)
        {
            this.Name = other.Name;
            this.Order = other.Order;
            this.Origin = other.Origin;
            this.RecipeType = other.RecipeType;
            this.Image = other.Image;
            this.Ingredient = other.Ingredient;
            this.HowToDo = other.HowToDo;
            this.Category = other.Category;
            this.CookingTime = other.CookingTime;

        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        #endregion

        public override CategoryType GetCategory()
        {
            return CategoryType.Chiken;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Main_Dishes;
        }

    }
}
