using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace FirstProject
{
    public class OpenAndCloseBrowser
    {
        IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver("C:/SeleniumWebDriver/ABarantcevCource/SeleniumWebDriverCourse/SeleniumWebDriverCourse");
            webDriver.Url = "https://gcatch.in/open-url-using-selenium-chromedriver-c/";
            webDriver.Navigate();
        }
        [Ignore("Old tests not updated")]
        [Test]
        public void Test()
        {
            webDriver.Navigate().GoToUrl(webDriver.Url);
            //Assert.Pass();
            Thread.Sleep(2000);
        }

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Close();
        }
    }
}