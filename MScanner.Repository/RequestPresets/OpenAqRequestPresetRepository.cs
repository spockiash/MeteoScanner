using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoScanner.Enums;
using Microsoft.EntityFrameworkCore;
using MScanner.Data;
using MScanner.Models.RequestModels;
using SQLitePCL;

namespace MScanner.Repository.RequestPresets
{
    public class OpenAqRequestPresetRepository : IRequestPresetRepository<OpenAqRequestModel>
    {
        private readonly MeteoScannerContext _context;

        public OpenAqRequestPresetRepository(MeteoScannerContext context)
        {
            _context = context;
        }
        public async Task<OpenAqRequestModel> GetByIdAsync(int id)
        {
            return await _context.ApiRequestPresets.Where(x => x.Id == id).Select(x => new OpenAqRequestModel()
            {
                Id = x.Id,
                ApiService = x.ApiService,
                PresetName = x.PresetName,
                City = x.City,
                CountryId = x.CountryId,
                Limit = x.Limit,
                Offset = x.Offset,
                Page = x.Page,
                Sort = x.Sort,
                UrlHost = x.UrlHost,
                UrlPath = x.UrlPath,
                UrlQuery = x.UrlQuery,
            }).FirstOrDefaultAsync() ?? new OpenAqRequestModel();
        }

        public async Task<List<OpenAqRequestModel>> GetByService(AvailableApiServices service)
        {
            return await _context.ApiRequestPresets.Where(x => x.ApiService == service).Select(x => new OpenAqRequestModel()
            {
                Id = x.Id,
                ApiService = x.ApiService,
                PresetName = x.PresetName,
                City = x.City,
                CountryId = x.CountryId,
                Limit = x.Limit,
                Offset = x.Offset,
                Page = x.Page,
                Sort = x.Sort,
                UrlHost = x.UrlHost,
                UrlPath = x.UrlPath,
                UrlQuery = x.UrlQuery,
            }).ToListAsync();
        }

        public async Task<List<OpenAqRequestModel>> GetAllAsync()
        {
            var presets = await _context.ApiRequestPresets.ToListAsync();
            return presets.Select(preset => new OpenAqRequestModel
            {
                Id = preset.Id,
                ApiService = preset.ApiService,
                PresetName = preset.PresetName,
                City = preset.City,
                CountryId = preset.CountryId,
                Limit = preset.Limit,
                Offset = preset.Offset,
                Page = preset.Page,
                Sort = preset.Sort,
                UrlHost = preset.UrlHost,
                UrlPath = preset.UrlPath,
                UrlQuery = preset.UrlQuery
            }).ToList();
        }

        public async Task AddAsync(OpenAqRequestModel model)
        {
            var presetEntity = OpenAqRequestPresetMapper.MapToEntity(model);
            await _context.ApiRequestPresets.AddAsync(presetEntity);
        }

        public async Task UpdateAsync(OpenAqRequestModel model)
        {
            var preset = OpenAqRequestPresetMapper.MapToEntity(model);
            _context.ApiRequestPresets.Update(preset);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(OpenAqRequestModel model)
        {
            var preset = OpenAqRequestPresetMapper.MapToEntity(model);
            _context.ApiRequestPresets.Remove(preset);
            await SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<OpenAqRequestModel> models)
        {
            var presets = OpenAqRequestPresetMapper.MapToEntities(models);
            await _context.ApiRequestPresets.AddRangeAsync(presets);
            await SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<OpenAqRequestModel> models)
        {
            var presets = OpenAqRequestPresetMapper.MapToEntities(models);
            _context.ApiRequestPresets.UpdateRange(presets);
            await SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<OpenAqRequestModel> models)
        {
            var presets = OpenAqRequestPresetMapper.MapToEntities(models);
            _context.ApiRequestPresets.RemoveRange(presets);
            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
