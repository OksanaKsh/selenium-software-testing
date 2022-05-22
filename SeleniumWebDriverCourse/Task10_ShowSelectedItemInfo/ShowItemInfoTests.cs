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


using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;

namespace FirstProject
{
    public class ShowItemInfoTests
    {
        IWebDriver webDriver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            webDriver.Url = "http://localhost/litecart/en/"; //open page (the same as get in Javascript)
            webDriver.Navigate();
        }

        [Test]
        //[Ignore ("Ignore a test not ready yet")]
        public void VerifyDataOnMainPageAndDetailedProductPageAreSame()
        {
            //MAIN PAGE
            //Find The campaign box/block(frame)
            var campains = webDriver.FindElement(By.CssSelector("#box-campaigns"));

            //!!! Rewrite FindElements and take the first
            //Regular price
            //Find first element Name and Prices in Campaign Box
            var productName = campains.FindElement(By.CssSelector(".product .name"));
            var productRegularPrice = campains.FindElement(By.CssSelector(".product .regular-price"));

            //в) Main Page: обычная цена зачёркнутая и серая (можно считать, что "серый" цвет это такой,
            //у которого в RGBa представлении одинаковые значения для каналов R, G и B)
            var colorRegularPriceMainPage = productRegularPrice.GetCssValue("color");
            var textDecorationRegularPriceMainPage = productRegularPrice.GetCssValue("text-decoration");

            //ParseColorRGB by using ColorHelper class
            Color cRegularMainPage = ColorHelper.ParseColor(colorRegularPriceMainPage);

            //Verify that the values of R,G, B are equal (grey color)
            Assert.AreEqual(cRegularMainPage.R, cRegularMainPage.G);
            Assert.AreEqual(cRegularMainPage.B, cRegularMainPage.G);
           // Assert.That

            //Verify that The price text is crossed
            Assert.IsTrue(textDecorationRegularPriceMainPage.Contains("line-through"));


            //Campaign price
            var productCampaignPrice = campains.FindElement(By.CssSelector(".product .campaign-price"));

            //г) акционная жирная и красная(можно считать, что "красный" цвет это такой,
            //у которого в RGBa представлении каналы G и B имеют нулевые значения)
            var colorCampaignRegularPriceMainPage = productCampaignPrice.GetCssValue("color");

            // ParseColorRGB by using ColorHelper class
            Color cCampaignMainPage = ColorHelper.ParseColor(colorCampaignRegularPriceMainPage);

            // Verify that values of G and B are equal to zero(red color)
            Assert.AreEqual(cCampaignMainPage.G, 0);
            Assert.AreEqual(cCampaignMainPage.B, 0);

            //Verify that campaign price is in Bold (or has value 700(bold value))
            var fontCampaignOnMainPage = productCampaignPrice.GetCssValue("font-weight");
            Assert.IsTrue(fontCampaignOnMainPage.Equals("bold") || fontCampaignOnMainPage.Equals("700"));
        //Assert that rewrite

            //д) акционная цена крупнее, чем обычная
            //(это тоже надо проверить на каждой странице независимо)
            var fontSizeOfRegularPriceMainPage = productRegularPrice.GetCssValue("font-size");
            var fontSizeOfCampaignPriceMainPage = productCampaignPrice.GetCssValue("font-size");
            var fontSizeOfRegularPriceMainPageValue = Double.Parse(fontSizeOfRegularPriceMainPage.Substring(0, fontSizeOfRegularPriceMainPage.Length - 2));
            var fontSizeOfCampaignPriceMainPageValue = Double.Parse(fontSizeOfCampaignPriceMainPage.Substring(0, fontSizeOfCampaignPriceMainPage.Length - 2));

            Assert.IsTrue(fontSizeOfCampaignPriceMainPageValue - fontSizeOfRegularPriceMainPageValue > 0);
            //Better use  assert That 

            //Define ProductName and Prices on Main page
            var nameOfProductOnMainPage = productName.GetAttribute("textContent");
            var regularPriceOfProductOnMainPage = productRegularPrice.GetAttribute("textContent");
            var campaignPriceOfProductOnMainPage = productCampaignPrice.GetAttribute("textContent");

            //DETAILED PRODUCT PAGE
            //Navigate to product Details page
            productName.Click();

            //Find the name of product in Title on detailed product page
            var titleOfProductOnDetailedPage = webDriver.FindElement(By.CssSelector("h1.title"));
            var nameOfProductOnDetailedPage = titleOfProductOnDetailedPage.GetAttribute("textContent");

            //Find the reqular nd campaign product prices on detailed product page
            var regularPriceOfProductOnDetailedPage = webDriver.FindElement(By.CssSelector(".regular-price")).GetAttribute("textContent");
            var campaingPriceOfProductOnDetailedPage = webDriver.FindElement(By.CssSelector(".campaign-price")).GetAttribute("textContent");

            //а) на главной странице и на странице товара совпадает текст названия товара
            //б) на главной странице и на странице товара совпадают цены (обычная и акционная)
            //Verify that name and prices of selected product on main and detailed view pages are equal
            Assert.AreEqual(nameOfProductOnMainPage, nameOfProductOnDetailedPage);
            Assert.AreEqual(regularPriceOfProductOnMainPage, regularPriceOfProductOnDetailedPage);

            Assert.AreEqual(campaignPriceOfProductOnMainPage, campaingPriceOfProductOnDetailedPage);
        }

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Quit();
        }
    }
}