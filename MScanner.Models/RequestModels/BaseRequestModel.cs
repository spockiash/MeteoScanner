using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoScanner.Enums;

namespace MScanner.Models.RequestModels
{
    public class BaseRequestModel
    {
        public long Id { get; set; }
        public AvailableApiServices ApiService { get; set; }
        [Required(ErrorMessage = "The Preset Name field is required.")]
        public string? PresetName { get; set; }
        public string? UrlHost { get; set; }
        public string? UrlPath { get; set; }
        public string? UrlQuery { get; set; }
    }
}
