using Microsoft.AspNetCore.Mvc;
using SmartphoneRentStore.Core.Contracts;
using SmartphoneRentStore.Core.Models.Admin;
using SmartphoneRentStore.Extensions;

namespace SmartphoneRentStore.Areas.Admin.Controllers
{
    public class SmartphoneController : AdminBaseController
    {
        private readonly ISmartphoneService smartphoneService;
        private readonly ISupplierService supplierService;

        public SmartphoneController(ISmartphoneService _smartphoneService, ISupplierService _supplierService)
        {
            smartphoneService = _smartphoneService;
            supplierService = _supplierService;
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var supplerId = await supplierService.GetSupplierIdAsync(userId) ?? 0;

            var mySmartphones = new MySmartphonesViewModel()
            {
                AddedSmartphones = await smartphoneService.AllSmartphonesBySupplierIdAsync(supplerId),
                RentedSmartphones = await smartphoneService.AllSmartphonesByUserIdAsync(userId)
            };   
            
            return View(mySmartphones);
        }

        [HttpGet]
        public async Task<IActionResult> Approve()
        {
            var model = await smartphoneService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int smartphoneId)
        { 
            await smartphoneService.ApproveSmartphoneAsync(smartphoneId);

            return RedirectToAction(nameof(Approve));
        }

    }
}
