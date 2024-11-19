namespace SmartphoneRentStore.Attributes
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Extensions;

    public class NotAnSupplierAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            
            ISupplierService? supplierService = context.HttpContext.RequestServices.GetService<ISupplierService>();

            if (supplierService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError); 
            }

            if (supplierService != null && supplierService.ExistsByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

        }
    }
}
