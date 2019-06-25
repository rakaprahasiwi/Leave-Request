using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface ILeaveTypeService
    {
        List<LeaveType> Get();
        List<LeaveType> GetSearch(string values);
        LeaveType Get(int id);
        bool Insert(LeaveTypeVM leaveTypesVM);
        bool Update(int id, LeaveTypeVM leaveTypesVM);
        bool Delete(int id);
    }
}
