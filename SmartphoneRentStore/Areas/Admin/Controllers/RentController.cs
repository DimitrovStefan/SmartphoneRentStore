namespace SmartphoneRentStore.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;


    public class RentController : AdminBaseController
    {
        private readonly IRentService rentService;

       
        public RentController(IRentService _rentService)
        {
            rentService = _rentService;
        }

       
        public async Task<IActionResult> All()
        {
            var model = await rentService.AllAsync();

            return View(model);
        }
    }
}
