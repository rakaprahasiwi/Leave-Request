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
            var get = myContext.LeaveRemains.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public LeaveRemain Get(int id)
        {
            var get = myContext.LeaveRemains.SingleOrDefault(x => x.Id == id);
            return get;
        }

        public List<LeaveRemain> GetSearch(string values)
        {
            var get = myContext.LeaveRemains.Where(x => (x.Duration.ToString().Contains(values) || x.Id.ToString().Contains(values) || x.Employee_Id.ToString().Contains(values)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(LeaveRemainVM leaveRemainVM)
        {
            var push = new LeaveRemain(leaveRemainVM);
            myContext.LeaveRemains.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int id, LeaveRemainVM leaveRemainVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(leaveRemainVM);
                myContext.Entry(get).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
