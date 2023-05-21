using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoScanner.Enums;

namespace MScanner.Data.Entities.RequestPresets
{
    public class BaseRequestPreset
    {
        public long Id { get; set; }
        public AvailableApiServices ApiService { get; set; }
        public string? PresetName { get; set; }
        public string? UrlHost { get; set; }
        public string? UrlPath { get; set; }
        public string? UrlQuery { get; set; }
    }
}
