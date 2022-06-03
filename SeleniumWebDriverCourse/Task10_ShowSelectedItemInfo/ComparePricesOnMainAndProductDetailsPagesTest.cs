//Сделайте сценарий, который проверяет, что при клике на товар открывается правильная страница
//товара в учебном приложении litecart.

//Более точно, нужно открыть главную страницу, выбрать первый товар в блоке Campaigns
//и проверить следующее:

//а) на главной странице и на странице товара совпадает текст названия товара
//б) на главной странице и на странице товара совпадают цены (обычная и акционная)
//в) обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой,
//у которого в RGBa представлении одинаковые значения для каналов R, G и B)
//г) акционная жирная и красная (можно считать, что "красный" цвет это такой, у которого в RGBa
//представлении каналы G и B имеют нулевые значения)
//(цвета надо проверить на каждой странице независимо, при этом цвета на разных страницах могут
//не совпадать)
//д) акционная цена крупнее, чем обычная (это тоже надо проверить на каждой странице независимо)


using Litecart.UI.Client;
using Litecart.UI.Client.Pages.UserApp;
using Litecart.UI.Client.Pages.UserApp.Asserts;
using Litecart.UI.Client.Pages.UserApp.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FirstProject
{
    public class ComparePricesOnMainAndProductDetailsPagesTest
    {
        public IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/en/");
        }

        [Test]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyDataOnMainPageAndDetailedProductPageAreSame()
        {
            // Arrange
            CampaignBlockOnMainPage campaignBlockOnMainPage = new CampaignBlockOnMainPage();

            // Act 
            var mainPageInfo = campaignBlockOnMainPage.ReadInfo();
            campaignBlockOnMainPage.ProductName.Click();

            ProductDetailsPage productDetailsPage = new ProductDetailsPage();
            var detailedProductPageInfo = productDetailsPage.ReadInfo();
        
            //Assert
            Assert.That(mainPageInfo.ProductName, Is.EqualTo(detailedProductPageInfo.ProductName));

            Assert.That(mainPageInfo.RegularPrice.Amount, Is.EqualTo(detailedProductPageInfo.RegularPrice.Amount));

            AssertComparePrices.VerifyThatRegularPriceIsLineThrough(mainPageInfo);
            AssertComparePrices.VerifyThatRegularPriceIsLineThrough(detailedProductPageInfo);
            AssertComparePrices.VerifyThatRegularPriceIsGrey(mainPageInfo);
            AssertComparePrices.VerifyThatRegularPriceIsGrey(detailedProductPageInfo);

            AssertComparePrices.VerifyThatRegularPriceIsBold(mainPageInfo);
            AssertComparePrices.VerifyThatRegularPriceIsBold(detailedProductPageInfo);
            AssertComparePrices.VerifyThatCampaignPriceIsRed(mainPageInfo);
            AssertComparePrices.VerifyThatCampaignPriceIsRed(detailedProductPageInfo);

            AssertComparePrices.VerifyThatCampaignPriceFontIsGreaterThanRegularPriceFont(mainPageInfo);
            AssertComparePrices.VerifyThatCampaignPriceFontIsGreaterThanRegularPriceFont(detailedProductPageInfo);
            
        }

        [TearDown]
        public void СloseBrowser()
        {
            Driver.Quit();
        }


    }
}