using Litecart.UI.Client.Pages.UserApp;
using Litecart.UI.Client.Pages.UserApp.Interfaces;
using OpenQA.Selenium;
using System.Drawing;

namespace Litecart.UI.Client.Helpers
{
    public static class ParseText
    {
        public  static int GetPrice(this IProductInfo product, IWebElement price)
        {
            var valueOfText = price.Text;
             var priceValue = Int32.Parse(valueOfText.Substring(1));
            return priceValue;
        }
        public static Color GetColor(this IProductInfo product, IWebElement price)
        {
            var color = ColorHelper.ParseColor(price.GetCssValue("color"));
            return color;
        }

        public static bool IsLineThrough(this IProductInfo product, IWebElement price)
        {
            return price.GetCssValue("text-decoration") != null ? true : false;
        }

        public static string GetSize(this IProductInfo product, IWebElement price)
        {
            string size = String.Concat(price.GetCssValue("font-size").Reverse().Skip(2).Reverse());
            return size;
        }
        public static double ToDouble(this IProductInfo product, string item)
        {
            var itemValue = Double.Parse(item);
            return itemValue;
        }

        public static bool IsBold(this IProductInfo product, IWebElement price)
        {
            return price.GetCssValue("font-weight").Equals("700") ? true : false;
        }
    }
}
