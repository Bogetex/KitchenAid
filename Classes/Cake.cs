using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    class Cake:Recipe
    {
        public Cake()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Cake;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Desserts;
        }
    }
}
