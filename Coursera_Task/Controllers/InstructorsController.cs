using Coursera_Task.ViewModels;
using Coursera_Task.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coursera_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly InstructorService _instructorService;

        public InstructorController(InstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorViewModel>>> GetAllInstructors()
        {
            var instructors = await _instructorService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorViewModel>> GetInstructorById(int id)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<ActionResult<InstructorViewModel>> CreateInstructor(InstructorViewModel instructorViewModel)
        {
            var createdInstructor = await _instructorService.CreateInstructorAsync(instructorViewModel);
            return CreatedAtAction(nameof(GetInstructorById), new { id = createdInstructor.Id }, createdInstructor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, InstructorViewModel instructorViewModel)
        {
            await _instructorService.UpdateInstructorAsync(id, instructorViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            await _instructorService.DeleteInstructorAsync(id);
            return NoContent();
        }
    }
}
