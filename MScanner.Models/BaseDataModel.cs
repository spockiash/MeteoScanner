using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MScanner.Models
{
    public class BaseDataModel
    {
        public long Id { get; set; }
        public string? Location { get; set; }
        public DateTime TimeStamp { get; set; }
        public virtual string GetUrlParameters()
        {
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["id"] = this.Id.ToString();
            return parameters.ToString() ?? string.Empty;
        }
    }
}
