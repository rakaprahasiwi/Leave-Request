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
    public class StatusTypeParameterRepository : IStatusTypeParameterRepository
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

        public List<StatusTypeParameter> Get()
        {
            var get = myContext.StatusTypeParameters.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public StatusTypeParameter Get(int id)
        {
            var get = myContext.StatusTypeParameters.Find(id);
            return get;
        }

        public List<StatusTypeParameter> GetSearch(string values)
        {
            var get = myContext.StatusTypeParameters.Where(x => (x.Name.Contains(values) || x.Id.ToString().Contains(values)) && x.IsDelete == false).ToList();
            return get;
        }

        public bool Insert(StatusTypeParameterVM statusTypeParameterVM)
        {
            var push = new StatusTypeParameter(statusTypeParameterVM);
            myContext.StatusTypeParameters.Add(push);
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

        public bool Update(int id, StatusTypeParameterVM statusTypeParameterVM)
        {
            var get = Get(id);
            if (get != null)
            {
                get.Update(id, statusTypeParameterVM);
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
