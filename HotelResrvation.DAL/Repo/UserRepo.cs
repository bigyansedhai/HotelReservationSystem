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
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                _userInfos = _hotelDBEntities.UserInfos.ToList();
            }
            return _userInfos;
        }

        public UserInfo login(string UserName, string Password)
        {
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                return _hotelDBEntities.UserInfos.Where(x => x.UserName.Equals(UserName) && x.Password.Equals(Password)).SingleOrDefault();
            }
        }

        public List<RoleANDRightTbl> GetRoleANDRightTbls(int? roleId)
        {
            List<RoleANDRightTbl> roleANDRights = new List<RoleANDRightTbl>();
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                roleANDRights = _hotelDBEntities.RoleANDRightTbls.Include("RightInfo").Where(x => x.RoleId == roleId).ToList();
            }
            return roleANDRights;

        }
        public bool insert(UserInfo item)
        {
           bool result;
           
            
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
           UserInfo userInfos =_hotelDBEntities.UserInfos.Add(item);
                int count = _hotelDBEntities.SaveChanges();
                if (count > 0)
                {
                    result = true;
                }
                else
                    result = false;
            }
            return result;

            //    dynamic param = new
            //    {
            //        address = item.Address,
            //        userName = item.UserName,
            //        phoneNumber = item.PhoneNumber,
            //        userType = item.UserType,
            //        password = item.Password,

            //    };


            //  result=  _hotelDBEntities.spUserInfoIns(param);
            //}
            //return false;





        }
        public UserInfo GetUser(int Id)
        {
            UserInfo userInfo = new UserInfo();
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                userInfo = _hotelDBEntities.UserInfos.Find(Id);
            }
            return userInfo;
        }

        public bool Edit(UserInfo userInfo)
        {
            bool result;
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                _hotelDBEntities.Entry(userInfo).State = System.Data.Entity.EntityState.Modified;
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

        public bool Delete(int Id)
        {
            bool result;
            using (HotelDBEntities1 _hotelDBEntities = new HotelDBEntities1())
            {
                UserInfo userInfo = _hotelDBEntities.UserInfos.Find(Id);
                _hotelDBEntities.UserInfos.Remove(userInfo);
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



