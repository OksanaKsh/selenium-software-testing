using Litecart.UI.Client.Helpers.Extensions.String;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class Cart : LitecartBasePage
    {
        IWebElement QuantityOfAddedItems => DriverFactory.Driver.FindElement(By.CssSelector("span.quantity"));
        IWebElement Checkout => DriverFactory.Driver.FindElement(By.CssSelector("a[href='http://localhost/litecart/en/checkout'][class='link']"));

        int QuantityBeforeAddingItems = DriverFactory.Driver.FindElement(By.CssSelector("span.quantity")).Text.ToInt();
        public void VerifyItemWasAddedToCart()
        {
            DriverFactory.Wait.Until(ExpectedConditions.TextToBePresentInElement(QuantityOfAddedItems, (QuantityBeforeAddingItems + 1).ToString()));
        }

        public void CheckOut()
        {
            Checkout.Click();
        }
    }
}
