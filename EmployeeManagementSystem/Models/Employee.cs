using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } //Primary Key

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Department { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
