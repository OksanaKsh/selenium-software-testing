using System.Drawing;

namespace Litecart.UI.Client.Pages.UserApp.dto
{
    public class ProductDetailsDto
    {
        public string? ProductName { get; set; }
        public RegularPriceDto? RegularPrice { get; set; }
        public CampaignPriceDto? CampaignPrice { get; set; }
        public PriceDto? Price { get; set; }    
    }
}
