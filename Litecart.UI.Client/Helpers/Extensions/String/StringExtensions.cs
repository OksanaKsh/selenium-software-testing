namespace Litecart.UI.Client.Helpers.Extensions.String
{
    public static  class StringExtensions
    {
        public static double ToDouble(this string item)
        {
            var itemValue = Double.Parse(item);
            return itemValue;
        }
    }
}
