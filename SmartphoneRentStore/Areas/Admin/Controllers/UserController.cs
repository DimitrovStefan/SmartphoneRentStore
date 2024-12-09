namespace SmartphoneRentStore.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Models.Admin.User;
    using static SmartphoneRentStore.Core.Constants.AdministratorConstants;


    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService _userService, IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }

        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UsersCacheKey);

            if (model == null || model.Any() == false) // if the cashe memory is null or empty, we will read it from the database
            {                                          // аnd it saves it in the cache to be there for next time
                model = await userService.AllAsync();
                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                memoryCache.Set(UsersCacheKey, model, cacheOptions); // key, value, options
            }

            

            return View(model);
        }
    }
}
