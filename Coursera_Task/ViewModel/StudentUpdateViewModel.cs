namespace Coursera_Task.ViewModels
{
    public class StudentUpdateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<StudentCourseXrefUpdateViewModel> CompletedCourses { get; set; }
    }

}