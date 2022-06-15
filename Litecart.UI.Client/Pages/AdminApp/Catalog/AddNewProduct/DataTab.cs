using FirstProject;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class DataTab
    {
        IWebElement SKU => DriverFactory.Driver.FindElement(By.CssSelector("input[name='sku']"));
        IWebElement GTIN => DriverFactory.Driver.FindElement(By.CssSelector("input[name='gtin']"));
        IWebElement TARIC => DriverFactory.Driver.FindElement(By.CssSelector("input[name='taric']"));
        IWebElement Weight => DriverFactory.Driver.FindElement(By.CssSelector("input[name='weight']"));
        IWebElement WeightMeasures => DriverFactory.Driver.FindElement(By.CssSelector("select[name='weight_class']"));
        IWebElement DimentionsWidth => DriverFactory.Driver.FindElement(By.CssSelector("select[name='dim_x']"));
        IWebElement DimentionsHeight => DriverFactory.Driver.FindElement(By.CssSelector("select[name='dim_y']"));
        IWebElement DimentionsLength => DriverFactory.Driver.FindElement(By.CssSelector("select[name='dim_z']"));
        IWebElement DimentionsMeasures => DriverFactory.Driver.FindElement(By.CssSelector("select[name='dim_class']"));
        IWebElement Attributes => DriverFactory.Driver.FindElement(By.CssSelector("textarea[name='attributes[en]'"));    
        IWebElement SaveButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name='save']"));
        
        public void FillDataInfoForNewProduct()
        {

        }
    }
}
