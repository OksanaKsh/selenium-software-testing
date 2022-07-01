﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace Litecart.UI.Client
{
    public class DriverFactory
    {
        public static WebDriver? Driver { get; set; }
        public static WebDriverWait Wait
        {
            get
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                return wait;
            }
        }

        public static IWebDriver StartBrowser(String browserName, string url)
        {
            if (browserName.Equals("Firefox"))
            {
                Driver = new FirefoxDriver();
            }
            else if ((browserName.Equals("Chrome")))
            {
                //SetProxy();
                Driver = new ChromeDriver();
            }
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
            return Driver;
        }

        public static WebDriver SetProxy()
        {
            Proxy proxy = new Proxy();
            proxy.Kind = ProxyKind.Manual;
            proxy.HttpProxy = "localhost:8888";
            ChromeOptions options = new ChromeOptions();
            options.Proxy = proxy;
            Driver = new ChromeDriver(options);
            return Driver;
        }
        public static void CloseBrowser()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public static void MakeScreenshot(WebDriver driver)
        {
            string screenshotsStorage = Path.Combine(TestContext.CurrentContext.WorkDirectory.ToString() ,"Screens", TestContext.CurrentContext.Test.MethodName.ToString()+".png");
            driver.GetScreenshot().SaveAsFile(screenshotsStorage, ScreenshotImageFormat.Png);
        }

        public void GetBrowserLogs() 
        {
            foreach (LogEntry l in Driver.Manage().Logs.GetLog("browser"))
            {
                Console.WriteLine(l);
            }
        }
        public static void Logging(WebDriver driver)
        {
            EventFiringWebDriver EventDriver = new EventFiringWebDriver(driver);
            EventDriver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod);
            EventDriver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + "found");
            EventDriver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);
            EventDriver.Manage().Window.Maximize();
        }
    }
}
