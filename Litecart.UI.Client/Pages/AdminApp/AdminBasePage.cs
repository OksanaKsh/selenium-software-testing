using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp
{
    public class AdminBasePage
    {
        protected IWebDriver? Driver;
        public HomePage HomePage => new HomePage();
        public LoginPage LoginPage => new LoginPage();    
        public CategoryElementPage CategoryElementPage => new CategoryElementPage();
        public AdminBasePage? AdminSite;
    }
}
