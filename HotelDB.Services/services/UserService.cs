using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelResrvation.DAL.Model;
using HotelResrvation.DAL.UserRepo;

namespace HotelDB.Services.services
{
    public interface IUserService
    {
        List<UserInfo>GetUsers();
        UserInfo login(string UserName, string Password);
        List<RoleANDRightTbl> GetRoleANDRightTbls(int? roleId);
        bool insert(UserInfo item);
    }
    public class UserService:IUserService
    {
        private IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public List<UserInfo> GetUsers()
        {
            return _userRepo.GetUsers();    
        }
       public UserInfo login(string UserName, string Password)
        {
            return _userRepo.login(UserName,Password);
        }
        public List<RoleANDRightTbl> GetRoleANDRightTbls(int? roleId)
        {
            return _userRepo.GetRoleANDRightTbls(roleId);
        }
        public bool insert(UserInfo item)
        {
            return _userRepo.insert(item);
        }
    }

   
}
