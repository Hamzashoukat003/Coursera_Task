using Coursera_Task.Data.Models;
using Coursera_Task.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursera_Task.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly ReportService _reportService;
        private readonly IConfiguration _configuration;

       

    
        public ReportController(ReportService reportService, IConfiguration configuration , BaseService baseService):base(baseService)
        {
            _reportService = reportService;
            _configuration = configuration;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReport(
            string? pinList,
            int? minimumCredit,
            DateTime? startDate,
            DateTime? endDate)
        {
            var reportList = await _reportService.GetReport(pinList, minimumCredit, startDate, endDate);
            return Ok(reportList);
        }
    }
}
