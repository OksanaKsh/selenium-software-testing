using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litecart.UI.Client.Pages.UserApp.dto
{
    public class RegularPriceDto
    {
        public int Amount { get; set; }
        public double Font { get; set; }
        public Color Color { get; set; }
        public bool IsLineThrough { get; set; }
    }
}
