using OpenQA.Selenium;
using Litecart.UI.Client.Helpers;

namespace LitecartUITests
{
    public class CountriesPage : LitecartBasePage
    {
        public static string UrlCountries => "http://localhost/litecart/admin/?app=countries&doc=countries";
        IList<IWebElement> TableRows => DriverFactory.Driver.FindElements(By.CssSelector("table.dataTable tr.row"));
        public static IList<IWebElement> ListOfCountries => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//td[5]")).ToList();
        IList<IWebElement> ListOfZones => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']/td[2]")).ToList();

        By zoneLocator = By.XPath(".//td[6]");
        By countryLocator = By.XPath(".//td[5]/a");

        public void VerifyZonesAreSortedForCountryWhenAmountOfZonesGreaterThanZero()
        {
            for (int i = 0; i < TableRows.Count; i++)
            {
                var zoneElement = TableRows[i].FindElement(zoneLocator).Text;

                if (Int32.Parse(zoneElement) > 0)
                {
                    TableRows[i].FindElement(countryLocator).Click();
                    AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(ListOfZones);
                    DriverFactory.Driver.Navigate().GoToUrl(UrlCountries);
                }
            }
        }
    }
}