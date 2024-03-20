using Coursera_Task.Data;
using Coursera_Task.Data.Models;
using Coursera_Task.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Coursera_Task.Services
{
    public class CoursesService : BaseService
    {
        public CoursesService(MyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CourseViewModel>> GetAllCourses()
        {
            var coursesFromDataModels = await _context.Courses.ToListAsync();

            return coursesFromDataModels.Select(course => new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                InstructorId = course.InstructorId,
                TotalTime = course.TotalTime,
                Credit = course.Credit,
                TimeCreated = course.TimeCreated
            });
        }

        public async Task<CourseViewModel> GetCourseById(int courseId)
        {
            var courseEntity = await _context.Courses.FindAsync(courseId);

            if (courseEntity == null)
            {
                return null;
            }

            return new CourseViewModel
            {
                Id = courseEntity.Id,
                Name = courseEntity.Name,
                InstructorId = courseEntity.InstructorId,
                TotalTime = courseEntity.TotalTime,
                Credit = courseEntity.Credit,
                TimeCreated = courseEntity.TimeCreated
            };
        }

        public async Task AddCourse(CourseViewModel courseViewModel)
        {
            var courseEntity = new Courses
            {
                Name = courseViewModel.Name,
                InstructorId = courseViewModel.InstructorId,
                TotalTime = courseViewModel.TotalTime,
                Credit = courseViewModel.Credit,
                TimeCreated = DateTime.Now
            };

            _context.Courses.Add(courseEntity);
            await _context.SaveChangesAsync();
            
        }

        public async Task UpdateCourse(int courseId, CourseViewModel updatedCourseViewModel)
        {
            var courseEntity = await _context.Courses.FindAsync(courseId);

            if (courseEntity == null)
            {
               return;
            }

            courseEntity.Name = updatedCourseViewModel.Name;
            courseEntity.InstructorId = updatedCourseViewModel.InstructorId;
            courseEntity.TotalTime = updatedCourseViewModel.TotalTime;
            courseEntity.Credit = updatedCourseViewModel.Credit;
            courseEntity.TimeCreated = updatedCourseViewModel.TimeCreated;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(int courseId)
        {
            var courseEntity = await _context.Courses.FindAsync(courseId);

            if (courseEntity == null)
            {
                return;
            }

            _context.Courses.Remove(courseEntity);
            await _context.SaveChangesAsync();
        }
    }
}
   