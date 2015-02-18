using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class SeaFood:Recipe
    {
        public SeaFood()
        { }
        public override CategoryType GetCategory()
        {
            return CategoryType.Sea_Food;
        }

        public override ServingOrderType GetOrder()
        {
            return ServingOrderType.Main_Dishes;
        }
    }
}
