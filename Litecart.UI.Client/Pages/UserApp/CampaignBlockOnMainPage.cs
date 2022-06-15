using OpenQA.Selenium;
using FirstProject.Interfaces;
using FirstProject.Dto;
using FirstProject.dto;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.String;

namespace FirstProject
{
    public class CampaignBlockOnMainPage : LitecartBasePage, IProductInfo
    {
        public IWebElement ProductName => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .name"));
        public IWebElement RegularPrice => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .regular-price"));
        public IWebElement CampaignPrice => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .campaign-price"));
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
