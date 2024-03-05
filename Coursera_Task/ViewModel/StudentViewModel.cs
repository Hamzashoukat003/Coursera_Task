namespace Coursera_Task.ViewModels
{
    public class StudentViewModel
    {
       public string PIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<StudentCourseViewModel> CompletedCourses { get; set; }
    }

}