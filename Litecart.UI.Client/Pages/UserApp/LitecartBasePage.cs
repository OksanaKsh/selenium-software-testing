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
    }
}
