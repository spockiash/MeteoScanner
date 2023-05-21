using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MScanner.Data;
using MScanner.Data.Entities;
using MScanner.Models.Models;

namespace MScanner.Repository
{
    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly MeteoScannerContext _context;
        private readonly IMapper _mapper;

        public SensorDataRepository(MeteoScannerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SensorDataModel>> GetAllAsync()
        {
            var entities = await _context.SensorData.ToListAsync();
            return _mapper.Map<List<SensorDataModel>>(entities);
        }

        public async Task<SensorDataModel> GetByIdAsync(int id)
        {
            var entity = await _context.SensorData.FindAsync(id);
            return _mapper.Map<SensorDataModel>(entity);
        }

        public async Task<SensorDataModel> AddAsync(SensorDataModel sensorData)
        {
            var entity = _mapper.Map<SensorDataEntity>(sensorData);
            await _context.SensorData.AddAsync(entity);
            return _mapper.Map<SensorDataModel>(entity);
        }

        public async Task<SensorDataModel> UpdateAsync(int id, SensorDataModel sensorData)
        {
            var entity = await _context.SensorData.FindAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Sensor data with the specified ID does not exist.");
            }
            _mapper.Map(sensorData, entity);
            return _mapper.Map<SensorDataModel>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SensorData.FindAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException("Sensor data with the specified ID does not exist.");
            }
            _context.SensorData.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

