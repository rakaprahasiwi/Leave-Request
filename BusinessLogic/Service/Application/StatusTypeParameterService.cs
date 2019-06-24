﻿using Common.Repository;
using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Application
{
    public class StatusTypeParameterService : IStatusTypeParameterService
    {
        private readonly IStatusTypeParameterRepository iStatusTypeParameterRepository;

        public StatusTypeParameterService() { }
        public StatusTypeParameterService(IStatusTypeParameterRepository _iStatusTypeParameterRepository)
        {
            iStatusTypeParameterRepository = _iStatusTypeParameterRepository;
        }

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return false;
            }
            else
            {
                return iStatusTypeParameterRepository.Delete(id);
            }
        }

        public List<StatusTypeParameter> Get()
        {
            return iStatusTypeParameterRepository.Get();
        }

        public StatusTypeParameter Get(int id)
        {
            return iStatusTypeParameterRepository.Get(id);
        }

        public List<StatusTypeParameter> GetSearch(string values)
        {
            return iStatusTypeParameterRepository.GetSearch(values);
        }

        public bool Insert(StatusTypeParameterVM statusTypeParameterVM)
        {
            if (string.IsNullOrWhiteSpace(statusTypeParameterVM.Name))
            {
                return false;
            }
            else
            {
                return iStatusTypeParameterRepository.Insert(statusTypeParameterVM);
            }
        }

        public bool Update(int id, StatusTypeParameterVM statusTypeParameterVM)
        {
            if (string.IsNullOrWhiteSpace(statusTypeParameterVM.Name))
            {
                return false;
            }
            else
            {
                return iStatusTypeParameterRepository.Update(id, statusTypeParameterVM);
            }
        }
    }
}
