﻿using MScanner.Data.Entities;
using MScanner.Models.Models;

namespace MScanner.Repository
{
    public interface ISensorDataRepository
    {
        Task<List<SensorDataModel>> GetAllAsync();
        Task<SensorDataModel> GetByIdAsync(int id);
        Task<SensorDataModel> AddAsync(SensorDataModel sensorData);
        Task<SensorDataModel> UpdateAsync(int id, SensorDataModel sensorData);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}