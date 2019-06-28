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
            container.RegisterType<ILeaveRequestGetAllRepository, LeaveRequestGetAllRepository>();
            container.RegisterType<ILeaveTypeRepository, LeaveTypeRepository>();
            container.RegisterType<ICalendarRepository, CalendarRepository>();

            //this is for service
            container.RegisterType<ILeaveRemainService, LeaveRemainService>();
            container.RegisterType<ILeaveRequestService, LeaveRequestService>();
            container.RegisterType<ILeaveRequestGetAllService, LeaveRequestGetAllService>();
            container.RegisterType<ILeaveTypeService, LeaveTypeService>();
            container.RegisterType<ICalendarService, CalendarService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}