using Coursera_Task.Data.Models;
using Coursera_Task.Services;
using Coursera_Task.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursera_Task.Controllers
{
    [Route("courses")]
    [ApiController]

    public class CoursesController : BaseController
    {
        private readonly CoursesService _coursesService;

        public CoursesController(BaseService baseService, CoursesService courseService) : base(baseService)
        {
            _coursesService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _coursesService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var course = await _coursesService.GetCourseById(courseId);

            if (course == null)
            {
                return NotFound(); 
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseViewModel courseViewModel)
        {
            await _coursesService.AddCourse(courseViewModel);
            return Ok("Course created successfully");
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] CourseViewModel updatedCourseViewModel)
        {
            await _coursesService.UpdateCourse(courseId, updatedCourseViewModel);
            return Ok("Course updated successfully");
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            await _coursesService.DeleteCourse(courseId);
            return Ok("Course deleted successfully");
        }
    }
}