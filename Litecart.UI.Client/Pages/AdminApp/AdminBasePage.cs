using OpenQA.Selenium;

namespace FirstProject
{
    public class AdminBasePage
    {
        public static string UrlCatalogPage => "http://localhost/litecart/admin/";
        public HomePage HomePage => new HomePage();
        public LoginPage LoginPage => new LoginPage();

        public CountriesPage CountriesPage => new CountriesPage();
        public GeoZonesPage GeoZonesPage => new GeoZonesPage();
        public CategoryElementPage CategoryElementPage => new CategoryElementPage();
        public CatalogPage CatalogPage => new CatalogPage();
       //public AdminBasePage AdminSite;
        public ActionPanel ActionPanel => new ActionPanel();    
    }
}
