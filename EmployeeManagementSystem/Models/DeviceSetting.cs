using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class DeviceSetting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IPAddress { get; set; }

        [Required]
        public int PortNumber { get; set; }

        public string Password { get; set; }

        public bool IsConnected { get; set; } = false;

        public DateTime? LastConnected { get; set; }

        public string DeviceName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
