using MeteoScanner.Enums;
using Microsoft.AspNetCore.Mvc;
using MScanner.Helpers;

namespace MeteoScanner.Core.Controllers
{
    public class RequestPresetsController : Controller
    {
        public IActionResult Index()
        {
            var dictionary = EnumHelper.ToDictionary(typeof(AvailableApiServices));
            return View(dictionary);
        }

        public IActionResult ServiceDetails(int id)
        {
            var dictionary = EnumHelper.ToDictionary(typeof(AvailableApiServices));
            
            // Check if the dictionary contains the key.
            if (!dictionary.ContainsKey(id))
            {
                return NotFound(); // Return a 404 Not Found page if the key doesn't exist.
            }

            var serviceName = dictionary[id];
            return View((id, serviceName));
        }
    }
}
