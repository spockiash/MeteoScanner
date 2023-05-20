using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MScanner.Models;
using MScanner.Models.Settings;

namespace MScanner.Services.ApiServices
{
    public interface IBaseApiService <T> where T : BaseDataModel
    {
        void ConfigureService(ApiSettingsModel settings);
        Task<T> PerformRequest(string arguments);

    }
}
