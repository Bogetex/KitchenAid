using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    class Cookies:Recipe
    {
        public Cookies()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Cookies;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Desserts;
        }
    }
}
