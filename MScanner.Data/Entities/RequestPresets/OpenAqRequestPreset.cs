

namespace MScanner.Data.Entities.RequestPresets
{
    public class OpenAqRequestPreset : BaseRequestPreset
    {
        public string? Limit { get; set; }
        public string? Page { get; set; }
        public string? Offset { get; set; }
        public string? Sort { get; set; }
        public string? CountryId { get; set; }
        public string? City { get; set; }
    }
}
