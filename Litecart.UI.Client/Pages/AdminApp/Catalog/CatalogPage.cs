using Litecart.UI.Client.Pages.AdminApp.AddNewProduct;
using Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog
{
    public class CatalogPage: AdminBasePage
    {
        public string CatalogPageUrl => "http://localhost/litecart/admin/?app=catalog&doc=catalog";
        public string CatalogWithGoodsUrl => "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
        IWebElement AddNewProductButton => DriverFactory.Driver.FindElement(By.XPath("//a[@class='button'][contains(text(),' Add New Product')]"));
        public AddNewProductPage AddNewProductPage => new AddNewProductPage();
        public int ProductsCount => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//tr")).ToList().Count;//how properly delete public if i need (ProductsCount) it in tests?
        
        public void AddNewProduct(GeneralProductDto generalProductInfo, InformationProductDto informationDataProduct, DataProductDto dataProduct)
        {
            AddNewProductButton.Click();
            this.CatalogPage.AddNewProductPage.GeneralTab.FillGeneralInfoForNewProduct(generalProductInfo);

            AddNewProductPage.InformationTab.Open();
            this.CatalogPage.AddNewProductPage.InformationTab.FillInformationTabInfoForNewProduct(informationDataProduct);

            AddNewProductPage.DataTab.Open();
            this.CatalogPage.AddNewProductPage.DataTab.FillDataInfoForNewProduct(dataProduct);
        }
    }
}
