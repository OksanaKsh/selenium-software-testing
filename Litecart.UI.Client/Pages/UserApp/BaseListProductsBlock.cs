using FirstProject.Dto;
using OpenQA.Selenium;

namespace FirstProject
{
    public class BaseListProductsBlock
    {
        public string Name { get; set; }
        public IWebElement Locator { get; set; }
        public List<ProductDetailsDto> ReadInfo()
        {

            return new List<ProductDetailsDto>();
        }
    }
}