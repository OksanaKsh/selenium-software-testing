using FirstProject;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class GeneralTab
    {
        IWebElement Status => DriverFactory.Driver.FindElement(By.CssSelector("input[name='status']"));//? how to add value 1
        IWebElement NameInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name='name[en]']"));
        IWebElement CodeInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name='code']"));
        IWebElement SelectCategories => DriverFactory.Driver.FindElement(By.CssSelector("input[name='categories[]']"));
        IWebElement DefaultCategory => DriverFactory.Driver.FindElement(By.CssSelector("input[name='default_category_id']"));
        IWebElement Gender => DriverFactory.Driver.FindElement(By.CssSelector(""));///???
        IWebElement Quantity => DriverFactory.Driver.FindElement(By.CssSelector("input[name='quantity']"));
        IWebElement QuantityUnit => DriverFactory.Driver.FindElement(By.CssSelector("input[name='quantity_unit_id']"));
        IWebElement DeliveryStatus => DriverFactory.Driver.FindElement(By.CssSelector("input[name='delivery_status_id']"));
        IWebElement SoldOutStatus => DriverFactory.Driver.FindElement(By.CssSelector("input[name='sold_out_status_id']"));
        IWebElement UploadImages => DriverFactory.Driver.FindElement(By.CssSelector("input[name='new_images[]']"));
        IWebElement DateValidFrom => DriverFactory.Driver.FindElement(By.CssSelector("input[name='date_valid_from']"));
        IWebElement DateValidTo => DriverFactory.Driver.FindElement(By.CssSelector("input[name='date_valid_to']"));
        IWebElement SaveButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name='save']"));
        
        public void FillGeneralInfoForNewProduct()
        {

        }
    }
}
