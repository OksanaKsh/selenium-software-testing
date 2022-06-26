//Сделайте сценарий для логина в панель администрирования учебного приложения http://localhost/litecart/admin/.

//Попробуйте запустить разработанный ранее сценарий логина во всех основных браузерах,
//доступных для вашей операционной системы.

//Paralel run

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace LitecartUITests
{
    public class LaunchChrome
    {
        IWebDriver webDriver;
        WebDriverWait wait;

        string adminUsername = "admin";
        string adminPassword = "admin";

        [SetUp]
        public void Setup()
        {
            string currentDirName = System.IO.Directory.GetCurrentDirectory();

            webDriver = new ChromeDriver(currentDirName);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            webDriver.Url = "http://localhost/litecart/admin/"; //open page (the same as get in Javascript)
            webDriver.Navigate();
            //Thread.Sleep(3000);
        }

        [Test]
        public void Test()
        {
            
            var element = webDriver.FindElement(By.Name("username"));
            webDriver.FindElement(By.Name("username")).SendKeys(adminUsername);

            webDriver.FindElement(By.Name("password")).SendKeys(adminPassword);

            webDriver.FindElement(By.Name("login")).Click();

        }

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Quit();
        }
    }
}