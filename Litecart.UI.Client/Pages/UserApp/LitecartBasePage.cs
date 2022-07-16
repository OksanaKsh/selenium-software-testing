namespace Litecart.UI.Client.Pages.UserApp
{
    public class LitecartBasePage
    {
        public static string LitecartAppHostIP = "192.168.0.195";
        public static string UrlAdminPanel = "http://"+ LitecartAppHostIP +"/ litecart/admin/";
        public static string UrlUserPage = "http://" + LitecartAppHostIP + "/litecart/en/";
        public HomePageLitecart HomePageLitecart => new HomePageLitecart();
        public ProductDetailsPage ProductDetailsPage => new ProductDetailsPage();
        public RegistrationPage RegistrationPage => new RegistrationPage();
        public MainLitecartPage MainLitecartPage => new MainLitecartPage();
    }
}