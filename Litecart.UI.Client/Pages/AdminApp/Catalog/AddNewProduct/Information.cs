using FirstProject;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class Information
    {
        IWebElement Manufacturer => DriverFactory.Driver.FindElement(By.CssSelector("select[name='manufacturer_id']"));
        IWebElement Supplier => DriverFactory.Driver.FindElement(By.CssSelector("select[name='supplier_id']"));
        IWebElement Keywords => DriverFactory.Driver.FindElement(By.CssSelector("select[name='keywords']"));
        IWebElement ShortDescription => DriverFactory.Driver.FindElement(By.CssSelector("select[name='short_description[en]']"));
        IWebElement Description => DriverFactory.Driver.FindElement(By.CssSelector("select[name='description[en]']"));
        IWebElement HeadTitle => DriverFactory.Driver.FindElement(By.CssSelector("select[name='head_title[en]']"));
        IWebElement MetaDescription => DriverFactory.Driver.FindElement(By.CssSelector("select[name='meta_description[en]']"));
        IWebElement SaveButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name='save']"));
        
        public void FillInformationTabInfoForNewProduct()
        {

        }
    }
}
