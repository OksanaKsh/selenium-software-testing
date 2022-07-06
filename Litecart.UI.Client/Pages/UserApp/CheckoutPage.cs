using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class CheckoutPage
    {
        IList<IWebElement> Items => DriverFactory.Driver.FindElements(By.CssSelector(("li.item")));
        By TableLocator => By.XPath("//table[@class='dataTable rounded-corners']");
        IWebElement TableWithAddedItems => DriverFactory.Driver.FindElement(TableLocator);
        IWebElement RemoveButton =>
            DriverFactory.Driver.FindElement(By.XPath("//p//button[@type='submit'][@name='remove_cart_item']"));
        public void RemoveAddedItems(Cart cart)
        {
            cart.Checkout.Click();
            for (int i = 0; i < Items.Count; i++)
            {
                Items[0].Click();
                RemoveButton.Click();
                DriverFactory.Wait.Until(
                    ExpectedConditions.ElementExists(TableLocator));
            }

            RemoveButton.Click();
            DriverFactory.Wait.Until(
                ExpectedConditions.StalenessOf(TableWithAddedItems));
        }
    }
}
