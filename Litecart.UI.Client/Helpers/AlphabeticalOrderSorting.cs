using NUnit.Framework;
using OpenQA.Selenium;


namespace Litecart.UI.Client.Helpers
{
    public static  class AlphabeticalOrderSorting
    {
        public static void VerifyThatItemsAreSortedInAlphabeticalOrder(IList<IWebElement> webElements)
        {
            List<string> currentElementNames = new List<string>();
            foreach (var webElement in webElements)
            {
                currentElementNames.Add(webElement.Text);
            }
            Assert.That(currentElementNames, Is.Ordered.Ascending);
        }
    }
}
