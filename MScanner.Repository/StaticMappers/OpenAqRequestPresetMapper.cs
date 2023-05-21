using System.Collections.Generic;
using System.Linq;
using MScanner.Data.Entities.RequestPresets;
using MScanner.Models.RequestModels;

public static class OpenAqRequestPresetMapper
{
    public static OpenAqRequestPreset MapToEntity(OpenAqRequestModel model)
    {
        return new OpenAqRequestPreset
        {
            Id = model.Id,
            Limit = model.Limit,
            Page = model.Page,
            Offset = model.Offset,
            Sort = model.Sort,
            CountryId = model.CountryId,
            City = model.City,
            UrlHost = model.UrlHost,
            UrlPath = model.UrlPath,
            UrlQuery = model.UrlQuery,
            ApiService = model.ApiService,
            PresetName = model.PresetName,
        };
    }

    public static List<OpenAqRequestPreset> MapToEntities(IEnumerable<OpenAqRequestModel> models)
    {
        return models.Select(MapToEntity).ToList();
    }
}