using Coursera_Task.Data.Models;
using Coursera_Task.Services;
using Coursera_Task.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursera_Task.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController
    {
        private readonly StudentsService _studentsService;

        public StudentsController(BaseService baseService, StudentsService studentService) : base(baseService)
        {
            _studentsService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetAllStudentWithCompletedCourses()
        {
            var students = await _studentsService.GetAllStudentsWithCompletedCourses();
            return Ok(students);
        }

        [HttpGet("{pin}")]
        public async Task<ActionResult<StudentViewModel>> GetStudent(string pin)
        {
            var student = await _studentsService.GetStudentByPIN(pin);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentsService.NewStuWithCourse studentViewModel)
        {
            await _studentsService.AddStudent(studentViewModel);
            return Ok();
        }

        [HttpPut("{pin}")]
        public async Task<IActionResult> UpdateStudent(string pin, StudentViewModel student)
        {
            await _studentsService.UpdateStudent(pin, student);
            return Ok();
        }

        [HttpDelete("{pin}")]
        public async Task<IActionResult> DeleteStudent(string pin)
        {
            await _studentsService.DeleteStudent(pin);
            return Ok();
        }
    }
}