using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class ActionPanel
    {    
        IWebElement SaveButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name='save']"));
        IWebElement CancelButton => DriverFactory.Driver.FindElement(By.Name("cancel"));
        IWebElement DeleteButton => DriverFactory.Driver.FindElement(By.Name("delete"));

        public void Save()
        {
            SaveButton.Click();
        }
        public void Cancel()
        {
            CancelButton.Click();
        }
    }
}
