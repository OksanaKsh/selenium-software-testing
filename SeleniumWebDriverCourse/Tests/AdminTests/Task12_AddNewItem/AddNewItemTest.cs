﻿//Задание 12.Сделайте сценарий добавления товара
//Сделайте сценарий для добавления нового товара (продукта) в учебном приложении litecart (в админке).

//Для добавления товара нужно открыть меню Catalog,
//в правом верхнем углу нажать кнопку "Add New ProductInfo",
//заполнить поля с информацией о товаре и сохранить.

//Достаточно заполнить только информацию на вкладках General,
//Information и Prices. Скидки (Campains) на вкладке Prices можно не добавлять.

//Переключение между вкладками происходит не мгновенно,
//поэтому после переключения можно сделать небольшую паузу (о том, как делать более правильные ожидания, будет рассказано в следующих занятиях).

//Картинку с изображением товара нужно уложить в репозиторий вместе с кодом.
//При этом указывать в коде полный абсолютный путь к файлу плохо, на другой машине работать не будет. Надо средствами языка программирования преобразовать относительный путь в абсолютный.

//После сохранения товара нужно убедиться,
//что он появился в каталоге (в админке).
//Клиентскую часть магазина можно не проверять.
using NUnit.Framework;
namespace LitecartUITests
{
    public class AddNewItemTest : AdminBaseUiTest
    {
        [TestCaseSource(typeof(DataProviderNewProductTest1),nameof(DataProviderNewProductTest1.AddNewProductData))]       
        public void AddNewItem(GeneralProductDto generalProductInfo, InformationProductDto informationDataProduct, DataProductDto dataProduct)
        {
            // Arrange
            LoginAdminApp();
            DriverFactory.Driver.Navigate().GoToUrl(CatalogPage.CatalogPageUrl);
            CatalogPage catalogPage = this.AdminSite.CatalogPage;
            var ItemAmountBeforeTest = CatalogPage.ListOfProductCount;

            // Act
            catalogPage.AddNewProduct(generalProductInfo, informationDataProduct, dataProduct);

            // Arrange
            Assert.That(CatalogPage.ListOfProductCount - ItemAmountBeforeTest == 1, Is.True);
        }
    }
}
