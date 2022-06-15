using OpenQA.Selenium;
using System.Drawing;

namespace Litecart.UI.Client.Helpers
{
    public static class ParsePriceCssValuesExtensions
    {
        public static double GetPrice(this IWebElement price)
        {
            var valueOfText = price.Text;
             var priceValue = Int32.Parse(valueOfText.Substring(1));
            return priceValue;
        }

        public static Color GetColor(this IWebElement price)
        {
            var color = ColorHelper.ParseColor(price.GetCssValue("color"));
            return color;
        }

        public static bool IsLineThrough(this IWebElement price)
        {
            return price.GetCssValue("text-decoration") != null ? true : false;
        }

        public static string GetSize(this IWebElement price)
        {
            string size = String.Concat(price.GetCssValue("font-size").Reverse().Skip(2).Reverse());
            return size;
        }

        public static bool IsBold(this IWebElement price)
        {
            return price.GetCssValue("font-weight").Equals("700") ? true : false;
        }
    }
}
