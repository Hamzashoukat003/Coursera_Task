using Coursera_Task.Data.Models;

namespace Coursera_Task.ViewModels
{
    public class InstructorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TimeCreated { get; set; }
        //public virtual ICollection<Courses> Courses { get; set; }
    }
}