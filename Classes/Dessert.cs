using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Dessert:Recipe
    {
        public Dessert()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Dessert;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Desserts;
        }
    }
}
