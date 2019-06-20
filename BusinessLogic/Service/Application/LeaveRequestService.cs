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
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository iLeaveRequestRepository;

        public LeaveRequestService() { }
        public LeaveRequestService(ILeaveRequestRepository _iLeaveRequestRepository)
        {
            iLeaveRequestRepository = _iLeaveRequestRepository;
        }

        public bool Delete(int id)
        {
            return iLeaveRequestRepository.Delete(id);
        }

        public List<LeaveRequest> Get()
        {
            return iLeaveRequestRepository.Get();
        }

        public LeaveRequest Get(int id)
        {
            return iLeaveRequestRepository.Get(id);
        }

        public List<LeaveRequest> GetSearch(string values)
        {
            return iLeaveRequestRepository.GetSearch(values);
        }

        public bool Insert(LeaveRequestVM leaveRequestVM)
        {
            if (string.IsNullOrWhiteSpace(leaveRequestVM.LeaveTypes_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Employee_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Manager_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.StatusTypeParameter_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Request_Date.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.From_Date.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.End_Date.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Reason) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Attachment))
            {
                return false;
            }
            else
            {
                return iLeaveRequestRepository.Insert(leaveRequestVM);
            }
        }

        public bool Update(int id, LeaveRequestVM leaveRequestVM)
        {
            if (string.IsNullOrWhiteSpace(leaveRequestVM.LeaveTypes_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Employee_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Manager_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.StatusTypeParameter_Id.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Request_Date.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.From_Date.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.End_Date.ToString()) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Reason) ||
                string.IsNullOrWhiteSpace(leaveRequestVM.Attachment))
            {
                return false;
            }
            else
            {
                return iLeaveRequestRepository.Update(id, leaveRequestVM);
            }
        }
    }
}
