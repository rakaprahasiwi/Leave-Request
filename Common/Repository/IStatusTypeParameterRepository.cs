using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface IStatusTypeParameterRepository
    {
        List<StatusTypeParameter> Get();
        List<StatusTypeParameter> GetSearch(string values);
        StatusTypeParameter Get(int id);
        bool Insert(StatusTypeParameterVM statusTypeParameterVM);
        bool Update(int id, StatusTypeParameterVM statusTypeParameterVM);
        bool Delete(int id);
    }
}
