using Coursera_Task.Data;
using Coursera_Task.Data.Models;
using Coursera_Task.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursera_Task.Services
{
    public class InstructorService: BaseService
    {
 

        public InstructorService(MyDbContext context) : base(context)
        {
          
        }

        public async Task<IEnumerable<InstructorViewModel>> GetAllInstructorsAsync()
        {
            var instructors = await _context.Instructors.ToListAsync();
            return instructors.Select(i => new InstructorViewModel
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                TimeCreated = i.TimeCreated
            });
        }

        public async Task<InstructorViewModel> GetInstructorByIdAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
                return null;

            return new InstructorViewModel
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                TimeCreated = instructor.TimeCreated
            };
        }

        public async Task<InstructorViewModel> CreateInstructorAsync(InstructorViewModel instructorViewModel)
        {
            var instructor = new Instructor
            {
                FirstName = instructorViewModel.FirstName,
                LastName = instructorViewModel.LastName,
                TimeCreated = DateTime.Now
            };

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            return new InstructorViewModel
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                TimeCreated = instructor.TimeCreated
            };
        }

        public async Task UpdateInstructorAsync(int id, InstructorViewModel instructorViewModel)
        {
            var instructor = await _context.Instructors.FindAsync(id);

            if (instructor != null)
            {
                instructor.FirstName = instructorViewModel.FirstName;
                instructor.LastName = instructorViewModel.LastName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteInstructorAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);

            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
