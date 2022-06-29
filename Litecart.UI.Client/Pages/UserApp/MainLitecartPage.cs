using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class MainLitecartPage : LitecartBasePage
    {
        public LoginPanel LoginPanel => new LoginPanel();
        public BaseListProductsBlock CampaignBlock => new BaseListProductsBlock( )
        {
            Locator = DriverFactory.Driver.FindElement(By.CssSelector("div[id='box-campaigns'][class='box']")),
        };
    }
}
