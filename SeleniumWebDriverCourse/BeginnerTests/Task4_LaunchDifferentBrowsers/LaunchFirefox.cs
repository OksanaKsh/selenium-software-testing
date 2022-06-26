//Сделайте сценарий для логина в панель администрирования учебного приложения http://localhost/litecart/admin/.

//Проверки можно пока никакие не делать, только действия -- заполнение полей, нажатия на кнопки и ссылки.

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Не забывайте о том, что браузер должен останавливаться, даже если возникли какие-либо ошибки во время выполнения сценария.

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace LitecartUITests
{
    public class LaunchFirefox
    {
        IWebDriver webDriver;
        WebDriverWait wait;

        string adminUsername = "admin";
        string adminPassword = "admin";



        [SetUp]
        public void Setup()
        {
            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            string absolutePathTOFirefoxDriver = "C:/Users/kshan/AppData/Local/Microsoft/WindowsApps/Mozilla.Firefox_n80bbvh6b1yt2/firefox.exe";

            //Run Full screen by the Help of commands using options
            FirefoxOptions options = new FirefoxOptions();
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            options.AddArguments("start-fullscreen");

            webDriver = new FirefoxDriver(currentDirName, options);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //webDriver.Manage().Timeouts().ImplicitWait(10, TimeUnit.Seconds);
            webDriver.Url = "http://localhost/litecart/admin/"; //open page (the same as get in Javascript)
            webDriver.Navigate();
            Thread.Sleep(3000);
        }

        [Test]
        public void Test()
        {
            try
            {

                webDriver.FindElement(By.Name("username")).SendKeys(adminUsername);

                webDriver.FindElement(By.Name("password")).SendKeys(adminPassword);

                webDriver.FindElement(By.Name("login")).Click();
            }
            catch (System.Exception)
            {
                webDriver.Quit();
            }

        }

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Quit();
        }
    }
}