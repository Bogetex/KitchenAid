using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Drink:Recipe
    {
        public Drink()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Drinks;
        }


        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Drinks;
        }
    }
}
