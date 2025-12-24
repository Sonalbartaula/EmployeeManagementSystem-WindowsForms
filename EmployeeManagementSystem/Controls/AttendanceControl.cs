using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controls
{
    
    public class AttendanceControl : UserControl
    {
        public AttendanceControl()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            this.BackColor = Color.White;

            ConnectDeviceControl connectionControl = new ConnectDeviceControl();
            connectionControl.Dock = DockStyle.Fill;
            this.Controls.Add(connectionControl);
        }
    }
}
