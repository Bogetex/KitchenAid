using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KitchenAid
{
    [Serializable]
    public class Fish:Recipe
    {
        public Fish()
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
