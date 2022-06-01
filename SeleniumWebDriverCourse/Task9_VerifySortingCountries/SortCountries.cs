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
using SeleniumExtras.PageObjects;

namespace FirstProject
{
    public class SortCountries
    {
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/admin/?app=countries&doc=countries");
            
        }

        [Test]
        //[Ignore("Ignore a test not ready yet")]
        public void CountriesAndZonesNameSorting()
        {
            //Login
            //PageFactory.InitElements(driver, this);
            LoginPage loginPage = new LoginPage(driver);
            PageFactory.InitElements(driver, loginPage);
            loginPage.LoginAdminApp("admin", "admin");

            // Arrange
            CountriesPage countriesPage = new CountriesPage(driver);
            //GeoZonesPage geoZonesPage = new GeoZonesPage(driver);

            //проверить, что страны расположены в алфавитном порядке
            AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(countriesPage.ListOfCountries);

            //б) для тех стран, у которых количество зон отлично от нуля -- открыть страницу этой страны и
            //там проверить, что зоны расположены в алфавитном порядке
            countriesPage.VerifyZonesAreSortedForCountryWhereZonesGreaterThanZero();


            ////2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
            //зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке
            driver.Navigate().GoToUrl(GeoZonesPage.urlGeoZones);
            GeoZonesPage geoZonesPage = new GeoZonesPage(driver);
            
            geoZonesPage.SelectEveryCountryAndVerifyThatZoneAreInAlphabeticalOrder();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}
