using System;

namespace FirstProject
{
    public class DataProductDto
    {
        public string SKU { get; set; }
        public string GTIN { get; set; }
        public string TARIC { get; set; }
        public double Weight { get; set; }
        public string WeightMeasures { get; set; }
        public double DimentionWidth { get; set; }
        public double DimentionHeight { get; set; }
        public double DimentionLength { get; set; }
        public string DimentionMeasures { get; set; }
        public string Attributes { get; set; }
    }
}
