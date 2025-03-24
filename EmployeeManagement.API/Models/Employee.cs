using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string DocNumber { get; set; }

        public List<string> Phones { get; set; } = new();
        
        public string? ManagerName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
