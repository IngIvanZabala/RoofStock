using AutoMapper;
using log4net;
using RoofStockAssesment.Common;
using RoofStockAssesment.Common.DTO;
using RoofStockAssesment.Common.Entities;
using RoofStockAssesment.Common.Models;
using System;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RoofStockAssesment.Data
{
    public interface IStockRepository
    {
        Task<BaseResponseModel> SaveStockData(PropertyDTO property);
    }

    public class StockRepository : IStockRepository
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        private readonly PropertiesContext _context;
        private readonly IMapper _mapper;
        public StockRepository(PropertiesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> SaveStockData(PropertyDTO property)
        {
            bool elementExist = await ElementAlreadyExist(property.Id);
            if (elementExist)
                return new BaseResponseModel { IsSuccess = false, Message = Constants.failMessage };
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Property newProperty = _mapper.Map<Property>(property);
                    await _context.Properties.AddAsync(newProperty);
                    await _context.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();
                    return new BaseResponseModel { IsSuccess = true, Message = Constants.okMessage };
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    _logger.Error($"An error has occured saving the item on the database {ex.Message}", ex);
                    throw;
                }
            }
        }
        internal async Task<bool> ElementAlreadyExist(int id)
        {
            try
            {
                var stockItem = await _context.Properties.Where(x => x.Id == id).FirstOrDefaultAsync();
                return stockItem != null;
            }
            catch (Exception ex)
            {
                _logger.Error($"An error has occured getting the records from the database {ex.Message}", ex);
                throw;
            }
        }
    }
}
