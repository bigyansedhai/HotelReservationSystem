using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelResrvation.DAL.Model;

namespace HotelResrvation.DAL.UserRepo
{
    public interface IUserRepo
    {
        List<UserInfo> GetUsers();
        UserInfo login(string UserName, string Password);
        List<RoleANDRightTbl> GetRoleANDRightTbls(int ? roleId);
        bool insert(UserInfo item);
        UserInfo GetUser(int Id);
        bool Edit(UserInfo userInfo);
        bool Delete(int Id);
    }
}
