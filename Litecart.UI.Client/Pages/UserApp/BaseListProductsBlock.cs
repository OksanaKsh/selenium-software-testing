using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class BaseListProductsBlock 
    {
        string Name { get; set; }
        string Locator { get; set; }

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
                    products.Add(new ProductCardInfo(item));

                }

                return products;;
            }
        }
        IList<IWebElement> ListOfProductElementsInSelectedBlock =>
            DriverFactory.Driver.FindElements(By.CssSelector("#box-campaigns.box li.product"));
        //ProductName = x.ProductName,
        //RegularPrice = x.RegularPrice,
        //CampaignPrice = x.CampaignPrice,
    }
}