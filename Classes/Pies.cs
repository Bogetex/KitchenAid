using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    class Pies:Recipe
    {
        public Pies()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Pies;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Desserts;
        }
    }
}
