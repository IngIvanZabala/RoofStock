using System;
using System.Collections.Generic;

#nullable disable

namespace RoofStockAssesment.Common.Entities
{
    public partial class Property
    {
        public int Id { get; set; }
        public string YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal GrossYield { get; set; }
        public string Address { get; set; }
    }
}
