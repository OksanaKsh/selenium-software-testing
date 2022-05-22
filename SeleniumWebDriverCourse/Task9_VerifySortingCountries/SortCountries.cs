//Сделайте сценарии, которые проверяют сортировку стран и геозон (штатов)
//в учебном приложении litecart.

//1) на странице http://localhost/litecart/admin/?app=countries&doc=countries
//а) проверить, что страны расположены в алфавитном порядке
//б) для тех стран, у которых количество зон отлично от нуля -- открыть страницу этой страны и
//там проверить, что зоны расположены в алфавитном порядке

//2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
//зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;

namespace FirstProject
{
    public class SortCountries
    {
        IWebDriver webDriver;
        private ChromeDriver webDriverZones;
        WebDriverWait wait;

        string adminUsername = "admin";
        string adminPassword = "admin";

        [SetUp]
        public void Setup()
        {

            //clean
            string currentDirName = System.IO.Directory.GetCurrentDirectory();

            webDriver = new ChromeDriver(currentDirName);
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            webDriver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries"; //open page (the same as get in Javascript)
            webDriver.Navigate();


            //Rewrite takeaway
            webDriverZones = new ChromeDriver(currentDirName);
            wait = new WebDriverWait(webDriverZones, TimeSpan.FromSeconds(10));
            webDriverZones.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones"; //open page (the same as get in Javascript)
            webDriverZones.Navigate();

        }
        //проверить, что страны расположены в алфавитном порядке
        [Test]
        [Ignore("Ignore a test not ready yet")]
        public void CountriesNameSorting()
        {
            //Login
            webDriver.FindElement(By.Name("username")).SendKeys(adminUsername);
            webDriver.FindElement(By.Name("password")).SendKeys(adminPassword);
            webDriver.FindElement(By.Name("login")).Click();
            //Thread.Sleep(2000);


            // Rewrite country grid row
            //Verify that Name column was sorted right
            var table = webDriver.FindElement(By.CssSelector("[class='dataTable']"));
            var listOfCountries = table.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr/td[5]")).ToList();
            var listOfZones = table.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr/td[6]")).ToList();
            // remove td and t body
            //var listOfZonesGreate

            //Created Copy of Original Array by pass in Constructor parametr
            var beforeSortedCountriesbyName = new List<IWebElement>(listOfCountries);

            //Created Copy of Original Array and Sorted it by usage AddRange method
            var afterSortCountriesbyName = new List<IWebElement>();
            afterSortCountriesbyName.AddRange(listOfCountries);
            afterSortCountriesbyName.OrderBy(x => x.Text);

            //Verify that Original and Sorted arrays are equal
            for (int i = 0; i < listOfCountries.Count(); i++)
                Assert.AreEqual(beforeSortedCountriesbyName[i].Text, afterSortCountriesbyName[i].Text);

            //Rewrite string[] sarray = new string[] { "c", "b", "a" };
            //Assert.That(sarray, Is.Ordered.Descending);
        }


        [Test]
        [Ignore("Ignore a test not ready yet")]
        public void ZonesSortedWhenZoneAmountGreatedThanZero
            ()
        {
            //Login
            webDriver.FindElement(By.Name("username")).SendKeys(adminUsername);
            webDriver.FindElement(By.Name("password")).SendKeys(adminPassword);
            webDriver.FindElement(By.Name("login")).Click();
            Thread.Sleep(2000);

            //Verify that Name column was sorted right
            var table = webDriver.FindElement(By.CssSelector("[class='dataTable']"));
            var listOfZones = table.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr/td[6]")).ToList();

            foreach (var zone in listOfZones)
            {

                if (Int32.Parse(zone.ToString()) > 0)
                {
                    var countryWhenZoneGreaterThanZero = new List<IWebElement>();
                    //countryWhenZoneGreaterThanZero = zone.FindElement(By.XPath(/ preceding::a[1]));
                    //countryWhenZoneGreaterThanZero.previousSibling.innerHTML;
                }
            }
            ////Created Copy of Original Array by pass in Constructor parametr
            //var beforeSortedCountriesbyName = new List<IWebElement>(listOfCountries);

            ////Created Copy of Original Array and Sorted it by usage AddRange method
            //var afterSortCountriesbyName = new List<IWebElement>();
            //afterSortCountriesbyName.AddRange(listOfCountries);
            //afterSortCountriesbyName.OrderBy(x => x.Text);

            ////Verify that Original and Sorted arrays are equal
            //for (int i = 0; i < listOfCountries.Count(); i++)
            //    Assert.AreEqual(beforeSortedCountriesbyName[i].Text, afterSortCountriesbyName[i].Text);
        }

        ////2) на странице http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones
        //зайти в каждую из стран и проверить, что зоны расположены в алфавитном порядке
        [Test]
        //[Ignore("Ignore a test not ready yet")]
        public void ZonesAreOrderedForEveryCountry()
        {
            //Login
            webDriverZones.FindElement(By.Name("username")).SendKeys(adminUsername);
            webDriverZones.FindElement(By.Name("password")).SendKeys(adminPassword);
            webDriverZones.FindElement(By.Name("login")).Click();
            Thread.Sleep(2000);

            //Verify that Name column was sorted right
            //var table = webDriverZones.FindElement(By.CssSelector("form[name='geo_zones_form']"));
            var listOfCountries = webDriverZones.FindElements(By.XPath("//table[@class='dataTable']/tbody/tr/td[3]/a")).ToList();

            for (int i = 0; i < listOfCountries.Count; i++)
            {
                listOfCountries[i].Click();
                Thread.Sleep(2000);
                var nameOfPageTitle = webDriverZones.FindElement(By.CssSelector("h1")).GetAttribute("innerText");
                Assert.AreEqual(" Edit Geo Zone", nameOfPageTitle);

                var tableOfZones = webDriverZones.FindElement(By.CssSelector(".dataTable#table-zones"));
                var listOfZones = tableOfZones.FindElements(By.XPath($"//table[@class='dataTable']/td[3]contains[@a,'zones[{i}]]"));
                //Dropdown methods
                //Created Copy of Original Array of Zones by pass in Constructor parametr
                var beforeSortedZones = new List<IWebElement>(listOfZones);

                //Created Copy of Original Array of Zones and Sorted it by usage AddRange method
                var afterSortZonesbyName = new List<IWebElement>();
                afterSortZonesbyName.AddRange(listOfZones);
                afterSortZonesbyName.OrderBy(x => x.Text);

                //Verify that Original and Sorted arrays are equal
                for (int j = 0; j < listOfZones.Count(); j++)
                    Assert.AreEqual(beforeSortedZones[j].Text, afterSortZonesbyName[j].Text);
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            webDriver.Quit();
        }
    }
}