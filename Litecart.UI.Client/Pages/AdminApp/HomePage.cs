using Litecart.UI.Client.Pages.AdminApp.Catalog.AddNewProduct;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Litecart.UI.Client.Pages.AdminApp
{
    public class HomePage: AdminBasePage
    {
        IList<IWebElement> CategoryList => DriverFactory.Driver.FindElements(By.CssSelector("li#app-"));
        IList<IWebElement> SubCategoryList => DriverFactory.Driver.FindElements(By.CssSelector("[id^='doc-']"));

        public void  EveryCategoryAndSubCategoryHasHeader()
        {
            CategoryElementPage categoryPage = CategoryElementPage; 
  
            for (int i = 0; i < CategoryList.Count; i++)
            {
                var element = CategoryList[i];
                element.Click();
                Assert.That(categoryPage.Header.Text, Is.Not.Null);

                for (int j = 0; j < SubCategoryList.Count; j++)
                {
                    var subCategoryElement = SubCategoryList[j];
                    subCategoryElement.Click();
                    Assert.That(categoryPage.Header.Text, Is.Not.Null);
                }
            }
        }
    }
}
