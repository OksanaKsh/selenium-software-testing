using Litecart.UI.Client.Pages.UserApp.Dto;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.UserApp.Interfaces
{
    public interface IProductInfo
    {
        IWebElement ProductName { get;  }
        IWebElement RegularPrice { get;  }
        IWebElement CampaignPrice { get; }

        ProductDetailsDto ReadInfo() ;
    }
}
