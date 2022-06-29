using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class BaseListProductsBlock 
    {
        public string Name { get; set; }
        public IWebElement Locator { get; set; }
        public ProductInfo ProductInfo => new ProductInfo();

    }
}