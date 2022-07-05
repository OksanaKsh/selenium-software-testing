//Сделайте сценарий, который проверяет, что ссылки на странице редактирования страны открываются в новом окне.

//    Сценарий должен состоять из следующих частей:

//1) зайти в админку
//2) открыть пункт меню Countries (или страницу http://localhost/litecart/admin/?app=countries&doc=countries)
//3) открыть на редактирование  или начать создание какую-нибудь странуновой
//4) возле некоторых полей есть ссылки с иконкой в виде квадратика со стрелкой -- они ведут на внешние страницы и открываются в новом окне, именно это и нужно проверить.

//    Конечно, можно просто убедиться в том, что у ссылки есть атрибут target="_blank". Но в этом упражнении требуется именно кликнуть по ссылке, чтобы она открылась в новом окне, потом переключиться в новое окно, закрыть его, вернуться обратно, и повторить эти действия для всех таких ссылок.

//    Не забудьте, что новое окно открывается не мгновенно, поэтому требуется ожидание открытия окна.
//using System;
using Litecart.UI.Client;
using Litecart.UI.Client.Pages.AdminApp;
using NUnit.Framework;
using SeleniumWebDriverCourse.AdminTests;

namespace SeleniumWebDriverCourse.Tests.AdminTests.Task12_AddNewItem
{
    public class CountriesLinksOpenedInNewWindowTest: AdminBaseUiTest
    {
        [Test]
        //[Repeat(5)]
        //[Ignore ("Ignore a test not ready yet")]
        public void CountriesLinksOpenedInNewWindow()
        {
            // Arrange
            LoginAdminApp();
            var countryPage = this.AdminSite.CountriesPage;
            DriverFactory.Driver.Navigate().GoToUrl(countryPage.UrlCountries);

            // Act & Assert
            countryPage.SelectRandomCountry().VerifyThatArrowLinkOpenNewWindow();
        }
    }
}
