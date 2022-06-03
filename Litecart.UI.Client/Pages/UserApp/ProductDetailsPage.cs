using NUnit.Framework;
using OpenQA.Selenium;
using Litecart.UI.Client.Pages.UserApp.Dto;
using Litecart.UI.Client.Pages.UserApp.dto;
using Litecart.UI.Client.Pages.UserApp.Interfaces;
using Litecart.UI.Client.Helpers;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class ProductDetailsPage: LitecartBasePage,IProductInfo
    {
        public IWebElement ProductName => DriverFactory.Driver.FindElement(By.CssSelector("h1.title"));

        public IWebElement RegularPrice => DriverFactory.Driver.FindElement(By.CssSelector(".regular-price"));

        public IWebElement CampaignPrice => DriverFactory.Driver.FindElement(By.CssSelector(".campaign-price"));


        public ProductDetailsDto ReadInfo()
        {
            ProductDetailsPage productDetailsPage = ProductDetailsPage;

            return new ProductDetailsDto()
            {
                ProductName = ProductName.Text,
                RegularPrice = new RegularPriceDto()
                {
                    Amount = productDetailsPage.GetPrice(RegularPrice),
                    Color = productDetailsPage.GetColor(RegularPrice),
                    Font = productDetailsPage.ToDouble(productDetailsPage.GetSize(RegularPrice)),
                    IsLineThrough = productDetailsPage.IsLineThrough(RegularPrice)
                },

                CampaignPrice = new CampaignPriceDto()
                {
                    Amount = productDetailsPage.GetPrice(CampaignPrice),
                    Color = productDetailsPage.GetColor(CampaignPrice),
                    Font = productDetailsPage.ToDouble(productDetailsPage.GetSize(CampaignPrice)),
                    IsFontBold = productDetailsPage.IsBold(CampaignPrice),
                }
            };
        }
    }
}
