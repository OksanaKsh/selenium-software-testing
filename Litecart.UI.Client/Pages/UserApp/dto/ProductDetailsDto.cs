using Litecart.UI.Client.Pages.UserApp.dto;
using System.Drawing;

namespace Litecart.UI.Client.Pages.UserApp.Dto
{
    public class ProductDetailsDto
    {
        public string? ProductName { get; set; }
        public RegularPriceDto? RegularPrice { get; set; }
        public CampaignPriceDto? CampaignPrice { get; set; }
    }
}
