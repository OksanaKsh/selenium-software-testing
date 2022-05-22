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
using Litecart.UI.Client;
using Litecart.UI.Client.Pages.AdminApp;
using SeleniumExtras.PageObjects;

namespace FirstProject
{
    public class MoveAlongAllMenuAdminPanelTest
    {
        public IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/admin/");
        }

        [Test]
        //[Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyThatEveryCategoryAndSubCategoryAreClickableAndHaveHeader()
        {
            //Login
            //PageFactory.InitElements(driver, this);
            LoginPage loginPage = new LoginPage(driver);
            PageFactory.InitElements(driver, loginPage);
            loginPage.LoginAdminApp("admin", "admin");

            // CategoryList
            HomePage homePage = new HomePage(driver);
            PageFactory.InitElements(driver, homePage);
            var list = homePage.MoveAlongListAndClickEveryElement(homePage.CategoryList);
            list.All((x) =>x != null);

            Assert.IsTrue(list.All((x) => x != null)); 

            //for (int i = 0; i < CategoryListCount; i++)
            //{
            //    var elementCollection = driver.FindElements(By.Id("app-"));
            //    var element = elementCollection[i];
            //    element.Click();

            //    var header = driver.FindElement(By.CssSelector("h1"));
            //    var headerText = header.Text;
            //    Assert.IsNotNull(headerText);

            //    // Move along Subcategory inside Category
            //    int subCategoryCount = driver.FindElements(By.CssSelector("[id^='doc-']")).Count();

            //    for (int j = 0; j < subCategoryCount; j++)
            //    {
            //        var subCategoryCollection = driver.FindElements(By.CssSelector("[id^='doc-']"));
            //        var subCategoryElement = subCategoryCollection[j];
            //        subCategoryElement.Click();

            //        var headerSubCategory = driver.FindElement(By.CssSelector("h1"));
            //        var headerheaderSubCategoryText = headerSubCategory.Text;
            //        Assert.IsNotNull(headerheaderSubCategoryText);
            //    }
            //}
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}