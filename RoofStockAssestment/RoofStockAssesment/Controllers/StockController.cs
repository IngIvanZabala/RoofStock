using log4net;
using Microsoft.AspNetCore.Mvc;
using RoofStockAssesment.Common;
using RoofStockAssesment.Common.Models;
using RoofStockAssesment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RoofStockAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly ILog _logger = LogHelper.GetLogger();
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpGet]
        public async Task <IActionResult> GetStockData()
        {
            try
            {
                //Request to get all the data from the API
                _logger.Info("Getting Stock Data");
                return new OkObjectResult(await _stockService.GetStockData());
            }
            catch (Exception)
            {
                return new BadRequestResult();
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //Request to get the data by and id sent from the UI
                _logger.Info("Getting Stock Data by Id");
                return new OkObjectResult(await _stockService.GetStockDataById(id));
            }
            catch (Exception)
            {
                return new BadRequestResult();
                throw;
            }
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> SaveStockData(int id)
        {
            try
            {
                //Request to add a new record on the database
                _logger.Info("Saving Stock Data");
                BaseResponseModel result = await _stockService.SaveStockData(id);
                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return new BadRequestResult();
                throw;
            }
        }
    }
}
