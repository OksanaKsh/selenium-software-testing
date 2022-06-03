//Сделайте сценарии, которые проверяют сортировку стран и геозон (штатов)
//в учебном приложении litecart.

//1) на странице http://localhost/litecart/admin/?app=countries&doc=countries
//а) проверить, что страны расположены в алфавитном порядке
//б) для тех стран, у которых количество зон отлично от нуля -- открыть страницу этой страны и
//там проверить, что зоны расположены в алфавитном порядке

//2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
//зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке

using NUnit.Framework;
using OpenQA.Selenium;
using Litecart.UI.Client;
using Litecart.UI.Client.Pages.UserApp;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Pages.AdminApp;

namespace FirstProject
{
    public class SortCountries
    {
        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.StartBrowser("Chrome", CountriesPage.UrlCountries);            
        }

        [Test]
        //[Ignore("Ignore a test not ready yet")]
        public void CountriesAndZonesNameSorting()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginAdminApp("admin", "admin");

            // Arrange
            CountriesPage countriesPage = new CountriesPage();

            // Act && Assert
            AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(countriesPage.ListOfCountries);

            countriesPage.VerifyZonesAreSortedForCountryWhenAmountOfZonesGreaterThanZero();

            Driver.Navigate().GoToUrl(GeoZonesPage.UrlGeoZones);
            GeoZonesPage geoZonesPage = new GeoZonesPage();

            // Act && Assert
            geoZonesPage.SelectEveryCountryAndVerifyThatZoneAreInAlphabeticalOrder();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
