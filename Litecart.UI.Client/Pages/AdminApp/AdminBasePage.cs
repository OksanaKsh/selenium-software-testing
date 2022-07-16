using Litecart.UI.Client.Pages.UserApp;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class AdminBasePage
    {
        public static string LitecartAppHostIP = "192.168.0.195";
        public string UrlCatalogPage => "http://" + LitecartAppHostIP + "/litecart/admin/";
        public HomePage HomePage => new HomePage();
        public LoginPage LoginPage => new LoginPage();

        public CountriesPage CountriesPage => new CountriesPage();
        public CountryDetailsPage CountryDetailsPage => new CountryDetailsPage();
        public GeoZonesPage GeoZonesPage => new GeoZonesPage();
        public CategoryElementPage CategoryElementPage => new CategoryElementPage();
        public CatalogPage CatalogPage => new CatalogPage();
        public ActionPanel ActionPanel => new ActionPanel();    
    }
}
