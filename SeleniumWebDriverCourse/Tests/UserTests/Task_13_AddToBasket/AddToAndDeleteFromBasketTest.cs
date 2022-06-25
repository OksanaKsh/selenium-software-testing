//Сделайте сценарий для добавления товаров в корзину и удаления товаров из корзины.

//1) открыть главную страницу
//2) открыть первый товар из списка
//2) добавить его в корзину (при этом может случайно добавиться товар, который там уже есть, ничего страшного)
//3) подождать, пока счётчик товаров в корзине обновится
//4) вернуться на главную страницу, повторить предыдущие шаги ещё два раза, чтобы в общей сложности в корзине было 3 единицы товара
//5) открыть корзину(в правом верхнем углу кликнуть по ссылке Checkout)
//6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица
using NUnit.Framework;

namespace FirstProject
{
    public class AddToAndDeleteFromBasketTest: UserBaseUiTest
    {
        [Test]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyAddingAndDeletingItemsToBasket()
        {

            // Arrange
            ProductDetailsPage productDetailsPage = Site.ProductDetailsPage;
            var cart = Site.MainLitecartPage.Cart;
            
            //Act
            productDetailsPage.AddingThreeItemsToCart(cart);

            Site.MainLitecartPage.CheckoutPage.RemoveAddedItems(cart);
        }
    }
}
