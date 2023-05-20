using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MScanner.Models;

namespace MScanner.Services.ApiServices
{
    public interface IApiService<T> : IBaseApiService<T> where T : BaseDataModel
    {
    }
}
