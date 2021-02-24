using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoofStockAssesment.Common.Models
{
    public class PropertiesModel
    {
        public int Id { get; set; }
        public string YearBuilt { get; set; }
        public string ListPrice { get; set; }
        public string MonthlyRent { get; set; }
        public string GrossYield { get; set; }
        public string MainImageUrl { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ZipPlusFour { get; set; }
        public string Bathrooms { get; set; }
        public string BedRooms { get; set; }
        public string squareFeet { get; set; }
        public Resources Resources { get; set; }

    }
}
