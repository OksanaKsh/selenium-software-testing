//Сделайте сценарий, который выполняет следующие действия в учебном приложении litecart.

//1) входит в панель администратора http://localhost/litecart/admin
//2) прокликивает последовательно все пункты меню слева, включая вложенные пункты
//3) для каждой страницы проверяет наличие заголовка (то есть элемента с тегом h1)

//Можно оформить сценарий либо как тест, либо как отдельный исполняемый файл.

//Если возникают проблемы с выбором локаторов для поиска элементов -- обращайтесь в чат за помощью.


using NUnit.Framework;

namespace SeleniumWebDriverCourse.AdminTests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class MoveAlongAllMenuAdminPanelTest: AdminBaseUiTest
    {
        [Test]
        //[Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void CategoryAndSubCategoryAreClickableAndHaveHeader()
        {
            // Arrange
            LoginAdminApp();

            // Act & Assert
            AdminSite.HomePage.EveryCategoryAndSubCategoryHasHeader();
        }
    }
}