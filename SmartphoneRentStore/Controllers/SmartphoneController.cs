namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Models.SmartPhone;

    [Authorize] // will be only for authorize users
    public class SmartphoneController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = new AllSmartPhonesQueryModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new AllSmartPhonesQueryModel();

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new SmartPhoneDetailsViewModel();
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SmartPhoneFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new SmartPhoneFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SmartPhoneFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new SmartPhoneDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, SmartPhoneFormModel model)
        {
            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }


        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
