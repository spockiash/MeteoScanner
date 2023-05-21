using MeteoScanner.Enums;
using Microsoft.AspNetCore.Mvc;
using MScanner.Helpers;
using MScanner.Models.RequestModels;
using MScanner.Repository.RequestPresets;

namespace MeteoScanner.Core.Controllers
{
    public class RequestPresetsController : Controller
    {
        private readonly IRequestPresetRepository<OpenAqRequestModel> _requestPresetRepository;

        public RequestPresetsController(IRequestPresetRepository<OpenAqRequestModel> requestPresetRepository)
        {
            _requestPresetRepository = requestPresetRepository;
        }
        public IActionResult Index()
        {
            var dictionary = EnumHelper.ToDictionary(typeof(AvailableApiServices));
            return View(dictionary);
        }

        public async Task<IActionResult> ServiceDetails(int id)
        {
            var service = (AvailableApiServices) id;

            var foundPresets = await _requestPresetRepository.GetByService(service);

            return View(foundPresets);
        }

        public IActionResult AddRequestPreset(int serviceId)
        {
            return View(new OpenAqRequestModel(){Id = 0, ApiService = (AvailableApiServices)serviceId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRequestPreset(OpenAqRequestModel model)
        {
            if (!ModelState.IsValid)
                return View(model); // Return the view with validation errors if the model is not valid
            model.Id = 0;
            // Save the new RequestPreset to your data store or perform other operations
            await _requestPresetRepository.AddAsync(model);
            await _requestPresetRepository.SaveChangesAsync();
            return RedirectToAction("Index"); // Redirect to the desired action after successful submission
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
