using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using HotelResrvation.DAL.Model;
using HotelResrvation.DAL.UserRepo;

namespace HotelDB.Services.services
{
    public interface IUserService
    {
        List<UserInfo>GetUsers();
        UserInfo login(string UserName, string Password);
        List<RoleANDRightTbl> GetRoleANDRightTbls(int?roleId);


        bool insert(UserInfo item);
        UserInfo GetUser(int Id);
        bool Edit(UserInfo userInfo);
        bool Delete(int Id);
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
        public List<RoleANDRightTbl> GetRoleANDRightTbls(int ? roleId)
        {
            return _userRepo.GetRoleANDRightTbls(roleId);
        }
       
        public bool insert(UserInfo item)
        {
            return _userRepo.insert(item);
        }

        public UserInfo GetUser(int Id)
        {
            return _userRepo.GetUser(Id);
        }

        public bool Edit(UserInfo userInfo)
        {
            return _userRepo.Edit(userInfo);
        }

        public bool Delete(int Id)
        {
            return _userRepo.Delete(Id);
        }
    }

   
}
