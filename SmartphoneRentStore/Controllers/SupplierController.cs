namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Supplier;
    using SmartphoneRentStore.Extensions;

    public class SupplierController : BaseController
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService _supplierService)
        {
            supplierService = _supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await supplierService.ExistsByIdAsync(User.Id())) // if any user what to become supplier and already exist any supplier
                                                             // with this id => BadRequest
            {
                return BadRequest();
            }

            var model = new BecomeSupplierFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeSupplierFormModel supplier)
        {
            return RedirectToAction(nameof(SmartphoneController.All), "Smartphones");
        }
    }
}
