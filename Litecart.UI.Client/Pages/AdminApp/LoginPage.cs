
using OpenQA.Selenium;

using SeleniumExtras.PageObjects;


namespace Litecart.UI.Client.Pages.AdminApp
{
    public  class LoginPage : AdminBasePage
    {
        IWebElement Username => DriverFactory.Driver.FindElement(By.Name("username"));
        IWebElement Password => DriverFactory.Driver.FindElement(By.Name("password"));
        IWebElement Login => DriverFactory.Driver.FindElement(By.Name("login"));

        public void LoginAdminApp(string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }
    }
}
