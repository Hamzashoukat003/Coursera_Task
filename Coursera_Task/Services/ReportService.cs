using Coursera_Task.Controllers;
using Coursera_Task.Data;
using Coursera_Task.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Coursera_Task.Services
{
    public class ReportService
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ReportService _reportService;

        public ReportService(MyDbContext context, IConfiguration configuration, BaseService baseService) 
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Report>> GetReport(string pinList, int? minimumCredit, DateTime? startDate, DateTime? endDate)
        {
            var reportList = new List<Report>();
            var connectionString = _configuration["ConnectionStrings:DefaultConnection"];

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GetReport", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PinList", pinList);
                    command.Parameters.AddWithValue("@MinimumCredit", minimumCredit);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            while (await reader.ReadAsync())
                            {
                                reportList.Add(new Report
                                {
                                    PIN = reader.GetString(reader.GetOrdinal("PIN")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    CourseName = reader.GetString(reader.GetOrdinal("CourseName")),
                                    InstructorFirstName = reader.GetString(reader.GetOrdinal("InstructorFirstName")),
                                    InstructorLastName = reader.GetString(reader.GetOrdinal("InstructorLastName")),
                                    CompletionDate = reader.GetDateTime(reader.GetOrdinal("CompletionDate")),
                                    TotalTime = reader.GetInt32(reader.GetOrdinal("TotalTime")),
                                    Credit = reader.GetInt32(reader.GetOrdinal("Credit"))
                                });
                            }
                        }
                    }
                }
            }

            return reportList;
        }
    }
}
