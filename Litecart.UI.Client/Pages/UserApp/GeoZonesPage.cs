using OpenQA.Selenium;
using Litecart.UI.Client.Helpers;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class GeoZonesPage: LitecartBasePage
    {
        public static string UrlGeoZones => "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
        IList<IWebElement> SelectedZonesList => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//td[3]//option[@selected]")).ToList();        
        IList<IWebElement> ListOfGeoZones => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//td[3]/a")).ToList();

        public void SelectEveryCountryAndVerifyThatZoneAreInAlphabeticalOrder()
        {
            for (int i= 0; i < ListOfGeoZones.Count; i++)          
            {
                ListOfGeoZones[i].Click();
                IList<IWebElement> selectedZonesList = DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//td[3]//option[@selected]")).ToList();
                AlphabeticalOrderSorting.VerifyThatItemsAreSortedInAlphabeticalOrder(selectedZonesList);
                DriverFactory.Driver.Navigate().Back();
            }
        }
    }
}
