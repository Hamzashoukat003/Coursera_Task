using Coursera_Task.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coursera_Task.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly BaseService _baseService;

        public BaseController(BaseService baseService)
        {
            _baseService = baseService;
        }
    }
}
