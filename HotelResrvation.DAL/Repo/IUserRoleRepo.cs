using HotelResrvation.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResrvation.DAL.Repo
{
   public interface IUserRoleRepo
    {
        List<UserRole> GetRoles();
    }
}
