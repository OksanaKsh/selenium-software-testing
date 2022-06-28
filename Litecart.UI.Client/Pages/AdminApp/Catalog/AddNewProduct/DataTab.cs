using Litecart.UI.Client.Pages.AdminApp.AddNewProduct;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class DataTab
    {
        IWebElement DataTabElement => DriverFactory.Driver.FindElement(By.CssSelector("a[href ='#tab-data']"));
        public void Open()
        {
            DataTabElement.Click();
        }

        IWebElement SKU => DriverFactory.Driver.FindElement(By.CssSelector("input[name='sku']"));
        IWebElement GTIN => DriverFactory.Driver.FindElement(By.CssSelector("input[name='gtin']"));
        IWebElement TARIC => DriverFactory.Driver.FindElement(By.CssSelector("input[name='taric']"));
        IWebElement Weight => DriverFactory.Driver.FindElement(By.CssSelector("input[name='weight']"));
        IWebElement WeightMeasures => DriverFactory.Driver.FindElement(By.CssSelector("select[name='weight_class']"));
        IWebElement DimentionsWidth => DriverFactory.Driver.FindElement(By.CssSelector("input[name='dim_x']"));
        IWebElement DimentionsHeight => DriverFactory.Driver.FindElement(By.CssSelector("input[name='dim_y']"));
        IWebElement DimentionsLength => DriverFactory.Driver.FindElement(By.CssSelector("input[name='dim_z']"));
        IWebElement DimentionsMeasures => DriverFactory.Driver.FindElement(By.CssSelector("select[name='dim_class']"));
        IWebElement Attributes => DriverFactory.Driver.FindElement(By.CssSelector("textarea[name^='attributes'"));
        IWebElement SaveButton => DriverFactory.Driver.FindElement(By.CssSelector("button[name='save']"));

        public void SetWeight(DataProductDto dataProduct)//do we need to pas this argument?
        {
            Weight.Clear();
            Weight.SendKeys(dataProduct.Weight.ToString());
            SelectElement weightMeasure = new SelectElement(WeightMeasures);
            weightMeasure.SelectByValue(dataProduct.WeightMeasures);
        }

        public void SetDimentions(DataProductDto dataProduct)
        {
            DimentionsWidth.Clear();
            DimentionsHeight.Clear();
            DimentionsLength.Clear();

            DimentionsWidth.SendKeys(dataProduct.DimentionWidth.ToString());
            DimentionsHeight.SendKeys(dataProduct.DimentionHeight.ToString());
            DimentionsLength.SendKeys(dataProduct.DimentionLength.ToString());

            SelectElement dimentionsMeasure = new SelectElement(DimentionsMeasures);
            dimentionsMeasure.SelectByValue(dataProduct.DimentionMeasures);
        }

        public void FillDataInfoForNewProduct(DataProductDto dataProduct)
        {
            SKU.SendKeys(dataProduct.SKU);
            GTIN.SendKeys(dataProduct.GTIN);
            TARIC.SendKeys(dataProduct.TARIC);
            SetWeight(dataProduct);
            SetDimentions(dataProduct);
            Attributes.SendKeys(dataProduct.Attributes);
            SaveButton.Click(); 
        }
    }
}
