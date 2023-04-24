namespace MScanner.Factories
{
    public interface IUrlFactory
    {
        string CreateUrl(string endpoint);
        void Initialize(string baseUrl);
    }

    public class UrlFactory : IUrlFactory
    {
        private string? _baseUrl;
        
        public string CreateUrl(string endpoint)
        {
            return $"{_baseUrl}/{endpoint}";
        }

        public void Initialize(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
    }
}