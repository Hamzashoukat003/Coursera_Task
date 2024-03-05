using Coursera_Task.Data;
using Coursera_Task.Data.Models;
using Coursera_Task.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Coursera_Task.Services
{
    public class StudentsService
    {
        private readonly MyDbContext _context;

        public StudentsService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentViewModel>> GetAllStudentsWithCompletedCourses()
        {
            var studentsWithCompletedCourses = await _context.Students
    .Include(s => s.CompletedCourses)
    .ToListAsync();

            var studentViewModels = studentsWithCompletedCourses.Select(student => new StudentViewModel
            {
                PIN = student.PIN,
                FirstName = student.FirstName,
                LastName = student.LastName,
                CompletedCourses = student.CompletedCourses
                    .Where(course => course.StudentPin == student.PIN)
                    .Select(course => new StudentCourseViewModel
                    {
                        StudentPin = student.PIN,
                        CourseId = course.CourseId,
                        CompletionDate = course.CompletionDate
                    })
                    .ToList()
            }).ToList();

            return studentViewModels;

        }
        public async Task<Students> GetStudentByPIN(string pin)
        {
            return await _context.Students.Include(s => s.CompletedCourses)
                                           .FirstOrDefaultAsync(s => s.PIN == pin);
        }

        public async Task<bool> AddStudent(NewStuWithCourse newStudent)
        {
            try
            {
                Students student = new Students
                {
                    FirstName = newStudent.FirstName,
                    LastName = newStudent.LastName,
                    PIN = GenerateStudentPin()
                };

                _context.Students.Add(student);
                _context.StudentsCoursesXref.Add(new StudentCourseXref { CompletionDate = DateTime.Now, StudentPin = student.PIN, CourseId = newStudent.CourseId });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error adding student: {ex.Message}");
                return false;
            }
        }

        public async Task UpdateStudent(string pin, StudentViewModel student)
        {
            var existingStudent = await _context.Students.FindAsync(pin);

            if (existingStudent == null)
            {
                return;
            }

            
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            // Update other properties as needed

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
            }
        }

       
        private bool StudentExistsPut(string pin)
        {
            return _context.Students.Any(s => s.PIN == pin);
        }


        public async Task<bool> DeleteStudent(string pin)
        {
            try
            {
                var student = await _context.Students.FindAsync(pin);
                if (student == null)
                {
                    return false;
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
                return false;
            }
        }

        private bool StudentExists(string pin)
        {
            return _context.Students.Any(e => e.PIN == pin);
        }

        private string GenerateStudentPin()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }

        public class NewStuWithCourse
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int CourseId { get; set; }
        }
    }
}