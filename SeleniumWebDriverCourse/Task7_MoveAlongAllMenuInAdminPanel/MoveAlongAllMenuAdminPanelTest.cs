//Сделайте сценарий, который выполняет следующие действия в учебном приложении litecart.

//1) входит в панель администратора http://localhost/litecart/admin
//2) прокликивает последовательно все пункты меню слева, включая вложенные пункты
//3) для каждой страницы проверяет наличие заголовка (то есть элемента с тегом h1)

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Если возникают проблемы с выбором локаторов для поиска элементов -- обращайтесь в чат за помощью.


using NUnit.Framework;
using OpenQA.Selenium;
using Litecart.UI.Client;
using Litecart.UI.Client.Pages.AdminApp;
using SeleniumExtras.PageObjects;

namespace FirstProject
{
    public class MoveAlongAllMenuAdminPanelTest
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/admin/");
        }

        [Test]
        //[Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void CategoryAndSubCategoryAreClickableAndHaveHeader()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginAdminApp("admin", "admin");

            // Arrange
            HomePage homePage = new HomePage();

            // Act & Assert
            homePage.EveryCategoryAndSubCategoryHasHeader();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}