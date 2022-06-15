using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    public class CatalogPage
    {       
        public static string CatalogPageUrl = "http://localhost/litecart/admin/?app=catalog&doc=catalog";
        IWebElement AddNewProductButton = DriverFactory.Driver.FindElements(By.CssSelector("a.button"))[0];
    
        public void AddNewProduct()
        {
            AddNewProductButton.Click();

        }

        public void VerifyThatAddedProductIsPresentInTable()
        {

        } 
    }
}
