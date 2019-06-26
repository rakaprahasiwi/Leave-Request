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
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        MyContext myContext = new MyContext();

        public bool Delete(int id)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Delete();
                myContext.Entry(get).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public List<LeaveType> Get()
        {
            var get = myContext.LeaveTypes.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public LeaveType Get(int id)
        {
            var get = myContext.LeaveTypes.Find(id);
            return get;
        }

        public List<LeaveType> GetSearch(string values)
        {
            var get = myContext.LeaveTypes.Where(x => (x.Name.Contains(values) || x.Id.ToString().Contains(values) || x.Duration.ToString().Contains(values) || x.Note.Contains(values)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(LeaveTypeVM leaveTypeVM)
        {
            var push = new LeaveType(leaveTypeVM);
            myContext.LeaveTypes.Add(push);
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

        public bool Update(int id, LeaveTypeVM leaveTypeVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(leaveTypeVM);
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
