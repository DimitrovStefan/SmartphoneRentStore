using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartphoneRentStore.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    
    }
}
