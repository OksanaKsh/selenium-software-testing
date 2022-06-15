using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.dto.AddNewProduct
{
    public class DataProductDto
    {
        public string Status { get; set; }
        public string NameInput { get; set; }
        public string CodeInput { get; set; }
        public string SelectCategories { get; set; }
        public string DefaultCategory { get; set; }
        public string Gender { get; set; }
        public double Quantity { get; set; }
        public string QuantityUnit { get; set; }
        public string DeliveryStatus { get; set; }
        public string SoldOutStatus { get; set; }
        public string UploadImages { get; set; }
        public string DateValidFrom { get; set; }
        public string DateValidTo { get; set; }
        public string SaveButton { get; set; }//? Should Save be here?
    }
}
