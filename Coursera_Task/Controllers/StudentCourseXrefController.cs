using Coursera_Task.Data.Models;
using Coursera_Task.Services;
using Coursera_Task.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursera_Task.Controllers
{

    [Route("studentcoursesxref")]
    [ApiController]
    public class StudentsCoursesXrefController : BaseController
    {
        private readonly StudentCourseService _studentCourseService;

        public StudentsCoursesXrefController(BaseService baseService, StudentCourseService studentCourseService) : base(baseService)
        {
            _studentCourseService = studentCourseService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourseViewModel>>> GetAllStudentCourses()
        {
            var studentCourses = await _studentCourseService.GetAllStudentCourses();
            return Ok(studentCourses);
        }

        [HttpGet("{studentId}/{courseId}")]
        public async Task<ActionResult<StudentCourseViewModel>> GetStudentCourse(string studentId, int courseId)
        {
            var studentCourse = await _studentCourseService.GetStudentCourseByIds(studentId, courseId);
            if (studentCourse == null)
            {
                return NotFound();
            }
            return Ok(studentCourse);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentCourse(StudentCourseViewModel studentCourseViewModel)
        {
            await _studentCourseService.AddStudentCourse(studentCourseViewModel);
            return Ok();
        }
        [HttpPut("students/{studentId}/courses/{courseId}")]
        public async Task<IActionResult> UpdateStudentCourse(string studentId, int courseId, StudentCourseViewModel updatedStudentCourseViewModel)
        {
            await _studentCourseService.UpdateStudentCourse(studentId, courseId, updatedStudentCourseViewModel);
            return Ok();
        }

        [HttpDelete("{studentId}/{courseId}")]
        public async Task<IActionResult> DeleteStudentCourse(string studentId, int courseId)
        {
            await _studentCourseService.DeleteStudentCourse(studentId, courseId);
            return Ok();
        }
    }
}
