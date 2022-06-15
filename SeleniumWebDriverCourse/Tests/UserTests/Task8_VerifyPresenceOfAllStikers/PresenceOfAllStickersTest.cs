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
using System.Collections.Generic;

namespace FirstProject
{
    public class PresenceOfAllStickersTest : UserBaseUiTest
    {

        [Test]
        //[Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyThatAllImagesHaveStickers()
        {
            // Arrange
            HomePageLitecart homePage = Site.HomePageLitecart;

            // Act & Assert
            //Assert.That(homePage.FindValuesOfStickersForImages(), Has.None.Null);
            Assert.That(homePage.FindValuesOfStickersForImagesLinq(), Has.None.Null);
        }
        [Test]
        public void VerifyThatAllImagesHaveStickersTest()
        {
            var list = new List<string>() { "123", null };

            // Act & Assert
            Assert.That(list, Has.None.Null);
        }
    }
}