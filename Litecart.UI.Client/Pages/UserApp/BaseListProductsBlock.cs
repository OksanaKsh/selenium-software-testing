using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class BaseListProductsBlock 
    {
        string Name { get; set; }
        string Locator { get; set; }
        By ProductNameLocator => By.XPath(".//div[@class ='name']");
        By RegularPriceLocator => By.XPath(".//div[@class ='price-wrapper']/s[@class ='regular-price']");
        By CampaignPriceLocator => By.XPath(".//div[@class ='price-wrapper']/strong[@class ='campaign-price']");
        //public ProductCardInfo ProductCardInfo => new ProductCardInfo();

        public BaseListProductsBlock(string locator )
        {
                this.Locator = locator; 
        }
        public List<ProductCardInfo> Products
        {
            get
            {
                List<ProductCardInfo> products = new List<ProductCardInfo>();
                foreach (var item in ListOfProductElementsInSelectedBlock)
                {
                    products.Add(new ProductCardInfo()
                    {
                        ProductName = item.FindElement(ProductNameLocator),
                        RegularPrice = item.FindElement(RegularPriceLocator),
                        CampaignPrice = item.FindElement(CampaignPriceLocator)
                    });
                };
                return products;
            }
        }
       IList<IWebElement> ListOfProductElementsInSelectedBlock =>
            DriverFactory.Driver.FindElements(By.CssSelector("#box-campaigns.box li.product"));

    }
}