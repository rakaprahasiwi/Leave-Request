using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Models;

namespace Common.Repository.Application
{
    public class LeaveRequestEmployeeRepository : ILeaveRequestEmployeeRepository
    {
        MyContext myContext = new MyContext();

        public LeaveRequest GetEmployee()
        {
            var get = myContext.LeaveRequests.Include("LeaveType").SingleOrDefault(x => x.Employee_Id == 1);
            return get;
        }
    }
}
