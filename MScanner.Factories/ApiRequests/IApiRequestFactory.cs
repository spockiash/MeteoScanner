using MScanner.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Factories.ApiRequests
{
    public interface IApiRequestFactory<in TRequestModel> where TRequestModel : BaseRequestModel
    {
        string CreateRequestLink(TRequestModel request);
    }
}
