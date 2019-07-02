using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Context;
using System.Data.Entity;

namespace Common.Repository.Application
{
    public class LeaveRequestGetAllRepository : ILeaveRequestGetAllRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                status = true;
            }
            return status;
        }

        public LeaveRequest Get(int id)
        {
            var get = myContext.LeaveRequests.Include("LeaveType").SingleOrDefault(x => x.Id == id);
            return get;
        }

        public List<LeaveRequest> GetAllList()
        {
            var get = myContext.LeaveRequests.Include("LeaveType").Where(x => x.Status != "Submited").ToList();
            return get;
        }

        public List<LeaveRequest> GetSearch(string values)
        {
            var get = myContext.LeaveRequests.Include("LeaveType").Where
               (x => (x.Employee_Id.ToString().Contains(values) ||
               x.Manager_Id.ToString().Contains(values) ||
               x.Id.ToString().Contains(values) ||
               x.Reason.Contains(values) ||
               x.Status.Contains(values) ||
               x.LeaveType_Id.ToString().Contains(values)) &&
               x.IsDelete == false).ToList();
            return get;
        }
    }
}
