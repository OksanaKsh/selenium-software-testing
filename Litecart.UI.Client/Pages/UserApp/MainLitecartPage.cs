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
        public CampaignBlockOnMainPage CampaignBlockOnMainPage => new CampaignBlockOnMainPage();
    }
}
