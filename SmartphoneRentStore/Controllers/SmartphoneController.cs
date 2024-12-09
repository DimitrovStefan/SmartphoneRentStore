namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Exeptions;
    using SmartphoneRentStore.Core.Extensions;
    using SmartphoneRentStore.Core.Models.SmartPhone;
    using SmartphoneRentStore.Core.Services;
    using SmartphoneRentStore.Extensions;
    using static SmartphoneRentStore.Core.Constants.MessageConstants;

    // will be only for authorize users (from BaseController)
    public class SmartphoneController : BaseController
    {
        private readonly ISmartphoneService smartphoneService;
        private readonly ISupplierService supplierService;
        private readonly ILogger<SmartphoneController> logger;

        public SmartphoneController(ISmartphoneService _smartphoneService, 
                                    ISupplierService _supplierService, 
                                    ILogger<SmartphoneController> _logger)
        {
            smartphoneService = _smartphoneService;
            supplierService = _supplierService;
            logger = _logger;
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

            if (User.IsAdmin())
            {
                return RedirectToAction("Mine", "Smartphone", new { area = "Admin" }); // if the user is admin redirect me to the admin menu "Mine"
            }

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
        public async Task<IActionResult> Details(int id, string information)
        {
            // First we check for existing id
            if (await smartphoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            //Here we already know we have match with some id so we take it:
            var model = await smartphoneService.SmartphoneDetailsByIdAsync(id);

            if (information != model.GetInformation()) // For Security
            {
                return BadRequest();
            }

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

            return RedirectToAction(nameof(Details), new { id = newSmartPhoneId, information = model.GetInformation()});
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await smartphoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await smartphoneService.HasSupplierWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false) // check for role "Administrator")
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

            if (await smartphoneService.HasSupplierWithIdAsync(id, User.Id()) == false // check if we have supplier with current id
                && User.IsAdmin() == false) // check for role "Administrator"
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

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation()});
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await smartphoneService.ExistsAsync(id) == false) // check for exist smaryphone
            {
                return BadRequest();
            }

            if (await smartphoneService.HasSupplierWithIdAsync(id, User.Id()) == false // check for exist supplier
                && User.IsAdmin() == false) // check for role "Administrator") 
            {
                return Unauthorized();
            }

            var smartphone = await smartphoneService.SmartphoneDetailsByIdAsync(id);

            var model = new SmartPhoneDetailsViewModel()
            {
                Description = smartphone.Description,
                ImageUrl = smartphone.ImageUrl,
                Title = smartphone.Title,
                PricePerMonth = smartphone.PricePerMonth
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(SmartPhoneDetailsViewModel model)
        {
            if (await smartphoneService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await smartphoneService.HasSupplierWithIdAsync(model.Id, User.Id()) == false // check for exist supplier
                && User.IsAdmin() == false) // check for role "Administrator") 
            {
                return Unauthorized();
            }

            await smartphoneService.DeleteAsync(model.Id);
             
            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> RentAsync(int id)
        {
            if (await smartphoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await supplierService.ExistsByIdAsync(User.Id()) // check for exist supplier
                && User.IsAdmin() == false)  // check for role "Administrator") 
            {
                return Unauthorized();
            }

            if (await smartphoneService.IsRentedAsync(id)) // check if it is already rented
            {
                return BadRequest();
            }


            await smartphoneService.RentAsync(id, User.Id()); // make rent

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await smartphoneService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await smartphoneService.IsRentedByUserWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            try
            {
                await smartphoneService.LeaveAsync(id, User.Id());
            }
            catch (UnauthorizedActionExeption ex)
            {
                logger.LogError(ex, "Smartphone Controle/Leave");

                return Unauthorized();
            }
            

            return RedirectToAction(nameof(All));
        }


    }

}



