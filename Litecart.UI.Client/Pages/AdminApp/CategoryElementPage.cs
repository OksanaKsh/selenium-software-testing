using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Litecart.UI.Client.Pages.AdminApp
{
    public class CategoryElementPage : AdminBasePage
    {
         public IWebElement Header => DriverFactory.Driver.FindElement(By.CssSelector("h1"));
    }
}
