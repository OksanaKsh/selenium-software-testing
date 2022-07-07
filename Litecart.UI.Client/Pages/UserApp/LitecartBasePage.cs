namespace Litecart.UI.Client.Pages.UserApp
{
    public class LitecartBasePage
    {
        public static string UrlAdminPanel = "http://localhost/litecart/admin/";
        public static string UrlUserPage = "http://localhost/litecart/en/";
        public HomePageLitecart HomePageLitecart => new HomePageLitecart();
        public ProductDetailsPage ProductDetailsPage => new ProductDetailsPage();
        public RegistrationPage RegistrationPage => new RegistrationPage();
        public MainLitecartPage MainLitecartPage => new MainLitecartPage();
    }
}