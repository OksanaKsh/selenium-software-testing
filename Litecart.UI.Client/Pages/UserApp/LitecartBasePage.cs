using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Pages.UserApp.dto;
using Litecart.UI.Client.Pages.UserApp.Dto;
using Litecart.UI.Client.Pages.UserApp.Interfaces;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class LitecartBasePage
    {
        protected IWebDriver? Driver;
        public CountriesPage CountriesPage => new CountriesPage();
        public GeoZonesPage GeoZonesPage => new GeoZonesPage();
        public HomePageLitecart HomePageLitecart => new HomePageLitecart();
        public ProductDetailsPage ProductDetailsPage => new ProductDetailsPage();
        public RegistrationPage RegistrationPage => new RegistrationPage();
        public CampaignBlockOnMainPage CampaignBlockOnMainPage => new CampaignBlockOnMainPage();
        public LitecartBasePage? Site;

        public static ProductDetailsDto ReadInfo(IProductInfo productPage)
        {

            return new ProductDetailsDto()
            {
                ProductName = productPage.ProductName.Text,
                RegularPrice = new RegularPriceDto()
                {
                    Amount = productPage.GetPrice(productPage.RegularPrice),
                    Color = productPage.GetColor(productPage.RegularPrice),
                    Font = productPage.ToDouble(productPage.GetSize(productPage.RegularPrice)),
                    IsLineThrough = productPage.IsLineThrough(productPage.RegularPrice)
                },

                CampaignPrice = new CampaignPriceDto()
                {
                    Amount = productPage.GetPrice(productPage.CampaignPrice),
                    Color = productPage.GetColor(productPage.CampaignPrice),
                    Font = productPage.ToDouble(productPage.GetSize(productPage.CampaignPrice)),
                    IsFontBold = productPage.IsBold(productPage.CampaignPrice),
                }
            };
        }
    }
}