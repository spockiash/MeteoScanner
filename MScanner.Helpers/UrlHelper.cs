using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Helpers
{
    public static class UrlHelper
    {
        /// <summary>
        /// Creates a complete URL by combining the base URL, URL path, and URL query.
        /// </summary>
        /// <param name="urlHost">The host of a service. For example 'https://someservice.net'</param>
        /// <param name="urlPath">The path of the URL.For example '/somePath/files'</param>
        /// <param name="urlQuery">The query string of the URL.For example '?params' </param>
        /// <returns>The complete URL string.</returns>
        public static string CreateUrl(string urlHost, string urlPath, string urlQuery)
        {
            return $"{urlHost}{urlPath}?{urlQuery}";
        }
    }
}
