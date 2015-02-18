using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    class IceCream:Recipe
    {
        public IceCream()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Ice_Cream;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Desserts;
        }
    }
}
