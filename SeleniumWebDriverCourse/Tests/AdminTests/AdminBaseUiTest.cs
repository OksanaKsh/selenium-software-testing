using NUnit.Framework;

namespace FirstProject
{
    public class AdminBaseUiTest
    {
        public AdminBasePage AdminSite { get; } =  new AdminBasePage(); 
        public void LoginAdminApp()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginAdminApp("admin", "admin");
        }

        [SetUp]
        public void Setup()
        {
            DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/admin/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            DriverFactory.CloseBrowser();
        }
    }
}
