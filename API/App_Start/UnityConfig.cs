using BusinessLogic.Service;
using BusinessLogic.Service.Application;
using Common.Repository;
using Common.Repository.Application;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //this is for repository
            container.RegisterType<ILeaveRemainRepository, LeaveRemainRepository>();
            container.RegisterType<ILeaveRequestRepository, LeaveRequestRepository>();
            container.RegisterType<ILeaveTypesRepository, LeaveTypesRepository>();
            container.RegisterType<IStatusTypeParameterRepository, StatusTypeParameterRepository>();

            //this is for service
            container.RegisterType<ILeaveRemainService, LeaveRemainService>();
            container.RegisterType<ILeaveRequestService, LeaveRequestService>();
            container.RegisterType<ILeaveTypesService, LeaveTypesService>();
            container.RegisterType<IStatusTypeParameterService, StatusTypeParameterService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}