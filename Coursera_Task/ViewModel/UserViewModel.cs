using System.ComponentModel.DataAnnotations;

namespace Coursera_Task.ViewModel
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
