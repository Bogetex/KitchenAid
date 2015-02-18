/// Utility Class 
/// By Ali Abdulhussein
/// On Dec. 23 2014
/// This class hold all help method needed in my project.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace KitchenAid.Utility
{
    /// <summary>
    /// StringReplacer
    /// This method to remove unwanted Char feom string
    /// By using framework string.replace
    /// Wher oldstring = replacer, and new string = replacmnet
    /// Ex:
    /// To remove space from string "a b"
    /// invoke StringReplacer("a b", ' ', '');
    /// </summary>
    public class HelpMethod
    {
        public static string StringReplacer(string inStr, char replacer, char recplacment)
        {
            return inStr.Replace(replacer,recplacment);
        }

        public static string[] EnumFriendlyText(string[] enumIn)
        {
            string[] obj=new string[enumIn.Length];
            for (int i = 0; i < enumIn.Length; i++)
            {
                obj[i] = StringReplacer(enumIn[i], '_',' ');
            }
            return obj;
        }

        public static int IntCounter(int start)
        {
            return start + 1;
        }

        public static string strCounter(int start)
        {
            return IntCounter(start).ToString();
        }

        public static bool ValidateString(params string[] strIn)
        {
            bool ok = true;
            foreach (var item in strIn)
            {
                ok = ok && ((!string.IsNullOrWhiteSpace(item))?true:false);
            }
            return ok;
        }

        public static bool ValidateInt(params string[] strIn)
        {
            bool ok = true;
            int outValue;
            foreach (var item in strIn)
            {
                ok = ok && int.TryParse(item, out outValue);
            }
            return ok;
        }

        public static Recipe RecipeFactory(CategoryType recipeCategory)
        {
            Recipe recipe = null;
            switch (recipeCategory)
            {
                case CategoryType.Meat:
                    recipe = new Meat();
                    break;
                case CategoryType.Chiken:
                    recipe = new Chicken();
                    break;
                case CategoryType.Cake:
                    recipe = new Cake();
                    break;
                case CategoryType.Cookies:
                    recipe = new Cookies();
                    break;
                case CategoryType.Dessert:
                    recipe = new Dessert();
                    break;
                case CategoryType.Drinks:
                    recipe = new Drink();
                    break;
                case CategoryType.Fish:
                    recipe = new Fish();
                    break;
                case CategoryType.Ice_Cream:
                    recipe = new IceCream();
                    break;
                case CategoryType.Pies:
                    recipe = new Pies();
                    break;
                case CategoryType.Salad:
                    recipe = new Salad();
                    break;
                case CategoryType.Sea_Food:
                    recipe = new SeaFood();
                    break;
                case CategoryType.Soup:
                    recipe = new Soup();
                    break;
                default:
                    break;
            }
            return recipe;
        }

        public static int ReadInteger(string strIn)
        {
            int tmpInt = 0;
            if (ValidateInt(strIn))
            {
                tmpInt = int.Parse(strIn);
            }
            return tmpInt;
        }

    }
}
