namespace SmartphoneRentStore.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SmartphoneRentStore.Core.Contracts;
    


    [Route("api/statistic")] // direction in url
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticApiController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;
        }


        [HttpGet]
        public async Task<IActionResult> GetStatistic()
        {
            var result = await statisticService.TotalAsync();

            return Ok(result);

        }


    }
}
