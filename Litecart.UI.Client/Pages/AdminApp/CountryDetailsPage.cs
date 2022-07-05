using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct;
using Litecart.UI.Client.Pages.UserApp;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Litecart.UI.Client.Pages.AdminApp
{
    public class CountryDetailsPage : AdminBasePage
    {
        private IList<IWebElement> ArrowLinks =>
            DriverFactory.Driver.FindElements(
                (By.XPath("//td[@id='content']//form[@method='post']//i[@class='fa fa-external-link']")));
        public void VerifyThatArrowLinkOpenNewWindow()
        {
            foreach (var link in ArrowLinks)
            {
                var MainWindow = DriverFactory.Driver.CurrentWindowHandle;
                ICollection<string> OldWindows = DriverFactory.Driver.WindowHandles;
                link.Click();
                DriverFactory.Wait.Until(x => x.WindowHandles.Count > OldWindows.Count);
                var NewWindow = DriverFactory.Driver.WindowHandles.Except(OldWindows).Single();
                DriverFactory.Driver.SwitchTo().Window(NewWindow);
                DriverFactory.Driver.Close();
                DriverFactory.Driver.SwitchTo().Window(MainWindow);
            }
        }
    }
}
