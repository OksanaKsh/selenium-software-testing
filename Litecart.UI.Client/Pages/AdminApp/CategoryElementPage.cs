using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Litecart.UI.Client.Pages.AdminApp
{
    public class CategoryElementPage
    {
        IWebDriver driver;

        public CategoryElementPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "h1")]
        public IWebElement Header { get; set; }

    }
}
