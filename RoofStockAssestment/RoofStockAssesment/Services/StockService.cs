using RoofStockAssesment.Common.Models;
using RoofStockAssesment.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using log4net;
using RoofStockAssesment.ExternalApi;
using RoofStockAssesment.Data;
using RoofStockAssesment.Common.DTO;
using AutoMapper;

namespace RoofStockAssesment.Services
{
    public interface IStockService
    {
        Task<List<PropertiesModel>> GetStockData();
        Task<BaseResponseModel> SaveStockData(int id);
        Task<PropertiesModel> GetStockDataById(int id);
    }

    public class StockService : IStockService
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly IExternalDataService _externalApi;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public StockService(IExternalDataService externalApi, IStockRepository stockRepository, IMapper mapper)
        {
            _externalApi = externalApi;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<List<PropertiesModel>> GetStockData()
        {
            try
            {
                StockPropertiesModel blobData = await _externalApi.GetStockData();
                List<PropertiesModel> properties = new List<PropertiesModel>();
                foreach (var property in blobData.Properties)
                {
                    if (property.Financial != null && property.Physical != null)
                    {
                        properties.Add(CastStockData(property));
                    }
                    else
                    {
                        _logger.Warn($"The element with Id {property.Id} has null values on Financial and Physical properties");
                    }
                }
                return properties;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PropertiesModel> GetStockDataById(int id)
        {
            PropertiesObject blobData = await _externalApi.GetStockDataById(id);
            return CastStockData(blobData);
        }

        public async Task<BaseResponseModel> SaveStockData(int id)
        {
            try
            {
                _logger.Info("Going to create the new property");
                var property = await GetStockDataById(id);
                Address itemAddress = _mapper.Map<Address>(property);
                PropertyDTO propertiesDTO = new PropertyDTO
                {
                    Id = property.Id,
                    YearBuilt = property.YearBuilt,
                    ListPrice = Convert.ToDecimal(property.ListPrice),
                    MonthlyRent = Convert.ToDecimal(property.MonthlyRent),
                    GrossYield = Convert.ToDecimal(property.GrossYield),
                    Address = JsonConvert.SerializeObject(itemAddress)
                };
                return await _stockRepository.SaveStockData(propertiesDTO);
            }
            catch (Exception ex)
            {
                _logger.Error($"An error has occured calling the repository {ex.Message}", ex);
                throw;
            }

        }
        internal PropertiesModel CastStockData(PropertiesObject blobData)
        {
            try
            {
                PropertiesModel property = new PropertiesModel
                {
                    Id = blobData.Id,
                    YearBuilt = blobData.Physical.YearBuilt,
                    ListPrice = blobData.Financial != null ? string.Format("{0:F2}", blobData.Financial.ListPrice) : "0",
                    MonthlyRent = blobData.Financial != null ? string.Format("{0:F2}", blobData.Financial.MonthlyRent) : "0",
                    GrossYield = string.Format("{0:F2}", (blobData.Financial != null ? Convert.ToDecimal(blobData.Financial.MonthlyRent) : 0 * 12)
                                 / (blobData.Financial != null ? Convert.ToDecimal(blobData.Financial.ListPrice) : 1)),
                    MainImageUrl = blobData.MainImageUrl,
                    Address1 = blobData.Address.Address1,
                    Address2 = blobData.Address.Address2,
                    City = blobData.Address.City,
                    Country = blobData.Address.Country,
                    County = blobData.Address.County,
                    District = blobData.Address.District,
                    State = blobData.Address.State,
                    ZipCode = blobData.Address.ZipCode,
                    ZipPlusFour = blobData.Address.ZipPlusFour,
                    Resources = blobData.Resources,
                    Bathrooms = blobData.Physical.Bathrooms,
                    BedRooms = blobData.Physical.BedRooms,
                    squareFeet = blobData.Physical.squareFeet
                };
                return property;
            }
            catch (Exception ex)
            {
                _logger.Error($"An error has occured casting the properties {ex.Message}", ex);
                throw;
            }
        }
    }
}
