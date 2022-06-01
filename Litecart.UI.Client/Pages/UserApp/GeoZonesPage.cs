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
    public class GeoZonesPage
    {
        public IWebDriver driver;
        public static string urlGeoZones = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
        IList<IWebElement> selectedZonesList = DriverFactory.driver.FindElements(By.XPath("//table[@class='dataTable']//td[3]//option[@selected]")).ToList();
        

        IList<IWebElement> listOfGeoZones = DriverFactory.driver.FindElements(By.XPath("//table[@class='dataTable']//td[3]/a")).ToList();
        public IList<IWebElement> ListOfGeoZones { get { return listOfGeoZones; } }

        public GeoZonesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        ////2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
        //зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке
        public void SelectEveryCountryAndVerifyThatZoneAreInAlphabeticalOrder()
        {
            foreach (var geoZone in ListOfGeoZones)
            {
                geoZone.Click();
                IList<IWebElement> selectedZonesList = DriverFactory.driver.FindElements(By.XPath("//table[@class='dataTable']//td[3]//option[@selected]")).ToList();
                AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(selectedZonesList);
            }
        }
    }
}
