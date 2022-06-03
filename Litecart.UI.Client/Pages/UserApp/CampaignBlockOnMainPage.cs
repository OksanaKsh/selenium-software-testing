using NUnit.Framework;
using OpenQA.Selenium;
using Litecart.UI.Client.Pages.UserApp.Dto;
using static Litecart.UI.Client.Helpers.ParseText;
using Litecart.UI.Client.Pages.UserApp.dto;
using Litecart.UI.Client.Pages.UserApp.Interfaces;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class CampaignBlockOnMainPage : LitecartBasePage, IProductInfo
    {
        public IWebElement ProductName => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .name"));

        public IWebElement RegularPrice => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .regular-price"));

        public IWebElement CampaignPrice => DriverFactory.Driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .campaign-price"));

        public object ProductDetailsDto { get; internal set; }

        public ProductDetailsDto ReadInfo()
        {
            CampaignBlockOnMainPage campaignBlock = CampaignBlockOnMainPage;

            return new ProductDetailsDto()
            {
                ProductName = ProductName.Text,
                RegularPrice = new RegularPriceDto()
                {
                    Amount = campaignBlock.GetPrice(RegularPrice),
                    Color = campaignBlock.GetColor(RegularPrice),
                    Font = campaignBlock.ToDouble(campaignBlock.GetSize(RegularPrice)),
                    IsLineThrough = campaignBlock.IsLineThrough(RegularPrice)
                },

                CampaignPrice = new CampaignPriceDto()
                {
                    Amount = campaignBlock.GetPrice(CampaignPrice),
                    Color = campaignBlock.GetColor(CampaignPrice),
                    Font = campaignBlock.ToDouble(campaignBlock.GetSize(CampaignPrice)),
                    IsFontBold = campaignBlock.IsBold(CampaignPrice),
                }
            };
        }
     
    }
}
