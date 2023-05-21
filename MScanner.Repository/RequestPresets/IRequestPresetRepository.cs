using MScanner.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoScanner.Enums;

namespace MScanner.Repository.RequestPresets
{
    public interface IRequestPresetRepository<T> where T : BaseRequestModel
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByService(AvailableApiServices service);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T model);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T model);
        Task AddRangeAsync(IEnumerable<T> models);
        Task UpdateRangeAsync(IEnumerable<T> models);
        Task DeleteRangeAsync(IEnumerable<T> models);
        Task SaveChangesAsync();
    }
}
