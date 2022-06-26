using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace LitecartUITests
{
    public class CategoryElementPage : AdminBasePage
    {
         public IWebElement Header => DriverFactory.Driver.FindElement(By.CssSelector("h1"));
    }
}
