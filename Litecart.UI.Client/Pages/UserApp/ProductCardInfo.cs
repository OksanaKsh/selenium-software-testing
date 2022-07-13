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
        IWebElement RegularPrice =>  item.FindElement(RegularPriceLocator);
        IWebElement CampaignPrice => item.FindElement(CampaignPriceLocator);
        IWebElement Price => item.FindElement(PriceLocator);
        IWebElement item;

        public ProductCardInfo(IWebElement item)
        {
            this.item = item;
        }
        By ProductNameLocator => By.XPath(".//div[@class ='name']");
        By RegularPriceLocator => By.XPath(".//div[@class ='price-wrapper']/s[@class ='regular-price']");
        By PriceLocator => By.XPath("./div[@class ='price-wrapper']/span[@class ='price']");
        By CampaignPriceLocator => By.XPath(".//div[@class ='price-wrapper']/strong[@class ='campaign-price']");

        public ProductDetailsDto ReadInfo()
        {
            if (!DriverFactory.Driver.IsElementExists(PriceLocator))
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
            else
            {
                return new ProductDetailsDto()
                {
                    Price = new PriceDto()
                    {
                        Amount = Price.GetPrice(),
                        Color = Price.GetColor(),
                        Font = Price.GetSize().ToDouble(),
                        IsLineThrough = Price.IsLineThrough()
                    }
                };
            }
        }
    }
}
