using AutoMapper;
using RoofStockAssesment.Common.DTO;
using RoofStockAssesment.Common.Entities;
using RoofStockAssesment.Common.Models;

namespace RoofStockAssesment.Common
{
    public class PropertiesProfiler : Profile
    {
        public PropertiesProfiler()
        {
            CreateMap<Property, PropertyDTO>();

            CreateMap<PropertyDTO, Property>();

            CreateMap<PropertiesModel, Address>();

            CreateMap<Address, PropertiesModel>();
        }
    }
}
