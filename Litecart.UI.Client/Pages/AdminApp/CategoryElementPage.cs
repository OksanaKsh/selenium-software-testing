using Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp
{
    public class CategoryElementPage : AdminBasePage
    {
         public IWebElement Header => DriverFactory.Driver.FindElement(By.CssSelector("h1"));
    }
}
