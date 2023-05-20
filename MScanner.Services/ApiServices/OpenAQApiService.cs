using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MScanner.Models.Models;
using MScanner.Models.Settings;

namespace MScanner.Services.ApiServices
{
    public class OpenAqApiService : IApiService<OpenAqDataModel>
    {
        public void ConfigureService(ApiSettingsModel settings)
        {
            throw new NotImplementedException();
        }

        public async Task<OpenAqDataModel> PerformRequest(string arguments)
        {
            throw new NotImplementedException();
        }
    }
}
