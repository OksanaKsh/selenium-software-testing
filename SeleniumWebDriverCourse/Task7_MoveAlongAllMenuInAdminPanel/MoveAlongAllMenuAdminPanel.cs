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
using System.Linq;

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
        }

        [Test]
        [Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void Test()
        {
            //Login
            webDriver.FindElement(By.Name("username")).SendKeys(adminUsername);
            webDriver.FindElement(By.Name("password")).SendKeys(adminPassword);
            webDriver.FindElement(By.Name("login")).Click();

            //Move along category
            var listCategory = webDriver.FindElements(By.CssSelector("li#app-"));
            int listCount = listCategory.Count();

            for (int i = 0; i < listCount; i++)
            {
                var elementCollection = webDriver.FindElements(By.Id("app-"));
                var element = elementCollection[i];
                element.Click();

                var header = webDriver.FindElement(By.CssSelector("h1"));
                var headerText = header.Text;
                Assert.IsNotNull(headerText);

                // Move along Subcategory inside Category
                int subCategoryCount = webDriver.FindElements(By.CssSelector("[id^='doc-']")).Count();

                for (int j = 0; j < subCategoryCount; j++)
                {
                    var subCategoryCollection = webDriver.FindElements(By.CssSelector("[id^='doc-']"));
                    var subCategoryElement = subCategoryCollection[j];
                    subCategoryElement.Click();

                    var headerSubCategory = webDriver.FindElement(By.CssSelector("h1"));
                    var headerheaderSubCategoryText = headerSubCategory.Text;
                    Assert.IsNotNull(headerheaderSubCategoryText);
                }
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Quit();
        }
    }
}