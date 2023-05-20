using MScanner.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MScanner.Helpers;

namespace MScanner.Factories.ApiRequests
{
    public class OpenAqRequestFactory : IApiRequestFactory<OpenAqRequestModel>
    {
        public string CreateRequestLink(OpenAqRequestModel request)
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            if (request.Limit != null)
                parameters["limit"] = request.Limit;
            if (request.Page != null)
                parameters["page"] = request.Page;
            if (request.Offset != null)
                parameters["offset"] = request.Offset;
            if (request.Sort != null)
                parameters["sort"] = request.Sort;
            if (request.CountryId != null)
                parameters["country_id"] = request.CountryId;
            if (request.City != null)
                parameters["city"] = request.City;

            request.UrlQuery = parameters.ToString();

            if (request.UrlHost == null || request.UrlPath == null || request.UrlQuery == null) return string.Empty;
            var result = UrlHelper.CreateUrl(request.UrlHost, request.UrlPath, request.UrlQuery);
            return result;

        }
    }
}
