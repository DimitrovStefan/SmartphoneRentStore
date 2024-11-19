namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Attributes;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Supplier;
    using SmartphoneRentStore.Extensions;
    using SmartphoneRentStore.Infrastructure.Data.Models;
    using static SmartphoneRentStore.Core.Constants.MessageConstants;

    public class SupplierController : BaseController
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService _supplierService)
        {
            supplierService = _supplierService;
        }

        [HttpGet]
        [NotAnSupplier]
        public IActionResult Become()
        {
            var model = new BecomeSupplierFormModel();

            return View(model);
        }

        [HttpPost]
        [NotAnSupplier]
        public async Task<IActionResult> Become(BecomeSupplierFormModel supplier)
        {
            if (await supplierService.UserWithPhoneNumberExistsAsync(User.Id())) // if exist user with the same phonenumber give me model error
            {
                ModelState.AddModelError(nameof(supplier.PhoneNumber), PhoneExits);
            }

            if (await supplierService.UserHasRentsAsync(User.Id())) // if exist rent give me a model error
            {
                ModelState.AddModelError("Error", HasRents);
            }


            if (ModelState.IsValid == false)
            { 
                return View(supplier);
            }

            await supplierService.CreateAsync(User.Id(), supplier.PhoneNumber, supplier.City);

            return RedirectToAction(nameof(SmartphoneController.All), "Smartphone");
        }
    }
}
