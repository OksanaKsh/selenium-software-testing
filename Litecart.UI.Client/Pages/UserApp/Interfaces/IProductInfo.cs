using FirstProject.Dto;
using OpenQA.Selenium;

namespace FirstProject.Interfaces
{
    public interface IProductInfo
    {
        IWebElement ProductName { get;  }
        IWebElement RegularPrice { get;  }
        IWebElement CampaignPrice { get; }
    }
}
