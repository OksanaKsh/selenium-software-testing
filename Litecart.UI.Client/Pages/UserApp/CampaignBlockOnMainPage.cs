using NUnit.Framework;
using OpenQA.Selenium;
using Litecart.UI.Client.Pages.UserApp.Dto;

namespace Litecart.UI.Client.Pages.UserApp
{
    public class CampaignBlockOnMainPage
    {
        public IWebDriver driver;

        public CampaignBlockOnMainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //List<IWebElement> listOfProductOnCampaignBlock = new List<IWebElement>();   
        //listOfProductOnCampaignBlock = driver.FindElements(By.CssSelector("#box-campaigns.box"));

        //Find product name in Campaign Block
        public IWebElement NameOfProductOnMainPage = DriverFactory.driver.FindElement(By.CssSelector("#box-campaigns.box .product .name"));

        //Find RegularPrice in Campaign Block
        IWebElement RegularPriceOfProductOnMainPage = DriverFactory.driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .regular-price"));

        //Find CampaignPrice in Campaign Block
        IWebElement CampaignPriceProductOnMainPage= DriverFactory.driver.FindElement(By.CssSelector("#box-campaigns.box .product .price-wrapper .campaign-price"));

        // Read Name, Regular and Campaign price from CampaignBlock OnMain Page
        public ProductDetailsOnMainPageDto ReadInfo()
        {
            return new ProductDetailsOnMainPageDto()
            {
                ProductName = NameOfProductOnMainPage.Text,// or .GetAttribute("textContent")
                RegularPrice = RegularPriceOfProductOnMainPage.Text,
                RegularPriceColor = ColorHelper.ParseColor(RegularPriceOfProductOnMainPage.GetCssValue("color")),
                IsLineThrough = RegularPriceOfProductOnMainPage.GetCssValue("text-decoration")!= null ? true : false,
                RegularPriceFont = Double.Parse(String.Concat(RegularPriceOfProductOnMainPage.GetCssValue("font-size").Reverse().Skip(2).Reverse())),

                CampaignPrice = CampaignPriceProductOnMainPage.Text,
                CampaignPriceFont = Double.Parse(String.Concat(CampaignPriceProductOnMainPage.GetCssValue("font-size").Reverse().Skip(2).Reverse())),
                CampaignPriceColor = ColorHelper.ParseColor(CampaignPriceProductOnMainPage.GetCssValue("color")),
                IsBold = CampaignPriceProductOnMainPage.GetCssValue("font-weight").Equals("700") ? true : false
            };
            }
        //Select the first product in Campaign block
        //public IWebElement SelectFirstElementInCampaign()
        //{
        //    return ListOfProductsInCampaign[0];
        //}


        //IWebElement firstProduct = ListOfProductsInCampaign[0]; - Why it is not allowed

    }

    }

