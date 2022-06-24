using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class MainLitecartPage : LitecartBasePage
    {
        public LoginPanel LoginPanel => new LoginPanel();

        public BaseListProductsBlock MostPopularBlock => new BaseListProductsBlock() { Name = "MostPopular" };
        public BaseListProductsBlock CampaignBlock => new BaseListProductsBlock( )
        {
            Name = "Campaign",
            Locator = DriverFactory.Driver.FindElement(By.CssSelector("div[id='box-campaigns'][class='box']"))
        };
        public BaseListProductsBlock RecentlyViewedBlock => new BaseListProductsBlock() { Name = "RecentlyViewed" };
    }
}
