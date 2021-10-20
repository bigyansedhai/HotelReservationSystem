using HotelResrvation.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResrvation.DAL.Repo
{
    public class UserRoleRepo : IUserRoleRepo
    {
        public List<UserRole> GetRoles()
        {
            List<UserRole> userRoles = new List<UserRole>();
            using(HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                userRoles= _hotelDBEntities.UserRoles.ToList();
            }
            return userRoles;
        }
    }
}
