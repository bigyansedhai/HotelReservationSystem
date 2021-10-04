using HotelDB.Services.services;
using HotelResrvation.DAL.Repo;
using HotelResrvation.DAL.UserRepo;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace HotelReservationSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IBranchService, BranchServices>();
            container.RegisterType<IBranch,BranchRepo>();
            container.RegisterType<IHotelRepo,HotelRepo>();
            container.RegisterType<IHotelService, HotelService>();
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRoleRepo, UserRoleRepo>();
            container.RegisterType<IUserRoleService, UserRoleService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}