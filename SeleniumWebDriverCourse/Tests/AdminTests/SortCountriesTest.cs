//Сделайте сценарии, которые проверяют сортировку стран и геозон (штатов)
//в учебном приложении litecart.

//1) на странице http://localhost/litecart/admin/?app=countries&doc=countries
//а) проверить, что страны расположены в алфавитном порядке
//б) для тех стран, у которых количество зон отлично от нуля -- открыть страницу этой страны и
//там проверить, что зоны расположены в алфавитном порядке

//2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
//зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке

using NUnit.Framework;
using Litecart.UI.Client.Helpers;

namespace LitecartUITests
{
    public class SortCountriesTest: AdminBaseUiTest
    {
        [Test]
        //[Ignore("Ignore a test not ready yet")]
        public void CountriesAndZonesNameSorting()
        {
            LoginAdminApp();
            DriverFactory.Driver.Navigate().GoToUrl(CountriesPage.UrlCountries);

            // Arrange
            CountriesPage countriesPage = AdminSite.CountriesPage;
            
            // Act && Assert
            AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(CountriesPage.ListOfCountries);

            countriesPage.VerifyZonesAreSortedForCountryWhenAmountOfZonesGreaterThanZero();

            DriverFactory.Driver.Navigate().GoToUrl(GeoZonesPage.UrlGeoZones);

            // Act && Assert
            GeoZonesPage.SelectEveryCountryAndVerifyThatZoneAreInAlphabeticalOrder();
        }
    }
}
