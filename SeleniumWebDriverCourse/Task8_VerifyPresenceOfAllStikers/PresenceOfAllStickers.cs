//Сделайте сценарий, проверяющий наличие стикеров у всех товаров в учебном приложении litecart
//на главной странице.
//Стикеры -- это полоски в левом верхнем углу изображения товара, на которых написано New или Sale
//или что-нибудь другое. 
//Сценарий должен проверять, что у каждого товара имеется ровно один стикер.

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Если возникают проблемы с выбором локаторов для поиска элементов -- обращайтесь в чат за помощью.

//Уложите созданный файл, содержащий сценарий, в ранее созданный репозиторий.
//В качестве ответа на задание отправьте ссылку на свой репозиторий и указание, какой именно файл содержит нужный сценарий.

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace FirstProject
{
    public class PresenceOfAllStickers
    {
        IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Url = "http://localhost/litecart/en/"; //open page (the same as get in Javascript)
            webDriver.Navigate();
        }

        [Test]
        //[Ignore ("Ignore a test not ready yet")]
        public void Test()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //Find a list of images and verify that all item have stickers
            var listCategory = wait.Until(d => d.FindElements(By.CssSelector(".image-wrapper")));
            int listCount = listCategory.Count();

            for (int i = 0; i < listCount; i++)
            {
                var elementCollection = webDriver.FindElements(By.CssSelector(".image-wrapper"));
                var element = elementCollection[i];
                var sticker = element.FindElement(By.CssSelector("[class^='sticker']"));
                Assert.IsNotNull(sticker);
            }
        }

        //foreach
        //Assert Text of found element Assert That
        //Repeat []
        // Private methods usege (Assert)

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Quit();
        }
    }
}