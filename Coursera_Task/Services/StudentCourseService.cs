using Coursera_Task.Data;
using Coursera_Task.Data.Models;
using Coursera_Task.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursera_Task.Services
{
    public class StudentCourseService
    {
        private readonly MyDbContext _context;

        public StudentCourseService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentCourseViewModel>> GetAllStudentCourses()
        {
            var studentCoursesFromDataModels = await _context.StudentsCoursesXref.ToListAsync();

            return studentCoursesFromDataModels.Select(studentCourse => new StudentCourseViewModel
            {
                StudentPin = studentCourse.StudentPin,
                CourseId = studentCourse.CourseId,
                CompletionDate = studentCourse.CompletionDate
            });
        }

        public async Task<StudentCourseViewModel> GetStudentCourseByIds(string studentId, int courseId)
        {
            var studentCourseEntity = await _context.StudentsCoursesXref.FindAsync(studentId, courseId);

            if (studentCourseEntity == null)
            {
                return null;
            }

            return new StudentCourseViewModel
            {
                StudentPin = studentCourseEntity.StudentPin,
                CourseId = studentCourseEntity.CourseId,
                CompletionDate = studentCourseEntity.CompletionDate
            };
        }

        public async Task AddStudentCourse(StudentCourseViewModel studentCourseViewModel)
        {
            var studentCourseEntity = new StudentCourseXref
            {
                StudentPin = studentCourseViewModel.StudentPin,
                CourseId = studentCourseViewModel.CourseId,
                CompletionDate = studentCourseViewModel.CompletionDate
            };

            _context.StudentsCoursesXref.Add(studentCourseEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentCourse(string studentId, int courseId, StudentCourseViewModel updatedStudentCourseViewModel)
        {
            var studentCourseEntity = await _context.StudentsCoursesXref.FindAsync(studentId, courseId);

            if (studentCourseEntity == null)
            {
                return;
            }

            studentCourseEntity.CompletionDate = updatedStudentCourseViewModel.CompletionDate;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentCourse(string studentId, int courseId)
        {
            var studentCourseEntity = await _context.StudentsCoursesXref.FindAsync(studentId, courseId);

            if (studentCourseEntity == null)
            {
                return;
            }

            _context.StudentsCoursesXref.Remove(studentCourseEntity);
            await _context.SaveChangesAsync();
        }
    }
}