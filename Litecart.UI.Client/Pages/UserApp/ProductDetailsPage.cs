using OpenQA.Selenium;
using Litecart.UI.Client.Pages.UserApp.Interfaces;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductDetailsPage: LitecartBasePage,IProductInfo
    {
        public IWebElement ProductName => DriverFactory.Driver.FindElement(By.CssSelector("h1.title"));

        public IWebElement RegularPrice => DriverFactory.Driver.FindElement(By.CssSelector(".regular-price"));

        public IWebElement CampaignPrice => DriverFactory.Driver.FindElement(By.CssSelector(".campaign-price"));
    }
}
