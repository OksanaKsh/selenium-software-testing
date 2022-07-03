using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;
using Litecart.UI.Client.Pages.UserApp.dto;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductCardInfo : LitecartBasePage
    {
        public IWebElement ProductName;
        IWebElement RegularPrice;
        IWebElement CampaignPrice;
        IWebElement Price;
        public ProductCardInfo(IWebElement item)
        {
            ProductName = item.FindElement(ProductNameLocator);
            try
            {
                
                    Price = item.FindElement(PriceLocator);
                    RegularPrice = null;
                    CampaignPrice = null;
            }
            catch (NoSuchElementException e)
            {
                Price = null;
                RegularPrice = item.FindElement(RegularPriceLocator);
                CampaignPrice = item.FindElement(CampaignPriceLocator);
            }

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
