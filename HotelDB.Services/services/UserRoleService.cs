using HotelResrvation.DAL.Model;
using HotelResrvation.DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB.Services.services
{
    public interface IUserRoleService
    {
        List<UserRole> GetRoles();
    }
   public  class UserRoleService:IUserRoleService
    {
        private UserRoleRepo _userRole;

        public UserRoleService(UserRoleRepo userRole)
        {
            _userRole = userRole;
        }

        public List<UserRole> GetRoles()
        {
            return _userRole.GetRoles();
        }
    }
}
