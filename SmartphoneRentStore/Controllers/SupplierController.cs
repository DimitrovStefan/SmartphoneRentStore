namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Supplier;

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
