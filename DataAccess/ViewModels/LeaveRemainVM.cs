using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class LeaveRemainVM
    {
        public int Id { get; set; }
        public int LeaveRequest_Id { get; set; }
        public int Employee_Id { get; set; }
        public int Duration { get; set; }

        public LeaveRemainVM() { }

        public LeaveRemainVM(int leave_request, int employee, int duration)
        {
            this.LeaveRequest_Id = leave_request;
            this.Employee_Id = employee;
            this.Duration = duration;
        }

        public void Update(int id, int leave_request, int employee, int duration)
        {
            this.Id = id;
            this.LeaveRequest_Id = leave_request;
            this.Employee_Id = employee;
            this.Duration = duration;
        }
    }
}
