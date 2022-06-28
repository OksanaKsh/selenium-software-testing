using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct
{
    public class AddNewProductPage
    {
        public GeneralTab GeneralTab => new GeneralTab();
        public DataTab DataTab => new DataTab();
        public InformationTab InformationTab => new InformationTab();
        public ActionPanel ActionPanel => new ActionPanel();

    }
}
