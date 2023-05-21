using MeteoScanner.Enums;
using MScanner.Models.RequestModels;
using Xunit;

namespace UnitTests
{
    public class OpenAqRequestPresetMapperTests
    {
        [Fact]
        public void MapToEntity_ReturnsValidEntity()
        {
            // Arrange
            var model = new OpenAqRequestModel
            {
                Id = 1,
                Limit = "100",
                Page = "1",
                Offset = "10",
                Sort = "asc",
                CountryId = "US",
                City = "New York",
                UrlHost = "example.com",
                UrlPath = "/api/data",
                UrlQuery = "?param=value",
                ApiService = AvailableApiServices.OpenAqApiService
            };

            // Act
            var entity = OpenAqRequestPresetMapper.MapToEntity(model);

            // Assert
            Assert.Equal(model.Id, entity.Id);
            Assert.Equal(model.Limit, entity.Limit);
            Assert.Equal(model.Page, entity.Page);
            Assert.Equal(model.Offset, entity.Offset);
            Assert.Equal(model.Sort, entity.Sort);
            Assert.Equal(model.CountryId, entity.CountryId);
            Assert.Equal(model.City, entity.City);
            Assert.Equal(model.UrlHost, entity.UrlHost);
            Assert.Equal(model.UrlPath, entity.UrlPath);
            Assert.Equal(model.UrlQuery, entity.UrlQuery);
            Assert.Equal(model.ApiService, entity.ApiService);
        }
    }
}