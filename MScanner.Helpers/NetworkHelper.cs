using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
namespace MScanner.Helpers
{
    public static class NetworkHelper
    {
        public static async Task<bool> IsApiOnline(string endpointUrl)
        {
            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(endpointUrl);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
