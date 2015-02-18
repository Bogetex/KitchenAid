using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Salad:Recipe
    {
        public Salad()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Salad;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Starters;
        }
    }
}
