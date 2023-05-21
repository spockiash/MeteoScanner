using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Models.RequestModels
{
    public class OpenAqRequestModel : BaseRequestModel
    {
        //Change the number of results returned. e.g. limit=1000 will return up to 1000 results
        public string? Limit { get; set; }
        //Paginate through results. e.g. page=1 will return first page of results
        public string? Page { get; set; }
        public string? Offset { get; set; }
        //Define sort order. e.g. ?sort=asc
        public string? Sort { get; set; }
        //Limit results by a certain country using two letter country code. e.g. US
        public string? CountryId { get; set; }
        //Limit results by a certain city or cities. (e.g. ?city=Chicago or ?city=Chicago&city=Boston)
        public string? City { get; set; }
    }
}
