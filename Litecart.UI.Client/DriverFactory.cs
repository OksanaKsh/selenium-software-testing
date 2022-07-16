using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System.Collections.Concurrent;
using OpenQA.Selenium.Remote;

namespace Litecart.UI.Client
{
    public class DriverFactory
    {
        static string RemoteURL = "http://localhost:4444/wd/hub";
        public static WebDriver Driver
        {
            get
            {
                return DriverCollection.First(pair => pair.Value == NUnit.Framework.TestContext.CurrentContext.Test.Name).Key;
            }
            
            set
            {
                DriverCollection.TryAdd(value, NUnit.Framework.TestContext.CurrentContext.Test.Name);
            }
        }

        public static readonly ConcurrentDictionary<  WebDriver, string> DriverCollection =
            new ConcurrentDictionary<WebDriver, string>();
    public static EventFiringWebDriver? EventDriver { get; set; }
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
            else if (browserName.Equals("Chrome"))
            {
                ChromeOptions capabilities = new ChromeOptions();
                capabilities.BrowserVersion = "103";
                capabilities.AddAdditionalCapability("enableVNC", true, true);
                Driver = new RemoteWebDriver(new Uri(RemoteURL),capabilities); 
                // SetProxy();
                //Driver = new ChromeDriver();
            }           
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
            return Driver;
        }

        //public static WebDriver SetProxy()
        //{
        //    Proxy proxy = new Proxy();
        //    proxy.Kind = ProxyKind.Manual;
        //    proxy.HttpProxy = "127.0.0.1:8888";
        //    ChromeOptions options = new ChromeOptions();
        //    options.Proxy = proxy;
        //    Driver = new ChromeDriver(options);
        //    return Driver;
        //}
        public static void CloseBrowser()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public static void MakeScreenshot(WebDriver driver)
        {
            string screenshotsStorage = Path.Combine(NUnit.Framework.TestContext.CurrentContext.WorkDirectory.ToString() ,"Screens", NUnit.Framework.TestContext.CurrentContext.Test.MethodName.ToString()+".png");
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
