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
    public class LeaveRemainRepository : ILeaveRemainRepository
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

        public List<LeaveRemain> Get()
        {
            var get = myContext.LeaveRemains.Include("LeaveRequest").Include("LeaveRequest.LeaveTypes").Include("LeaveRequest.StatusTypeParameter").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public LeaveRemain Get(int id)
        {
            var get = myContext.LeaveRemains.Include("LeaveRequest").Include("LeaveRequest.LeaveTypes").Include("LeaveRequest.StatusTypeParameter").SingleOrDefault(x => x.Id == id);
            return get;
        }

        public List<LeaveRemain> GetSearch(string values)
        {
            var get = myContext.LeaveRemains.Include("LeaveRequest").Where
                (x => (x.Duration.ToString().Contains(values) ||
                x.LeaveRequest_Id.ToString().Contains(values) ||
                x.Id.ToString().Contains(values)) &&
                x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(LeaveRemainVM leaveRemainVM)
        {
            var push = new LeaveRemain(leaveRemainVM);
            var getLeaveRequest = myContext.LeaveRequests.Find(leaveRemainVM.LeaveRequest_Id);
            push.LeaveRequest = getLeaveRequest;
            myContext.LeaveRemains.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        public bool Update(int id, LeaveRemainVM leaveRemainVM)
        {
            var get = Get(id);
            var getLeaveRequest = myContext.LeaveRequests.Find(leaveRemainVM.LeaveRequest_Id);
            get.LeaveRequest = getLeaveRequest;
            if (get != null)
            {
                get.Update(id, leaveRemainVM);
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                status = true;
            }

            return status;
        }
    }
}
