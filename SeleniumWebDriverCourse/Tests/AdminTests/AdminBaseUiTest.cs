using Litecart.UI.Client;
using Litecart.UI.Client.Pages.AdminApp;
using Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace SeleniumWebDriverCourse.AdminTests
{
    public class AdminBaseUiTest
    {
        public Proxy Proxy;
        public AdminBasePage AdminSite  =>  new AdminBasePage(); 
        public void LoginAdminApp()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginAdminApp("admin", "admin");
        }

        [SetUp]
        public void Setup()
        {
            DriverFactory.SetProxy();
            DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/admin/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                //DriverFactory.Logging(DriverFactory.Driver);
                DriverFactory.MakeScreenshot(DriverFactory.Driver);
            }
            DriverFactory.CloseBrowser();
        }
    }
}
