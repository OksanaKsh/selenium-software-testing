using OpenQA.Selenium;

namespace FirstProject
{
    public class CatalogPage:AdminBasePage
    {       
        public static string CatalogPageUrl => "http://localhost/litecart/admin/?app=catalog&doc=catalog";
        public IWebElement AddNewProductButton => DriverFactory.Driver.FindElement(By.CssSelector("a[class='button'][href='http://localhost/litecart/admin/?category_id=0&app=catalog&doc=edit_product']"));
        public AddNewProductPage AddNewProductPage => new AddNewProductPage();
        public static int ListOfProductCount => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//tr")).ToList().Count;
       
        public static int GetInitialListCount()  // How to write inital value in property?
        { return ListOfProductCount; }
        int initialProductCount;
        public void AddNewProduct(GeneralProductDto generalProductInfo, InformationProductDto informationDataProduct, DataProductDto dataProduct)
        {
            initialProductCount = GetInitialListCount();
            AddNewProductButton.Click();
            GeneralTab generalTab = this.CatalogPage.AddNewProductPage.GeneralTab;
            generalTab.FillGeneralInfoForNewProduct(generalProductInfo);

            AddNewProductPage.InformationTabElement.Click();
            InformationTab informationTab = this.CatalogPage.AddNewProductPage.InformationTab; ;
            informationTab.FillInformationTabInfoForNewProduct(informationDataProduct);

            AddNewProductPage.DataTabElement.Click();
            DataTab dataTab = this.CatalogPage.AddNewProductPage.DataTab;
            dataTab.FillDataInfoForNewProduct(dataProduct);

            //ActionPanel action = this.ActionPanel;
            //action.Save();
        }

        public bool VerifyThatAddedProductIsPresentInTable()
        {
            if (ListOfProductCount > initialProductCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
