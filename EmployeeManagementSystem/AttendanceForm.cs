using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class AttendanceForm : Form
    {
        private readonly User _currentUser;

        public AttendanceForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            
        }

        
    }
}
