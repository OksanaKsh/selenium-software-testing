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
using NUnit.Framework;
using OpenQA.Selenium;

namespace FirstProject
{
    public class CompareProductDetailsOnMainAndProductDetailsPagesTests
    {
        public IWebDriver driver;
        //WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.StartBrowser("Chrome", "http://localhost/litecart/en/");
        }

        [Test]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyDataOnMainPageAndDetailedProductPageAreSame()
        {
            // Arrange?
            CampaignBlockOnMainPage campaignBlockOnMainPage = new CampaignBlockOnMainPage(driver);

            // Act 
            var mainPage = campaignBlockOnMainPage.ReadInfo();
            campaignBlockOnMainPage.NameOfProductOnMainPage.Click();

            ProductDetailsPage productDetailsPage = new ProductDetailsPage(driver);
            var detailedProductPage = productDetailsPage.ReadInfo();

            //Assert
            //а) на главной странице и на странице товара совпадает текст названия товара           
            Assert.AreEqual(mainPage.ProductName, detailedProductPage.ProductName);

            //б) на главной странице и на странице товара совпадают цены (обычная и акционная)
            Assert.AreEqual(mainPage.RegularPrice, detailedProductPage.RegularPrice);

            //в) обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой,
            //у которого в RGBa представлении одинаковые значения для каналов R, G и B)
            Assert.True(mainPage.IsLineThrough);
            Assert.True(detailedProductPage.IsLineThrough);
            Assert.AreEqual(mainPage.RegularPriceColor.R, mainPage.RegularPriceColor.G);
            Assert.AreEqual(mainPage.RegularPriceColor.R, mainPage.RegularPriceColor.B);
            Assert.AreEqual(detailedProductPage.RegularPriceColor.R, detailedProductPage.RegularPriceColor.G);
            Assert.AreEqual(detailedProductPage.RegularPriceColor.R, detailedProductPage.RegularPriceColor.B);

            //г) акционная жирная и красная (можно считать, что "красный" цвет это такой, у которого в RGBa
            //представлении каналы G и B имеют нулевые значения)
            Assert.True(mainPage.IsBold);
            Assert.AreEqual(0, mainPage.CampaignPriceColor.G);
            Assert.AreEqual(0, mainPage.CampaignPriceColor.B);

            Assert.True(detailedProductPage.IsBold);
            Assert.AreEqual(0, detailedProductPage.CampaignPriceColor.G);
            Assert.AreEqual(0, detailedProductPage.CampaignPriceColor.B);

            //д) акционная цена крупнее, чем обычная (это тоже надо проверить на каждой странице независимо)
            Assert.Greater(mainPage.CampaignPriceFont, mainPage.RegularPriceFont);
            Assert.Greater(detailedProductPage.CampaignPriceFont, detailedProductPage.RegularPriceFont);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }


    }
}