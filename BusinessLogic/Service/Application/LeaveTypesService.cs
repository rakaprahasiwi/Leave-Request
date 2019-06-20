using Common.Repository;
using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Application
{
    public class LeaveTypesService : ILeaveTypesService
    {
        private readonly ILeaveTypesRepository iLeaveTypesRepository;

        public LeaveTypesService() { }
        public LeaveTypesService(ILeaveTypesRepository _iLeaveTypesRepository)
        {
            iLeaveTypesRepository = _iLeaveTypesRepository;
        }

        public bool Delete(int id)
        {
            return iLeaveTypesRepository.Delete(id);
        }

        public List<LeaveTypes> Get()
        {
            return iLeaveTypesRepository.Get();
        }

        public LeaveTypes Get(int id)
        {
            return iLeaveTypesRepository.Get(id);
        }

        public List<LeaveTypes> GetSearch(string values)
        {
            return iLeaveTypesRepository.GetSearch(values);
        }

        public bool Insert(LeaveTypesVM leaveTypesVM)
        {
            if (string.IsNullOrWhiteSpace(leaveTypesVM.Name))
            {
                return false;
            }
            else
            {
                return iLeaveTypesRepository.Insert(leaveTypesVM);
            }
        }

        public bool Update(int id, LeaveTypesVM leaveTypesVM)
        {
            if (string.IsNullOrWhiteSpace(leaveTypesVM.Name))
            {
                return false;
            }
            else
            {
                return iLeaveTypesRepository.Update(id, leaveTypesVM);
            }
        }
    }
}
