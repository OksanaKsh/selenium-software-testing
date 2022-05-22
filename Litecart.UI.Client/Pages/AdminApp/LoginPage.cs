
using OpenQA.Selenium;

using SeleniumExtras.PageObjects;


namespace Litecart.UI.Client.Pages.AdminApp
{
    public  class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement Login { get; set; }

      

        public void LoginAdminApp(string username, string password)
        {
            //IWebElement Username = driver.FindElement(By.Name("username"));
            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }
    }
}
