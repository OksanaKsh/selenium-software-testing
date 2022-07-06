using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using Litecart.UI.Client.Helpers.Extensions.WebDriver;
using Litecart.UI.Client.Pages.UserApp.dto;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductCardInfo : LitecartBasePage
    {
        public IWebElement ProductName => item.FindElement(ProductNameLocator);
        IWebElement RegularPrice => DriverFactory.Driver.IsElementExists(CampaignPriceLocator) ? item.FindElement(RegularPriceLocator) :null;
        IWebElement CampaignPrice => DriverFactory.Driver.IsElementExists(CampaignPriceLocator) ? item.FindElement(CampaignPriceLocator) :null;
        IWebElement Price => DriverFactory.Driver.IsElementExists(PriceLocator) ? item.FindElement(PriceLocator) : null;
        IWebElement item;

        public ProductCardInfo(IWebElement item)
        {
            this.item = item;
        }
        By ProductNameLocator => By.XPath(".//div[@class ='name']");
        By RegularPriceLocator => By.XPath(".//div[@class ='price-wrapper']/s[@class ='regular-price']");
        By PriceLocator => By.XPath(".//div[@class ='price-wrapper']/span[@class ='price']");
        By CampaignPriceLocator => By.XPath(".//div[@class ='price-wrapper']/strong[@class ='campaign-price']");

        public ProductDetailsDto ReadInfo()
        {
            return new ProductDetailsDto()
            {
                ProductName = ProductName.Text,
                RegularPrice = new RegularPriceDto()
                {
                    Amount = RegularPrice.GetPrice(),
                    Color = RegularPrice.GetColor(),
                    Font = RegularPrice.GetSize().ToDouble(),
                    IsLineThrough = RegularPrice.IsLineThrough()
                },
                CampaignPrice = new CampaignPriceDto()
                {
                    Amount = CampaignPrice.GetPrice(),
                    Color = CampaignPrice.GetColor(),
                    Font = CampaignPrice.GetSize().ToDouble(),
                    IsFontBold = CampaignPrice.IsBold(),
                }
            };
        }
    }
}
