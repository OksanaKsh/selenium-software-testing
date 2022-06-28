using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class BaseListProductsBlock 
    {
        public string Name { get; set; }
        public IWebElement Locator { get; set; }
        //public List<ProductInfo> Products;
        public IList<IWebElement> ListOfProductElementsInSelectedBlock => DriverFactory.Driver.FindElements(By.CssSelector("#box-campaigns.box li.product"));
        public ProductInfo ProductInfo = new ProductInfo();

        public BaseListProductsBlock()
        {
            ProductInfo.IdentifyProductInfo(ListOfProductElementsInSelectedBlock);
        }      

    }
}