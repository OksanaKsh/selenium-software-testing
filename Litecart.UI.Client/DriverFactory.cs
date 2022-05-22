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
        public static IWebDriver? driver;

        public static IWebDriver StartBrowser(String browserName, string url)
        {
            if (browserName.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if ((browserName.Equals("Chrome")))
            {
                driver = new ChromeDriver();
            }
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }
        public WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));//Where to put it
        
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
