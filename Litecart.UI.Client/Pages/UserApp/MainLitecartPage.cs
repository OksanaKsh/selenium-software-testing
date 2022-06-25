
namespace FirstProject
{
    public class MainLitecartPage : LitecartBasePage
    {
        public BaseListProductsBlock CampaignBlock => new BaseListProductsBlock()
        {
            Locator = "div#box-campaigns.box",
        };
        public BaseListProductsBlock MostPopularBlock => new BaseListProductsBlock()
        {
            Locator = "div[id='box-most-popular'][class='box']",
        };
        public Cart Cart => new Cart();
        public CheckoutPage CheckoutPage => new CheckoutPage(); 
    }
}
