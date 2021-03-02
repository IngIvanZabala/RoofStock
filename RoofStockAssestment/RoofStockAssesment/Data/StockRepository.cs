using AutoMapper;
using log4net;
using RoofStockAssesment.Common;
using RoofStockAssesment.Common.DTO;
using RoofStockAssesment.Common.Entities;
using RoofStockAssesment.Common.Models;
using System;
using System.Threading.Tasks;
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
        //Saving element data

        public async Task<BaseResponseModel> SaveStockData(PropertyDTO property)
        {
            // checking if the element already exists on the database
            bool elementExist = await ElementAlreadyExist(property.Id);
            if (elementExist)
                // returning isSuccess = false if the element already exists
                return new BaseResponseModel { IsSuccess = false, Message = Constants.failMessage };
            //Creating a new database context transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Mapping the dto object into the database entity
                    Property newProperty = _mapper.Map<Property>(property);
                    //creatint the new record
                    await _context.Properties.AddAsync(newProperty);
                    //saving the new record
                    await _context.SaveChangesAsync();
                    //Doing the commit for the transaction
                    await dbContextTransaction.CommitAsync();
                    //Returning the successfull message
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
                //checking if the element already exists on the database
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
