using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.ViewModels;
using DataAccess.Context;
using System.Data.Entity;

namespace Common.Repository.Application
{
    public class LeaveRequestRepository : ILeaveRequestRepository
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

        public List<LeaveRequest> Get()
        {
            var get = myContext.LeaveRequests.Include("LeaveTypes").Include("StatusTypeParameter").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public LeaveRequest Get(int id)
        {
            var get = myContext.LeaveRequests.Include("LeaveTypes").Include("StatusTypeParameter").SingleOrDefault(x => x.Id == id);
            return get;
        }

        public List<LeaveRequest> GetSearch(string values)
        {
            var get = myContext.LeaveRequests.Where
                (x => (x.Employee_Id.ToString().Contains(values) ||
                x.Manager_Id.ToString().Contains(values) ||
                x.Id.ToString().Contains(values)) &&
                x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(LeaveRequestVM leaveRequestVM)
        {
            var push = new LeaveRequest(leaveRequestVM);
            var getLeaveType = myContext.LeaveTypess.Find(leaveRequestVM.LeaveTypes_Id);
            var getStatusType = myContext.StatusTypeParameters.Find(leaveRequestVM.StatusTypeParameter_Id);
            push.LeaveTypes = getLeaveType;
            push.StatusTypeParameter = getStatusType;
            myContext.LeaveRequests.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        public bool Update(int id, LeaveRequestVM leaveRequestVM)
        {
            var get = Get(id);
            var getLeaveType = myContext.LeaveTypess.Find(leaveRequestVM.LeaveTypes_Id);
            var getStatusType = myContext.StatusTypeParameters.Find(leaveRequestVM.StatusTypeParameter_Id);
            get.LeaveTypes = getLeaveType;
            get.StatusTypeParameter = getStatusType;
            if (get != null)
            {
                get.Update(id, leaveRequestVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                status = true;
            }
            return status;
        }
    }
}
