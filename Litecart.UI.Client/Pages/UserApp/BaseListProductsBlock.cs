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
                List<ProductCardInfo> products = ListOfProductElementsInSelectedBlock.Select(x => new ProductCardInfo(x)).ToList();

                return products;;
            }
        }
        IWebElement CurrentBlock => DriverFactory.Driver.FindElement(By.CssSelector(Locator));
        IList<IWebElement> ListOfProductElementsInSelectedBlock => CurrentBlock.FindElements(By.XPath(".//li[@class='product column shadow hover-light']"));

    }
}