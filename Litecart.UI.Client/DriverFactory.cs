using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace FirstProject
{
    public class DriverFactory
    {
        public static IWebDriver? Driver { get; set; }
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public static IWebDriver StartBrowser(String browserName, string url)
        {
            if (browserName.Equals("Firefox"))
            {
                Driver = new FirefoxDriver();
            }
            else if ((browserName.Equals("Chrome")))
            {
                Driver = new ChromeDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
            return Driver;
        }
        
        public static void CloseBrowser()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
