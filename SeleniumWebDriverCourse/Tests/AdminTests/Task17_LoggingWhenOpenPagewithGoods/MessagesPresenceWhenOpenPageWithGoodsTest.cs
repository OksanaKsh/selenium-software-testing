﻿//Сделайте сценарий, который проверяет, не появляются ли в логе браузера сообщения при открытии страниц в учебном приложении,
//а именно -- страниц товаров в каталоге в административной панели.

//    Сценарий должен состоять из следующих частей:

//1) зайти в админку
//2) открыть каталог, категорию, которая содержит товары (страница http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1)
//3) последовательно открывать страницы товаров и проверять, не появляются ли в логе браузера сообщения (любого уровня)

using System;
using System.Linq;
using Litecart.UI.Client;
using Litecart.UI.Client.Helpers.Extensions.WebDriver;
using Litecart.UI.Client.Pages.AdminApp.Catalog;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriverCourse.AdminTests;

namespace SeleniumWebDriverCourse.Tests.AdminTests.Task17_LoggingWhenOpenPagewithGoods
{
    public class MessagesPresenceWhenOpenPageWithGoodsTest:AdminBaseUiTest
    {
        [Test]
        //[Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void MessagesPresenceWhenOpenPageWithGoods()
        {
            // Arrange
            LoginAdminApp();
            DriverFactory.Driver.Navigate().GoToUrl(CatalogPage.CatalogWithGoodsUrl);

            // Act & Assert
            AdminSite.CatalogPage.OpenProductsOnCatalogPageAndVerifyLogs();
        }
    }
}
