using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class BaseListProductsBlock 
    {
        string Name { get; set; }
        string Locator { get; set; }
        public ProductInfo ProductInfo => new ProductInfo();

        public BaseListProductsBlock(string locator )
        {
                this.Locator = locator; 
        }

    }
}