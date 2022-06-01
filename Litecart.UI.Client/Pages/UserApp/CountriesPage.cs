using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using SeleniumExtras.PageObjects;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Litecart.UI.Client.Helpers;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class CountriesPage
    {
        public IWebDriver driver;

        public CountriesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Country

        IList<IWebElement> tableRows = DriverFactory.driver.FindElements(By.CssSelector("table.dataTable tr.row"));
        IList<IWebElement> listOfCountries = DriverFactory.driver.FindElements(By.XPath("//table[@class='dataTable']//td[5]")).ToList();
        public IList<IWebElement> ListOfCountries { get { return listOfCountries; } }
        By zoneLocator = By.XPath("//table[@class='dataTable']//td[6]");
        By countryLocator = By.XPath("//table[@class='dataTable']//td[5]/a");

        // Edit Countries page 
        IList<IWebElement> tableOfZones = DriverFactory.driver.FindElements(By.CssSelector(".dataTable#table-zones"));
        IList<IWebElement> listOfZones = DriverFactory.driver.FindElements(By.XPath("//table[@class='dataTable']/td[2]")).ToList();
        public IList<IWebElement> ListOfZones { get { return listOfZones; } }

        // для тех стран, у которых количество зон отлично от нуля -- открыть страницу этой страны и
        //там проверить, что зоны расположены в алфавитном порядке
        
        public void VerifyZonesAreSortedForCountryWhereZonesGreaterThanZero()
        {
            var testVariable = tableRows.Where(row => int.Parse(row.FindElement(zoneLocator).Text) > 0).ToList();
            foreach (var row in tableRows.Where(row => int.Parse(row.FindElement(zoneLocator).Text) > 0))
            {
                row.FindElement(countryLocator).Click();
                AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(listOfZones);
            }
        }

        //public void VerifyZonesAreSortedForCountryWhereZonesGreaterThanZero()
        //{
        //    foreach (var row in tableRows)
        //    {
        //        if (int.Parse(row.FindElement(zoneLocator).Text) > 0)
        //        {
        //            row.FindElement(countryLocator).Click();
        //            AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(listOfZones);
        //        }
        //    }
        //}

        ////Version 2
        //public void Test()
        //{

        //    foreach (var zone in listOfZones)
        //    {

        //        if (Int32.Parse(zone.Text) > 0)
        //        {
        //            //var countryWhenZoneGreaterThanZero = new List<IWebElement>();
        //            IWebElement countryWhenZoneGreaterThanZero = zone.FindElement(By.XPath("{zone}/preceding-sibling::a[1])"));
        //            countryWhenZoneGreaterThanZero.Click();


        //        }
        //        IWebElement countryWhenZoneGreaterThanZero1 = zone.FindElement(By.XPath(String.Format("{0}/preceding-sibling::a[1]", zone)));
        //    }
        //}
    }
}