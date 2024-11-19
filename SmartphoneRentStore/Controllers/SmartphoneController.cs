namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.SmartPhone;
    using SmartphoneRentStore.Extensions;

    // will be only for authorize users (from BaseController)
    public class SmartphoneController : BaseController
    {
        private readonly ISmartphoneService smartphoneService;
        private readonly ISupplierService supplierService;

        public SmartphoneController(ISmartphoneService _smartphoneService, ISupplierService _supplierService)
        {
            smartphoneService = _smartphoneService;
            supplierService = _supplierService;
        }


        [AllowAnonymous] 
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllSmartPhonesQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllSmartPhonesQueryModel();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new SmartPhoneDetailsViewModel();
            
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (await supplierService.ExistsByIdAsync(User.Id()) == false) // If the user is not Supplier redirect to Become Supplier..
            {
                return RedirectToAction(nameof(SupplierController.Become), "Supplier");
            }

            var model = new SmartPhoneFormModel()
            {
                Categories = await smartphoneService.AllCategoriesAsync()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(SmartPhoneFormModel model)
        {
            if (await supplierService.ExistsByIdAsync(User.Id()) == false) // If the user is not Supplier redirect to Become Supplier..
            {
                return RedirectToAction(nameof(SupplierController.Become), "Supplier");
            }

            if (await smartphoneService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await smartphoneService.AllCategoriesAsync();
                
                return View(model);
            }

            int? supplierId = await supplierService.GetSupplierIdAsync(User.Id());

            int newSmartPhoneId = await smartphoneService.CreateAsync(model, supplierId ?? 0); // if is null

            return RedirectToAction(nameof(Details), new { id = newSmartPhoneId });
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
