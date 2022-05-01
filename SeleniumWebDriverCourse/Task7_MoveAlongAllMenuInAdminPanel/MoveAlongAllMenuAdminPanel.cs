//Сделайте сценарий, который выполняет следующие действия в учебном приложении litecart.

//1) входит в панель администратора http://localhost/litecart/admin
//2) прокликивает последовательно все пункты меню слева, включая вложенные пункты
//3) для каждой страницы проверяет наличие заголовка (то есть элемента с тегом h1)

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Если возникают проблемы с выбором локаторов для поиска элементов -- обращайтесь в чат за помощью.


using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace FirstProject
{
    public class MoveAlongAllMenuAdminPanel
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
        [Ignore ("Ignore a test not ready yet")]
        public void Test()
        {
            try
            {
                //Login
                webDriver.FindElement(By.Name("username")).SendKeys(adminUsername);

                webDriver.FindElement(By.Name("password")).SendKeys(adminPassword);

                webDriver.FindElement(By.Name("login")).Click();
                Thread.Sleep(2000);

                //Move along category
                ReadOnlyCollection<IWebElement> listCategory = webDriver.FindElements(By.Id("app-"));
                foreach(IWebElement element in listCategory) 
                {
                    element.Click();
                    Thread.Sleep(2000);
                } ReadOnlyCollection<IWebElement> listSubCategory = webDriver.FindElements(By.CssSelector("[id^=doc-]"));
                foreach(IWebElement element in listSubCategory) 
                {
                    element.Click();
                    Thread.Sleep(2000);
                }

                //section[//h1[@id='hi']] 
                //webDriver.FindElement(By.Name("Appearence")).Click();
                //webDriver.FindElement(By.Name("Template")).Click();


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