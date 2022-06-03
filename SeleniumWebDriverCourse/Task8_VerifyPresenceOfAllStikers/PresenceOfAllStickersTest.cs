//Сделайте сценарий, проверяющий наличие стикеров у всех товаров в учебном приложении litecart
//на главной странице.
//Стикеры -- это полоски в левом верхнем углу изображения товара, на которых написано New или Sale
//или что-нибудь другое. 
//Сценарий должен проверять, что у каждого товара имеется ровно один стикер.

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Если возникают проблемы с выбором локаторов для поиска элементов -- обращайтесь в чат за помощью.

//Уложите созданный файл, содержащий сценарий, в ранее созданный репозиторий.
//В качестве ответа на задание отправьте ссылку на свой репозиторий и указание, какой именно файл содержит нужный сценарий.

using Litecart.UI.Client;
using Litecart.UI.Client.Pages.UserApp;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FirstProject
{
    public class PresenceOfAllStickersTest
    {
        public IWebDriver? Driver;

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/en/");
        }

        [Test]
        //[Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyThatAllImagesHaveStickers()
        {
            // Arrange
            HomePageLitecart homePage = new HomePageLitecart();

            // Act & Assert
            Assert.That(homePage.FindValuesOfStickersForImages(), Has.No.Null);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver?.Quit();
        }
    }
}