using OpenQA.Selenium;

namespace LitecartUITests
{
    public class Cart
    {
        public IWebElement Quantity => DriverFactory.Driver.FindElement(By.CssSelector("span.quantity"));
        public IWebElement Checkout => DriverFactory.Driver.FindElement(By.CssSelector("a[href='http://localhost/litecart/en/checkout'][class='link']"));
    }
}
