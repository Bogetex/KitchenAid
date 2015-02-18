using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Meat:Recipe
    {
        public Meat()
        { }

        public override CategoryType GetCategory()
        {
            return CategoryType.Meat;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Main_Dishes;
        }
    }
}
