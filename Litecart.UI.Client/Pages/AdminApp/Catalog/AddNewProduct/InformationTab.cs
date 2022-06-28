using Litecart.UI.Client.Pages.AdminApp.AddNewProduct;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class InformationTab
    {
        IWebElement ManufacturerDropdown => DriverFactory.Driver.FindElement(By.CssSelector("select[name='manufacturer_id']"));
        IWebElement Supplier => DriverFactory.Driver.FindElement(By.CssSelector("select[name='supplier_id']"));//? empty dropdown what to do when fill form , just do not touch?
        IWebElement Keywords => DriverFactory.Driver.FindElement(By.CssSelector("input[name='keywords']"));
        IWebElement ShortDescription => DriverFactory.Driver.FindElement(By.CssSelector("input[name^='short_description']"));
        IWebElement Description => DriverFactory.Driver.FindElement(By.CssSelector("textarea[name^='description']"));
        IWebElement HeadTitle => DriverFactory.Driver.FindElement(By.CssSelector("input[name^='head_title']"));
        IWebElement MetaDescription => DriverFactory.Driver.FindElement(By.CssSelector("input[name^='meta_description']"));
        
        public void SelectManufacturer(InformationProductDto informationDataProduct)
        {
            SelectElement manufacrurer = new SelectElement(ManufacturerDropdown);
            manufacrurer.SelectByText(informationDataProduct.Manufacturer);
        }

        public void FillInformationTabInfoForNewProduct(InformationProductDto informationDataProduct)
        {
            SelectManufacturer(informationDataProduct);
            Keywords.SendKeys(informationDataProduct.Keywords);
            ShortDescription.SendKeys(informationDataProduct.ShortDescription);
            Description.SendKeys(informationDataProduct.ShortDescription);
            HeadTitle.SendKeys(informationDataProduct.HeadTitle);   
            MetaDescription.SendKeys(informationDataProduct.MetaDescription);
        }
    }
}
