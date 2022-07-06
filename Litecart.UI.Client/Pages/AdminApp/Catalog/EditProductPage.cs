
using Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog
{
    public class EditProductPage : AdminBasePage
    {
        public By EditProductHeader = By.XPath("//td/h1[contains(text(),' Edit Product:')]");
        public ActionPanel ActionPanel => new ActionPanel();
    }
}
