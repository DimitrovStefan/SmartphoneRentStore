namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Models;
    using System.Diagnostics;


    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISmartphoneService smartphoneService;

        public HomeController(
            ILogger<HomeController> logger,
            ISmartphoneService _smartphoneService)
        {
            _logger = logger;
            smartphoneService = _smartphoneService;
        }


        [AllowAnonymous] // don't need logg in 
        public async Task<IActionResult> Index()
        {
            var model = await smartphoneService.LastFourSmartphonesAsync();

            return View(model);
        }


        [AllowAnonymous] // don't need logg in 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            { 
                return View("Error400");
            }

            if (statusCode == 400)
            {
                return View("Error401");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }


            return View();
        }
    }
}
