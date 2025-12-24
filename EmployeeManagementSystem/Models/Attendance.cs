using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public string Status { get; set; } // "Present", "Absent", "Late", "Half Day"
        public string NepaliDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
