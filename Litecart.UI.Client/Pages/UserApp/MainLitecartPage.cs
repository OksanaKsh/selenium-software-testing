using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class MainLitecartPage: LitecartBasePage
    {
        public LoginPanel LoginPanel => new LoginPanel();
      
        public CampaignBlockOnMainPage CampaignBlockOnMainPage => new CampaignBlockOnMainPage();

        public BaseListProductsBlock MostPopularBlock => new BaseListProductsBlock() { Name = "MostPopular" };
        public BaseListProductsBlock CampaignBlock => new BaseListProductsBlock() { Name = "Campaign" };
        public BaseListProductsBlock RecentlyViewedBlock => new BaseListProductsBlock() { Name = "RecentlyViewed" };
    }
}
