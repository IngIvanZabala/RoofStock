namespace RoofStockAssesment.Common.DTO
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal GrossYield { get; set; }
        public string Address { get; set; }
    }
}
