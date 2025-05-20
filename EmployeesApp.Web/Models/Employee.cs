using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeesApp.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must specify a name")]
        [SuspiciousPerson("Pontus Wittenmark", ErrorMessage = "Suspicious person detected!")]
        public string Name { get; set; } = null!;

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        [Required(ErrorMessage = "You must specify an e-mail address")]
        public string Email { get; set; } = null!;

    }
}
