using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litecart.UI.Client
{
    public class DriverFactory
    {
        public static IWebDriver? Driver { get; set; }

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
        public WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));//Where to put it
        
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
