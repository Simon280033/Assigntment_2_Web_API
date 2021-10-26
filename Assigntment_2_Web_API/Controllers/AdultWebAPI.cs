using Microsoft.AspNetCore.Mvc;

namespace Assigntment_2_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultWebAPI : ControllerBase
    {
        private IAdultsService adultsService;

        public AdultWebAPI(IAdultsService adultsService)
        {
            this.adultsService = adultsService;
        }
    }
}