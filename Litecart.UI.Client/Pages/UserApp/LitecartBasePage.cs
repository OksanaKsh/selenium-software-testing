namespace FirstProject
{
    public class LitecartBasePage
    {
        public static string UrlAdminPanel = "http://localhost/litecart/admin/";
        public HomePageLitecart HomePageLitecart => new HomePageLitecart();
        public ProductDetailsPage ProductDetailsPage => new ProductDetailsPage();
        public RegistrationPage RegistrationPage => new RegistrationPage();
        public MainLitecartPage MainLitecartPage => new MainLitecartPage();
        
        //public CampaignBlockOnMainPage CampaignBlockOnMainPage => new CampaignBlockOnMainPage();
        //public static LitecartBasePage? Site { get; set; }  
    }
}