using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Leave
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } // "Sick", "Casual", "Annual"
        public string Reason { get; set; }
        public string Status { get; set; } // "Pending", "Approved", "Rejected"
    }

}
