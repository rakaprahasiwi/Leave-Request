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
        

        public List<LeaveRequest> GetEmployee()
        {
            var get = myContext.LeaveRequests.Include("LeaveType").Where(x => x.Employee_Id == 2).ToList();
            return get;
        }
    }
}
