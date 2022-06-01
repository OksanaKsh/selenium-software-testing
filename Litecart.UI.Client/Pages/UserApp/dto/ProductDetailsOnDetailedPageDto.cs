using System.Drawing;

namespace Litecart.UI.Client.Pages.UserApp.Dto
{
    public class ProductDetailsOnDetailedPageDto
    {
        public string ProductName { get; set; }

        //Regular Price
        public string RegularPrice { get; set; }
        public double RegularPriceFont { get; set; }
        public Color RegularPriceColor { get; set; }
        



        public bool IsLineThrough { get; set; }

        //Campaign price
        public string CampaignPrice { get; set; }
        public double CampaignPriceFont { get; set; }
        public Color CampaignPriceColor { get; set; }
        
        public bool IsFontBold { get; set; }
    }

    public class RegularPrice
    {
        public string Amount { get; set; }
        public double Font { get; set; }
        public Color Color { get; set; }
    }  
}
