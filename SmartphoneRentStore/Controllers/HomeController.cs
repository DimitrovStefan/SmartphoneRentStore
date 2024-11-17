namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Home;
    using SmartphoneRentStore.Models;
    using System.Diagnostics;


    public class HomeController : Controller
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

        public async Task<IActionResult> Index()
        {
            var model = await smartphoneService.LastFourSmartphones();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
