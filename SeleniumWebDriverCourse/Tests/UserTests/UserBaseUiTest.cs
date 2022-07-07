
using Litecart.UI.Client;
using Litecart.UI.Client.Pages.UserApp;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace SeleniumWebDriverCourse.UserTests
{
    public class UserBaseUiTest
    {
        public string MainPageUrl => "http://localhost/litecart/en/";
        public LitecartBasePage Site => new LitecartBasePage();
      
        [SetUp]
        public void Setup()
        {
            DriverFactory.StartBrowser("Chrome", MainPageUrl);
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                DriverFactory.MakeScreenshot(DriverFactory.Driver);
            }
            DriverFactory.CloseBrowser();
        }
    }
}
