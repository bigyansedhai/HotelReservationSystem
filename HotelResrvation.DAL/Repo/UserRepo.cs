using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelResrvation.DAL.Model;
namespace HotelResrvation.DAL.UserRepo
{
    public class UserRepo : IUserRepo
    {
        public List<UserInfo> GetUsers()
        {
            List<UserInfo> _userInfos = new List<UserInfo>();
            using (HotelDBEntities _hotelDBEntities = new HotelDBEntities())
            {
                _userInfos = _hotelDBEntities.UserInfos.ToList();
            }
            return _userInfos;
        }

        public UserInfo login(string UserName, string Password)
        {
            using (HotelDBEntities _hotelDBEntities = new HotelDBEntities())
            {
                return _hotelDBEntities.UserInfos.Where(x => x.UserName.Equals(UserName) && x.Password.Equals(Password)).SingleOrDefault();
            }
        }

        public List<RoleANDRightTbl> GetRoleANDRightTbls(int? roleId)
        {
            List<RoleANDRightTbl> roleANDRights = new List<RoleANDRightTbl>();
            using (HotelDBEntities _hotelDBEntities = new HotelDBEntities())
            {
                roleANDRights = _hotelDBEntities.RoleANDRightTbls.Where(x => x.RoleId == roleId).ToList();
            }
            return roleANDRights;

        }
        public bool insert(UserInfo item)
        {
            bool result;
            using (HotelDBEntities _hotelDBEntities = new HotelDBEntities())
            {
                _hotelDBEntities.UserInfos.Add(item);
                int count = _hotelDBEntities.SaveChanges();
                if (count > 0)
                {
                    result = true;
                }
                else
                    result = false;
            }
            return result;

        }
       
        

    }
}
