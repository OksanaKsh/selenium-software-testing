using OpenQA.Selenium;

namespace LitecartUITests
{
    public class AddNewProductPage
    {
        public  GeneralTab GeneralTab => new GeneralTab();
        public DataTab DataTab => new DataTab();
        public InformationTab InformationTab => new InformationTab();
        public ActionPanel ActionPanel => new ActionPanel();

        public IWebElement GeneralTabElement => DriverFactory.Driver.FindElement(By.CssSelector("a[href ='#tab-general']"));
        public IWebElement InformationTabElement => DriverFactory.Driver.FindElement(By.CssSelector("a[href ='#tab-information']"));
        public IWebElement DataTabElement => DriverFactory.Driver.FindElement(By.CssSelector("a[href ='#tab-data']"));
    }
}
