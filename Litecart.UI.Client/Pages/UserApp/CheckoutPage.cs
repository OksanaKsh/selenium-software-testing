using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace LitecartUITests
{
    public class CheckoutPage
    {
        public IList<IWebElement> Items => DriverFactory.Driver.FindElements(By.CssSelector(("li.item")));
        public By TableLocator => By.XPath("//table[@class='dataTable rounded-corners']");
        private IWebElement TableWithAddedItems => DriverFactory.Driver.FindElement(TableLocator);
        public void RemoveAddedItems(Cart cart)
        {
            cart.Checkout.Click();
            for (int i = 0; i < Items.Count; i++)
            {
                Items[0].Click();
                DriverFactory.Driver.FindElement(By.XPath("//p//button[@type='submit'][@name='remove_cart_item']"))
                    .Click();
                DriverFactory.Wait.Until(
                    ExpectedConditions.ElementExists(TableLocator));
            }

            DriverFactory.Driver.FindElement(By.XPath(".//p//button[@type='submit'][@name='remove_cart_item']"))
                .Click();
            DriverFactory.Wait.Until(
                ExpectedConditions.StalenessOf(TableWithAddedItems));
        }
    }
}
