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
    }
}
