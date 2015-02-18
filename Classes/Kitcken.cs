using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Kitcken:Recipe
    {
        public Kitcken()
        { }
        public override CategoryType GetCategory()
        {
            throw new NotImplementedException();
        }

        public override ServingOrderType GetOrder()
        {
            throw new NotImplementedException();
        }
    }
}
