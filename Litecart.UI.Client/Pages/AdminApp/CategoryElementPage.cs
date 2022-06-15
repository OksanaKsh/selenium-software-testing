using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace FirstProject
{
    public class CategoryElementPage : AdminBasePage
    {
         public IWebElement Header => DriverFactory.Driver.FindElement(By.CssSelector("h1"));
    }
}
