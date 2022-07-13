using Litecart.UI.Client.Helpers;
using Litecart.UI.Client.Helpers.Extensions.WebDriver;
using Litecart.UI.Client.Pages.AdminApp.AddNewProduct;
using Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog
{
    public class CatalogPage : AdminBasePage
    {
        public static string CatalogPageUrl => "http://localhost/litecart/admin/?app=catalog&doc=catalog";
        public static string CatalogWithGoodsUrl => CatalogPageUrl + "&category_id=1";
        //public static string CatalogWithGoodsUrl => "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";

        IWebElement AddNewProductButton => DriverFactory.Driver.FindElement(By.XPath("//a[@class='button'][contains(text(),' Add New Product')]"));
        public AddNewProductPage AddNewProductPage => new AddNewProductPage();
        public EditProductPage EditProductPage => new EditProductPage();
        public int ProductsCount => DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//tr")).ToList().Count;//how properly delete public if i need (ProductsCount) it in tests?

        public IList<IWebElement> ProductsNameList =>
            DriverFactory.Driver.FindElements(By.XPath("//table[@class='dataTable']//tr[@class='row']//td[3]/a[@href]"));

        public void AddNewProduct(GeneralProductDto generalProductInfo, InformationProductDto informationDataProduct, DataProductDto dataProduct)
        {
            AddNewProductButton.Click();
            this.CatalogPage.AddNewProductPage.GeneralTab.FillGeneralInfoForNewProduct(generalProductInfo);

            AddNewProductPage.InformationTab.Open();
            this.CatalogPage.AddNewProductPage.InformationTab.FillInformationTabInfoForNewProduct(informationDataProduct);

            AddNewProductPage.DataTab.Open();
            this.CatalogPage.AddNewProductPage.DataTab.FillDataInfoForNewProduct(dataProduct);
        }

        public IList<LogEntry> ReadLogs()
        {
            var currentBrowserLogs = BrowserLogging.VerifyMessagesAppearanceInBrowserLogs();
            ActionPanel.Cancel();
            return currentBrowserLogs;
        }
    }
}

