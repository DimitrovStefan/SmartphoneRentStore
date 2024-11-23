namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.SmartPhone;
    using SmartphoneRentStore.Core.Services;
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
        [HttpGet]                          //[FromQuery] Gets values exactly from the query string.
        public async Task<IActionResult> All([FromQuery] AllSmartPhonesQueryModel model)
        {
            var smartphones = await smartphoneService.AllAsync(
                 model.Category,
                 model.SearchTerm,
                 model.Sorting,
                 model.CurrentPage = Math.Max(1, model.CurrentPage),
                 model.SmartphonesPerPage);

            model.TotalSmartphoneCount = smartphones.TotalSmartPhoneCount;
            model.SmartPhones = smartphones.SmartPhones;

            model.Categories = await smartphoneService.AllCategoriesNamesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id(); // Take my id

            IEnumerable<SmartPhoneServiceModel> model;

            if (await supplierService.ExistsByIdAsync(userId))
            {
                var supplierId = await supplierService.GetSupplierIdAsync(userId) ?? 0; // check if i'em a supplier and take my id
                model = await smartphoneService.AllSmartphonesBySupplierIdAsync(supplierId); // here he take my models (smartphones) witch a added 
            }
            else
            {
                model = await smartphoneService.AllSmartphonesByUserIdAsync(userId);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // First we check for existing id
            if (await smartphoneService.ExistsAsync(id) == false) 
            {
                return BadRequest();
            }

            //Here we already know we have match with some id so we take it:
            var model = await smartphoneService.SmartphoneDetailsByIdAsync(id);


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
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist"); // check if the current category exist
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
            if (await smartphoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await smartphoneService.HasSupplierWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await smartphoneService.GetSmartphoneFormModelByIdAsync(id);
            

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, SmartPhoneFormModel model)
        {
            if (await smartphoneService.ExistsAsync(id) == false) // check if we have a samrtphone with exist id
            {
                return BadRequest();
            }

            if (await smartphoneService.HasSupplierWithIdAsync(id, User.Id()) == false) // check if we have supplier with current id
            {
                return Unauthorized();
            }

            if (await smartphoneService.CategoryExistsAsync(model.CategoryId) == false) // check if the current category exist
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await smartphoneService.AllCategoriesAsync();

                return View(model);
            }

            await smartphoneService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
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
