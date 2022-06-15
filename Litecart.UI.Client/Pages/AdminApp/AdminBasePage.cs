using OpenQA.Selenium;

namespace FirstProject
{
    public class AdminBasePage
    {
        public static string UrlAdminPanel => "http://localhost/litecart/admin/";
        public HomePage HomePage => new HomePage();
        public LoginPage LoginPage => new LoginPage();

        public CountriesPage CountriesPage => new CountriesPage();
        public GeoZonesPage GeoZonesPage => new GeoZonesPage(); public CategoryElementPage CategoryElementPage => new CategoryElementPage();
        public static AdminBasePage? AdminSite { get; set; }
    }
}
