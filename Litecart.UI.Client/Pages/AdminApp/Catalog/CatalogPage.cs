using OpenQA.Selenium;

namespace LitecartUITests
{
    public class CatalogPage:AdminBasePage
    {       
        public static string CatalogPageUrl => "http://localhost/litecart/admin/?app=catalog&doc=catalog";
        public IWebElement AddNewProductButton => DriverFactory.Driver.FindElement(By.CssSelector("a[class='button'][href='http://localhost/litecart/admin/?category_id=0&app=catalog&doc=edit_product']"));
        public AddNewProductPage AddNewProductPage => new AddNewProductPage();
        public static int ListOfProductCount => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//tr")).ToList().Count;
        
        public void AddNewProduct(GeneralProductDto generalProductInfo, InformationProductDto informationDataProduct, DataProductDto dataProduct)
        {
            AddNewProductButton.Click();
            this.CatalogPage.AddNewProductPage.GeneralTab.FillGeneralInfoForNewProduct(generalProductInfo);

            AddNewProductPage.InformationTabElement.Click();
            this.CatalogPage.AddNewProductPage.InformationTab.FillInformationTabInfoForNewProduct(informationDataProduct);

            AddNewProductPage.DataTabElement.Click();
            this.CatalogPage.AddNewProductPage.DataTab.FillDataInfoForNewProduct(dataProduct);
        }
    }
}
