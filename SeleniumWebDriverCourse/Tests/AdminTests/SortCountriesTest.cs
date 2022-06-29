//Сделайте сценарии, которые проверяют сортировку стран и геозон (штатов)
//в учебном приложении litecart.

//1) на странице http://localhost/litecart/admin/?app=countries&doc=countries
//а) проверить, что страны расположены в алфавитном порядке
//б) для тех стран, у которых количество зон отлично от нуля -- открыть страницу этой страны и
//там проверить, что зоны расположены в алфавитном порядке

//2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
//зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке

using Litecart.UI.Client;
using NUnit.Framework;
using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Pages.UserApp;

namespace SeleniumWebDriverCourse.AdminTests
{
    public class SortCountriesTest: AdminBaseUiTest
    {
        [Test]
        //[Ignore("Ignore a test not ready yet")]
        public void CountriesAndZonesNameSorting()
        {
            LoginAdminApp();

            // Arrange
            CountriesPage countriesPage = AdminSite.CountriesPage;
            DriverFactory.Driver.Navigate().GoToUrl(countriesPage.UrlCountries);

            // Act && Assert
            AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(countriesPage.ListOfCountries);

            countriesPage.VerifyZonesAreSortedForCountryWhenAmountOfZonesGreaterThanZero();

            DriverFactory.Driver.Navigate().GoToUrl(GeoZonesPage.UrlGeoZones);

            // Act && Assert
            this.AdminSite.GeoZonesPage.SelectEveryCountryAndVerifyThatZoneAreInAlphabeticalOrder();
        }
    }
}
