
using NUnit.Framework;

namespace FirstProject
{
    public class UserBaseUiTest
    {

        public LitecartBasePage Site { get; } = new LitecartBasePage();
      
        [SetUp]
        public void Setup()
        {
            DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/en/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            DriverFactory.CloseBrowser();
        }
    }
}
