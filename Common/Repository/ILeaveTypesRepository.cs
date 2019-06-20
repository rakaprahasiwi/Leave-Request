using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface ILeaveTypesRepository
    {
        List<LeaveTypes> Get();
        List<LeaveTypes> GetSearch(string values);
        LeaveTypes Get(int id);
        bool Insert(LeaveTypesVM leaveTypesVM);
        bool Update(int id, LeaveTypesVM leaveTypesVM);
        bool Delete(int id);
    }
}
