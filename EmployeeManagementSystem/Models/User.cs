using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }   // Primary Key

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Role { get; set; }   // Admin | User
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
