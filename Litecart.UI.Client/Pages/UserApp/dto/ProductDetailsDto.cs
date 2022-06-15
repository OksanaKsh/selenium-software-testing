using FirstProject.dto;
using System.Drawing;

namespace FirstProject.Dto
{
    public class ProductDetailsDto
    {
        public string? ProductName { get; set; }
        public RegularPriceDto? RegularPrice { get; set; }
        public CampaignPriceDto? CampaignPrice { get; set; }
    }
}
