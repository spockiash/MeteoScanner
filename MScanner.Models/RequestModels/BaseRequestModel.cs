using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Models.RequestModels
{
    public class BaseRequestModel
    {
        public string? UrlHost { get; set; }
        public string? UrlPath { get; set; }
        public string? UrlQuery { get; set; }
    }
}
