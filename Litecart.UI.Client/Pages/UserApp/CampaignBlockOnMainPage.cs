using OpenQA.Selenium;
using Litecart.UI.Client.Pages.UserApp.Interfaces;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class CampaignBlockOnMainPage : LitecartBasePage, IProductInfo
    {
        public IWebElement ProductName => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .name"));

        public IWebElement RegularPrice => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .regular-price"));

        public IWebElement CampaignPrice => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .campaign-price"));

        public object ProductDetailsDto { get; internal set; }     
    }
}
