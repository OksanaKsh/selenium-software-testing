using OpenQA.Selenium;

namespace FirstProject
{
    public class GeneralTab
    {
        IWebElement Status => DriverFactory.Driver.FindElement(By.CssSelector("input[name='status'][value='0']"));//? how to add value 1
        IWebElement NameInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name='name[en]']"));
        IWebElement CodeInput => DriverFactory.Driver.FindElement(By.CssSelector("input[name='code']"));
        IWebElement SelectCategories => DriverFactory.Driver.FindElement(By.CssSelector("input[type='checkbox'][name^='categories'][value='1']"));
        IWebElement DefaultCategory => DriverFactory.Driver.FindElement(By.CssSelector("select[name='default_category_id'] option[value='0']"));
        IWebElement Gender => DriverFactory.Driver.FindElement(By.CssSelector("input[type='checkbox'][name^='product_groups'][value='1-2']"));///???
        IWebElement Quantity => DriverFactory.Driver.FindElement(By.CssSelector("input[name='quantity']"));
        IWebElement QuantityUnit => DriverFactory.Driver.FindElement(By.CssSelector("input[name='quantity_unit_id']"));
        IWebElement DeliveryStatus => DriverFactory.Driver.FindElement(By.CssSelector("input[name='delivery_status_id']"));
        IWebElement SoldOutStatus => DriverFactory.Driver.FindElement(By.CssSelector("select[name='sold_out_status_id'] option[value='2']"));
        IWebElement UploadImages => DriverFactory.Driver.FindElement(By.CssSelector("input[name='new_images[]']"));
        IWebElement DateValidFrom => DriverFactory.Driver.FindElement(By.CssSelector("input[name='date_valid_from']"));
        IWebElement DateValidTo => DriverFactory.Driver.FindElement(By.CssSelector("input[name='date_valid_to']"));
        
        public void FillGeneralInfoForNewProduct(GeneralProductDto generalProductInfo)
        {
            Status.Click(); 
            NameInput.SendKeys(generalProductInfo.Name);
            CodeInput.SendKeys(generalProductInfo.Code);
            SelectCategories.Click();
            DefaultCategory.Click();
            Gender.Click();
            Quantity.Clear();
            Quantity.SendKeys(generalProductInfo.Quantity.ToString());
            SoldOutStatus.Click();
            UploadImages.SendKeys(generalProductInfo.UploadImages);
            DateValidFrom.SendKeys(generalProductInfo.DateValidFrom.ToString());  
            DateValidTo.SendKeys(generalProductInfo.DateValidTo.ToString()); 
        }
    }
}
