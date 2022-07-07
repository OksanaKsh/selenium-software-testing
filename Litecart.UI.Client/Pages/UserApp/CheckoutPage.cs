using Litecart.UI.Client.Helpers.Extensions.WebDriver;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class CheckoutPage : LitecartBasePage
    {
        By ShortcutsLocator = By.CssSelector("li.shortcut a img");
        IList<IWebElement> Shortcuts => DriverFactory.Driver.FindElements(ShortcutsLocator);
        //int ShortcutsCount = DriverFactory.Driver.FindElements(ShortcutsLocator).Count;
        By TableLocator => By.XPath("//table[@class='dataTable rounded-corners']");
        IWebElement TableWithAddedItems => DriverFactory.Driver.FindElement(TableLocator);
        IWebElement RemoveButton =>
            DriverFactory.Driver.FindElement(By.XPath("//p//button[@type='submit'][@name='remove_cart_item']"));

        public void RemoveAddedItems()
        {
            for (int i =0; i < Shortcuts.Count ; i++)
            {
                Shortcuts[0].Click();
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
