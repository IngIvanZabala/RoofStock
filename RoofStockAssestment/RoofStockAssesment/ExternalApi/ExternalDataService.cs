using log4net;
using Newtonsoft.Json;
using RoofStockAssesment.Common;
using RoofStockAssesment.Common.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RoofStockAssesment.ExternalApi
{
    public interface IExternalDataService
    {
        Task<StockPropertiesModel> GetStockData();
        Task<PropertiesObject> GetStockDataById(int id);
    }

    public class ExternalDataService : IExternalDataService
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        public async Task<StockPropertiesModel> GetStockData()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    _logger.Info("Calling external API to get the data");
                    return JsonConvert.DeserializeObject<StockPropertiesModel>(await webClient.DownloadStringTaskAsync(Constants.fileUrl));
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"An error has occured getting the properties {ex.Message}", ex);
                throw;
            }

        }
        public async Task<PropertiesObject> GetStockDataById(int id)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    _logger.Info($"Calling external API to get the data by the following Id: {id}");
                    var properties = JsonConvert.DeserializeObject<StockPropertiesModel>(await webClient.DownloadStringTaskAsync(Constants.fileUrl));
                    return properties.Properties.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"An error has occured getting the property data by the followind id: {id} {ex.Message}", ex);
                throw;
            }

        }
    }
}
