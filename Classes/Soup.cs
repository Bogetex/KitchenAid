using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    class Soup:Recipe
    {
        public Soup()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Soup;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Starters;
        }
    }
}
