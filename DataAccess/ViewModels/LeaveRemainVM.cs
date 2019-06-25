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
        public int Employee_Id { get; set; }
        public int Duration { get; set; }

        public LeaveRemainVM() { }

        public LeaveRemainVM(int employee, int duration)
        {
            this.Employee_Id = employee;
            this.Duration = duration;
        }

        public void Update(int id, int employee, int duration)
        {
            this.Id = id;
            this.Employee_Id = employee;
            this.Duration = duration;
        }
    }
}
