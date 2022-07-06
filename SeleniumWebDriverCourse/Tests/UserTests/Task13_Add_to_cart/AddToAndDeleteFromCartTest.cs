//Сделайте сценарий для добавления товаров в корзину и удаления товаров из корзины.

//1) открыть главную страницу
//2) открыть первый товар из списка
//2) добавить его в корзину (при этом может случайно добавиться товар, который там уже есть, ничего страшного)
//3) подождать, пока счётчик товаров в корзине обновится
//4) вернуться на главную страницу, повторить предыдущие шаги ещё два раза, чтобы в общей сложности в корзине было 3 единицы товара
//5) открыть корзину(в правом верхнем углу кликнуть по ссылке Checkout)
//6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица

using Litecart.UI.Client;
using Litecart.UI.Client.Helpers.Extensions.String;
using Litecart.UI.Client.Helpers.Extensions.WebDriver;
using Litecart.UI.Client.Pages.UserApp;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumWebDriverCourse.UserTests;

namespace SeleniumWebDriverCourse.Tests.UserTests.Task13_Add_to_cart
{
    public class AddToAndDeleteFromCartTest : UserBaseUiTest
    {
        //[Repeat(5)]
        [Test]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyAddingAndDeletingItemsToBasket()
        {

            // Arrange
            var cart = Site.MainLitecartPage.Cart;

            //Act
            //Site.ProductDetailsPage.AddingThreeItemsToCart(cart);

            for (int i = 0; i < 3; i++)
            {
                Site.MainLitecartPage.MostPopularBlock.Products[0].ProductName.Click();
                var currentProductDetails = Site.MainLitecartPage.ProductDetailsPage;
                var initialQuantity = cart.Quantity.Text.ToInt();

                if (DriverFactory.Driver.IsElementExists(currentProductDetails.SizeDropdown))
                {
                    new SelectElement(currentProductDetails.SizeDropdownElement).SelectByIndex(1);
                }

                currentProductDetails.AddItemToCart();

                DriverFactory.Wait.Until(ExpectedConditions.TextToBePresentInElement(cart.Quantity, (initialQuantity + 1).ToString()));
                DriverFactory.Driver.Navigate().GoToUrl("http://localhost/litecart/en/");
                DriverFactory.Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[id='box-account-login']")));
            }
            Site.MainLitecartPage.CheckoutPage.RemoveAddedItems(cart);
        }
    }
}
