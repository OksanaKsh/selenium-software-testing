using OpenQA.Selenium;

namespace LitecartUITests
{
    public class BaseListProductsBlock 
    {
        public string Name { get; set; }
        public string Locator { get; set; }
        public ProductCards ProductCards = new ProductCards();
    }
}