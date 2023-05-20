using MScanner.Factories.ApiRequests;
using MScanner.Models.RequestModels;

namespace UnitTests
{
    public class OpenAqRequestFactoryTests
    {
        [Fact]
        public void CreateRequestLink_ShouldReturnCorrectUrl()
        {
            // Arrange
            var factory = new OpenAqRequestFactory();
            var request = new OpenAqRequestModel
            {
                Limit = "100",
                Page = "1",
                Offset = "0",
                Sort = "asc",
                CountryId = "CZ",
                City = "Prague",
                UrlHost = "https://api.openaq.org",
                UrlPath = "/v2/cities"
            };
            var expectedUrl = "https://api.openaq.org/v2/cities?limit=100&page=1&offset=0&sort=asc&country_id=CZ&city=Prague";

            // Act
            var resultUrl = factory.CreateRequestLink(request);

            // Assert
            Assert.Equal(expectedUrl, resultUrl);
        }
    }
}