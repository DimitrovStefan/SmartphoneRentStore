namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Models.Supplier;

    [Authorize]
    public class SupplierController : Controller
    {
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
