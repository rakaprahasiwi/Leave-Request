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
    public class LeaveTypesRepository : ILeaveTypesRepository
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

        public List<LeaveTypes> Get()
        {
            var get = myContext.LeaveTypess.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public LeaveTypes Get(int id)
        {
            var get = myContext.LeaveTypess.Find(id);
            return get;
        }

        public List<LeaveTypes> GetSearch(string values)
        {
            var get = myContext.LeaveTypess.Where(x => (x.Name.Contains(values) || x.Id.ToString().Contains(values)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(LeaveTypesVM leaveTypesVM)
        {
            var push = new LeaveTypes(leaveTypesVM);
            myContext.LeaveTypess.Add(push);
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

        public bool Update(int id, LeaveTypesVM leaveTypesVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(leaveTypesVM);
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
