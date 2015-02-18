/// IRecipe interface
/// By Ali Abdulhussein
/// On 25 Dec. 2014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KitchenAid.Utility;

/// this Interface contain only Properties, and method that implement by derived class
namespace KitchenAid
{
    interface IRecipe
    {
        Id ID { get; }
        string Name { get; set; }
        string ExtraInfo { get; set; }

        ListManager<Ingredient> Ingredient { get; set; }

        CategoryType Category { get; set; }

        ServingOrderType Order { get; set; }

        ListManager<string> HowToDo { get; set; }

        string Image { get; set; }

        CategoryType GetCategory();

        ServingOrderType GetOrder();



    }
}
