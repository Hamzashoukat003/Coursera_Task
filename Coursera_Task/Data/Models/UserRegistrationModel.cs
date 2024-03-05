using System.ComponentModel.DataAnnotations;

namespace Coursera_Task.Data.Models
{
    public class UserRegistrationModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
