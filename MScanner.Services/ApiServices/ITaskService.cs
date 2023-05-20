using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MScanner.Models;

namespace MScanner.Services.ApiServices
{
    public interface ITaskService<in T> where T : IApiService<BaseDataModel>
    {
        Task StartTask(T apiService, TimeSpan interval);
    }
}
