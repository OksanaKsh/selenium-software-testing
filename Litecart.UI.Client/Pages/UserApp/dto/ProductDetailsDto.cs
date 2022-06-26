using System.Drawing;
using LitecartUITests.dto;

namespace LitecartUITests.Dto
{
    public class ProductDetailsDto
    {
        public string? ProductName { get; set; }
        public RegularPriceDto? RegularPrice { get; set; }
        public CampaignPriceDto? CampaignPrice { get; set; }
    }
}
