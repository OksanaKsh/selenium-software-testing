//Сделайте сценарий для логина в панель администрирования учебного приложения http://localhost/litecart/admin/.

//Проверки можно пока никакие не делать, только действия -- заполнение полей, нажатия на кнопки и ссылки.

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Не забывайте о том, что браузер должен останавливаться, даже если возникли какие-либо ошибки во время выполнения сценария.

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace FirstProject
{
    public class LaunchEdge

    {
        IWebDriver webDriver;
        WebDriverWait wait;

        string adminUsername = "admin";
        string adminPassword = "admin";



        [SetUp]
        public void Setup()
        {
            string currentDirName = System.IO.Directory.GetCurrentDirectory();


            webDriver = new EdgeDriver(currentDirName);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

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